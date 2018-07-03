using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TinhLuong.Models;
using TinhLuongBLL;

namespace TinhLuong.Controllers
{
    public class LoginController : AlertController
    {
        SaveLog sv = new SaveLog();
        // GET: Login
        public ActionResult Index()
        {
            Login acc = checkCookie();
            if (acc == null) return View();
            else return View(acc);
        }

        //logout
        public ActionResult Logout()
        {
            sv.save(Session[SessionCommon.Username].ToString(), "LOGOUT");
            ///xoa file
            ///
            string subPath = "/Assets/FileReports/" + Session[SessionCommon.Username].ToString().ToLower(); // your code goes here
            System.IO.DirectoryInfo di = new DirectoryInfo(Server.MapPath(subPath));

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            Session.Abandon();
            if (Response.Cookies["username"] != null)
            {
                HttpCookie ckUsername = new HttpCookie("username");
                ckUsername.Value = Request.Cookies["username"].Value;
                ckUsername.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(ckUsername);
            }
            if (Response.Cookies["password"] != null)
            {
                HttpCookie ckpassword = new HttpCookie("password");
                ckpassword.Value = Request.Cookies["password"].Value;
                ckpassword.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(ckpassword);
            }
            return Redirect("/dang-nhap");
        }


        /// <summary>
        /// check cookie login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        /// 
        public Login checkCookie()
        {
            Login acc = null;
            string username = string.Empty;
            string password = string.Empty;
            if (Request.Cookies["username"] != null) username = Request.Cookies["username"].Value;
            if (!string.IsNullOrEmpty(username))
            {
                acc = new Login { Username = username, Remember = true };
            }
            return acc;
        }

        /// <summary>
        /// login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public ActionResult LoginAction(Login login)
        {
            if (login.Remember)
            {
                ///save username for login after
                HttpCookie ckUsername = new HttpCookie("username");
                ckUsername.Expires = DateTime.Now.AddDays(30);
                ckUsername.Value = login.Username;
                Response.Cookies.Add(ckUsername);
            }
            if (ModelState.IsValid)
            {
                var ip = new GetInfoClient().GetIP();
                var mode = new GetInfoClient().GetBrowserInfo();
                //string v = EnDeCryptMD5.Decrypt("yvV2wTrz44I=", "salary", true);
                var users = new LoginBLL().LoginAction(login.Username, EnDeCryptMD5.Encrypt(login.Password, "salary", true), ip, mode);
                if (users.Rows[0]["OutputCode"].ToString()=="1")
                {
                    var listCredentials = new HomeBLL().GetListCredential(login.Username);
                    Session.Add(SessionCommon.Username, users.Rows[0]["UserName"].ToString());
                    Session.Add(SessionCommon.DonViID, users.Rows[0]["DonViID"].ToString());
                    Session.Add(SessionCommon.NhanSuID, users.Rows[0]["NhanSuID"].ToString());
                    Session.Add(SessionCommon.SESSION_CREDENTIALS, listCredentials);
                    ///add cokkies
                    ///
                    ///tao folder with Ussername
                    ///
                    string subPath = "/Assets/FileReports/" + Session[SessionCommon.Username].ToString().ToLower(); // your code goes here
                    bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

                    if (!exists)
                        System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
                    ///xoa file
                    ///
                    System.IO.DirectoryInfo di = new DirectoryInfo(Server.MapPath(subPath));

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    return Redirect("/Home");
                }
                else
                {
                    setAlert(users.Rows[0]["OutputString"].ToString(), "error");
                    return Redirect("/dang-nhap");
                }
            }
            setAlert("Vui lòng không để trống tài khoản hoặc mật khẩu", "error");
            return Redirect("/dang-nhap");

        }

        public JsonResult ForgotPass()
        {
            setAlert("Vui lòng liên hệ với quản trị hệ thống để được cấp lại mật khẩu. Trân trọng!", "info");
            return Json(new
            {
                status = 1
            });
        }
    }
}
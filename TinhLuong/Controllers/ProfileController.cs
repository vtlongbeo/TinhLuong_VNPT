using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;
using TinhLuongINFO;

namespace TinhLuong.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Profile
        SaveLog sv = new SaveLog();
        public ActionResult Index()
        {
            // sv.save(Session[SessionCommon.Username].ToString(), "He thong->Thong tin ca nhan");
            var rs = new HomeBLL().GetOne_DM_Users(Session[SessionCommon.Username].ToString());
            return View(rs);
        }

        public ActionResult UpdateInfo(DM_Users us, HttpPostedFileBase Avartar)
        {
            //tạo folder lưu ảnh
            ///tao folder with Ussername
            ///
            string subPath = "/Assets/Avatar/" + Session[SessionCommon.Username].ToString().ToLower(); // your code goes here

            bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
            ///xoa file
            ///
            if (Avartar != null && Avartar.ContentLength > 0)
            {
                ///xoa file
                ///
                string extension = Path.GetExtension(Avartar.FileName);
                string[] validFileTypes = { ".png", ".jpg" };
                if (validFileTypes.Contains(extension))
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(Server.MapPath(subPath));
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    //luu file moi
                    string fileName = "fileUpload_" + Session[SessionCommon.Username].ToString() + "_" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "_" + Avartar.FileName;
                    string path1 = Path.Combine(Server.MapPath("~/Assets/Avatar/" + Session[SessionCommon.Username].ToString()), fileName);
                    string pathSave = "/Assets/Avatar/" + Session[SessionCommon.Username].ToString() + "/" + fileName;
                    try
                    {
                        Avartar.SaveAs(path1);
                        var rs = new HomeBLL().UpdateUser(Session[SessionCommon.Username].ToString(), us.HoTen, pathSave);
                        if (rs > 0)
                        {
                            sv.save(Session[SessionCommon.Username].ToString(), "He thong->Thong tin ca nhan->Cap nhat thong tin thanh cong-hoten-" + us.HoTen + "-linkavr-" + pathSave);
                            setAlert("Cập nhật thành công", "success");
                        }
                        else
                        {
                            sv.save(Session[SessionCommon.Username].ToString(), "He thong->Thong tin ca nhan->Cap nhat thong tin that bai");
                            setAlert("Cập nhật thất bại", "error");
                        }
                    }
                    catch
                    {
                        setAlert("Tên tệp quá dài, Vui lòng đặt tên và chọn lại tệp!", "error");
                    }
                }
                else
                {
                    setAlert("Avatar phải có đuôi .png, .jpg", "error");
                }

            }
            else
            {
                var rs = new HomeBLL().UpdateUser(Session[SessionCommon.Username].ToString(), us.HoTen, null);
                sv.save(Session[SessionCommon.Username].ToString(), "He thong->Thong tin ca nhan->Cap nhat thong tin -hoten-" + us.HoTen);
            }
            return Redirect("/Profile");
        }
    }
}
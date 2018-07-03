using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;

namespace TinhLuong.Controllers
{
    public class UsedDiaryController : Controller
    {
        SaveLog sv = new SaveLog();
        // GET: UsedDiary
       
        public ActionResult Index()
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "He thong->nhat ky su dung");
            return View();
        }

        
        public ActionResult IndexDetail(string start, string end)
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "He thong->nhat ky su dung-start-"+start+"-end-"+end);
            var rs = new LoginBLL().GetAll_Diary(Session[SessionCommon.Username].ToString(), start, end);
            return View(rs);
        }
    }
}
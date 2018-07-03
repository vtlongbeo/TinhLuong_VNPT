using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinhLuong.Controllers
{
    public class AlertController : Controller
    {
        // GET: Alert
        protected void setAlert(string mssg, string type)
        {
            TempData["AlertMessage"] = mssg;
            switch (type)
            {
                case "success":
                    {
                        TempData["AlertType"] = "alert-success";
                        break;
                    }
                case "warning":
                    {
                        TempData["AlertType"] = "alert-warning";
                        break;
                    }
                case "error":
                    {
                        TempData["AlertType"] = "alert-error";
                        break;
                    }
                case "info":
                    {
                        TempData["AlertType"] = "alert-info";
                        break;
                    }
                case "dark":
                    {
                        TempData["AlertType"] = "alert-dark";
                        break;
                    }
            }

        }
    }
}
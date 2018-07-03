using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TinhLuongBLL;

namespace TinhLuong.Models
{
    public class SaveLog
    {
        public void save(string UserName, string Action)
        {
            var ip = new GetInfoClient().GetIP();
            var mode = new GetInfoClient().GetBrowserInfo();
            var log = new HomeBLL().SaveLog_ActionUser(UserName, ip, Action, mode);
        }
    }
}
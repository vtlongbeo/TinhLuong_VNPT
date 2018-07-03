using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDAL;
using TinhLuongINFO;

namespace TinhLuongBLL
{
   public class HomeBLL
    {
        HomeDAL dal = new HomeDAL();
        public DM_Users GetOne_DM_Users(string Username)
        {
            return dal.GetOne_DM_Users(Username);
        }
        public int ChangePassword(string Username, string OldPassword, string newPassword)
        {
            return dal.ChangePassword(Username, OldPassword, newPassword);
        }
        public List<string> GetListCredential(string userName)
        {
            return dal.GetListCredential(userName);
        }
        public DataTable Tuyen_GetCurrentDate()
        {
            return dal.Tuyen_GetCurrentDate();
        }
        public int UpdateUser(string UserName, string HoTen, string Avatar)
        {
            return dal.UpdateUser(UserName, HoTen, Avatar);
        }
        public int SaveLog_ActionUser(string UserName, string Ip, string Action, string Mode)
        {
            return dal.SaveLog_ActionUser(UserName, Ip, Action, Mode);
        }
}
}

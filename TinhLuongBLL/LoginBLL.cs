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
    public class LoginBLL
    {
        LoginDAL dal = new LoginDAL();
        public DataTable LoginAction(string Username, string Password, string IpUser, string Mode)
        {
            return dal.LoginAction(Username, Password, IpUser, Mode);
        }
        public List<Log_Login> GetAll_Diary(string Username,string startdate, string enddate)
        {
            return dal.GetAll_Diary(Username,startdate, enddate);
        }
    }
}

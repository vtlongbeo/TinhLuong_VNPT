using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDataAdapter;
using System.Data.SqlClient;
using System.Data;
using TinhLuongINFO;

namespace TinhLuongDAL
{
    public class LoginDAL
    {
        public DataTable LoginAction(string Username, string Password, string IpUser, string Mode)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@UserName",Username),
                new SqlParameter("@PassWord",Password),
                new SqlParameter("@IpUser", IpUser),
                 new SqlParameter("@Mode", Mode),
            };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Login", parm);

            return ds.Tables[0];
        }
        public List<Log_Login> GetAll_Diary(string Username, string startdate, string enddate)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@UserName", Username),
            new SqlParameter("@StartDate", startdate),
            new SqlParameter("@EndDate", enddate)
             }; 
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_getAll_UsedDiary", parm);
            return ds.Tables[0].DataTableToList<Log_Login>();
        }
    }
}

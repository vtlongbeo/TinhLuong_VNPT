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
    public class HomeDAL
    {
        public DM_Users GetOne_DM_Users(string Username)
        {
            SqlParameter parm = new SqlParameter("@Username", Username);
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetOne_DM_Users", parm);
            return ds.Tables[0].DataTableToList<DM_Users>().First();
        }
        public int ChangePassword(string Username, string OldPassword, string newPassword)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                   {
                        new SqlParameter("@User", Username),
                        new SqlParameter("@Old", OldPassword),
                        new SqlParameter("NewPass", newPassword)
                   };
                return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_TinhLuongDbDM_Users_ChangePass", parm);

            }
            catch
            {
                return -1;
            }
        }
        public List<string> GetListCredential(string userName)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@Username",SqlDbType.NVarChar),
               };
                parm[0].Value = userName;
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetAll_Group_WithUser", parm);
                List<Credential> result = ds.Tables[0].DataTableToList<Credential>();
                return result.Select(x => x.RightID).ToList();
            }
            catch
            {
                return new List<string>();
            }


        }
        public DataTable Tuyen_GetCurrentDate()
        {
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetCurrentDate");
            return ds.Tables[0];
        }
        public DM_Users getInfoUser(string username)
        {
            SqlParameter parm = new SqlParameter("@UserName", username);
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetOne_Dm_User", parm);
            return ds.Tables[0].DataTableToList<DM_Users>().First();
        }
        public int UpdateUser(string UserName, string HoTen, string Avatar)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@UserName", UserName),
                new SqlParameter("@hoten", HoTen),
                new SqlParameter("@avatar",Avatar)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tyen_Update_Users", parm);
        }
        public int SaveLog_ActionUser(string UserName,string Ip, string Action, string Mode)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@UserName",UserName),
                new SqlParameter("@IpUser", Ip),
                new SqlParameter("@Action", Action),
                new SqlParameter("@Mode", Mode)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_SaveLog_ActionUser", parm);
        }
    }
}

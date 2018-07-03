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
    public class PhanQuyenDAL
    {
        public DataTable GetAll_DM_User()
        {
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_getAll_DM_User");
            return ds.Tables[0];
        }

        public int Change_IsActive(string UserName)
        {
            try
            {
                SqlParameter parm = new SqlParameter("@UserName", UserName);
                return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Change_IsActive_User", parm);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public List<Dm_Group> getAll_DM_Group()
        {
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetAll_DM_Group");
            return ds.Tables[0].DataTableToList<Dm_Group>();
        }
        public string GetGroup_UserName(string UserName)
        {
            SqlParameter parm = new SqlParameter("@UserName", UserName);
            return (string)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetGroup_UserName", parm);
        }
        public int Update_User_Group(string UserName, string GroupID)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@UserName", UserName),
                new SqlParameter("@GroupID", GroupID)
            };
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Update_User_Group", parm);

            }
            catch
            {
                return -1;
            }
        }
        public int Insert_User(DM_Users user)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@UserName",user.UserName),
                    new SqlParameter("@PassWord",user.PassWord),
                    new SqlParameter("@DonViID",user.DonViID),
                    new SqlParameter("@GhiChu",user.GhiChu),
                    new SqlParameter("@HoTen", user.HoTen),
                    new SqlParameter("@GroupID", user.GroupID)
                };
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Insert_User", parm);

            }
            catch
            {
                return 0;
            }
        }
        public string GetPassDefault()
        {
            return (string)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_getPassDefault");
        }
        public string CheckUser(string UserName)
        {
            SqlParameter parm = new SqlParameter("@UserName", UserName);
            return (string)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_CheckUser",parm);
        }
        public List<DM_DonVi> GetAll_DM_DonVi()
        {
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetAll_DM_DonVi");
            return ds.Tables[0].DataTableToList<DM_DonVi>();
        }
        public int Delete_User(string UserName)
        {
            SqlParameter parm = new SqlParameter("@UserName", UserName);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Delete_User", parm);
        }
        public int ResetPass(string UserName, string Password)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@UserName", UserName),
            new SqlParameter("@PassWord",Password),
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_ResetPass", parm);
        }
        public List<Group_Right> getAll_DM_Rights()
        {
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_getAll_DM_Rights");
            return ds.Tables[0].DataTableToList<Group_Right>();
        }
        public List<string> GetAll_Group_Right_GroupID(string GroupID)
        {
            SqlParameter parm = new SqlParameter("@GroupID", GroupID);
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Tuyen_GetAll_Group_Right_GroupID]", parm);
            return ds.Tables[0].DataTableToList<Group_Right>().Select(x => x.RightID).ToList();
        }
        public string getName_Group(string GroupID)
        {
            SqlParameter parm = new SqlParameter("@GroupID", GroupID);
            return (string)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_getNameGroup", parm);

        }
        public int Update_Group_Right(string RightID, string GroupID)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@GroupID",GroupID),
                new SqlParameter("@RightID",RightID)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Update_Group_Right", parm);
        }
        public int Insert_DM_Group(string GroupName)
        {
            SqlParameter parm = new SqlParameter("@GroupName", GroupName);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Insert_DM_Group", parm);
        }
        public int Delete_DM_Group(string GroupID)
        {
            try
            {
                SqlParameter parm = new SqlParameter("@GroupID", GroupID);
                return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Delete_DM_Group", parm);
            }
            catch
            {
                return 0;
            }
        }

        public int ChangePass_Default(string NewPass)
        {
            SqlParameter parm = new SqlParameter("@NewPass", NewPass);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_ChangePass_Default", parm);
        }
        public string CheckNhanVien_InDonVi(int Thang, int Nam, string DonViID, string NhanSuID)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Thang",Thang),
                    new SqlParameter("@Nam", Nam),
                    new SqlParameter("@DonViID", DonViID),
                    new SqlParameter("@NhanSuID", NhanSuID)
                };
                return (string)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_CheckNhanVien_InDonVi", parm);
            }
            catch(Exception e)
            {
                //throw new Exception("CheckUserInDonVi::Lỗi get dữ liệu!!!.", e);
                return "ERROR:" + e.Message;
            }
        }
    }
}

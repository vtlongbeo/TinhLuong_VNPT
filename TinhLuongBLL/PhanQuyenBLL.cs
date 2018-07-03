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
    public class PhanQuyenBLL
    {
        PhanQuyenDAL dal = new PhanQuyenDAL();
        public DataTable GetAll_DM_User()
        {
            return dal.GetAll_DM_User();
        }
        public int ChangePass_Default(string NewPass)
        {
            return dal.ChangePass_Default(NewPass);
        }
        public int Change_IsActive(string UserName)
        {
            return dal.Change_IsActive(UserName);
        }
        public int ResetPass(string UserName, string Password)
        {
            return dal.ResetPass(UserName, Password);
        }
        public List<Dm_Group> getAll_DM_Group()
        {
            return dal.getAll_DM_Group();
        }
        public string GetGroup_UserName(string UserName)
        {
            return dal.GetGroup_UserName(UserName);
        }
        public int Update_User_Group(string UserName, string GroupID)
        {
            return dal.Update_User_Group(UserName, GroupID);
        }
        public int Insert_User(DM_Users user)
        {
            return dal.Insert_User(user);
        }
        public string CheckUser(string UserName)
        {
            return dal.CheckUser(UserName);
        }
        public List<DM_DonVi> GetAll_DM_DonVi()
        {
            return dal.GetAll_DM_DonVi();
        }
        public string GetPassDefault()
        {
            return dal.GetPassDefault();
        }
        public int Delete_User(string UserName)
        {
            return dal.Delete_User(UserName);
        }
        public List<Group_Right> getAll_DM_Rights()
        {
            return dal.getAll_DM_Rights();
        }
        public List<string> GetAll_Group_Right_GroupID(string GroupID)
        {
            return dal.GetAll_Group_Right_GroupID(GroupID);
        }
        public string getName_Group(string GroupID)
        {
            return dal.getName_Group(GroupID);
        }
        public int Update_Group_Right(string RightID, string GroupID)
        {
            return dal.Update_Group_Right(RightID, GroupID);
        }
        public int Insert_DM_Group(string GroupName)
        {
            return dal.Insert_DM_Group(GroupName);
        }
        public int Delete_DM_Group(string GroupID)
        {
            return dal.Delete_DM_Group(GroupID);
        }
        public string CheckNhanVien_InDonVi(int Thang, int Nam, string DonViID, string NhanSuID)
        {
            return dal.CheckNhanVien_InDonVi(Thang, Nam, DonViID, NhanSuID);
        }
    }
}

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
    public class ChamCongDAL
    {
        
        public DataTable GetChamCongDonVi( string thang, string nam,string DonViID,string TramID,string Username)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@DonViID", DonViID),
                    new SqlParameter("@TramID", TramID),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@Thang",thang),
                    new SqlParameter("@Username",Username)
               };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_FILLDATA_CHAMCONG_BYTRAM", parm);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ChamCong::GetChamCongDonVi::Error occured.", ex);
            }

        }

        public List<DM_ChamCong> SelectByMaChamCong(string MaChamCong)
        {
            try
            {
                SqlParameter parm = new SqlParameter("@MaChamCong", MaChamCong);
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_ChamCong_DM_NgayChamCong", parm);
                return ds.Tables[0].DataTableToList<DM_ChamCong>();
            }
            catch (Exception ex)
            {
                throw new Exception("ChamCong::SelectByIdNgayChamCong::Error occured.", ex);
            }
        }

        

        public DataTable GetChamCongDonViByNhanSu(string NhanVienID, string thang, string nam, int TrucDem)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@NhanVienID", NhanVienID),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@Thang",thang),
                    new SqlParameter("@TrucDem",TrucDem)
               };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_GetChamCongDonViByNhanSu", parm);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ChamCong::GetChamCongDonViByNhanSu::Error occured.", ex);
            }

        }

        public DataTable GetInfoByNhanSuID(string NhanVienID, int thang, int nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@NhanVienID", NhanVienID),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@Thang",thang)
               };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_GetInfoByNhanSuID", parm);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ChamCong::GetInfoByNhanSuID::Error occured.", ex);
            }

        }

        public bool UpdateChamCongByNhanVien(int NhanVienID, int Nam, int Thang, int Ngay,string MaChamCong, string Note,int TrucDem,string Username)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@NhanVienID", NhanVienID),
                new SqlParameter("@Thang", Thang),
                new SqlParameter("@Nam",Nam),
                new SqlParameter("Note",Note),
                new SqlParameter("@MaChamCong",MaChamCong),
                new SqlParameter("@TrucDem",TrucDem),
                new SqlParameter("@Ngay",Ngay),
                new SqlParameter("@Username",Username),
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_UpdateChamCongByNhanSuID", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable ChamCong_SelectByDonVi(string thang, string nam, string DonViID, int TrucDem, string Username)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@DonViID", DonViID),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@Thang",thang),
                    new SqlParameter("@TrucDem",TrucDem),
                    new SqlParameter("@Username",Username)
               };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_ChamCong_SelectByDonVi", parm);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ChamCong::ChamCong_SelectByDonVi::Error occured.", ex);
            }

        }

        public string ChotChamCong(string Thang, string Nam)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", Thang),
                new SqlParameter("@Nam",Nam)
            };
            try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Long_ChotChamCong", parm);
                return ds.Tables[0].Rows[0]["SOS"].ToString();
            }
            catch (Exception ex)
            {
                return "Lỗi chốt dữ liệu";
            }
        }
        public bool UpdateLuongTrucDem(string Thang, string Nam, string UserName)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", Thang),
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@UserName",UserName)
            };
            try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Long_sp_Update_LuongTrucDem", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;                
            }
        }
    }
}

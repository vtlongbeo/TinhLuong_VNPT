using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDataAdapter;
using System.Data;
using System.Data.SqlClient;
using TinhLuongINFO;

namespace TinhLuongDAL
{
    public class BaoCaoChungDAL
    {
        public List<DM_DonVi> Get_ListTenDonVi(string donviId)
        {
            SqlParameter parm = new SqlParameter("@IdDonVi", donviId);
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpDM_DonVi_SelectLevel2", parm);
            return ds.Tables[0].DataTableToList<DM_DonVi>();
        }
        public List<DM_DonVi> Get_ListTenTram(string donviId)
        {
            SqlParameter parm = new SqlParameter("@IdDonVi", donviId);
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpDM_DonVi_SelectLevel3", parm);
            return ds.Tables[0].DataTableToList<DM_DonVi>();
        }
        public List<NhanVien> Get_ListTenNhanVien(string donviId)
        {
            SqlParameter parm = new SqlParameter("@IdDonVi", donviId);
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpDM_NhanVien_SelectLevel3", parm);
            return ds.Tables[0].DataTableToList<NhanVien>();

        }
        public DataTable RequestTableNhanVien(decimal nam, decimal thang, string nhanSuID, string DonViID_Session, string type)
        {
            if (type == "nv")
            {
                SqlParameter[] parm = new SqlParameter[]
                   {
                        new SqlParameter("@Nam",nam),
                        new SqlParameter("@Thang",thang),
                        new SqlParameter("@IdNhansu",nhanSuID),
                        new SqlParameter("@IdDonvi", DonViID_Session)
                   };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_TinhLuongDBTmpBangLuong_GetTableNhanVien", parm);
                return ds.Tables[0];
            }
            else
            {
                SqlParameter[] parm = new SqlParameter[]
                   {
                        new SqlParameter("@Nam",nam),
                        new SqlParameter("@Thang",thang),
                        new SqlParameter("@IdDonVi",nhanSuID),
                        new SqlParameter("@DonViID_Session",DonViID_Session)
                   };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_TinhLuongDBTmpBangLuong_SelectByDonVi", parm);
                return ds.Tables[0];
            }

        }
        public DataTable GetSourceRptDSChiTiet_CSHT(string donviId, decimal nam, decimal thang)
        {
            SqlParameter[] parm = new SqlParameter[]
                   {
                        new SqlParameter("@Nam",nam),
                        new SqlParameter("@Thang",thang),
                        new SqlParameter("@DonViID", donviId)
                   };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuongCSHT_SelectByDonVi", parm);
            return ds.Tables[0];
        }
        public DataTable GetSourceRptDSChiTietKKLD_CSHT(string donviId, decimal nam, decimal thang)
        {
            SqlParameter[] parm = new SqlParameter[]
                   {
                        new SqlParameter("@Nam",nam),
                        new SqlParameter("@Thang",thang),
                        new SqlParameter("@DonViID", donviId)
                   };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuongKKLD_CSHT_SelectByDonVi", parm);
            return ds.Tables[0];
        }
        public DataTable GetRptKy1_AgriBank(decimal nam, decimal thang)
        {
            SqlParameter[] parm = new SqlParameter[]
                   {
                        new SqlParameter("@Nam",nam),
                        new SqlParameter("@Thang",thang)
                   };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuongKy1_SelectAgriBank", parm);
            return ds.Tables[0];
        }
        public DataTable GetRptKy1_VietComBank(decimal nam, decimal thang)
        {
            SqlParameter[] parm = new SqlParameter[]
                   {
                        new SqlParameter("@Nam",nam),
                        new SqlParameter("@Thang",thang)
                   };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuongKy1_SelectVietComBank", parm);
            return ds.Tables[0];
        }
        public DataTable GetRptKy1_ViettinBank(decimal nam, decimal thang)
        {
            SqlParameter[] parm = new SqlParameter[]
                   {
                        new SqlParameter("@Nam",nam),
                        new SqlParameter("@Thang",thang)
                   };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuongKy1_SelectVietInBank", parm);
            return ds.Tables[0];
        }
        public DataTable GetRpt_AgriBank(decimal nam, decimal thang)
        {
            SqlParameter[] parm = new SqlParameter[]
                   {
                        new SqlParameter("@Nam",nam),
                        new SqlParameter("@Thang",thang)
                   };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuong_SelectAgriBank", parm);
            return ds.Tables[0];
        }
        public DataTable GetRpt_VietComBank(decimal nam, decimal thang)
        {
            SqlParameter[] parm = new SqlParameter[]
                   {
                        new SqlParameter("@Nam",nam),
                        new SqlParameter("@Thang",thang)
                   };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuong_SelectVietComBank", parm);
            return ds.Tables[0];
        }
        public DataTable GetRpt_ViettinBank(decimal nam, decimal thang)
        {
            SqlParameter[] parm = new SqlParameter[]
                   {
                        new SqlParameter("@Nam",nam),
                        new SqlParameter("@Thang",thang)
                   };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuong_SelectVietInBank", parm);
            return ds.Tables[0];
        }
        public List<DM_LoaiBoSung> GetLoaiBoSung(int Nam)
        {
            SqlParameter parm = new SqlParameter("@Nam", Nam);
           
              try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_SALARYTMP_List_LoaiBS", parm);
                return ds.Tables[0].DataTableToList<DM_LoaiBoSung>();
            }
            catch
            {
                return new List<DM_LoaiBoSung>();
            }
        }
        public DataTable GetSourceRptDSBS(string donviId, decimal nam, int loai)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@IdDonVi", donviId),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@Loai", loai)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "BoSungBangLuong_SelectByDonVi", parm);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetRptAgriBankBoSung(int nam, int loai)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam",nam),
                    new SqlParameter("@Loai",loai)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "BoSungBangLuong_SelectAgriBank", parm);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetRptVietComBankBoSung(int nam, int loai)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam",nam),
                    new SqlParameter("@Loai",loai)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "BoSungBangLuong_SelectVietComBank", parm);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetRptViettinBankBoSung(int nam, int loai)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam",nam),
                    new SqlParameter("@Loai",loai)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "BoSungBangLuong_SelectVietInBank", parm);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetRptNhanTienMatBoSung(int nam, int loai)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam",nam),
                    new SqlParameter("@Loai",loai)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "DanhSachNhanTienMatBS", parm);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        public bool ActiveLuong(int Nam, int Thang, int loai)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@Thang",Thang),
                new SqlParameter("@Loai",loai),
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_Update_Active_BangLuong", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}


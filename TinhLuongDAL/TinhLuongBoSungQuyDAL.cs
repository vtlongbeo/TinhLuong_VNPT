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
    public class TinhLuongBoSungQuyDAL
    {
        public bool GetData_TinhLuongBoSungQuy(int Quy, int Nam, decimal NguonBoSung, string DienGiai)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Quy",Quy),
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@NguonBoSung",NguonBoSung),
                new SqlParameter("@DienGiai",DienGiai)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetData_TinhLuongBoSung", parm);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TinhLuongBoSungQuy(int Nam, int LoaiBS)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@LoaiBS",LoaiBS)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_TinhBoSung_SauKhiCapNhat", parm);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<DM_LoaiBoSung> getLuongBS(int Nam)
        {
            SqlParameter parm = new SqlParameter("@Nam", Nam);
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_sp_List_LoaiBS_QUY", parm);
            return ds.Tables[0].DataTableToList<DM_LoaiBoSung>();
        }

        public List<BSQ_PhanNguonDV> GetAll_BSQ_PhanNguonDV_BoSung(int Nam, int LoaiBS,string DonViID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@LoaiBS", LoaiBS),
                new SqlParameter("@DonViID",DonViID)
            };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetAll_BSQ_PhanNguonDV_BoSung", parm);
            return ds.Tables[0].DataTableToList<BSQ_PhanNguonDV>();
        }
        public List<BSQ_BoSungDonVi> GetAll_BSQ_BoSungDonVi(int Nam,  int LoaiBS,string DonViID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@LoaiBS", LoaiBS),
                new SqlParameter("@DonViID",DonViID)
            };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetAll_BSQ_BoSungDonVi", parm);
            return ds.Tables[0].DataTableToList<BSQ_BoSungDonVi>();
        }
        public List<BSQ_LanhDao> GetAll_BSQ_LanhDao(int Nam, int LoaiBS,string DonViID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@LoaiBS", LoaiBS),
                new SqlParameter("@DonViID",DonViID)
            };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetAll_BSQ_LanhDao", parm);
            return ds.Tables[0].DataTableToList<BSQ_LanhDao>();
        }
        public List<BSQ_BangThongTin> GetAll_BSQ_BangThongTin(int Nam, int LoaiBS,string DonViID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@LoaiBS", LoaiBS),
                new SqlParameter("@DonViID",DonViID)
            };
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetAll_BSQ_BangThongTin", parm);
            return ds.Tables[0].DataTableToList<BSQ_BangThongTin>();
        }

        public bool Update_BSQ_PhanNguonDV_BoSung( int Nam, int LoaiBS, string DonViID, string Type, decimal Value)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@LoaiBS",LoaiBS),
                new SqlParameter("@DonViID",DonViID),
                new SqlParameter("@Type",Type),
                new SqlParameter("@Value",Value)
            };
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Update_BSQ_PhanNguonDv", parm);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update_BSQ_BangThongTin( int Nam,int NhanSuID, int LoaiBS, string DonViID, string Type, decimal Value)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@LoaiBS",LoaiBS),
                new SqlParameter("@DonViID",DonViID),
                new SqlParameter("@Type",Type),
                new SqlParameter("@Value",Value),
               new SqlParameter("@NhanSuID",NhanSuID)
            };
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Update_BSQ_BangThongTin", parm);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update_BSQ_BoSungDonVi( int Nam, int LoaiBS, string DonViID, string Type, decimal Value)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@LoaiBS",LoaiBS),
                new SqlParameter("@DonViID",DonViID),
                new SqlParameter("@Type",Type),
                new SqlParameter("@Value",Value)
            };
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Update_BSQ_BoSungDonVi", parm);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update_BSQ_sOtAIkHOAN( int Nam, int NhanSuID, int LoaiBS, string SoTK)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@LoaiBS",LoaiBS),
               new SqlParameter("@NhanSuID",NhanSuID),
               new SqlParameter("@SoTK",SoTK)
            };
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Update_SoTaiKhoan", parm);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update_BSQ_LanhDao_BoSung( int Nam, int LoaiBS, int NhanSuID, string Type, decimal Value)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@LoaiBS",LoaiBS),
                new SqlParameter("@NhanSuID",NhanSuID),
                new SqlParameter("@Type",Type),
                new SqlParameter("@Value",Value)
            };
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Update_BSQ_LanhDao", parm);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Ouput TinhLuong_DeleteBoSungQuy( int Nam, int LoaiBS)
        {
            Ouput ou = new Ouput();
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",DbType.Int32),
                new SqlParameter("@LoaiBS",DbType.Int32),
                new SqlParameter("@OutputCode",DbType.Int32),
                new SqlParameter("@OutputString",SqlDbType.NVarChar, 250)
            };
            parm[0].Value = Nam;
            parm[1].Value = LoaiBS;
            parm[2].Direction = ParameterDirection.Output;
            parm[3].Direction = ParameterDirection.Output;
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Del_LuongBoSung", parm);
                ou.OutputString = parm[3].Value.ToString();
                ou.OutputCode = int.Parse(parm[2].Value.ToString());
            }
            catch(Exception ex)
            {
                ou.OutputString = "Xảy ra lỗi thực thi. Vui lòng thử lại";
                ou.OutputCode = -1;
            }
            return ou;
        }
        public List<BSQ_LuongKHTamUng> GetAll_BSQ_LuongKHTamUng(int Nam)
        {
            SqlParameter parm = new SqlParameter("@Nam", Nam);
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetAll_BSQ_LuongKHTamUng", parm);
            return ds.Tables[0].DataTableToList<BSQ_LuongKHTamUng>();
        }
        public bool Update_LuongKHTamUng(int Nam, int NhanSuID, decimal LuongKH,bool IsActive)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@NhanSuID",NhanSuID),
                new SqlParameter("@LuongKH",LuongKH),
                new SqlParameter("@IsActive",IsActive)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_UpDate_LuongKHTamUng", parm);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<BSQ_LanhDao> GetAll_LanhDao(int Nam)
        {
            SqlParameter parm = new SqlParameter("@Nam", Nam);
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetAll_LanhDao_Nam", parm);
            return ds.Tables[0].DataTableToList<BSQ_LanhDao>();
        }
        public bool Insert_LuongKH(int Nam, int NhanSuID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@NhanSuID",NhanSuID)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_AddNew_LanhDao", parm);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete_LuongKH(int Nam, int NhanSuID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@NhanSuID",NhanSuID)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Delete_LanhDao", parm);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int UpLuongBS(string NgayCK, string UserName)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@NgayCK",NgayCK),
                new SqlParameter("@UserName",UserName)
            };
            try
            {
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Tuyen_CopyBangLuongBoSung]", parm);
                
            }
            catch
            {
                return -1000;
            }
        }
        public DataTable GetTenBS()
        {
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_getTenBS");
            return ds.Tables[0];
        }

        public bool TinhLuongBoSung(decimal nambs, string diengiai, string ngayck, decimal thangck, decimal namck, string username)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nambs",nambs),
                new SqlParameter("@DienGiai", diengiai),
                new SqlParameter("@Ngayck",ngayck),
                new SqlParameter("@Thangck",thangck),
                new SqlParameter("@Namck",namck),
                new SqlParameter("@Username",username)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongBoSung", parm);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("TinhLuongBoSung::SelectByPrimaryKey::Error occured.", ex);
            }
        }

        public DataTable TinhLuongKH_Fiber(int Thang, int Nam, string Type, decimal SoTien,string LoaiDV)
        {
            SqlParameter[] parm;
            string proc = "";
            if (Type == "FIBER" || Type == "LL")
            {
                parm = new SqlParameter[] {
               new SqlParameter("@Thang",Thang),
               new SqlParameter("@Nam",Nam),
               new SqlParameter("@NguonBoSung", SoTien),
                new SqlParameter("@Type", Type),
               new SqlParameter("@DonVi",LoaiDV)
                };
                proc = "Tuyen_TinhLuong_Fiber";

            }
            else
            {
                parm = new SqlParameter[] {
               new SqlParameter("@Thang",Thang),
               new SqlParameter("@Nam",Nam),
               new SqlParameter("@NguonBoSung", SoTien)
                };
                proc = "Tuyen_TinhLuong_KeHoachDV";
            }
            try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, proc, parm);
                return ds.Tables[0];
            }
            catch(Exception ex)
            {
                return new DataTable();
            }
        }
    }
}

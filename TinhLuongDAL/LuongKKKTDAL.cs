using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDataAdapter;

namespace TinhLuongDAL
{
    public class LuongKKKTDAL
    {
        public DataTable GetSourceRptKhenThuong(string donviId, decimal nam, decimal thang)
        {

            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@DonViID", donviId)
                 }; 
                 DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuongKhenThuong_SelectByDonVi", parm);
                return ds.Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }
        public string GetTenDVRptDS(string donviId)
        {
            // SqlCommand sqlCommand = new SqlCommand();
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@IdDonVi", SqlDbType.VarChar,50),
                new SqlParameter("@TenDV", SqlDbType.NVarChar,150),
                new SqlParameter("@TenDVCha", SqlDbType.NVarChar,150),
                };

                parm[0].Value = donviId;
                parm[1].Direction = ParameterDirection.Output;
                parm[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Get_TenDonVi", parm);
                return parm[1].Value.ToString();
            }
            catch
            {
                return "";
            }
        }
        public string GetTenDVChaRptDS(string donviId)
        {
            // SqlCommand sqlCommand = new SqlCommand();
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@IdDonVi", SqlDbType.VarChar,50),
                new SqlParameter("@TenDV", SqlDbType.NVarChar,150),
                new SqlParameter("@TenDVCha", SqlDbType.NVarChar,150),
                };

                parm[0].Value = donviId;
                parm[1].Direction = ParameterDirection.Output;
                parm[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Get_TenDonVi", parm);
                return parm[2].Value.ToString();
            }
            catch
            {
                return "";
            }
        }
        public DataTable GetSourceFooterRptDS(string donviId, decimal nam, decimal thang)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@IdDonVi", donviId),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@Thang", thang)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TenNguoiKyDS", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public bool UpdateLKK(decimal thang, decimal nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam)
                };
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuong_KKKhenThuong", parm);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("TinhLuongKKKhenThuong::SelectByPrimaryKey::Lỗi cập nhật!!!.", ex);
            }

        }
        public bool ThemMoiTinhLuong_Log(decimal thang, decimal nam, string username, DateTime ngayup, string sukien, string bangid, string nhansuid)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam),
                new SqlParameter("@UserName", username),
                new SqlParameter("@NgayUp", ngayup),
                new SqlParameter("@SuKien", sukien),
                new SqlParameter("@BangID", bangid),
                new SqlParameter("@NhanSuID",nhansuid),
            };

            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuong_Themmoi_Log", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool FillDataLuongKK(string thang, string nam,string UserName)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@UserName", UserName)
                };
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_sp_getLuongLapDat", parm);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("TinhLuongKKKhenThuong::FillDataLuongKK::Lỗi cập nhật!!!.", ex);
            }

        }


        public DataTable GetLuongPHLD(string Thang, string Nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam", Nam),
                    new SqlParameter("@Thang", Thang)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_sp_GETLuongPhoiHoplapdat", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetLuongKKLD(string Thang, string Nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam", Nam),
                    new SqlParameter("@Thang", Thang)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_sp_GetLuongLapDatByThang", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetChiTietLuongKKLD(string Thang, string Nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam", Nam),
                    new SqlParameter("@Thang", Thang)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_sp_GetChiTietLuongLapDatByThang", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public bool XacThucLuongKK(int ID, string TYPE, string UserName)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@ID", ID),
                    new SqlParameter("@TYPE", TYPE),
                    new SqlParameter("@UserName", UserName)
                };
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_sp_XacThucLuongLapDat", parm);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("TinhLuongKKKhenThuong::FillDataLuongKK::Lỗi cập nhật!!!.", ex);
            }

        }


        public bool UpdateLUONGDTTK(int Thang, int Nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Thang", Thang),
                    new SqlParameter("@Nam", Nam)
                };
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_sp_Update_LUONGDTTK_ByThangNam", parm);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("TinhLuongDTTK::UpdateLUONGDTTK::Lỗi cập nhật!!!.", ex);
            }

        }

        public DataTable GetChiTietBaoHongNhieuLan(string Thang, string Nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam", Nam),
                    new SqlParameter("@Thang", Thang)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Long_sp_GET_ChiTietBaohongNhieuLan", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetGiamTruBaoHongNhieuLan(string Thang, string Nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam", Nam),
                    new SqlParameter("@Thang", Thang)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Long_sp_GET_GiamTruBaoHongNhieuLan", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public bool XacThucBaoHongNhieuLan(int ID, string TYPE, string UserName)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@ID", ID),
                    new SqlParameter("@TYPE", TYPE),
                    new SqlParameter("@UserName", UserName)
                };
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_sp_XacThucBaoHongNhieuLan", parm);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("TinhLuongKKKhenThuong::XacThucBaoHongNhieuLan::Lỗi cập nhật!!!.", ex);
            }

        }


        public DataTable ChiTietCatHuy(string Thang, string Nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam", Nam),
                    new SqlParameter("@Thang", Thang)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_sp_GET_ChiTietCatHuy", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }


        public DataTable THCatHuy(string Thang, string Nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam", Nam),
                    new SqlParameter("@Thang", Thang)
                };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_sp_GET_CatHuyByThang", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public bool XacThucCatHuy(int ID, string TYPE, string UserName)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@ID", ID),
                    new SqlParameter("@TYPE", TYPE),
                    new SqlParameter("@UserName", UserName)
                };
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LONG_sp_XacThucCatHuy", parm);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("TinhLuongKKKhenThuong::LONG_sp_XacThucCatHuy::Lỗi cập nhật!!!.", ex);
            }

        }

    }
}

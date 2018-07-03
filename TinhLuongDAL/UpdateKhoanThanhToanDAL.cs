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
    public class UpdateKhoanThanhToanDAL
    {
        public DataTable GetBangLuongKyIDonVi(string IDDonVi, decimal thang, decimal nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@DonViID", IDDonVi),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@Thang",thang)
               };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuongKy1_SelectByDonVi", parm);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuong::SelectByIdDonvi::Error occured.", ex);
            }

        }
        public DataTable GetBangLuongKy1_ByNhanVien(string NhanSuID, decimal thang, decimal nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@NhanSuID", NhanSuID),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@Thang",thang)
               };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuongKy1_SelectByNhanVien", parm);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuong::SelectByIdDonvi::Error occured.", ex);
            }

        }
        public int BangLuongKy1_Update(decimal thang, decimal nam, string nhansuid, string sotk, decimal anca, decimal ctp_khth, decimal tt_themgio, decimal chenuoc,
          decimal ctp_khac, decimal boiduongk3, decimal khac, decimal luongky1, decimal chuyenkhoan)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                 new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam),
                new SqlParameter("@nhansuid", nhansuid),
                //dbCmd.Parameters.Add(new SqlParameter("@sotk", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, sotk));
               new SqlParameter("@sotk", sotk),
               new SqlParameter("@anca",  anca),
               new SqlParameter("@ctp_khth", ctp_khth),
                new SqlParameter("@tt_themgio", tt_themgio),
                new SqlParameter("@chenuoc",  chenuoc),
                new SqlParameter("@ctp_khac",  ctp_khac),
                new SqlParameter("@boiduongk3", boiduongk3),
                new SqlParameter("@khac", khac),
                new SqlParameter("@luongky1", luongky1),
                new SqlParameter("@chuyenkhoan", chuyenkhoan),
            };
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "BangLuongKy1_Update", parm);

            }
            catch
            {
                return -1;
            }
        }
    }
}

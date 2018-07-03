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
    public class QuyLuongDAL
    {
        public DataTable GetListQuyLuong(decimal thang, decimal nam, string donviId)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam",nam),
                new SqlParameter("@DonViID",donviId),
            };

            try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuong_LayQuyLuong", parm);
                return ds.Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }
        public DataTable GetListQuyLuongByDonVi(decimal thang, decimal nam, string donviId)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam",nam),
                new SqlParameter("@DonViID",donviId),
            };

            try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_TinhLuong_LayQuyLuong_ByDonViID", parm);
                return ds.Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }

        public bool XoaQuyLuong(decimal thang, decimal nam, string donviId)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang",thang),
                new SqlParameter("@Nam",nam),
                new SqlParameter("@DonViID",donviId)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuong_Xoa", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CapnhatQuyLuong(decimal thang, decimal nam, string donviId, decimal quygt, decimal quytt, decimal quythe, decimal chatluongthang,
           decimal htkh, decimal htcntt, decimal tylethe, decimal tylecuoc, decimal cstl, decimal stt, decimal quygt_kh, decimal quythe_kh)
        {
            //dbCmd.Parameters.Add(new SqlParameter("@Thang", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, thang));
            //dbCmd.Parameters.Add(new SqlParameter("@Nam", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, nam));
            //dbCmd.Parameters.Add(new SqlParameter("@DonViID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, donviId    ));
            //dbCmd.Parameters.Add(new SqlParameter("@QuyGT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, quygt));
            //dbCmd.Parameters.Add(new SqlParameter("@QuyTT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, quytt));
            //dbCmd.Parameters.Add(new SqlParameter("@ChatLuongThang", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, chatluongthang));
            //dbCmd.Parameters.Add(new SqlParameter("@Tyle_HTKH", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, hethongkh));
            //dbCmd.Parameters.Add(new SqlParameter("@Tyle_HTCNTT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, hethongcntt));
            //dbCmd.Parameters.Add(new SqlParameter("@CSTL_LDDB", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, cstl));
            //dbCmd.Parameters.Add(new SqlParameter("@STT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, stt));
            SqlParameter[] parm = new SqlParameter[]
            {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@DonViID", donviId),
                    new SqlParameter("@QuyGT", quygt),
                    new SqlParameter("@QuyTT", quytt),
                    new SqlParameter("@QuyThe", quythe),
                    new SqlParameter("@ChatLuongThang", chatluongthang),
                    new SqlParameter("@Tyle_HTKH",  htkh),
                    new SqlParameter("@Tyle_HTCNTT",  htcntt),
                    new SqlParameter("@Tyle_The",  tylethe),
                    new SqlParameter("@Tyle_Cuoc", tylecuoc),
                    new SqlParameter("@CSTL_LDDB", cstl),
                    new SqlParameter("@STT",  stt),
                    new SqlParameter("@QuyGT_KH",  quygt_kh),
                    new SqlParameter("@QuyThe_KH",  quythe_kh),
            };

            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuong_Update", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ThemMoiQuyLuong(decimal thang, decimal nam, string donviId, decimal quygt, decimal quytt, decimal quythe, decimal chatluongthang,
           decimal htkh, decimal htcntt, decimal tylethe, decimal tylecuoc, decimal cstl, decimal stt, decimal quygt_kh, decimal quythe_kh)
        {
            //dbCmd.Parameters.Add(new SqlParameter("@Thang", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, thang));
            //dbCmd.Parameters.Add(new SqlParameter("@Nam", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, nam));
            //dbCmd.Parameters.Add(new SqlParameter("@DonViID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, donviId    ));
            //dbCmd.Parameters.Add(new SqlParameter("@QuyGT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, quygt));
            //dbCmd.Parameters.Add(new SqlParameter("@QuyTT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, quytt));
            //dbCmd.Parameters.Add(new SqlParameter("@ChatLuongThang", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, chatluongthang));
            //dbCmd.Parameters.Add(new SqlParameter("@Tyle_HTKH", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, hethongkh));
            //dbCmd.Parameters.Add(new SqlParameter("@Tyle_HTCNTT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, hethongcntt));
            //dbCmd.Parameters.Add(new SqlParameter("@CSTL_LDDB", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, cstl));
            //dbCmd.Parameters.Add(new SqlParameter("@STT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, stt));
            SqlParameter[] parm = new SqlParameter[]
            {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@DonViID", donviId),
                    new SqlParameter("@QuyGT", quygt),
                    new SqlParameter("@QuyTT", quytt),
                    new SqlParameter("@QuyThe", quythe),
                    new SqlParameter("@ChatLuongThang", chatluongthang),
                    new SqlParameter("@Tyle_HTKH",  htkh),
                    new SqlParameter("@Tyle_HTCNTT",  htcntt),
                    new SqlParameter("@Tyle_The",  tylethe),
                    new SqlParameter("@Tyle_Cuoc", tylecuoc),
                    new SqlParameter("@CSTL_LDDB", cstl),
                    new SqlParameter("@STT",  stt),
                    new SqlParameter("@QuyGT_KH",  quygt_kh),
                    new SqlParameter("@QuyThe_KH",  quythe_kh),
            };

            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuong_Themmoi", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

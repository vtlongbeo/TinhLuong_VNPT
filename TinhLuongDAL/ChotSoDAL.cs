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
    public class ChotSoDAL
    {
        public List<DM_DonVi> Select_ByDonViCha(string donviid)
        {
            try
            {
                SqlParameter parm = new SqlParameter("@IdDonVi", donviid);
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpDM_DonVi_SelectByDonViCha", parm);
                return ds.Tables[0].DataTableToList<DM_DonVi>();

            }
            catch (Exception ex)
            {
                throw new Exception("DM_DonVi::SelectAll::Error occured.", ex);
            }
        }
        public List<DM_BangChotSo> GetByBangChot(decimal thang, decimal nam, string donviId)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang",thang),
                new SqlParameter("@Nam",nam),
                new SqlParameter("@DonViID",donviId)
            };
            try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuong_LayDMBangChot", parm);
                return ds.Tables[0].DataTableToList<DM_BangChotSo>();
            }
            catch (Exception ex)
            {
                throw new Exception("DM_BangChotSo::SelectAll::Error occured.", ex);
            }
        }
        public DataTable GetListChotso(decimal thang, decimal nam, string donviId)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
                new SqlParameter("@Thang",thang),
                new SqlParameter("@Nam",nam),
                new SqlParameter("@DonViID",donviId)
             };

            try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuong_LayBangChotSo", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("DM_BangChotSo::SelectAll::Error occured.", ex);
            }
        }
        public DataTable GetListChotso_BangID(decimal thang, decimal nam, string donviId, string BangID)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
                new SqlParameter("@Thang",thang),
                new SqlParameter("@Nam",nam),
                new SqlParameter("@DonViID",donviId),
                new SqlParameter("@BangID",BangID)
             };

            try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_TinhLuong_LayBangChotSo_WithBangID", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("DM_BangChotSo::SelectAll::Error occured.", ex);
            }
        }
        public bool CapnhatBangChotSo(decimal Nam, decimal Thang, string BangID, string DonViID, int TinhTrang, string USERNAME)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam", Nam),
                new SqlParameter("@Thang", Thang),
                new SqlParameter("@BangID",BangID),
                new SqlParameter("@DonViID",DonViID),
                new SqlParameter("@TinhTrang",TinhTrang),
                new SqlParameter("@USERNAME",USERNAME),
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuong_Update_Chotso", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ChotSoBS> GetList_ChotSoBS(int Nam)
        {
            SqlParameter parm = new SqlParameter("@Nam", Nam);
            DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetAll_ChotSo_BS", parm);
            return ds.Tables[0].DataTableToList<ChotSoBS>();
        }
        public Ouput Tuyen_Check_ChotSoBS(int Nam, int LoaiBS)
        {
            Ouput ou = new Ouput();
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",SqlDbType.Int),
                new SqlParameter("@LoaiBS",SqlDbType.Int),
                new SqlParameter("@OutputCode",SqlDbType.Int),
                new SqlParameter("@OutputString",SqlDbType.NVarChar,250)
            };
            parm[0].Value = Nam;
            parm[1].Value = LoaiBS;
            parm[2].Direction = ParameterDirection.Output;
            parm[3].Direction = ParameterDirection.Output;
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Check_ChotSoBS", parm);
                ou.OutputCode =int.Parse(parm[2].Value.ToString());
                ou.OutputString = parm[3].Value.ToString();
            }
            catch(Exception ex)
            {
                ou.OutputCode = -1;
                ou.OutputString = "Xảy ra lỗi thực thi. Vui lòng thử lại";
            }
            return ou;
        }
        public Ouput Tuyen_Update_ChotSoBS(int Nam, int LoaiBS,string Username)
        {
            Ouput ou = new Ouput();
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",SqlDbType.Int),
                new SqlParameter("@LoaiBS",SqlDbType.Int),
                 new SqlParameter("@Username",SqlDbType.VarChar,50),
                new SqlParameter("@OutputCode",SqlDbType.Int),
                new SqlParameter("@OutputString",SqlDbType.NVarChar,250)
            };
            parm[0].Value = Nam;
            parm[1].Value = LoaiBS;
            parm[2].Value = Username;
            parm[3].Direction = ParameterDirection.Output;
            parm[4].Direction = ParameterDirection.Output;
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Update_STT_ChotSoBS", parm);
                ou.OutputCode = int.Parse(parm[3].Value.ToString());
                ou.OutputString = parm[4].Value.ToString();
            }
            catch (Exception ex)
            {
                ou.OutputCode = -1;
                ou.OutputString = "Xảy ra lỗi thực thi. Vui lòng thử lại";
            }
            return ou;
        }
    }
}

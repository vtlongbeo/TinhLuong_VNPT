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
    public class TinhLuong3PsDAL
    {
        public bool UpdateLCN(string IdDonVi, decimal thang, decimal nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                     new SqlParameter("@IdDonVi", IdDonVi),
                     new SqlParameter("@Thang", thang),
                     new SqlParameter("@Nam", nam),
                };
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongCaNhan", parm);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("TinhLuongCaNhan::SelectByPrimaryKey::Error occured.", ex);
            }
        }
        public int CopyBangLuongThang(decimal thang, decimal nam,int NC)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                     new SqlParameter("@Thang", thang),
                     new SqlParameter("@Nam", nam),
                     new SqlParameter("@NC",NC)
                };
               var rs= SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Tuyen_CopyBangLuongThang]", parm);
                if (rs > 0) return 1;
                else return -1;
            }
            catch (Exception ex)
            {
                throw new Exception("TinhLuongCaNhan::SelectByPrimaryKey::Error occured.", ex);
            }
        }
    }
}

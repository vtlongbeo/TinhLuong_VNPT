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
   public class LoaiTruCongNoDAL
    {
        public DataTable GetLoaiTruCongNo(string donviId, decimal nam, decimal thang)
        {

            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@IdDonVi", donviId)
                 };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "LoaiTruCongNo", parm);
                return ds.Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }
    }
}

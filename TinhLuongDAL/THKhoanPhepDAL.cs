using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TinhLuongDataAdapter;

namespace TinhLuongDAL
{
   public class THKhoanPhepDAL
    {
        public DataTable GetSourceRptTHKhoanPhep(string donviId, decimal nam, decimal thang)
        {
             try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                new SqlParameter("@Nam", nam),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@IdDonVi", donviId),
                };

                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongTHKhoanPhep", parm);
                return ds.Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }
    }
}

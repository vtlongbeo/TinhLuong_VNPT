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
   public class LuongLanhDaoDAL
    {
        public DataTable GetSourceRptLD(decimal nam, decimal thang)
        {
          
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@Thang", thang),
                 };

                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "RepoViewLuongLanhDao", parm);
                return ds.Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }
        public DataTable GetSourceRpt(decimal nam, decimal thang)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                 new SqlParameter("@Nam", nam),
                new SqlParameter("@Thang", thang),
                 };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongThongBao", parm);
                return ds.Tables[0];
            }
            catch
            {
                return new DataTable();

            }
        }
    }
}

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
    public class CommonDAL
    {
        public DataTable GetDonGia(string LoaiLuong,string LoaiCap)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                     new SqlParameter("@LoaiLuong", LoaiLuong),
                     new SqlParameter("@LoaiCap", LoaiCap)
                };
                
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_GetDonGia", parm);
                return ds.Tables[0];
            }
            catch(Exception e)
            {
                return new DataTable();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDAL;
namespace TinhLuongBLL
{
   public class LuongLanhDaoBLL
    {
        LuongLanhDaoDAL dal = new LuongLanhDaoDAL();
        public DataTable GetSourceRptLD(decimal nam, decimal thang)
        {
            return dal.GetSourceRptLD(nam,thang);
        }
        public DataTable GetSourceRpt(decimal nam, decimal thang)
        {
            return dal.GetSourceRpt(nam, thang);
        }
    }
}

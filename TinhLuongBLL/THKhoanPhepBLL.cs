using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDAL;

namespace TinhLuongBLL
{
   public class THKhoanPhepBLL
    {
        THKhoanPhepDAL dal = new THKhoanPhepDAL();
        public DataTable GetSourceRptTHKhoanPhep(string donviId, decimal nam, decimal thang)
        {
            return dal.GetSourceRptTHKhoanPhep(donviId, nam, thang);
        }
    }
}

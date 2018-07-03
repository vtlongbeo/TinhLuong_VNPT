using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDAL;

namespace TinhLuongBLL
{
    public class TongHopLuongBLL
    {
        TongHopLuongDAL dal = new TongHopLuongDAL();
        public DataTable GetSourceRptDS(string donviId, decimal nam, decimal thang)
        {
            return dal.GetSourceRptDS(donviId, nam,thang);
        }
    }
}

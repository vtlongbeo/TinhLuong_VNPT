using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDAL;

namespace TinhLuongBLL
{
    public class LoaiTruCongNoBLL
    {
        LoaiTruCongNoDAL dal = new LoaiTruCongNoDAL();
        public DataTable GetLoaiTruCongNo(string donviId, decimal nam, decimal thang)
        {
            return dal.GetLoaiTruCongNo(donviId, nam, thang);
        }
    }
}

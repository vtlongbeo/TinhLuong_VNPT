using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDAL;
using TinhLuongINFO;
namespace TinhLuongBLL
{
   public class CommonBLL
    {
        CommonDAL dal = new CommonDAL();
        public DataTable GetDonGia(string LoaiLuong, string LoaiCap)
        {
            return dal.GetDonGia(LoaiLuong,LoaiCap);
        }
    }
}

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
   public class UpdateKhoanThanhToanBLL
    {
        UpdateKhoanThanhToanDAL dal = new UpdateKhoanThanhToanDAL();
        public DataTable GetBangLuongKyIDonVi(string IDDonVi, decimal thang, decimal nam)
        {
            return dal.GetBangLuongKyIDonVi(IDDonVi, thang, nam);
        }
        public DataTable GetBangLuongKy1_ByNhanVien(string NhanSuID, decimal thang, decimal nam)
        {
            return dal.GetBangLuongKy1_ByNhanVien(NhanSuID, thang, nam);
        }
        public int BangLuongKy1_Update(decimal thang, decimal nam, string nhansuid, string sotk, decimal anca, decimal ctp_khth, decimal tt_themgio, decimal chenuoc,
          decimal ctp_khac, decimal boiduongk3, decimal khac, decimal luongky1, decimal chuyenkhoan)
        {
            return dal.BangLuongKy1_Update(thang, nam, nhansuid, sotk, anca, ctp_khth, tt_themgio, chenuoc,
           ctp_khac, boiduongk3, khac, luongky1, chuyenkhoan);
        }
    }
}

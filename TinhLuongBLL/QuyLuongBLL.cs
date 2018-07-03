using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDAL;

namespace TinhLuongBLL
{
    public class QuyLuongBLL
    {
        QuyLuongDAL dal = new QuyLuongDAL();
        public DataTable GetListQuyLuong(decimal thang, decimal nam, string donviId)
        {
            return dal.GetListQuyLuong(thang, nam, donviId);
        }
        public DataTable GetListQuyLuongByDonVi(decimal thang, decimal nam, string donviId)
        {
            return dal.GetListQuyLuongByDonVi(thang, nam, donviId);
        }
        public bool XoaQuyLuong(decimal thang, decimal nam, string donviId)
        {
            return dal.XoaQuyLuong(thang, nam, donviId);
        }
        public bool CapnhatQuyLuong(decimal thang, decimal nam, string donviId, decimal quygt, decimal quytt, decimal quythe, decimal chatluongthang,
          decimal htkh, decimal htcntt, decimal tylethe, decimal tylecuoc, decimal cstl, decimal stt, decimal quygt_kh, decimal quythe_kh)
        {
            return dal.CapnhatQuyLuong(thang, nam, donviId, quygt, quytt, quythe, chatluongthang,
           htkh, htcntt, tylethe, tylecuoc, cstl, stt, quygt_kh, quythe_kh);
        }
        public bool ThemMoiQuyLuong(decimal thang, decimal nam, string donviId, decimal quygt, decimal quytt, decimal quythe, decimal chatluongthang,
         decimal htkh, decimal htcntt, decimal tylethe, decimal tylecuoc, decimal cstl, decimal stt, decimal quygt_kh, decimal quythe_kh)
        {
            return dal.ThemMoiQuyLuong(thang, nam, donviId, quygt, quytt, quythe, chatluongthang,
           htkh, htcntt, tylethe, tylecuoc, cstl, stt, quygt_kh, quythe_kh);
        }
    }
}

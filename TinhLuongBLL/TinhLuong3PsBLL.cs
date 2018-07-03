using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDAL;

namespace TinhLuongBLL
{
   public class TinhLuong3PsBLL
    {
        TinhLuong3PsDAL dal = new TinhLuong3PsDAL();
        public bool UpdateLCN(string IdDonVi, decimal thang, decimal nam)
        {
            return dal.UpdateLCN(IdDonVi, thang, nam);
        }
        public int CopyBangLuongThang(decimal thang, decimal nam,int NC)
        {
            return dal.CopyBangLuongThang(thang, nam,NC);
        }
    }
}

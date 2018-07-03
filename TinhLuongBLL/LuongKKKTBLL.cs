using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDAL;

namespace TinhLuongBLL
{
    public class LuongKKKTBLL
    {
        LuongKKKTDAL dal = new LuongKKKTDAL();
        public DataTable GetSourceRptKhenThuong(string donviId, decimal nam, decimal thang)
        {
            return dal.GetSourceRptKhenThuong(donviId, nam, thang);
        }
        public string GetTenDVRptDS(string donviId)
        {
            return dal.GetTenDVRptDS(donviId);
        }
        public string GetTenDVChaRptDS(string donviId)
        {
            return dal.GetTenDVChaRptDS(donviId);
        }
        public DataTable GetSourceFooterRptDS(string donviId, decimal nam, decimal thang)
        {
            return dal.GetSourceFooterRptDS(donviId, nam, thang);
        }
        public bool UpdateLKK(decimal thang, decimal nam)
        {
            return dal.UpdateLKK(thang, nam);
        }
        public bool ThemMoiTinhLuong_Log(decimal thang, decimal nam, string username, DateTime ngayup, string sukien, string bangid, string nhansuid)
        {
            return dal.ThemMoiTinhLuong_Log(thang, nam, username, ngayup, sukien, bangid, nhansuid);
        }
        public bool FillDataLuongKK(string thang, string nam, string UserName)
        {
            return dal.FillDataLuongKK(thang, nam, UserName);
        }

        public DataTable GetLuongPHLD(string Thang, string Nam)
        {
            return dal.GetLuongPHLD(Thang, Nam);
        }

        public DataTable GetLuongKKLD(string Thang, string Nam)
        {
            return dal.GetLuongKKLD(Thang, Nam);
        }

        public DataTable GetChiTietLuongKKLD(string Thang, string Nam)
        {
            return dal.GetChiTietLuongKKLD(Thang, Nam);
        }

        public bool XacThucLuongKK(int ID, string TYPE, string UserName)
        {
            return dal.XacThucLuongKK(ID,TYPE,UserName);
        }

        public bool UpdateLUONGDTTK(int Thang, int Nam)
        {
            return dal.UpdateLUONGDTTK(Thang, Nam);
        }

        public DataTable GetGiamTruBaoHongNhieuLan(string Thang, string Nam)
        {
            return dal.GetGiamTruBaoHongNhieuLan(Thang, Nam);
        }
        public DataTable GetChiTietBaoHongNhieuLan(string Thang, string Nam)
        {
            return dal.GetChiTietBaoHongNhieuLan(Thang, Nam);
        }
        public bool XacThucBaoHongNhieuLan(int ID, string TYPE, string UserName)
        {
            return dal.XacThucBaoHongNhieuLan(ID, TYPE, UserName);
        }

        public DataTable THCatHuy(string Thang, string Nam)
        {
            return dal.THCatHuy(Thang,Nam);
        }

        public DataTable ChiTietCatHuy(string Thang, string Nam)
        {
            return dal.ChiTietCatHuy(Thang, Nam);
        }
        public bool XacThucCatHuy(int ID, string TYPE, string UserName)
        {
            return dal.XacThucCatHuy(ID, TYPE, UserName);
        }
    }
}

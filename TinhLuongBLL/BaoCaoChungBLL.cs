using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TinhLuongDAL;
using TinhLuongINFO;

namespace TinhLuongBLL
{
   public class BaoCaoChungBLL
    {
        BaoCaoChungDAL dal = new BaoCaoChungDAL();
        public List<DM_DonVi> Get_ListTenDonVi(String donviId)
        {
            return dal.Get_ListTenDonVi(donviId);
        }
        public List<DM_DonVi> Get_ListTenTram(string donviId)
        {
            return dal.Get_ListTenTram(donviId);
        }
        public List<NhanVien> Get_ListTenNhanVien(string donviId)
        {
            return dal.Get_ListTenNhanVien(donviId);
        }
        public DataTable RequestTableNhanVien(decimal nam, decimal thang, string nhanSuID, string DonViID_Session,string type)
        {
            return dal.RequestTableNhanVien(nam, thang, nhanSuID,DonViID_Session,type);
        }
        public DataTable GetSourceRptDSChiTiet_CSHT(string donviId, decimal nam, decimal thang)
        {
            return dal.GetSourceRptDSChiTiet_CSHT(donviId, nam, thang);
        }
        public DataTable GetSourceRptDSChiTietKKLD_CSHT(string donviId, decimal nam, decimal thang)
        {
            return dal.GetSourceRptDSChiTietKKLD_CSHT(donviId, nam,thang);
        }
        public DataTable GetRptKy1_AgriBank(decimal nam, decimal thang)
        {
            return dal.GetRptKy1_AgriBank(nam, thang);
        }
        public DataTable GetRptKy1_VietComBank(decimal nam, decimal thang)
        {
            return dal.GetRptKy1_VietComBank(nam, thang);
        }
        public DataTable GetRptKy1_ViettinBank(decimal nam, decimal thang)
        {
            return dal.GetRptKy1_ViettinBank(nam, thang);
        }
        public DataTable GetRpt_AgriBank(decimal nam, decimal thang)
        {
            return dal.GetRpt_AgriBank(nam, thang);
        }
        public DataTable GetRpt_VietComBank(decimal nam, decimal thang)
        {
            return dal.GetRpt_VietComBank(nam, thang);
        }
        public DataTable GetRpt_ViettinBank(decimal nam, decimal thang)
        {
            return dal.GetRpt_ViettinBank(nam, thang);
        }
        public List<DM_LoaiBoSung> GetLoaiBoSung(int Nam)
        {
            return dal.GetLoaiBoSung(Nam);
        }
        public DataTable GetSourceRptDSBS(string donviId, decimal nam, int loai)
        {
            return dal.GetSourceRptDSBS(donviId, nam, loai);
        }
        public DataTable GetRptAgriBankBoSung(int nam, int loai)
        {
            return dal.GetRptAgriBankBoSung(nam, loai);
        }
        public DataTable GetRptVietComBankBoSung(int nam, int loai)
        {
            return dal.GetRptVietComBankBoSung(nam, loai);
        }
        public DataTable GetRptViettinBankBoSung(int nam, int loai)
        {
            return dal.GetRptViettinBankBoSung(nam, loai);
        }
        public DataTable GetRptNhanTienMatBoSung(int nam, int loai)
        {
            return dal.GetRptNhanTienMatBoSung(nam, loai);
        }
        public bool ActiveLuong(int Nam, int Thang, int loai)
        {
            return dal.ActiveLuong(Nam, Thang, loai);
        }
    }
}

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
    public class ChamCongBLL
    {

        ChamCongDAL dal = new ChamCongDAL();
        public DataTable GetChamCongDonVi(string thang, string nam, string DonViID, string TramID, string Username)
        {
            return dal.GetChamCongDonVi(thang, nam, DonViID, TramID, Username);
        }

        public DataTable ChamCong_SelectByDonVi(string thang, string nam, string DonViID, int TrucDem, string Username)
        {
            return dal.ChamCong_SelectByDonVi(thang, nam, DonViID, TrucDem, Username);
        }

        public DataTable GetChamCongDonViByNhanSu(string NhanVienID, string thang, string nam, int TrucDem)
        {
            return dal.GetChamCongDonViByNhanSu(NhanVienID, thang, nam, TrucDem);
        }

        public List<DM_ChamCong> SelectByMaChamCong(string MaChamCong)
        {
            return dal.SelectByMaChamCong(MaChamCong);
        }

        public DataTable GetInfoByNhanSuID(string NhanVienID, int thang, int nam)
        {
            return dal.GetInfoByNhanSuID(NhanVienID, thang, nam);
        }

        public bool UpdateChamCongByNhanVien(int NhanVienID, int Nam, int Thang, int Ngay, string MaChamCong, string Note, int TrucDem,string Username)
        {
            return dal.UpdateChamCongByNhanVien(NhanVienID, Nam, Thang, Ngay, MaChamCong, Note, TrucDem, Username);
        }

        public string ChotChamCong(string Thang, string Nam)
        {
            return dal.ChotChamCong(Thang, Nam);
        }
        public  bool UpdateLuongTrucDem(string Thang, string Nam, string UserName)
        {
            return dal.UpdateLuongTrucDem(Thang, Nam, UserName);
        }

    }
}

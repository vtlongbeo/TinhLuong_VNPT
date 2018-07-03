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
    public class ImportExcelBLL
    {
        ImportExcelDAL dal = new ImportExcelDAL();
        public bool GetChotSo(decimal thang, decimal nam, string IdDonVi, string BangID)
        {
            return dal.GetChotSo(thang, nam, IdDonVi, BangID);
        }
        public bool CapNhatBangLuongKy1_Import(int nam, int thang, string nhansuid, string donviid, int anca, int ctp_khth, int tt_themgio, int chenuoc,
              int ctp_khac, int boiduongk3, int khac, int luongky1, string USERNAME)
        {
            return dal.CapNhatBangLuongKy1_Import(nam, thang, nhansuid, donviid, anca, ctp_khth, tt_themgio, chenuoc,
               ctp_khac, boiduongk3, khac, luongky1, USERNAME);
        }
        public bool UpdateDT(int nam, int thang, int nhansuid, string donviid, decimal doanhthu, string username)
        {
            return dal.UpdateDT(nam, thang, nhansuid, donviid, doanhthu, username);
        }
        public List<string> GetBangLuongDonVi(string IDDonVi, decimal thang, decimal nam)
        {
            return dal.GetBangLuongDonVi(IDDonVi, thang, nam);
        }
        public bool Update_SQLPTTB(decimal nam, decimal thang, string IdDonVi, string username)
        {
            return dal.Update_SQLPTTB(nam, thang, IdDonVi, username);
        }
        public bool UpdateTAMUNGKTP(BangLuong bl)
        {
            return dal.UpdateTAMUNGKTP(bl);
        }
        public bool Update_BSC(decimal nam, decimal thang, string username)
        {
            return dal.Update_BSC(nam, thang, username);
        }
        public bool Delete_KKLD(decimal nam, decimal thang, string username, int Loai)
        {
            return dal.Delete_KKLD(nam, thang, username,Loai);
        }
        public bool UpdateLAPDAT(BangLuongLapDat bl)
        {
            return dal.UpdateLAPDAT(bl);
        }
        public bool UpdateKDTM(BangLuong bl)
        {
            return dal.UpdateKDTM(bl);
        }
        public bool Update_KHENTHUONG(decimal Nam, decimal Thang, string UserName, decimal LuongKK, string NhanSuID)
        {
            return dal.Update_KHENTHUONG(Nam, Thang, UserName, LuongKK, NhanSuID);
        }
        public bool Delete_TangGiam(decimal nam, decimal thang, string username)
        {
            return dal.Delete_TangGiam(nam, thang, username);
        }
        public bool Delete_LuongKhac(decimal nam, decimal thang, string username,int Loai,string DonViID)
        {
            return dal.Delete_LuongKhac(nam, thang, username, Loai,DonViID);
        }

        public bool Delete_LuongKTP(decimal nam, decimal thang, string username, int Loai, string DonViID)
        {
            return dal.Delete_LuongKTP(nam, thang, username, Loai, DonViID);
        }
        public bool Update_LUONGKHAC(decimal Nam, decimal Thang, string UserName, decimal LuongKhac, string NhanSuID,string loailuong)
        {
            return dal.Update_LUONGKHAC(Nam, Thang, UserName, LuongKhac, NhanSuID,loailuong);
        }

        public bool Update_LUONGKTP(decimal Nam, decimal Thang, string UserName, decimal LuongKhac, string NhanSuID, string loailuong)
        {
            return dal.Update_LUONGKTP(Nam, Thang, UserName, LuongKhac, NhanSuID, loailuong);
        }
        public bool Update_DoanhThuNgoai(decimal Nam, decimal Thang, string UserName, decimal LUONGKDTM, string NhanSuID, string DonViID)
        {
            return dal.Update_DoanhThuNgoai(Nam, Thang, UserName, LUONGKDTM, NhanSuID, DonViID);
        }
        public bool Update_TangGiam(decimal Nam, decimal Thang, string UserName, decimal LUONGKTP, string NhanSuID)
        {
            return dal.Update_TangGiam(Nam, Thang, UserName, LUONGKTP, NhanSuID);
        }
        public bool UpdateUNGCUU(int Nam, int Thang, string NhanSuID, int LuongTN, string UserName)
        {
            return dal.UpdateUNGCUU(Nam, Thang, NhanSuID, LuongTN, UserName);
        }
        public bool Delete_UngCuu(decimal nam, decimal thang, string username)
        {
            return dal.Delete_UngCuu(nam, thang, username);
        }
        public bool Delete_BoSung_Temp()
        {
            return dal.Delete_BoSung_Temp();
        }
        public bool UpdateBoSung(string NhanSuID, int TongTien, string DonViID, string DonViChaID, int ChuyenKhoan, string NgayCK, int ThuNop, string Username, string sotk)
        {
            return dal.UpdateBoSung(NhanSuID, TongTien, DonViID, DonViChaID, ChuyenKhoan, NgayCK, ThuNop, Username, sotk);
        }
        public bool Import_BaoHongGiamTru(int nam, int thang, int PhieuBaoHongID)
        {
            return dal.Import_BaoHongGiamTru(nam, thang, PhieuBaoHongID);
        }
        public bool Delete_BaoHongGiamTru(int nam, int thang)
        {
            return dal.Delete_BaoHongGiamTru(nam, thang);
        }
        public bool Insert_MLLTB(int nam, int thang, string DonViID, string Loai, int TGMLL, int SLTB)
        {
            return dal.Insert_MLLTB(nam, thang, DonViID, Loai, TGMLL, SLTB);
        }
        public bool Delete_MLLTB(int nam, int thang,  string Loai)
        {
            return dal.Delete_MLLTB(nam, thang, Loai);
        }
        public DataTable GetKKLapDat(int thang, int nam, string type)
        {
            return dal.GetKKLapDat(thang, nam, type);
        }
        public DataTable GetLuongTBDuyTri(int thang, int nam)
        {
            return dal.GetLuongTBDuyTri(thang, nam);
        }
        public int Get_SoNgayCong(int thang, int nam)
        {
            return dal.Get_SoNgayCong(thang, nam);
        }
        public DataTable TinhLuong_MLLTB(int thang, int nam)
        {
            return dal.TinhLuong_MLLTB(thang, nam);
        }
    }
}

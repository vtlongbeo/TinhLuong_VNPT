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
    public class TinhLuongBoSungQuyBLL
    {
        TinhLuongBoSungQuyDAL dal = new TinhLuongBoSungQuyDAL();
        public bool GetData_TinhLuongBoSungQuy(int Quy, int Nam, decimal NguonBoSung, string DienGiai)
        {
            return dal.GetData_TinhLuongBoSungQuy(Quy, Nam, NguonBoSung, DienGiai);
        }
        public List<BSQ_PhanNguonDV> GetAll_BSQ_PhanNguonDV_BoSung(int Nam, int LoaiBS,string DonViID)
        {
            return dal.GetAll_BSQ_PhanNguonDV_BoSung(Nam,  LoaiBS,DonViID);
        }
        public List<DM_LoaiBoSung> getLuongBS(int Nam)
        {
            return dal.getLuongBS(Nam);
        }
        public bool TinhLuongBoSungQuy(int Nam, int LoaiBS)
        {
            return dal.TinhLuongBoSungQuy( Nam, LoaiBS);
        }
        public List<BSQ_LanhDao> GetAll_BSQ_LanhDao(int Nam, int LoaiBS,string DonViID)
        {
            return dal.GetAll_BSQ_LanhDao(Nam,  LoaiBS,DonViID);
        }
        public List<BSQ_BoSungDonVi> GetAll_BSQ_BoSungDonVi(int Nam,  int LoaiBS,string DonViID)
        {
            return dal.GetAll_BSQ_BoSungDonVi(Nam, LoaiBS,DonViID);
        }
        public List<BSQ_BangThongTin> GetAll_BSQ_BangThongTin(int Nam,  int LoaiBS,string DonViID)
        {
            return dal.GetAll_BSQ_BangThongTin(Nam,  LoaiBS,DonViID);
        }
        public bool Update_BSQ_PhanNguonDV_BoSung( int Nam, int LoaiBS, string DonViID, string Type, decimal Value)
        {
            return dal.Update_BSQ_PhanNguonDV_BoSung( Nam, LoaiBS, DonViID, Type, Value);
        }
        public bool Update_BSQ_BangThongTin( int Nam, int NhanSuID, int LoaiBS, string DonViID, string Type, decimal Value)
        {
            return dal.Update_BSQ_BangThongTin( Nam, NhanSuID, LoaiBS, DonViID, Type, Value);
        }
        public bool Update_BSQ_sOtAIkHOAN( int Nam, int NhanSuID, int LoaiBS, string SoTK)
        {
            return dal.Update_BSQ_sOtAIkHOAN( Nam, NhanSuID, LoaiBS, SoTK);
        }
        public bool Update_BSQ_BoSungDonVi( int Nam, int LoaiBS, string DonViID, string Type, decimal Value)
        {
            return dal.Update_BSQ_BoSungDonVi( Nam, LoaiBS, DonViID, Type, Value);
        }
        public bool Update_BSQ_LanhDao_BoSung( int Nam, int LoaiBS, int NhanSuID, string Type, decimal Value)
        {
            return dal.Update_BSQ_LanhDao_BoSung( Nam, LoaiBS, NhanSuID, Type, Value);
        }
        public Ouput TinhLuong_DeleteBoSungQuy(int Nam, int LoaiBS)
        {
            return dal.TinhLuong_DeleteBoSungQuy( Nam, LoaiBS);
        }
        public List<BSQ_LuongKHTamUng> GetAll_BSQ_LuongKHTamUng(int Nam)
        {
            return dal.GetAll_BSQ_LuongKHTamUng(Nam);
        }
        public bool Update_LuongKHTamUng(int Nam, int NhanSuID, decimal LuongKH, bool IsActive)
        {
            return dal.Update_LuongKHTamUng(Nam, NhanSuID, LuongKH,IsActive);
        }
        public List<BSQ_LanhDao> GetAll_LanhDao(int Nam)
        {
            return dal.GetAll_LanhDao(Nam);
        }
        public bool Insert_LuongKH(int Nam, int NhanSuID)
        {
            return dal.Insert_LuongKH(Nam, NhanSuID);
        }
        public bool Delete_LuongKH(int Nam, int NhanSuID)
        {
            return dal.Delete_LuongKH(Nam, NhanSuID);
        }
        public int UpLuongBS(string NgayCK, string UserName)
        {
            return dal.UpLuongBS(NgayCK, UserName);
        }
        public DataTable GetTenBS()
        {
            return dal.GetTenBS();
        }
        public bool TinhLuongBoSung(decimal nambs, string diengiai, string ngayck, decimal thangck, decimal namck, string username)

        {
            return dal.TinhLuongBoSung(nambs, diengiai, ngayck, thangck, namck, username);
        }
        public DataTable TinhLuongKH_Fiber(int Thang, int Nam, string Type, decimal SoTien,string LoaiDV)
        {
            return dal.TinhLuongKH_Fiber(Thang, Nam, Type, SoTien,LoaiDV);
        }
    }
}

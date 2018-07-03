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
    public class ChotSoBLL
    {
        ChotSoDAL dal = new ChotSoDAL();
        public List<DM_DonVi> Select_ByDonViCha(string donviid)
        {
            return dal.Select_ByDonViCha(donviid);
        }
        public List<DM_BangChotSo> GetByBangChot(decimal thang, decimal nam, string donviId)
        {
            return dal.GetByBangChot(thang, nam, donviId);
        }
        public DataTable GetListChotso(decimal thang, decimal nam, string donviId)
        {
            return dal.GetListChotso(thang, nam, donviId);
        }
        public DataTable GetListChotso_BangID(decimal thang, decimal nam, string donviId, string BangID)
        {
            return dal.GetListChotso_BangID(thang, nam, donviId, BangID);
        }
        public bool CapnhatBangChotSo(decimal Nam, decimal Thang, string BangID, string DonViID, int TinhTrang, string USERNAME)
        {
            return dal.CapnhatBangChotSo(Nam, Thang, BangID, DonViID, TinhTrang, USERNAME);
        }
        public List<ChotSoBS> GetList_ChotSoBS(int Nam)
        {
            return dal.GetList_ChotSoBS(Nam);
        }
        public Ouput Tuyen_Check_ChotSoBS(int Nam, int LoaiBS)
        {
            return dal.Tuyen_Check_ChotSoBS(Nam, LoaiBS);
        }
        public Ouput Tuyen_Update_ChotSoBS(int Nam, int LoaiBS,string Username)
        {
            return dal.Tuyen_Update_ChotSoBS(Nam, LoaiBS,Username);
        }
    }
}

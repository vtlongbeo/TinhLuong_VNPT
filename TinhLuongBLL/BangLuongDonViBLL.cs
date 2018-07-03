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
  public  class BangLuongDonViBLL
    {
        BangLuongDonViDAL dal = new BangLuongDonViDAL();
        public DataTable GetBangLuongDonVi(string IDDonVi, decimal thang, decimal nam)
        {
            return dal.GetBangLuongDonVi(IDDonVi, thang, nam);
        }
        public List<BangLuong> SelectByField(string fieldName, object value)
        {
            return dal.SelectByField(fieldName, value);
        }
        public DataTable GetBangLuongDonViByNhanSu(string IDNhanSu, decimal thang, decimal nam)
        {
            return dal.GetBangLuongDonViByNhanSu(IDNhanSu, thang, nam);
        }
        public List<DM_DonVi> SelectByDonVi(string IDDonVi)
        {
            return dal.SelectByDonVi(IDDonVi);
        }
        public int Update_BangLuongDonVi(BangLuong businessObject)
        {
            return dal.Update_BangLuongDonVi(businessObject);
        }
        public int Insert_BangLuongDonVi(BangLuong businessObject)
        {
            return dal.Insert_BangLuongDonVi(businessObject);
        }
    }
}

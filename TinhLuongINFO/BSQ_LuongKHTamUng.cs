using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
  public class BSQ_LuongKHTamUng
    {
        private int nam;
        private int nhanSuID;
        private string donViID;
        private string hoTen;
        private string tenDonVi;
        private decimal luongKHTamUng;
        private bool isActive;

        public int Nam
        {
            get
            {
                return nam;
            }

            set
            {
                nam = value;
            }
        }

        public int NhanSuID
        {
            get
            {
                return nhanSuID;
            }

            set
            {
                nhanSuID = value;
            }
        }

        public string DonViID
        {
            get
            {
                return donViID;
            }

            set
            {
                donViID = value;
            }
        }

        public string HoTen
        {
            get
            {
                return hoTen;
            }

            set
            {
                hoTen = value;
            }
        }

        public string TenDonVi
        {
            get
            {
                return tenDonVi;
            }

            set
            {
                tenDonVi = value;
            }
        }

        public decimal LuongKHTamUng
        {
            get
            {
                return luongKHTamUng;
            }

            set
            {
                luongKHTamUng = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
            }
        }
    }
}

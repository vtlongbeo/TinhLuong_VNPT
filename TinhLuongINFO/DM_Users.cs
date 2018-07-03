using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
   public class DM_Users
    {
        private int iD;
        private string userName;
        private int nhanSuID;
        private string donViID;
        private string ghiChu;
        private bool isActive;
        private string tenDonVi;
        private string passWord;
        private string hoTen;
        private string groupID;
        private string avartar;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
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

        public string GhiChu
        {
            get
            {
                return ghiChu;
            }

            set
            {
                ghiChu = value;
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

        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
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

        public string PassWord
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
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

        public string GroupID
        {
            get
            {
                return groupID;
            }

            set
            {
                groupID = value;
            }
        }

        public string Avartar
        {
            get
            {
                return avartar;
            }

            set
            {
                avartar = value;
            }
        }
    }
}

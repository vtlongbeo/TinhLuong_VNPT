using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
   public class BangLuongLapDat
    {
        private decimal nam;
        private decimal thang;
        private string nhanSuID;
        private decimal lUONGKKLD;
        private decimal lUONGSPITTER;
        private decimal lUONGPHLD;
        private string userName;
        private DateTime ngayUp;

        public decimal Nam
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

        public decimal Thang
        {
            get
            {
                return thang;
            }

            set
            {
                thang = value;
            }
        }

        public string NhanSuID
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

        public decimal LUONGKKLD
        {
            get
            {
                return lUONGKKLD;
            }

            set
            {
                lUONGKKLD = value;
            }
        }

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

        public DateTime NgayUp
        {
            get
            {
                return ngayUp;
            }

            set
            {
                ngayUp = value;
            }
        }

        public decimal LUONGSPITTER
        {
            get
            {
                return lUONGSPITTER;
            }

            set
            {
                lUONGSPITTER = value;
            }
        }

        public decimal LUONGPHLD
        {
            get
            {
                return lUONGPHLD;
            }

            set
            {
                lUONGPHLD = value;
            }
        }
    }
}

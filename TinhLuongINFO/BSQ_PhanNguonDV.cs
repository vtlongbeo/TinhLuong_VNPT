using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
    public class BSQ_PhanNguonDV
    {
        private int sTT;
        private int quy;
        private int nam;
        private string donViID;
        private decimal p3Quy;
        private decimal diemP1;
        private decimal p1P3;
        private decimal nguonP3DV;
        private decimal giamTruQuyLuong;
        private decimal nguonP3SauGiamTru;
        private decimal nguonBoSung;
        private int loaiBS;
        private string tenDonVi;

        public int Quy
        {
            get
            {
                return quy;
            }

            set
            {
                quy = value;
            }
        }

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

        public decimal P3Quy
        {
            get
            {
                return p3Quy;
            }

            set
            {
                p3Quy = value;
            }
        }

        public decimal DiemP1
        {
            get
            {
                return diemP1;
            }

            set
            {
                diemP1 = value;
            }
        }

        public decimal P1P3
        {
            get
            {
                return p1P3;
            }

            set
            {
                p1P3 = value;
            }
        }

        public decimal NguonP3DV
        {
            get
            {
                return nguonP3DV;
            }

            set
            {
                nguonP3DV = value;
            }
        }

        public decimal GiamTruQuyLuong
        {
            get
            {
                return giamTruQuyLuong;
            }

            set
            {
                giamTruQuyLuong = value;
            }
        }

        public decimal NguonP3SauGiamTru
        {
            get
            {
                return nguonP3SauGiamTru;
            }

            set
            {
                nguonP3SauGiamTru = value;
            }
        }

        public decimal NguonBoSung
        {
            get
            {
                return nguonBoSung;
            }

            set
            {
                nguonBoSung = value;
            }
        }

        public int LoaiBS
        {
            get
            {
                return loaiBS;
            }

            set
            {
                loaiBS = value;
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

        public int STT
        {
            get
            {
                return sTT;
            }

            set
            {
                sTT = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
    public class BSQ_BoSungDonVi
    {
        private int sTT;
        private int quy;
        private int nam;
        private string donViChaID;
        private string donViID;
        private decimal p1;
        private decimal p1P2;
        private decimal p3;
        private decimal nguonP3BoSung;
        private int loaiBS;
        private string tenDonVi;

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

        public string DonViChaID
        {
            get
            {
                return donViChaID;
            }

            set
            {
                donViChaID = value;
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

        public decimal P1
        {
            get
            {
                return p1;
            }

            set
            {
                p1 = value;
            }
        }

        public decimal P1P2
        {
            get
            {
                return p1P2;
            }

            set
            {
                p1P2 = value;
            }
        }

        public decimal P3
        {
            get
            {
                return p3;
            }

            set
            {
                p3 = value;
            }
        }

        public decimal NguonP3BoSung
        {
            get
            {
                return nguonP3BoSung;
            }

            set
            {
                nguonP3BoSung = value;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
    public class BSQ_LanhDao
    {
        private int nam;
        private string hoTen;
        private int sTT;
        private int quy;
        private string donViID;
        private string donViChaID;
        private int nhanSuID;
        private decimal tienLuongKHP3Quy;
        private decimal p3DonVi;
        private decimal giamTruTienP3Quy;
        private decimal boSungP3Quy;
        private int loaiBS;

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

        public decimal TienLuongKHP3Quy
        {
            get
            {
                return tienLuongKHP3Quy;
            }

            set
            {
                tienLuongKHP3Quy = value;
            }
        }

        public decimal P3DonVi
        {
            get
            {
                return p3DonVi;
            }

            set
            {
                p3DonVi = value;
            }
        }

        public decimal GiamTruTienP3Quy
        {
            get
            {
                return giamTruTienP3Quy;
            }

            set
            {
                giamTruTienP3Quy = value;
            }
        }

        public decimal BoSungP3Quy
        {
            get
            {
                return boSungP3Quy;
            }

            set
            {
                boSungP3Quy = value;
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
    }
}

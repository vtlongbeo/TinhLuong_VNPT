using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
    public class BangLuong
    {
        private decimal nam;
        private decimal thang;
        private decimal sTT;
        private string nhanSuID;
        private string donViID;
        private string tenDonVi;
        private string hoTen;
        private decimal hSCB;
        private decimal hSPC;
        private decimal hSLCD;
        private decimal hSCN;
        private decimal hSBP;
        private decimal cSTL;
        private decimal hSGD;
        private decimal tYLEHT_GD;
        private decimal dONGIA;
        private decimal nC;
        private decimal nP;
        private decimal nR;
        private decimal nTS;
        private decimal tNC;
        private string dTHU;
        private decimal ODINH;
        private decimal aDSL;
        private decimal mYTV;
        private decimal? _fTTH;
        private decimal? _dIDONG;
        private decimal? _LUONGDTTK;
        //private decimal? _lUONGCS;
        private decimal? _lUONGTT;
        private decimal? _lUONGGT;
        private decimal? _lUONGTN;
        // private decimal? _lUONGKTP;
        //private decimal? _lUONGGT_CLNC;
        //private decimal? _lUONGTT_CLNC;
        // private decimal? _lUONGPHEP;
        //private decimal? _lUONGKHOANPHEP;
        private decimal lUONGPTTB;
        private decimal lUONGKDTM;
        private decimal lUONGKHAC;
        private decimal tAMUNG;
        private string userName;
        private DateTime ngayUp;
        private decimal bHXH;
        private decimal bHYT;
        private decimal bHTN;
        private decimal kHOANNOP;
        private decimal tONGLUONG;
        private decimal tHUCLINH;
        private decimal cODINH;

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

        public decimal STT
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

        public decimal HSCB
        {
            get
            {
                return hSCB;
            }

            set
            {
                hSCB = value;
            }
        }

        public decimal HSPC
        {
            get
            {
                return hSPC;
            }

            set
            {
                hSPC = value;
            }
        }

        public decimal HSLCD
        {
            get
            {
                return hSLCD;
            }

            set
            {
                hSLCD = value;
            }
        }

        public decimal HSCN
        {
            get
            {
                return hSCN;
            }

            set
            {
                hSCN = value;
            }
        }

        public decimal HSBP
        {
            get
            {
                return hSBP;
            }

            set
            {
                hSBP = value;
            }
        }

        public decimal CSTL
        {
            get
            {
                return cSTL;
            }

            set
            {
                cSTL = value;
            }
        }

        public decimal HSGD
        {
            get
            {
                return hSGD;
            }

            set
            {
                hSGD = value;
            }
        }

        public decimal TYLEHT_GD
        {
            get
            {
                return tYLEHT_GD;
            }

            set
            {
                tYLEHT_GD = value;
            }
        }

        public decimal DONGIA
        {
            get
            {
                return dONGIA;
            }

            set
            {
                dONGIA = value;
            }
        }

        public decimal NC
        {
            get
            {
                return nC;
            }

            set
            {
                nC = value;
            }
        }

        public decimal NP
        {
            get
            {
                return nP;
            }

            set
            {
                nP = value;
            }
        }

        public decimal NR
        {
            get
            {
                return nR;
            }

            set
            {
                nR = value;
            }
        }

        public decimal NTS
        {
            get
            {
                return nTS;
            }

            set
            {
                nTS = value;
            }
        }

        public decimal TNC
        {
            get
            {
                return tNC;
            }

            set
            {
                tNC = value;
            }
        }

        public string DTHU
        {
            get
            {
                return dTHU;
            }

            set
            {
                dTHU = value;
            }
        }

        public decimal ODINH1
        {
            get
            {
                return ODINH;
            }

            set
            {
                ODINH = value;
            }
        }

        public decimal ADSL
        {
            get
            {
                return aDSL;
            }

            set
            {
                aDSL = value;
            }
        }

        public decimal MYTV
        {
            get
            {
                return mYTV;
            }

            set
            {
                mYTV = value;
            }
        }

        public decimal? FTTH
        {
            get
            {
                return _fTTH;
            }

            set
            {
                _fTTH = value;
            }
        }

        public decimal? DIDONG
        {
            get
            {
                return _dIDONG;
            }

            set
            {
                _dIDONG = value;
            }
        }

        public decimal? LUONGDTTK
        {
            get
            {
                return _LUONGDTTK;
            }

            set
            {
                _LUONGDTTK = value;
            }
        }

        public decimal? LUONGTT
        {
            get
            {
                return _lUONGTT;
            }

            set
            {
                _lUONGTT = value;
            }
        }

        public decimal? LUONGGT
        {
            get
            {
                return _lUONGGT;
            }

            set
            {
                _lUONGGT = value;
            }
        }

        public decimal? LUONGTN
        {
            get
            {
                return _lUONGTN;
            }

            set
            {
                _lUONGTN = value;
            }
        }

        public decimal LUONGPTTB
        {
            get
            {
                return lUONGPTTB;
            }

            set
            {
                lUONGPTTB = value;
            }
        }

        public decimal LUONGKDTM
        {
            get
            {
                return lUONGKDTM;
            }

            set
            {
                lUONGKDTM = value;
            }
        }

        public decimal LUONGKHAC
        {
            get
            {
                return lUONGKHAC;
            }

            set
            {
                lUONGKHAC = value;
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

        public decimal BHXH
        {
            get
            {
                return bHXH;
            }

            set
            {
                bHXH = value;
            }
        }

        public decimal BHYT
        {
            get
            {
                return bHYT;
            }

            set
            {
                bHYT = value;
            }
        }

        public decimal BHTN
        {
            get
            {
                return bHTN;
            }

            set
            {
                bHTN = value;
            }
        }

        public decimal KHOANNOP
        {
            get
            {
                return kHOANNOP;
            }

            set
            {
                kHOANNOP = value;
            }
        }

        public decimal TONGLUONG
        {
            get
            {
                return tONGLUONG;
            }

            set
            {
                tONGLUONG = value;
            }
        }

        public decimal THUCLINH
        {
            get
            {
                return tHUCLINH;
            }

            set
            {
                tHUCLINH = value;
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

        public decimal TAMUNG
        {
            get
            {
                return tAMUNG;
            }

            set
            {
                tAMUNG = value;
            }
        }

        public decimal CODINH
        {
            get
            {
                return cODINH;
            }

            set
            {
                cODINH = value;
            }
        }
    }
}

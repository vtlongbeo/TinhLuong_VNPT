using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
    public class THLuong
    {
        private int _NhanVienID;
        private int _SoLuong;
        private int _Luong;

        public int NhanVienID
        {
            get
            {
                return _NhanVienID;
            }

            set
            {
                _NhanVienID = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return _SoLuong;
            }

            set
            {
                _SoLuong = value;
            }
        }

        public int Luong
        {
            get
            {
                return _Luong;
            }

            set
            {
                _Luong = value;
            }
        }
    }
}

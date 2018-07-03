using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
   public class NhanVien
    {
        private int nhansuID;
        private string hoten;

        public int NhansuID
        {
            get
            {
                return nhansuID;
            }

            set
            {
                nhansuID = value;
            }
        }

        public string Hoten
        {
            get
            {
                return hoten;
            }

            set
            {
                hoten = value;
            }
        }
    }
}

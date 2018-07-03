using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
  public  class ChotSoBS
    {
        private int nam;
        private int loaiBS;
        private int sTT;
        private bool active;
        private string dienGiai;
        private string userName;

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

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        public string DienGiai
        {
            get
            {
                return dienGiai;
            }

            set
            {
                dienGiai = value;
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
    }
}

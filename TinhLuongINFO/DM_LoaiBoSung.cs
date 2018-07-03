using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
   public class DM_LoaiBoSung
    {
        private int loai;
        private string dienGiai;
        private int loaiBS;
        public int Loai
        {
            get
            {
                return loai;
            }

            set
            {
                loai = value;
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
    }
}

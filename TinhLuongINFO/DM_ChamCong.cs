using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
    public class DM_ChamCong
    {
        private string maChamCong;
        private string tenChamCong;

        public string MaChamCong
        {
            get
            {
                return maChamCong;
            }

            set
            {
                maChamCong = value;
            }
        }

        public string TenChamCong
        {
            get
            {
                return tenChamCong;
            }

            set
            {
                tenChamCong = value;
            }
        }
    }
}

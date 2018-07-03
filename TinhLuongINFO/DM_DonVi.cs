using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
   public class DM_DonVi
    {
        private string donViID;
        private string donViChaID;
        private string tenDonVi;
        private int level;

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

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }
    }
}

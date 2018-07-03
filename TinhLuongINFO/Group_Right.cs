using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
   public class Group_Right
    {
        private string groupID;
        private string rightID;
        private string rightName;

        public string GroupID
        {
            get
            {
                return groupID;
            }

            set
            {
                groupID = value;
            }
        }

        public string RightID
        {
            get
            {
                return rightID;
            }

            set
            {
                rightID = value;
            }
        }

        public string RightName
        {
            get
            {
                return rightName;
            }

            set
            {
                rightName = value;
            }
        }
    }
}

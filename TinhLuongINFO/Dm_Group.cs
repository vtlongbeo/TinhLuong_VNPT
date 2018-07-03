using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
   public class Dm_Group
    {
        private int groupID;
        private string groupName;

        public int GroupID
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

        public string GroupName
        {
            get
            {
                return groupName;
            }

            set
            {
                groupName = value;
            }
        }
    }
}

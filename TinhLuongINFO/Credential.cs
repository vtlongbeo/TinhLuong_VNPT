using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{

        public class Credential
        {
            private string groupID;
            private string rightID;

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
        }
    
}

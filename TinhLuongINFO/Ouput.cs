using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
    public class Ouput
    {
        private string outputString;
        private int outputCode;

        public string OutputString
        {
            get
            {
                return outputString;
            }

            set
            {
                outputString = value;
            }
        }

        public int OutputCode
        {
            get
            {
                return outputCode;
            }

            set
            {
                outputCode = value;
            }
        }
    }
}

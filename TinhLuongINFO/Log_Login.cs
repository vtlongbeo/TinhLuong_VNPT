using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
  public  class Log_Login
    {
        private string userName;
        private string loginTimeConvert;
        private string ipUser;
        private string action;
        private string mode;

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

        public string LoginTimeConvert
        {
            get
            {
                return loginTimeConvert;
            }

            set
            {
                loginTimeConvert = value;
            }
        }

        public string IpUser
        {
            get
            {
                return ipUser;
            }

            set
            {
                ipUser = value;
            }
        }

        public string Action
        {
            get
            {
                return action;
            }

            set
            {
                action = value;
            }
        }

        public string Mode
        {
            get
            {
                return mode;
            }

            set
            {
                mode = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSoftware
{
    class UserIdentify
    {
        private static UserIdentify instance;
        public static UserIdentify Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserIdentify();
                }
                return instance;
            }
        }

        


        public UserIdentify()
        {
            UserIdentify.instance = this;
        }
    }

}

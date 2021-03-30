using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Class1
    {
        
        private static string b = "";
        private static string c = "";

        public  string a
        {
            get { return b; }
            set { b = value; }
        }

        public string z
        {
            get { return c;  }
            set { c = value; }
        }


    }
}

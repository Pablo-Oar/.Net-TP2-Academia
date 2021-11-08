using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class MetodosUtiles
    {
        public static bool validaNotEmpty(string[] ar)
        {
            bool valid = true;
            foreach(string i in ar)
            {
                if (i == "" || i == null) {
                    valid = false;
                }
            }
            return valid;
        }
    }
}

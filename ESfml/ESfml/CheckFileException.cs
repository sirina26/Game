using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithMac
{
    public class CheckFileException: Exception
    {
        public CheckFileException() :
            base("This kind of object is not supported by the Factory")
        {
        }
    }
}

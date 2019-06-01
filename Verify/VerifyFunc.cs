using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verify
{
    class VerifyFunc
    {
        public bool Verify(string text, int num)
        { 
            if (Int32.Parse(text) == num)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

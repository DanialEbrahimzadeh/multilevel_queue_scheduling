using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU
{
    class _Queue  
    {
        string[] myElement=new string[100];

        public _Queue()
        {
            counter = -1;
        }

        public int counter = -1;

        public bool ISEMPTY()
        {
            if (counter == -1)
                return true;
            return false;
        }
        public void ADD(string a1)
        {
            if (ISEMPTY())
            {
                myElement[0] = a1;
            }
            else
            {
                for (int count = counter + 1; count != 0; count--)
                {
                    myElement[count] = myElement[count - 1];
                }
                myElement[0] = a1;
            }
            counter++;
        }
        public string DELETE()
        {
            string r="" ;
            if (!ISEMPTY())
            {
                r = myElement[counter];
                counter--;
                return r;
            }
            return r;
        }
    }
}

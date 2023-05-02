using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU
{
    public class _Element
    {
        public int A1;
        public int A2;
        public string A3;
        public bool Is_End;
        public bool Is_1End;
        public bool Is_2End;
        public int sub;
        public _Element()
        {
            A1 = A2 = 0;
            A3 = "";
            sub = 0;
            Is_1End = false;
            Is_2End = false;
            Is_End = false;
        }
        public _Element(int a1, int a2, string a3)
        {
            A1 = a1;
            A2 = a2;
            A3 = a3;
        }
    }
}

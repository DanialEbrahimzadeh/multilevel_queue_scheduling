using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU
{


    public struct _Node
    {
        int _ProcessIputTime;
        int _ProcessExecuteTime;
        string _ProcessName;
        _Node* _Next;
    }

    class _LinkedList
    {
        unsafe _Node* _First = new _Node();
        unsafe _Node* _Last = new _Node();

        public int _CountOfElements = 0;

        public void _AddFirst(_Node n)
        {
            n._Next = _First;
            _First = n;
            _CountOfElements++;
        }
        public _Node _DeleteLast()
        {
            //_Node temp = _First;
            for (_Node temp = _First; temp._Next; temp = temp._Next)
                _CountOfElements--;
        }
        public void _Sort()
        {

        }
        public bool _IsEmpty()
        {
            if (_CountOfElements == 0)
                return true;
            return false;
        }
    }
}

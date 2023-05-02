using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU
{
    public class _QueueOfInputs
    {
        public _QueueOfInputs()
        {
            counter = -1;
            for (int i = 0; i < 100; i++)
                Element[i] = new _Element();
        }

        _Element[] Element = new _Element[100];
        public int counter = -1;
        

        public bool ISEMPTY()
        {
            if (counter == -1)
                return true;
            return false;
        }
        public void ADD(_Element E)
        {
            if (ISEMPTY())
            {
                Element[0] = E;
            }
            else
            {
                for (int count = counter+1; count != 0; count--)
                {
                    Element[count].A1 = Element[count - 1].A1;
                    Element[count].A2 = Element[count - 1].A2;
                    Element[count].A3 = Element[count - 1].A3;
                    Element[count].Is_1End = Element[count - 1].Is_1End;
                    Element[count].Is_2End = Element[count - 1].Is_2End;
                    Element[count].sub = Element[count - 1].sub;  
                }
                Element[0] = E;
            }
            counter++;
        }
        public _Element DELETE()
        {
            _Element Result = new _Element();
            if (!ISEMPTY())
            {     
                Result.A1 = Element[counter].A1;
                Result.A2 = Element[counter].A2;
                Result.A3 = Element[counter].A3;
                Result.Is_1End = Element[counter].Is_1End;
                Result.Is_2End = Element[counter].Is_2End;
                Result.Is_End = Element[counter].Is_End;
                Result.sub = Element[counter].sub;
                counter--;
            }
            return Result;
        }
        public void SORT()
        {
            int i = 0;

            if (counter >= 1)
            {
                for (int j = 1; j <= counter; j++)
                {
                    int Key1 = Element[j].A1;
                    int Key2 = Element[j].A2;
                    string Key3 = Element[j].A3;
                    int key4 = Element[j].sub;
                    bool key5 = Element[j].Is_1End;
                    bool key6 = Element[j].Is_2End;
                    bool key7 = Element[j].Is_End;
                    i = j - 1;
                    while (i >= 0 && Element[i].A1 < Key1)
                    {
                        Element[i + 1].A1 = Element[i].A1;
                        Element[i + 1].A2 = Element[i].A2;
                        Element[i + 1].A3 = Element[i].A3;
                        Element[i + 1].sub = Element[i].sub;
                        Element[i + 1].Is_1End = Element[i].Is_1End;
                        Element[i + 1].Is_2End = Element[i].Is_2End;
                        Element[i + 1].Is_End = Element[i].Is_End;

                        i--;
                    }
                    Element[i + 1].A1 = Key1;
                    Element[i + 1].A2 = Key2;
                    Element[i + 1].A3 = Key3;
                    Element[i + 1].sub = key4;
                    Element[i + 1].Is_1End = key5;
                    Element[i + 1].Is_2End = key6;
                    Element[i + 1].Is_End = key7;
                }
            }
        }

        public void COPY_TO(_QueueOfInputs q)
        {
            for (int i = 0; i <= q.counter; i++)
            {
                Element[i].A1 = q.Element[i].A1;
                Element[i].A2 = q.Element[i].A2;
                Element[i].A3 = q.Element[i].A3;
                Element[i].Is_1End = q.Element[i].Is_1End;
                Element[i].Is_2End = q.Element[i].Is_2End;
                Element[i].sub = q.Element[i].sub;
            }
            counter = q.counter;
                 
        }
    }
}

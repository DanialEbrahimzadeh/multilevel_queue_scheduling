using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CPU
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            label3.Text = "Time Quantum 1 is " + _TimeQuantum1 + " second.";
            label4.Text = "Time Quantum 2 is " + _TimeQuantum2 + " second.";

            _names.Add("Process");
            _dataArray.Add(str1);

            _names.Add("Time Of Input Process");
            _dataArray.Add(str2);

            _names.Add("Time Of Execute Process");
            _dataArray.Add(str3);

            dataGridView1.DataSource = GetResultsTable1();
        }

        static public string[] STR0 = new string[100];
        static public string[] STR1 = new string[100];
        static public string[] STR2 = new string[100];
        static public string[] STR3 = new string[100];

        static public string[] str1 = new string[100];
        static public string[] str2 = new string[100];
        static public string[] str3 = new string[100];

        public int _TimeQuantum1 = 4;
        public int _TimeQuantum2 = 8;

        public _QueueOfInputs myQueueOfInputs = new _QueueOfInputs();
        public _QueueOfInputs myQueueOfInputsOfTable = new _QueueOfInputs();

        Error myError = new Error();
        List<string> _names = new List<string>();
        List<string[]> _dataArray = new List<string[]>();
        DataTable d = new DataTable();

        public DataTable GetResultsTable1()
        {
            // Loop through all process names.
            for (int i = 0; i < 3; i++)
            {
                // The current process name.
                string name = this._names[i];

                // Add the program name to our columns.
                d.Columns.Add(name);

                // Add all of the memory numbers to an object list.
                List<object> objectNumbers = new List<object>();

                // Put every column's numbers in this List.
                foreach (String str in this._dataArray[i])
                {
                    if (str != null)
                        objectNumbers.Add((object)str);
                }

                // Keep adding rows until we have enough.
                while (d.Rows.Count < objectNumbers.Count)
                {
                    d.Rows.Add();
                }

                // Add each item to the cells in the column.
                for (int a = 0; a < objectNumbers.Count; a++)
                {
                    d.Rows[a][i] = objectNumbers[a];
                }
            }
            return d;
        }

        private void EXITbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CHANGETIMESbtn_Click(object sender, EventArgs e)
        {
            string Str1 = textBox1.Text.Trim();
            string Str2 = textBox2.Text.Trim();
            int Num1;
            int Num2;
            bool isNum1 = int.TryParse(Str1, out Num1);
            bool isNum2 = int.TryParse(Str2, out Num2);
            if (isNum1 && isNum2)
            {
                if (_TimeQuantum1 < _TimeQuantum2)
                {
                    _TimeQuantum1 = int.Parse(textBox1.Text);
                    _TimeQuantum2 = int.Parse(textBox2.Text);
                    label3.Text = "Time Quantum 1 is " + _TimeQuantum1 + " second.";
                    label4.Text = "Time Quantum 2 is " + _TimeQuantum2 + " second.";
                }
                else
                {
                    myError.errortext = "TimeQuantum1 should be litle than TimeQuantum2!";
                    myError.ShowDialog();
                }
            }
            else
            {
                myError.errortext = "Your input times are not valid!";
                myError.ShowDialog();
            }
        }

        private void READFILEbtn_Click(object sender, EventArgs e)
        {
            string line="";
            string FileName="";
            openFileDialog1.Filter = "Text Files|*.txt;";
            openFileDialog1.FileName = "";
            DialogResult dr = openFileDialog1.ShowDialog();
            myQueueOfInputs = new _QueueOfInputs();
            myQueueOfInputsOfTable = new _QueueOfInputs();

            FirstValueArrayString();

            if (dr == DialogResult.OK)
                FileName = openFileDialog1.FileName;

            if (FileName != "")
            {
                FileStream myFile = new FileStream(FileName,FileMode.Open,FileAccess.Read);
                StreamReader Reader_myFile = new StreamReader(myFile);
                int numberOfWords = 0;
                while (Reader_myFile.Peek()!=-1)
                {
                    line = Reader_myFile.ReadLine();
                    string[] words = line.Split();
                    string[] value = new string[3];
                   
                    foreach (string word in words)
                    {
                        value[numberOfWords] = word;
                        numberOfWords++;
                    }
                    _Element e1 = new _Element(int.Parse(value[1]), int.Parse(value[2]), value[0]);
                    myQueueOfInputs.ADD(e1);
                    numberOfWords = 0;
                }

                myFile.Close();
                Reader_myFile.Close();

            }
            myQueueOfInputs.SORT();
            myQueueOfInputsOfTable.COPY_TO(myQueueOfInputs);
        }

        private void READTABLEbtn_Click(object sender, EventArgs e)
        {
            READbtn.Enabled = true;
            CLEARbtn.Enabled = true;
            dataGridView1.Enabled = true;
        }
        
        private void READbtn_Click(object sender, EventArgs e)
        {
            myQueueOfInputs = new _QueueOfInputs();
            myQueueOfInputsOfTable = new _QueueOfInputs();
            FirstValueArrayString();
            for (int rows = 0; rows < dataGridView1.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count - 1; col++)
                {
                    if (dataGridView1.Rows[rows].Cells[col].Value.ToString() != "")
                    {
                        string value3 = dataGridView1.Rows[rows].Cells[col++].Value.ToString();
                        int value1 = int.Parse(dataGridView1.Rows[rows].Cells[col++].Value.ToString());
                        int value2 = int.Parse(dataGridView1.Rows[rows].Cells[col].Value.ToString());
                        _Element e1 = new _Element(value1, value2, value3);
                        myQueueOfInputs.ADD(e1);
                    }
                }
            }
            myQueueOfInputs.SORT();
            myQueueOfInputsOfTable.COPY_TO(myQueueOfInputs);
        }

        private void SHOWRESULTbtn_Click(object sender, EventArgs e)
        {
            if (myQueueOfInputs.ISEMPTY())
            {
                myError.errortext = "You have input any data.";
                myError.ShowDialog();
            }
            else
            {
                myShow();
                CPU(myQueueOfInputs, _TimeQuantum1, _TimeQuantum2);

                READbtn.Enabled = false;
                CLEARbtn.Enabled = false;
                dataGridView1.Enabled = false;

                Form2 myForm2 = new Form2();
                myForm2.ShowDialog();

                do
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        try
                        {
                            dataGridView1.Rows.Remove(row);
                        }
                        catch (Exception) { }
                    }
                } while (dataGridView1.Rows.Count > 1);

            }
        }

        public void myShow()
        {
            for (int i = 0; !myQueueOfInputsOfTable.ISEMPTY(); i++)
            {
                _Element temp = myQueueOfInputsOfTable.DELETE();
                if (temp != null)
                {
                    str1[i] = temp.A3;
                    str2[i] = temp.A1.ToString();
                    str3[i] = temp.A2.ToString();
                }
            }
        }

        static public void FirstValueArrayString()
        {
            for (int i = 0; i < 100; i++)
                STR0[i] = "";
            for (int i = 0; i < 100; i++)
                STR1[i] = "";
            for (int i = 0; i < 100; i++)
                STR2[i] = "";
            for (int i = 0; i < 100; i++)
                STR3[i] = "";

            for (int i = 0; i < 100; i++)
                str1[i] = "";
            for (int i = 0; i < 100; i++)
                str2[i] = "";
            for (int i = 0; i < 100; i++)
                str3[i] = "";
        }

        void CPU(_QueueOfInputs input , int t1, int t2)
        {
            _Queue line1=new _Queue();
            _Queue line2=new _Queue();
            _Queue line3=new _Queue();
            int j=0;
            _QueueOfInputs temp=new _QueueOfInputs();
            _QueueOfInputs temp1=new _QueueOfInputs();
            _QueueOfInputs temp2=new _QueueOfInputs();
            _Element E1 = new _Element();
            _Element E2 = new _Element();
            _Element E3 = new _Element();
            _Element E4 = new _Element();

            _Element element=new _Element();
            element=input.DELETE();
            for(j=0;j<element.A1;j++)
            {
                line1.ADD("-");
                line2.ADD("-");
                line3.ADD("-");
            }

            input.ADD(element);
            input.SORT();

            while(true)
            {
                E1 = input.DELETE();
                if (E1.Is_1End == false)
                {
                    if (E1.A1 <= j)
                    {
                        if (E1.A2 <= t1)
                        {
                            for (int i = 0; i < E1.A2; i++)
                            {
                                line1.ADD(E1.A3);
                                line2.ADD("-");
                                line3.ADD("-");
                            }
                            j = j + E1.A2;
                            E1.Is_1End = true;
                            E1.Is_2End = true;
                            E1.Is_End = true;
                        }  //end of if
                        if (E1.A2 > t1)
                        {
                            for (int i = 0; i < t1; i++)
                            {
                                line1.ADD(E1.A3);
                                line2.ADD("-");
                                line3.ADD("-");
                            }
                            j = j + t1;
                            E1.Is_1End = true;
                            E1.sub = E1.A2 - t1;
                            temp.ADD(E1);
                            E1 = null;
                        }  //end of if
                    }
                    else 
                    {
                        input.ADD(E1);
                        input.SORT();
                    }
                }  //end of if
                if (input.ISEMPTY())
                {
                    if (temp.ISEMPTY())
                    {
                        if (!temp1.ISEMPTY())
                        {
                            while (!temp1.ISEMPTY())
                            {
                                E2 = temp1.DELETE();
                                for (int i = 0; i < E2.sub; i++)
                                {
                                    line1.ADD("-");
                                    line2.ADD("-");
                                    line3.ADD(E2.A3);
                                }
                                j += E2.sub;
                                E2.Is_1End = true;
                                E2.Is_2End = true;
                                E2.Is_End = true;
                            }
                        }
                    }
                    else
                    {
                        while (!temp.ISEMPTY())
                        { 
                            E2=temp.DELETE();
                            if (E2.sub <= t2)
                            {
                                for (int i = 0; i < E2.sub; i++)
                                {
                                    line1.ADD("-");
                                    line2.ADD(E2.A3);
                                    line3.ADD("-");
                                }
                                j = j + E2.sub;
                                E2.Is_2End = true;
                                E2.Is_End = true;
                            } //end of if
                            if (E2.sub > t2)
                            {
                                for (int i = 0; i < t2; i++)
                                {
                                    line1.ADD("-");
                                    line2.ADD(E2.A3);
                                    line3.ADD("-");
                                }
                                j = j + t2;
                                E2.Is_2End = true;
                                E2.sub = E2.sub - t2;
                                temp1.ADD(E2);
                            } //end of if
                        }//end of while
                        if (!temp1.ISEMPTY())
                        {
                            while (!temp1.ISEMPTY())
                            {
                                E2 = temp1.DELETE();
                                for (int i = 0; i < E2.sub; i++)
                                {
                                    line1.ADD("-");
                                    line2.ADD("-");
                                    line3.ADD(E2.A3);
                                }
                                j = j + E2.sub;
                                E2.Is_End = true;        
                            }//end of while
                        }
                    }
                }
                else
                {
                    E3 = input.DELETE();
                    if (E3.A1 <= j)
                    {
                        input.ADD(E3);
                        input.SORT();
                        continue;   
                    }
                    else
                    {
                        if (temp.ISEMPTY())
                        {
                            if (temp1.ISEMPTY())
                            {
                                for (int i = 0; j < E3.A1; i++,j++)
                                {
                                    line1.ADD("-");
                                    line2.ADD("-");
                                    line3.ADD("-");
                                }
                                input.ADD(E3);
                                input.SORT();
                                continue;
                            }
                            else
                            {
                                while (j <= E3.A1 && !temp1.ISEMPTY())
                                {
                                    E4=temp1.DELETE();
                                    for (int i = 0; i < E4.sub; i++)
                                    {
                                        line1.ADD("-");
                                        line2.ADD("-");
                                        line3.ADD(E4.A3);
                                    }  
                                    j = j + E4.sub;
                                    E4.Is_End = true;                
                                }
                                if (temp1.ISEMPTY())
                                {
                                    if (E3.A1 <= j)
                                    {
                                        input.ADD(E3);
                                        input.SORT();
                                        continue;
                                    }
                                    else
                                    {
                                        for (int i = 0; j < E3.A1; i++,j++)
                                        {
                                            line1.ADD("-");
                                            line2.ADD("-");
                                            line3.ADD("-");        
                                        }
                                        input.ADD(E3);
                                        input.SORT();
                                        continue;
                                    }
                                }
                                else
                                {
                                    input.ADD(E3);
                                    input.SORT();
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            while (j <= E3.A1 && !temp.ISEMPTY())
                            {
                                E4 = temp.DELETE();
                                if (E4.sub <= t2)
                                {
                                    for (int i = 0; i < E4.sub; i++)
                                    {
                                        line1.ADD("-");
                                        line2.ADD(E4.A3);
                                        line3.ADD("-");
                                    }
                                    j = j + E4.sub;
                                    E4.Is_2End = true;
                                    E4.Is_End = true;
                                } //end of if
                                if (E4.sub > t2)
                                {
                                    for (int i = 0; i < t2; i++)
                                    {
                                        line1.ADD("-");
                                        line2.ADD(E4.A3);
                                        line3.ADD("-");
                                    }
                                    j = j + t2;
                                    E4.Is_2End = true;
                                    E4.sub = E4.sub - t2;
                                    temp1.ADD(E4);
                                } //end of if
                            }
                            if (temp.ISEMPTY())
                            {
                                if (E3.A1 <= j)
                                {
                                    input.ADD(E3);
                                    input.SORT();
                                    continue;
                                }
                                else
                                {
                                    if (temp1.ISEMPTY())
                                    {
                                        for (int i = 0; j < E3.A1; i++, j++)
                                        {
                                            line1.ADD("-");
                                            line2.ADD("-");
                                            line3.ADD("-");
                                        }
                                        input.ADD(E3);
                                        input.SORT();
                                        continue;
                                    }
                                    else
                                    {
                                        while (j <= E3.A1 && !temp1.ISEMPTY())
                                        {
                                            E4 = temp1.DELETE();
                                            for (int i = 0; i < E4.sub; i++)
                                            {     
                                                line1.ADD("-");
                                                line2.ADD("-");
                                                line3.ADD(E4.A3);        
                                            }
                                            j = j + E4.sub;
                                            E4.Is_End = true;
                                        }
                                        if (temp1.ISEMPTY())
                                        {
                                            if (E3.A1 <= j)
                                            {
                                                input.ADD(E3);
                                                input.SORT();
                                                continue;
                                            }
                                            else
                                            {
                                                for (int i = 0; j < E3.A1; i++, j++)
                                                {

                                                    line1.ADD("-");
                                                    line2.ADD("-");
                                                    line3.ADD("-");        
                                                }
                                                input.ADD(E3);
                                                input.SORT();
                                                continue;
                                            }
                                        }
                                        else 
                                        {
                                            input.ADD(E3);
                                            input.SORT();
                                            continue;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                input.ADD(E3);
                                input.SORT();
                                continue;
                            }
                        }
                    }
                }
                
                if (temp.ISEMPTY() && temp1.ISEMPTY()  && input.ISEMPTY())
                {
                    break;
                }
            }   //end of while

            string str;
            for (int a = 0; a<j; a++)
            {
                STR0[a] = a.ToString();
            }
            for (int a = 0; !line1.ISEMPTY(); a++)
            {
                str = line1.DELETE();
                if (str != "")
                {
                    STR1[a] = str;
                }
            }
            for (int a = 0; !line2.ISEMPTY(); a++)
            {
                str = line2.DELETE();
                if (str != "")
                {
                    STR2[a] = str;
                }
            }
            for (int a = 0; !line3.ISEMPTY(); a++)
            {
                str = line3.DELETE();
                if (str != "")
                {
                    STR3[a] = str;
                }
            }
            
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            READbtn.Enabled = false;
            dataGridView1.Enabled = false;
        }

        private void CLEARbtn_Click(object sender, EventArgs e)
        {
            do
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    try
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                    catch (Exception) { }
                }
            } while (dataGridView1.Rows.Count > 1);
        }

    }
}


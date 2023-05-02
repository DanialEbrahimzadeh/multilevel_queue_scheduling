using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
namespace CPU
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
           

            _names.Add("Process");
            _dataArray.Add(Form1.str1);

            _names.Add("Time Of Input Process");
            _dataArray.Add(Form1.str2);

            _names.Add("Time Of Execute Process");
            _dataArray.Add(Form1.str3);

            names.Add("Time (second)");
            dataArray.Add(Form1.STR0);

            names.Add("Queue1");
            dataArray.Add(Form1.STR1);

            names.Add("Queue2");
            dataArray.Add(Form1.STR2);

            names.Add("Queue3");
            dataArray.Add(Form1.STR3);

            dataGridView1.DataSource = GetResultsTable();
            dataGridView2.DataSource = GetResultsTable2();
        }

        List<string> _names = new List<string>();
        List<string[]> _dataArray = new List<string[]>();
        DataTable d = new DataTable();
        public DataTable GetResultsTable()
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
                    if (str!="")
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

        private void OKbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        List<string> names = new List<string>();
        List<string[]> dataArray = new List<string[]>();
        DataTable d2 = new DataTable();
        public DataTable GetResultsTable2()
        {
            // Loop through all process names.
            for (int i = 0; i < 4; i++)
            {
                // The current process name.
                string name = this.names[i];

                // Add the program name to our columns.
                d2.Columns.Add(name);

                // Add all of the memory numbers to an object list.
                List<object> objectNumbers = new List<object>();

                // Put every column's numbers in this List.
                foreach (String str in this.dataArray[i])
                {
                    if (str != "")
                        objectNumbers.Add((object)str);
                }

                // Keep adding rows until we have enough.
                while (d2.Rows.Count < objectNumbers.Count)
                {
                    d2.Rows.Add();
                }

                // Add each item to the cells in the column.
                for (int a = 0; a < objectNumbers.Count; a++)
                {
                    d2.Rows[a][i] = objectNumbers[a];
                }
            }
            return d2;
        }

        public Color ColorFunction(int ColorNumber)
        {
            switch (ColorNumber % 100)
            {
                case 0:
                    return Color.DarkOrange;
                case 1:
                    return Color.DeepPink;
                case 2:
                    return Color.DeepSkyBlue;
                case 3:
                    return Color.Fuchsia;
                case 4:
                    return Color.Gold;
                case 5:
                    return Color.GreenYellow;
                case 6:
                    return Color.Red;
                case 7:
                    return Color.Cyan;
                case 8:
                    return Color.Yellow;
                case 9:
                    return Color.YellowGreen;
                case 10:
                    return Color.Brown;
                case 11:
                    return Color.LightSteelBlue;
                case 12:
                    return Color.Plum;
                case 13:
                    return Color.PowderBlue;
                case 14:
                    return Color.Chocolate;
                case 15:
                    return Color.Coral;
                case 16:
                    return Color.CornflowerBlue;
                case 17:
                    return Color.Cornsilk;
                case 18:
                    return Color.Crimson;
                case 19:
                    return Color.Gray;
                case 20:
                    return Color.DarkBlue;
                case 21:
                    return Color.DarkCyan;
                case 22:
                    return Color.DarkGoldenrod;
                case 23:
                    return Color.DarkGray;
                case 24:
                    return Color.DarkGreen;
                case 25:
                    return Color.DarkKhaki;
                case 26:
                    return Color.DarkMagenta;
                case 27:
                    return Color.DarkOliveGreen;
                case 28:
                    return Color.Silver;
                case 29:
                    return Color.DarkOrchid;
                case 30:
                    return Color.DarkRed;
                case 31:
                    return Color.DarkSalmon;
                case 32:
                    return Color.DarkSeaGreen;
                case 33:
                    return Color.DarkSlateBlue;
                case 34:
                    return Color.DeepPink;
                case 35:
                    return Color.DeepSkyBlue;
                case 36:
                    return Color.ForestGreen;
                case 37:
                    return Color.Fuchsia;
                case 38:
                    return Color.Gold;
                case 39:
                    return Color.GreenYellow;
                case 40:
                    return Color.HotPink;
                case 41:
                    return Color.Honeydew;
                case 42:
                    return Color.IndianRed;
                case 43:
                    return Color.Indigo;
                case 44:
                    return Color.LawnGreen;
                case 45:
                    return Color.LimeGreen;
                case 46:
                    return Color.Linen;
                case 47:
                    return Color.Magenta;
                case 48:
                    return Color.Maroon;
                case 49:
                    return Color.MintCream;
                case 50:
                    return Color.MistyRose;
                case 51:
                    return Color.Moccasin;
                case 52:
                    return Color.NavajoWhite;
                case 53:
                    return Color.Navy;
                case 54:
                    return Color.OldLace;
                case 55:
                    return Color.Olive;
                case 56:
                    return Color.Orange;
                case 57:
                    return Color.Orchid;
                case 58:
                    return Color.PaleGreen;
                case 59:
                    return Color.PaleTurquoise;
                case 60:
                    return Color.PaleVioletRed;
                case 61:
                    return Color.PapayaWhip;
                case 62:
                    return Color.PeachPuff;
                case 63:
                    return Color.Peru;
                case 64:
                    return Color.Pink;
                case 65:
                    return Color.Plum;
                case 66:
                    return Color.PowderBlue;
                case 67:
                    return Color.Purple;
                case 68:
                    return Color.Red;
                case 69:
                    return Color.RosyBrown;
                case 70:
                    return Color.RoyalBlue;
                case 71:
                    return Color.SaddleBrown;
                case 72:
                    return Color.Salmon;
                case 73:
                    return Color.SandyBrown;
                case 74:
                    return Color.SeaGreen;
                case 75:
                    return Color.Sienna;
                case 76:
                    return Color.Silver;
                case 77:
                    return Color.SkyBlue;
                case 78:
                    return Color.SlateGray;
                case 79:
                    return Color.SpringGreen;
                case 80:
                    return Color.SteelBlue;
                case 81:
                    return Color.Tan;
                case 82:
                    return Color.Teal;
                case 83:
                    return Color.Thistle;
                case 84:
                    return Color.Tomato;
                case 85:
                    return Color.Turquoise;
                case 86:
                    return Color.Violet;
                case 87:
                    return Color.Yellow;
                case 88:
                    return Color.YellowGreen;
                case 89:
                    return Color.ForestGreen;
                case 90:
                    return Color.Fuchsia;
                case 91:
                    return Color.Gold;
                case 92:
                    return Color.Gray;
                case 93:
                    return Color.HotPink;
                case 94:
                    return Color.Indigo;
                case 95:
                    return Color.Ivory;
                case 96:
                    return Color.LawnGreen;
                case 97:
                    return Color.LightCyan;
                case 98:
                    return Color.Maroon;
                default:
                    return Color.MintCream;

            }
        }

        private void SHOWbtn_Click(object sender, EventArgs e)
        {
            int numberOfRows = 0;
            int flag = 0;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                flag = 0;
                for (int j = 1; j < dataGridView2.ColumnCount; j++)
                {
                    if (dataGridView2.Rows[i].Cells[j].Value.ToString() != "-")
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                    numberOfRows++;
            }
            label4.Text = numberOfRows.ToString() + " (Second)";

            numberOfRows = dataGridView2.RowCount - 1;
            label2.Text = numberOfRows.ToString() + " (Second)";
            ShowSecondBySecond();          
        }

        void ShowSecondBySecond()
        {
            for (int k = 0; k < Form1.str1.Length; k++)
            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    dataGridView2.Rows[i].Cells[0].Style.BackColor = Color.White;
                    dataGridView2.Rows[i].Cells[0].Style.ForeColor = Color.Black;

                    for (int j = 1; j < dataGridView2.ColumnCount; j++)
                    {
                        if (dataGridView2.Rows[i].Cells[j].Value.ToString() == Form1.str1[k])
                        {
                            dataGridView2.Rows[i].Cells[j].Style.BackColor = ColorFunction(k);
                            dataGridView2.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                        }
                        if (dataGridView2.Rows[i].Cells[j].Value.ToString() == "-")
                        {
                            dataGridView2.Rows[i].Cells[j].Style.BackColor = Color.White;
                            dataGridView2.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                        }
                    }   
                }      
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "End Time Of Processes is :";
            label2.Text = "-";
            label3.Text = "Wasted Time Of Processes is :";
            label4.Text = "-";

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Style.BackColor = ColorFunction(i);
                dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                dataGridView1.Rows[i].Cells[0].Style.SelectionBackColor = ColorFunction(i);
            }
        }
    }
}

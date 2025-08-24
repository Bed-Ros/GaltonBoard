using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Вывод:";

            int orbs = (int)numericUpDown1.Value;
            int boxes = (int)numericUpDown2.Value;
            int[] value_box = new int[boxes];
            Random rand = new Random();
            int x=rand.Next(100);

            for (int i = 0; i < orbs; i++)
            {
                int polojenie = (((boxes*2)-1)/2)+1;
                for (int stroka = 0; stroka < boxes - 1;stroka++)
                {
                    x = (16807 * x) % 2147483645;
                    if ( x> 50) ++polojenie;
                    else --polojenie;
                }
                value_box[(polojenie/2)]++;
            }

            for(int i =0; i < boxes; i++)
            {
                label3.Text += " " + value_box[i];
            }
        }
    }
}

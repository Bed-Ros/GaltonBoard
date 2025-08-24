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
        public void draw_board()
        {
            //g.DrawRectangle(pen_black_5, 10, 10, 50, 50);
            //g.DrawRectangle(pen_white_5, 10, 10, 50, 50);
            //жердочка
            //g.DrawEllipse(pen_black_5, 10, 10, 15, 15);

            //начальная воронка
            g.DrawLine(pen_black_5, (400 / 2) - 60, 0, (400 / 2) - 10, 30);
            g.DrawLine(pen_black_5, (400 / 2) + 60, 0, (400 / 2) + 10, 30);

            //жердочки
            short r = 14;
            int mid = (pictureBox1.Width - r) / 2;
            int mid_glass = pictureBox1.Width / 2;

            g.DrawEllipse(pen_black_5, mid, 60, r, r);

            g.DrawEllipse(pen_black_5, mid - 30, 90, r, r);
            g.DrawEllipse(pen_black_5, mid + 30, 90, r, r);

            g.DrawEllipse(pen_black_5, mid, 120, r, r);
            g.DrawEllipse(pen_black_5, mid - 60, 120, r, r);
            g.DrawEllipse(pen_black_5, mid + 60, 120, r, r);

            g.DrawEllipse(pen_black_5, mid - 30, 150, r, r);
            g.DrawEllipse(pen_black_5, mid + 30, 150, r, r);
            g.DrawEllipse(pen_black_5, mid - 90, 150, r, r);
            g.DrawEllipse(pen_black_5, mid + 90, 150, r, r);

            g.DrawEllipse(pen_black_5, mid, 180, r, r);
            g.DrawEllipse(pen_black_5, mid - 60, 180, r, r);
            g.DrawEllipse(pen_black_5, mid + 60, 180, r, r);
            g.DrawEllipse(pen_black_5, mid - 120, 180, r, r);
            g.DrawEllipse(pen_black_5, mid + 120, 180, r, r);

            //стаканы
            g.DrawLine(pen_black_5, mid_glass, 180 + r, mid_glass, pictureBox1.Height);
            g.DrawLine(pen_black_5, mid_glass - 60, 180 + r, mid_glass - 60, pictureBox1.Height);
            g.DrawLine(pen_black_5, mid_glass + 60, 180 + r, mid_glass + 60, pictureBox1.Height);
            g.DrawLine(pen_black_5, mid_glass - 120, 180 + r, mid_glass - 120, pictureBox1.Height);
            g.DrawLine(pen_black_5, mid_glass + 120, 180 + r, mid_glass + 120, pictureBox1.Height);
            g.DrawLine(pen_black_5, mid_glass - 180, 180 + r, mid_glass - 180, pictureBox1.Height);
            g.DrawLine(pen_black_5, mid_glass + 180, 180 + r, mid_glass + 180, pictureBox1.Height);

            g.DrawLine(pen_black_5, mid_glass + 180, pictureBox1.Height, mid_glass - 180, pictureBox1.Height);
        }

        Pen pen_black_5;
        Pen pen_white_5;
        Pen pen_green_5;
        Graphics g;



        public Form1()
        {
            InitializeComponent();

            pen_black_5 = new Pen(Color.Black, 5);
            pen_white_5 = new Pen(Color.White, 5);
            pen_green_5 = new Pen(Color.Green, 5);
            g = Graphics.FromHwnd(pictureBox1.Handle);

            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            int orbs = (int)numericUpDown1.Value;
            int boxes = 6;
            int[] value_box = new int[boxes];
            Random rand = new Random();
            int rnd = rand.Next(100);

            for (int i = 0; i < orbs; i++)
            {
                int x= (pictureBox1.Width - 4) / 2; 
                int y=10;
                int d=4;
                int slp = (int)numericUpDown2.Value;

                g.DrawEllipse(pen_green_5, x, y, d, d);
                System.Threading.Thread.Sleep(slp);
                g.DrawEllipse(pen_white_5, x, y, d, d);
                System.Threading.Thread.Sleep(slp);
                y = 50;
                g.DrawEllipse(pen_green_5, x, y, d, d);
                System.Threading.Thread.Sleep(slp);

                int polojenie = (((boxes * 2) - 1) / 2) + 1;
                for (int stroka = 0; stroka < boxes-1; stroka++)
                {
                    g.DrawEllipse(pen_white_5, x, y, d, d);
                    rnd = (16807 * rnd) % 2147483645;
                    if (rnd >50)
                    {
                        x += 30;
                        ++polojenie;
                    }
                    else {
                        x -= 30;
                        --polojenie;
                    }
                    y += 30;
                    g.DrawEllipse(pen_green_5, x, y, d, d);
                    System.Threading.Thread.Sleep(slp);
                }
                g.DrawEllipse(pen_white_5, x, y, d, d);
                value_box[(polojenie / 2)]++;
                
                progressBar1.Value= value_box[0];
                progressBar1.Refresh();
                progressBar2.Value = value_box[1];
                progressBar2.Refresh();
                progressBar3.Value = value_box[2];
                progressBar3.Refresh();
                progressBar4.Value = value_box[3];
                progressBar4.Refresh();
                progressBar5.Value = value_box[4];
                progressBar5.Refresh();
                progressBar6.Value = value_box[5];
                progressBar6.Refresh();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            draw_board();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

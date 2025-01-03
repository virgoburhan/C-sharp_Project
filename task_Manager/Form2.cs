﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace task_manager2
{
    public partial class Form2 : Form
    {
        int x = 0;
        List<Point> cpu_pt = new List<Point>();
        List<Point> ram_pt = new List<Point>();
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 2;
            int cpu_val = (pictureBox1.Height * (int)Math.Round(CPU.NextValue())) / 100;
            int ram_val = (pictureBox2.Height * (int)Math.Round(RAM.NextValue())) / 100;

            cpu_pt.Add(new Point(x, pictureBox1.Height - cpu_val));
            ram_pt.Add(new Point(x, pictureBox2.Height - ram_val));
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (x > pictureBox1.Width || x > pictureBox2.Width)
            {
                x = 0;
                cpu_pt.Clear();
                ram_pt.Clear();
            }
            g.FillRectangle(new HatchBrush(HatchStyle.Cross, Color.Green), pictureBox1.ClientRectangle);
            if (cpu_pt.Count > 1)
                g.DrawLines(new Pen(new SolidBrush(Color.FromArgb(255, 0, 255, 100))), cpu_pt.ToArray());
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(new HatchBrush(HatchStyle.Cross, Color.Green), pictureBox1.ClientRectangle);
            if (ram_pt.Count > 1)
                g.DrawLines(new Pen(new SolidBrush(Color.FromArgb(255, 0, 255, 100))), ram_pt.ToArray());
        }
    }
}

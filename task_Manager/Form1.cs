using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace task_manager2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listAllProcess();
        }
        public void listAllProcess()
        {
            Process[] AllProcess = Process.GetProcesses();
            foreach (Process p in AllProcess)
            {
                try
                {
                    dataGridView1.Rows.Add(p.ProcessName, p.Id, p.Responding, p.StartTime.ToString());
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process p1 = Process.GetProcessById(Int32.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()));
            p1.Kill();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}

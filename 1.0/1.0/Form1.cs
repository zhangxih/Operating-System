using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._0
{
    public partial class Form1 : Form
    {
        PCB mark = new PCB("空");
        PCB markl = new PCB("空");
        PCB[] pcbs = new PCB[5];
        int[] times = new int[5];
        string queue;
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < 5; i++)
            {
                int j = i + 1;
                pcbs[i] = new PCB("Q" + j);
            }
            mark.nextpcb = pcbs[0];
            markl.nextpcb = pcbs[4];
            for (int i = 0; i < 4; i++)
            {
                pcbs[i].nextpcb = pcbs[i + 1];
            }
            pcbs[4].nextpcb = pcbs[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            queue = "";
            if (!int.TryParse(textBox1.Text, out times[0]))
            {
                MessageBox.Show("请输入进程需求的时间");
                return;
            }
            if (!int.TryParse(textBox2.Text, out times[1]))
            {
                MessageBox.Show("请输入进程需求的时间");
                return;
            }
            if (!int.TryParse(textBox3.Text, out times[2]))
            {
                MessageBox.Show("请输入进程需求的时间");
                return;
            }
            if (!int.TryParse(textBox4.Text, out times[3]))
            {
                MessageBox.Show("请输入进程需求的时间");
                return;
            }
            if (!int.TryParse(textBox5.Text, out times[4]))
            {
                MessageBox.Show("请输入进程需求的时间");
                return;
            }
            for(int i = 0; i < 5; i++)
            {
                pcbs[i].RequiredTime = times[i];
            }
            if (mark.nextpcb.status == 'E')
                RPCB.Text = "无";
            else
                RPCB.Text = mark.nextpcb.Name;
            while (mark.nextpcb != markl.nextpcb)
            {
                mark.nextpcb = mark.nextpcb.nextpcb;
                queue = queue + mark.nextpcb.Name + " ";
            }
            mark.nextpcb = mark.nextpcb.nextpcb;
            Queue.Text = queue;
            if (mark.nextpcb.Run())
            {
                mark.nextpcb = mark.nextpcb.nextpcb;
                markl.nextpcb.nextpcb = mark.nextpcb;
            }
            else
            {
                markl.nextpcb = mark.nextpcb;
                mark.nextpcb = mark.nextpcb.nextpcb;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }
    }


}

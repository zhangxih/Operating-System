using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._0
{
    public partial class Form1 : Form
    {
        List<Storage> storages = new List<Storage>();
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    storages.Add(new Storage(i,j));
                }
            }
            label.Text = Storage.Show(storages);
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

        private void RequestButton_Click(object sender, EventArgs e)
        {
            int nobyte = 100;
            int nobit = 100;
            foreach(Storage storage in storages)
            {
                if(storage.status == 0)
                {
                    nobyte = storage.numberOfByte;
                    nobit = storage.numberOfBit;
                    break;
                }
            }
            if (nobyte == 100 && nobit == 100)
            {
                MessageBox.Show("不存在空闲的存储空间！");
                return;
            }
            storages[8 * nobyte + nobit].status = 1;
            label1.Text = "柱面号：" + nobyte + "\r\n磁道号：" + nobit / 4 + "\r\n物理记录号：" + nobit % 4;
            label.Text = Storage.Show(storages);
        }

        private void ReleaseButton_Click(object sender, EventArgs e)
        {
            int n1, n2, n3;
            if (!int.TryParse(textBox1.Text, out n1))
            {
                MessageBox.Show("请输入柱面号！");
                return;
            }
            if (!int.TryParse(textBox2.Text, out n2))
            {
                MessageBox.Show("请输入磁道号！");
                return;
            }
            if (!int.TryParse(textBox3.Text, out n3))
            {
                MessageBox.Show("请输入物理记录号！");
                return;
            }
            if (n1>7||n2>1||n3>3)
            {
                MessageBox.Show("不存在该物理地址！");
                return;
            }
            if (storages[8*n1+4*n2+n3].status==0)
            {
                MessageBox.Show("该存储空间未存储信息！");
                return;
            }
            storages[8 * n1 + 4 * n2 + n3].status = 0;
            label.Text = Storage.Show(storages);
            label2.Text = "字节号：" + storages[8 * n1 + 4 * n2 + n3].numberOfByte + "\r\n位数：" + storages[8 * n1 + 4 * n2 + n3].numberOfBit;
        }
    }
}

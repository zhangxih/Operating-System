using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._0
{
    public partial class Form1 : Form
    {
        List<Storage> sto = new List<Storage>();
        List<Storage> stoed = new List<Storage>();
        int number = 0;
        bool[] space = new bool[128];
        public Form1()
        {
            InitializeComponent();
            sto = Storage.storages(space);
            DataBindingSource.DataSource = sto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int length;
            if (!int.TryParse(Request.Text, out length))
            {
                MessageBox.Show("请输入申请空间大小！");
                return;
            }
            int address = Storage.request(length, sto);
            if (address == 12345)
            {
                MessageBox.Show("主存空间不足！");
                return;
            }
            else
            {
                for (int i = address;i< address + length; i++)
                {
                    space[i] = true;
                }
                number++;
                stoed.Add(new Storage(number, address, length, true));
                sto = Storage.storages(space);
                DataBindingSource.DataSource = sto;
                DataBindingSource.ResetBindings(true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num;
            if (!int.TryParse(Release.Text, out num))
            {
                MessageBox.Show("请输入释放空间号码！");
                return;
            }
            if (number < num)
            {
                MessageBox.Show("还未申请此存储空间！");
                return;
            }
            if (!stoed[num - 1].allocated)
            {
                MessageBox.Show("此存储空间已经释放！");
                return;
            }
            else
            {
                stoed[num - 1].allocated = false;
                for (int i = stoed[num - 1].Address; i < stoed[num - 1].Address + stoed[num - 1].Length; i++)
                {
                    space[i] = false;
                }
                sto = Storage.storages(space);
                DataBindingSource.DataSource = sto;
                DataBindingSource.ResetBindings(true);
            }
        }
    }
}

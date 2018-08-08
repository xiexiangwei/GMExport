using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMExport
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        Point downPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & this.WindowState == FormWindowState.Normal)
            {
                downPoint = new Point(e.X, e.Y);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - downPoint.X,
                    this.Location.Y + e.Y - downPoint.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            mysqlhelper.GetInstance().ConfigByServer(0);
            mysqlhelper.GetInstance().init();
            MessageBox.Show("已选择外网测试服务器");
            this.Close();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mysqlhelper.GetInstance().ConfigByServer(1);
            mysqlhelper.GetInstance().init();
            MessageBox.Show("已选择外网正式服务器","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            mysqlhelper.GetInstance().ConfigByServer(2);
            mysqlhelper.GetInstance().init();
            MessageBox.Show("已选择内网测试服务器", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}

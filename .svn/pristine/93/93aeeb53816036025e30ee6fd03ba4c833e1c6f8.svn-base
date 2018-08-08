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
    public partial class ChangePwd : Form
    {
        public ChangePwd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (TBAccount.Text == "")
            {
                MessageBox.Show("请输入帐号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = true;
                return;
            }
            if (TBOldPassword.Text==  "")
            {
                MessageBox.Show("请输入旧密码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = true;
                return;
            }
            if (TBNewPassword.Text  == "")
            {
                MessageBox.Show("请输入新密码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = true;
                return;
            }
            string sql = string.Format("update Login.tb_gm set password='{0}' where account='{1}' and password='{2}'", TBNewPassword.Text, TBAccount.Text, TBOldPassword.Text);
            mysqlhelper.GetInstance().MysqlCommand(sql);
            MessageBox.Show("修改密码成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button1.Enabled = true;
        }
        // 移动窗体
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        // 窗体上鼠标按下时
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & this.WindowState == FormWindowState.Normal)
            {
                // 移动窗体
                this.Capture = false;
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}

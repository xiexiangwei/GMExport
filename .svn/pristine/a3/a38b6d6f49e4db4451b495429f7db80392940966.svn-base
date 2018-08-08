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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            BtnLogin.Enabled = false;
            if (TBAccount.Text == "")
            {
                MessageBox.Show("请输入帐号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnLogin.Enabled = true;
                return;
            }
            if (TBPwd.Text=="")
            {
                MessageBox.Show("请输入密码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnLogin.Enabled = true;
                return;
            }
            if (mysqlhelper.GetInstance().GetServerType() == -1)
            {
                MessageBox.Show("请选择要操作的服务器!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnLogin.Enabled = true;
                return;
            }
            string sql = string.Format("select * from `Login`.tb_gm where account='{0}' and password='{1}'", TBAccount.Text, TBPwd.Text);
            if(mysqlhelper.GetInstance().GetServerType() == 2)
            {
                sql = string.Format("select * from `lcl-login`.tb_gm where account='{0}' and password='{1}'", TBAccount.Text, TBPwd.Text);
            }
             
            DataSet res= mysqlhelper.GetInstance().MysqlQuery(sql);
            if (res.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("帐号或者密码错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnLogin.Enabled = true;
                return;
            }
            Main f = new Main(res.Tables[0].Rows[0][1].ToString(), Convert.ToInt32(res.Tables[0].Rows[0][3]));
            f.Show();
            BtnLogin.Enabled = true;
            this.Hide();
        }

        private void LKChangePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePwd f = new ChangePwd();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mysqlhelper.GetInstance().destory();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setting f = new Setting();
            f.ShowDialog();
        }       
       
    }
}

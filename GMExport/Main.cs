﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMExport
{
    public partial class Main : Form
    {
        string user;
        int permission;
        string server_ip = "";
        public Main(string _user, int _permission)
        {
            InitializeComponent();
            user = _user;
            permission = _permission;
            if (mysqlhelper.GetInstance().GetServerType() == 0)
            {
                server_ip = "123.206.229.210";
                label4.Text = "GM管理工具(外网测试服务器)";
            }
            else if (mysqlhelper.GetInstance().GetServerType() == 1)
            {
                server_ip = "111.231.102.63";
                label4.Text = "GM管理工具(外网正式服务器)";
                label4.ForeColor = Color.Red;
            }
            else if (mysqlhelper.GetInstance().GetServerType() == 2)
            {
                server_ip = "10.7.48.25";
                label4.Text = "GM管理工具(内网测试服务器)";
            }
            if (permission == 10) {
                this.button3.Enabled = false;
                this.button4.Enabled = false;
            }

            RegistrationOfDayRegister f = new RegistrationOfDayRegister();
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            this.Day_export_gb.Controls.Clear();
            this.Day_export_gb.Controls.Add(f);
            f.Show();
        }
        public delegate DataSet MysqlQueryDLG(string sql);

        private void Main_Load(object sender, EventArgs e)
        {
            TSLInfo.Text = string.Format("GM：{0} 权限：{1}", user, permission == 0 ? "一级" : "二级");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出程序?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                mysqlhelper.GetInstance().destory();
                System.Environment.Exit(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void button3_Click(object sender, EventArgs e)
        {
            NoticeTask f = new NoticeTask(server_ip);
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GameData f = new GameData();
            f.ShowDialog();
        }

        private void Configure_btn_Click(object sender, EventArgs e)
        {
            ChannelSwitch c = new ChannelSwitch(server_ip);
            c.ShowDialog();
        }
    }
}

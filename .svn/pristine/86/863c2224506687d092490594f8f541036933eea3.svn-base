using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMExport
{
    class mysqlhelper
    {

        private static mysqlhelper uniqueInstance;
        private SshClient ssClient;
        private mysqlhelper() { }
        public static mysqlhelper GetInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new mysqlhelper();
            }
            return uniqueInstance;
        }
        bool NeedSSH = true;//是否需要ssh
        string SSHHost = "111.231.102.63";     // SSH地址
        int SSHPort = 22;                      // SSH端口
        string SSHUser = "root";               // SSH用户名
        string SSHPassword = "xiexiangwei001"; // SSH密码
        static string sqlIPA = "127.0.0.1";           // 映射地址  实际上也可以写其它的   Linux上的MySql的my.cnf bind-address 可以设成0.0.0.0 或者不设置
        string sqlHost = "172.17.0.3";         // mysql安装的机器IP 也可以是内网IP 比如：192.168.1.20
        static uint sqlport = 33061;                  // 数据库端口及映射端口
        string sqlConn = "Database=mysql;Data Source=" + sqlIPA + ";Port=" + sqlport + ";User Id=root;Password=xiexiangwei001;CharSet=utf8";
        static MySqlConnection mysqlConn;      // mysql连接句柄
        int ServerType = -1;//服务器类型

        public int GetServerType()
        {   
            //获取服务器类型
            return ServerType;
        }

        public void ConfigByServer(int serverType)
        {
            ServerType = serverType;
            //根据服务器类型配置
            if (serverType == 0)
            { 
                //外网测试服务器
                NeedSSH = false;
                sqlHost = "123.206.229.210";       
                uint sqlport = 3306;
                sqlConn = "Database=mysql;Data Source=" + sqlHost + ";Port=" + sqlport + ";User Id=root;Password=Xiexiangwei123!;CharSet=utf8;";

            }
            else if (serverType == 1)
            {
                //外网正式服务器
                NeedSSH = true;
                SSHHost = "111.231.102.63";     
                SSHPort = 22;                     
                SSHUser = "root";              
                SSHPassword = "xiexiangwei001";
                sqlIPA = "127.0.0.1";          
                sqlHost = "172.17.0.3";       
                sqlport = 33061;
                sqlConn = "Database=mysql;Data Source=" + sqlIPA + ";Port=" + sqlport + ";User Id=root;Password=xiexiangwei001;CharSet=utf8;";
            }
            else if (serverType == 2)
            {
                //内网测试服务器
                NeedSSH = false;
                sqlHost = "123.206.229.210";
                uint sqlport = 3306;
                sqlConn = "Database=mysql;Data Source=" + sqlHost + ";Port=" + sqlport + ";User Id=root;Password=Xiexiangwei123!;CharSet=utf8;";
            }
        }


        public void init()
        {   
            destory();
            if (ssClient != null)
            {
                ssClient.Disconnect();
            }
            if (NeedSSH)
            {
                //初始化环境
                PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(SSHHost, SSHPort, SSHUser, SSHPassword);
                connectionInfo.Timeout = TimeSpan.FromSeconds(30);

                ssClient = new SshClient(connectionInfo);
                try
                {
                    ssClient.Connect();
                    if (!ssClient.IsConnected)
                    {
                        MessageBox.Show("SSH connect failed");
                    }
                    var portFwdL = new ForwardedPortLocal(sqlIPA, sqlport, sqlHost, sqlport); //映射到本地端口
                    ssClient.AddForwardedPort(portFwdL);
                    portFwdL.Start();
                    if (!ssClient.IsConnected)
                    {
                        MessageBox.Show("port forwarding failed");
                    }
                    mysqlConn = new MySqlConnection(sqlConn);

                    try
                    {
                        mysqlConn.Open();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                mysqlConn = new MySqlConnection(sqlConn);
                try
                {
                    mysqlConn.Open();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        public void destory()
        {
            try
            {
                if (mysqlConn != null)
                {
                    mysqlConn.Close();
                }
                if (!ssClient.IsConnected)
                {
                    ssClient.Disconnect();
                }
            }
            catch
            { }
        }

        public DataSet MysqlQuery(string sql)
        {   
            DataSet ds = new DataSet();
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
            myDataAdapter.SelectCommand = new MySqlCommand(sql, mysqlConn);
            try
            {
                myDataAdapter.Fill(ds);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return ds;
        }

        public void MysqlCommand(string sql)
        {
            MySqlCommand mysqlCommand = new MySqlCommand(sql, mysqlConn);
            try
            {
                mysqlCommand.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }      
        }

    }

}

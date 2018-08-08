using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMExport
{
    public partial class GameData : Form
    {
        private delegate void LoadDayPayData(int id, string date, string pay);
        LoadDayPayData loadDayPayData;

        private delegate void LoadDayNewData(int id, string date, string add);
        LoadDayNewData loadDayNewData;

        private delegate void LoadDayChallengeData(int id, string date, string dayUser, string times);
        LoadDayChallengeData loadDayChallengeData;

        private delegate void LoadDayMatchData(int id, string date, string dayUser, string times);
        LoadDayMatchData loadMatchData;

        private delegate void LoadDayInviteData(int id, string date, string count);
        LoadDayInviteData loadDayInviteData;

        private delegate void LoadDayWXLoginData(int id, string date, string unionID, string times);
        LoadDayWXLoginData loadDayWXLoginData;

        private delegate void LoadUserGoldData(int id, string date, string uid, string gold);
        LoadUserGoldData loadUserGoldData;

        private delegate void LoadUserRedPackData(int id, string uid, string name, string rpp, string rp);
        LoadUserRedPackData loadUserRedPackData;

        private delegate void LoadUserLevelData(int id, string date, string uid, string maxLevelID);
        LoadUserLevelData loadUserLevelData;

        private delegate void LoadUserADData(int id, string date, string uid, string times);
        LoadUserADData loadUserADData;

        private delegate void LoadDayPayUserCountData(int id, string date, string count);
        LoadDayPayUserCountData loadDayPayUserCountData;

        private delegate void LoadDayActiveUserData(int id, string date, string uid);
        LoadDayActiveUserData loadDayActiveUserData;

        private delegate void LoadDayOnlineUserCountData(int id, string date, string hour, string count);
        LoadDayOnlineUserCountData loadDayOnlineUserCountData;

        private delegate void LoadDayNewUserUidData(int id, string date, string uid);
        LoadDayNewUserUidData loadDayNewUserUidData;

        private delegate void LoadDayLoginData(int id, string date, string count);
        LoadDayLoginData loadDayLoginData;

        private delegate void LoadDailyCumulativeNumberOfUsersData(int id, string time, string total);
        LoadDailyCumulativeNumberOfUsersData loadDailyCumulativeNumberOfUsersData;

        private delegate void LoadDailyCheckoutStatisticsData(int id, string time, string level_id, string total_users, string total_into, string total_error, string avg_step);
        LoadDailyCheckoutStatisticsData loadDailyCheckoutStatisticsData;

        private delegate void LoadDailyPropsStatisticsData(int id, string time, string prop_id, string uses, string buys);
        LoadDailyPropsStatisticsData loadDailyPropsStatisticsData;

        //默认一页行数
        private int pageSize;
        //每页当前索引
        private int[] pageIndex;


        private DataSet myDataSet = new DataSet();
        public GameData()
        {
            InitializeComponent();
            pageSize = 100;
            pageIndex = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Control.CheckForIllegalCrossThreadCalls = false;
            loadDayPayData = new LoadDayPayData(LoadDayPayDataFunc);
            loadDayNewData = new LoadDayNewData(LoadDayNewDataFunc);
            loadDayChallengeData = new LoadDayChallengeData(LoadDayChallengeDataFunc);
            loadMatchData = new LoadDayMatchData(LoadMatchDataFunc);
            loadDayInviteData = new LoadDayInviteData(LoadDayInviteDataFunc);
            loadDayWXLoginData = new LoadDayWXLoginData(LoadDayWXLoginDataFunc);
            loadUserGoldData = new LoadUserGoldData(LoadUserGoldDataFunc);
            loadUserRedPackData = new LoadUserRedPackData(LoadUserRedPackDataFunc);
            loadUserLevelData = new LoadUserLevelData(LoadUserLevelDataFunc);
            loadUserADData = new LoadUserADData(LoadUseADDataFunc);
            loadDayPayUserCountData = new LoadDayPayUserCountData(LoadDayPayUserCountDataFunc);
            loadDayActiveUserData = new LoadDayActiveUserData(LoadDayActiveUserDataFunc);
            loadDayOnlineUserCountData = new LoadDayOnlineUserCountData(LoadDayOnlineUserCountDataFunc);
            loadDayNewUserUidData = new LoadDayNewUserUidData(LoadDayNewUserUidDataFunc);
            loadDayLoginData = new LoadDayLoginData(LoadDayLoginDataFunc);
            loadDailyCumulativeNumberOfUsersData = new LoadDailyCumulativeNumberOfUsersData(LoadDailyCumulativeNumberOfUsersDataFunc);
            loadDailyCheckoutStatisticsData = new LoadDailyCheckoutStatisticsData(LoadDailyCheckoutStatisticsDataFunc);
            loadDailyPropsStatisticsData = new LoadDailyPropsStatisticsData(LoadDailyPropsStatisticsDataFunc);
        }

        private void GameData_Load(object sender, EventArgs e)
        {
            lblState.Text = "游戏数据分析--正在查询,请稍后...";
            string 每日付费 = "SELECT time,SUM(total_fee)/100 FROM( SELECT DATE_FORMAT(insert_time,'%Y-%m-%d') as time ,total_fee FROM Game.tb_order WHERE state=1 and DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= insert_time ) as a GROUP BY time;";
            string 每日新增 = "SELECT time,count(uid) FROM( SELECT DATE_FORMAT(registertime,'%Y-%m-%d') as time , uid  FROM Login.tb_account where  DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= registertime GROUP BY  time,uid) AS a GROUP BY time;";
            string 每日挑战关卡 = "SELECT time,COUNT(DISTINCT uid),COUNT(uid) FROM( SELECT DATE_FORMAT(time,'%Y-%m-%d') as time ,uid  FROM Log.tb_challenge_log where DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= time GROUP BY  time) AS a GROUP BY time;";
            string 比赛 = "SELECT time,COUNT(DISTINCT uid),COUNT(uid) FROM( SELECT DATE_FORMAT(time,'%Y-%m-%d') as time ,uid  FROM Log.tb_user_prop_log WHERE way=28 and  DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= time GROUP BY  time) AS a GROUP BY time;";
            string 每日邀新 = "SELECT * FROM ( SELECT DATE_FORMAT(update_time,'%Y-%m-%d') as time ,COUNT(*) FROM Game.tb_share WHERE invite_uid!=0 AND source_uid!=0 and DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= update_time GROUP BY  time ) AS a GROUP BY time;";
            string 每日微信登陆 = "SELECT time,account,count(account) FROM (SELECT DATE_FORMAT(login_time,'%Y-%m-%d') as time,account FROM Log.tb_login_log WHERE partner=2 and DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= login_time) AS a GROUP BY time,account;";
            string 玩家金币 = "SELECT * FROM ( SELECT DATE_FORMAT(time,'%Y-%m-%d') as t,uid,left_num FROM Log.tb_user_prop_log WHERE prop_id=1000 and DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= time ORDER BY time DESC) AS a GROUP BY t,uid;";
            string 红包 = "SELECT uid,name,red_pack_pool,red_pack FROM Game.tb_user;";
            string 关卡 = "SELECT * FROM ( SELECT DATE_FORMAT(time,'%Y-%m-%d') as time , uid,MAX(level_id) FROM Log.tb_level_log where DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= time GROUP BY  time) AS a GROUP BY time,uid;";
            string 广告 = "SELECT time,uid,count(uid) FROM (SELECT DATE_FORMAT(cmdtime,'%Y-%m-%d') as time,uid FROM Log.tb_cmd_log WHERE cmd=2067 and  DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= cmdtime) AS a GROUP BY time,uid;";
            string 每日付费人数 = "SELECT time,COUNT(DISTINCT uid) FROM( SELECT DATE_FORMAT(insert_time,'%Y-%m-%d') as time ,uid FROM Game.tb_order WHERE state=1 and DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= insert_time ) as a GROUP BY time;";
            string 每日活跃玩家 = "SELECT time,uid FROM( SELECT DATE_FORMAT(login_time,'%Y-%m-%d') AS time , Log.tb_login_log.account,Login.tb_account.uid FROM Log.tb_login_log LEFT JOIN Login.tb_account ON Log.tb_login_log.account=Login.tb_account.account ) AS a GROUP BY time,uid;";
            string 每日分时在线人数 = "SELECT DATE_FORMAT(time,'%Y-%m-%d') as t,HOUR(time) as h,count FROM Game.tb_user_count where DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= time GROUP BY t,h ORDER BY time DESC;";
            string 每日新增用户uid = "SELECT time,uid FROM( SELECT DATE_FORMAT(registertime,'%Y-%m-%d') as time , uid  FROM Login.tb_account  where DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= registertime GROUP BY  time,uid) AS a GROUP BY time,uid;";
            string 每日登录 = "select DATE_FORMAT(login_time,'%Y-%m-%d') AS time,COUNT(1) from Log.tb_login_log where DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= login_time GROUP BY DATE_FORMAT(login_time,'%Y-%m-%d');";
            string 每日累计用户数 = "select a.date AS time,sum(b.num) AS total from (select DATE_FORMAT(registertime,'%Y-%m-%d') date,count(1) num from `Login`.tb_account GROUP BY DATE_FORMAT(registertime,'%Y-%m-%d')) a,(select DATE_FORMAT(registertime,'%Y-%m-%d') date,count(1) num from `Login`.tb_account GROUP BY DATE_FORMAT(registertime,'%Y-%m-%d')) b where a.date >= b.date group by a.date;";
            string 每日关卡统计 = "select DATE_FORMAT(time,'%Y-%m-%d') AS time,level_id, count(DISTINCT uid),count(1), count(if(result=1,true,null)), IFNULL(FORMAT(AVG(case when result=0 then step end),1),0) FROM Log.tb_level_log where DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= time GROUP BY DATE_FORMAT(time,'%Y-%m-%d'),level_id;";
            string 每日道具统计 = "select DATE_FORMAT(time,'%Y-%m-%d'), prop_id, count(if(type=1,true,null)), count(if(way=10,true,null)) from Log.tb_user_prop_log  where DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= time GROUP BY DATE_FORMAT(time,'%Y-%m-%d'),prop_id;";

            string sql = 每日付费 + 每日新增 + 每日挑战关卡 + 比赛 + 每日邀新 + 每日微信登陆 + 玩家金币 + 红包 + 关卡 + 广告 + 每日付费人数 + 每日活跃玩家 + 每日分时在线人数 + 每日新增用户uid + 每日登录 + 每日累计用户数 + 每日关卡统计 + 每日道具统计;
            Thread t1 = new Thread(() => GetAllData(new string[] { 每日付费, 每日新增, 每日挑战关卡, 比赛, 每日邀新, 每日微信登陆, 玩家金币, 红包, 关卡, 广告, 每日付费人数, 每日活跃玩家, 每日分时在线人数, 每日新增用户uid, 每日登录, 每日累计用户数, 每日关卡统计, 每日道具统计 }));
            t1.Start();
        }

        void GetAllData(string[] sqlArray)
        {
            GetGameData(sqlArray[0], 1);
            GetGameData(sqlArray[1], 2);
            GetGameData(sqlArray[2], 3);
            GetGameData(sqlArray[3], 4);
            GetGameData(sqlArray[4], 5);
            GetGameData(sqlArray[5], 6);
            GetGameData(sqlArray[6], 7);
            GetGameData(sqlArray[7], 8);
            GetGameData(sqlArray[8], 9);
            GetGameData(sqlArray[9], 10);
            GetGameData(sqlArray[10], 11);
            GetGameData(sqlArray[11], 12);
            GetGameData(sqlArray[12], 13);
            GetGameData(sqlArray[13], 14);
            GetGameData(sqlArray[14], 15);
            GetGameData(sqlArray[15], 16);
            GetGameData(sqlArray[16], 17);
            GetGameData(sqlArray[17], 18);
        }



        public delegate DataSet MysqlQueryDLG(string sql);
        void GetGameData(string sql, int type)
        {
            Console.WriteLine(string.Format("GetGameData() sql:{0} type:{1}", sql, type));
            MysqlQueryDLG mqd = new MysqlQueryDLG(mysqlhelper.GetInstance().MysqlQuery);
            IAsyncResult cookie = mqd.BeginInvoke(sql, null, null);
            DataSet ds = mqd.EndInvoke(cookie);
            DataTable t = ds.Tables[0].Copy();
            t.TableName = type.ToString();
            myDataSet.Tables.Add(t);
            this.Invoke((EventHandler)(delegate { lblState.Text = "游戏数据分析"; lblStatus.Text = string.Format("{0}/{1}", type, pageIndex.Length); }));
            switch (type)
            {   
                   
                case 1: new Thread(new ThreadStart(delegate { ThreadLoadPayData(ds.Tables[0]); })).Start(); break;
                case 2: new Thread(new ThreadStart(delegate { ThreadLoadDayNewData(ds.Tables[0]); })).Start(); break;
                case 3: new Thread(new ThreadStart(delegate { ThreadLoadDayChallengeData(ds.Tables[0]); })).Start(); break;
                case 4: new Thread(new ThreadStart(delegate { ThreadLoadMatchData(ds.Tables[0]); })).Start(); break;
                case 5: new Thread(new ThreadStart(delegate { ThreadLoadDayInviteData(ds.Tables[0]); })).Start(); break;
                case 6: new Thread(new ThreadStart(delegate { ThreadLoadDayWXLoginData(ds.Tables[0]); })).Start(); break;
                case 7: new Thread(new ThreadStart(delegate { ThreadLoadUserGoldData(ds.Tables[0]); })).Start(); break;
                case 8: new Thread(new ThreadStart(delegate { ThreadLoadUserRedPackData(ds.Tables[0]); })).Start(); break;
                case 9: new Thread(new ThreadStart(delegate { ThreadLoadUserLevelData(ds.Tables[0]); })).Start(); break;
                case 10: new Thread(new ThreadStart(delegate { ThreadLoadUseADData(ds.Tables[0]); })).Start(); break;
                case 11: new Thread(new ThreadStart(delegate { ThreadLoadDayPayUserCountData(ds.Tables[0]); })).Start(); break;
                case 12: new Thread(new ThreadStart(delegate { ThreadLoadDayActiveUserData(ds.Tables[0]); })).Start(); break;
                case 13: new Thread(new ThreadStart(delegate { ThreadLoadDayOnlineUserCountData(ds.Tables[0]); })).Start(); break;
                case 14: new Thread(new ThreadStart(delegate { ThreadLoadDayNewUserUidData(ds.Tables[0]); })).Start(); break;
                case 15: new Thread(new ThreadStart(delegate { ThreadLoadDayLoginData(ds.Tables[0]); })).Start(); break;
                case 16: new Thread(new ThreadStart(delegate { ThreadLoadDailyCumulativeNumberOfUsersData(ds.Tables[0]); })).Start(); break;
                case 17: new Thread(new ThreadStart(delegate { ThreadLoadDailyCheckoutStatisticsData(ds.Tables[0]); })).Start(); break;
                case 18: new Thread(new ThreadStart(delegate { ThreadLoadDailyPropsStatisticsData(ds.Tables[0]); })).Start(); break;
            }
        }


        //加载每日付费
        void LoadDayPayDataFunc(int id, string date, string pay)
        {
            int index = this.DayPayDGV.Rows.Add();
            this.DayPayDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayPayDGV.Rows[index].Cells[1].Value = date;
            this.DayPayDGV.Rows[index].Cells[2].Value = pay;
        }

        void ThreadLoadPayData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDayPayData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }

        //加载每日新增玩家
        void LoadDayNewDataFunc(int id, string date, string add)
        {
            int index = this.DayNewDGV.Rows.Add();
            this.DayNewDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayNewDGV.Rows[index].Cells[1].Value = date;
            this.DayNewDGV.Rows[index].Cells[2].Value = add;
        }

        void ThreadLoadDayNewData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDayNewData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }


        //加载每日挑战
        void LoadDayChallengeDataFunc(int id, string date, string dayUser, string times)
        {
            int index = this.DayChallengeDGV.Rows.Add();
            this.DayChallengeDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayChallengeDGV.Rows[index].Cells[1].Value = date;
            this.DayChallengeDGV.Rows[index].Cells[2].Value = dayUser;
            this.DayChallengeDGV.Rows[index].Cells[3].Value = times;
        }

        void ThreadLoadDayChallengeData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDayChallengeData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString(), t.Rows[n][2].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }

        //加载比赛
        void LoadMatchDataFunc(int id, string date, string dayUser, string times)
        {
            int index = this.DayMatchDGV.Rows.Add();
            this.DayMatchDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayMatchDGV.Rows[index].Cells[1].Value = date;
            this.DayMatchDGV.Rows[index].Cells[2].Value = dayUser;
            this.DayMatchDGV.Rows[index].Cells[3].Value = times;
        }

        void ThreadLoadMatchData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadMatchData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString(), t.Rows[n][2].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }


        //加载每日邀新
        void LoadDayInviteDataFunc(int id, string date, string count)
        {
            int index = this.DayInviteDGV.Rows.Add();
            this.DayInviteDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayInviteDGV.Rows[index].Cells[1].Value = date;
            this.DayInviteDGV.Rows[index].Cells[2].Value = count;
        }

        void ThreadLoadDayInviteData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDayInviteData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }

        //加载微信登陆
        void LoadDayWXLoginDataFunc(int id, string date, string unionID, string times)
        {
            int index = this.DayWXLoginDGV.Rows.Add();
            this.DayWXLoginDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayWXLoginDGV.Rows[index].Cells[1].Value = date;
            this.DayWXLoginDGV.Rows[index].Cells[2].Value = unionID;
            this.DayWXLoginDGV.Rows[index].Cells[3].Value = times;
        }
        void ThreadLoadDayWXLoginData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDayWXLoginData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString(), t.Rows[n][2].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }


        //加载玩家金币
        void LoadUserGoldDataFunc(int id, string date, string uid, string gold)
        {
            int index = this.DayGoldDGV.Rows.Add();
            this.DayGoldDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayGoldDGV.Rows[index].Cells[1].Value = date;
            this.DayGoldDGV.Rows[index].Cells[2].Value = uid;
            this.DayGoldDGV.Rows[index].Cells[3].Value = gold;
        }

        void ThreadLoadUserGoldData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadUserGoldData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString(), t.Rows[n][2].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }



        //加载玩家红包
        void LoadUserRedPackDataFunc(int id, string uid, string name, string rpp, string rp)
        {
            int index = this.UserRedPackDGV.Rows.Add();
            this.UserRedPackDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.UserRedPackDGV.Rows[index].Cells[1].Value = uid;
            this.UserRedPackDGV.Rows[index].Cells[2].Value = name;
            this.UserRedPackDGV.Rows[index].Cells[3].Value = rpp;
            this.UserRedPackDGV.Rows[index].Cells[4].Value = rp;
        }

        void ThreadLoadUserRedPackData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadUserRedPackData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString(), t.Rows[n][2].ToString(), t.Rows[n][3].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }


        //加载玩家关卡
        void LoadUserLevelDataFunc(int id, string date, string uid, string levelID)
        {
            int index = this.UserLevelDGV.Rows.Add();
            this.UserLevelDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.UserLevelDGV.Rows[index].Cells[1].Value = date;
            this.UserLevelDGV.Rows[index].Cells[2].Value = uid;
            this.UserLevelDGV.Rows[index].Cells[3].Value = levelID;
        }

        void ThreadLoadUserLevelData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadUserLevelData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString(), t.Rows[n][2].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }


        //加载玩家关卡
        void LoadUseADDataFunc(int id, string date, string uid, string times)
        {
            int index = this.UserADDGV.Rows.Add();
            this.UserADDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.UserADDGV.Rows[index].Cells[1].Value = date;
            this.UserADDGV.Rows[index].Cells[2].Value = uid;
            this.UserADDGV.Rows[index].Cells[3].Value = times;
        }

        void ThreadLoadUseADData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadUserADData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString(), t.Rows[n][2].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }

        //加载每日付费人数
        void LoadDayPayUserCountDataFunc(int id, string data, string count)
        {
            int index = this.DayPayUserCountDGV.Rows.Add();
            this.DayPayUserCountDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayPayUserCountDGV.Rows[index].Cells[1].Value = data;
            this.DayPayUserCountDGV.Rows[index].Cells[2].Value = count;
        }

        void ThreadLoadDayPayUserCountData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDayPayUserCountData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }

        //加载统计每日活跃玩家uid
        void LoadDayActiveUserDataFunc(int id, string data, string uid)
        {
            int index = this.DayActiveUserDGV.Rows.Add();
            this.DayActiveUserDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayActiveUserDGV.Rows[index].Cells[1].Value = data;
            this.DayActiveUserDGV.Rows[index].Cells[2].Value = uid;
        }

        void ThreadLoadDayActiveUserData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDayActiveUserData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }

        //加载每日分时在线人数
        void LoadDayOnlineUserCountDataFunc(int id, string data, string hour, string count)
        {
            int index = this.DayOnlineUserCountDGV.Rows.Add();
            this.DayOnlineUserCountDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayOnlineUserCountDGV.Rows[index].Cells[1].Value = data;
            this.DayOnlineUserCountDGV.Rows[index].Cells[2].Value = hour;
            this.DayOnlineUserCountDGV.Rows[index].Cells[3].Value = count;
        }

        void ThreadLoadDayOnlineUserCountData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDayOnlineUserCountData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString(), t.Rows[n][2].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }

        //加载每日分时在线人数
        void LoadDayNewUserUidDataFunc(int id, string data, string uid)
        {
            int index = this.DayNewUidDGV.Rows.Add();
            this.DayNewUidDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayNewUidDGV.Rows[index].Cells[1].Value = data;
            this.DayNewUidDGV.Rows[index].Cells[2].Value = uid;
        }

        void ThreadLoadDayNewUserUidData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDayNewUserUidData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }

        //加载每日登录次数
        void LoadDayLoginDataFunc(int id, string date, string count)
        {
            int index = this.DayLoginDGV.Rows.Add();
            this.DayLoginDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DayLoginDGV.Rows[index].Cells[1].Value = date;
            this.DayLoginDGV.Rows[index].Cells[2].Value = count;
        }

        void ThreadLoadDayLoginData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDayLoginData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }


        //加载每日累计用户数
        void LoadDailyCumulativeNumberOfUsersDataFunc(int id, string date, string total)
        {
            int index = this.DailyCumulativeNumberOfUsersDGV.Rows.Add();
            this.DailyCumulativeNumberOfUsersDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DailyCumulativeNumberOfUsersDGV.Rows[index].Cells[1].Value = date;
            this.DailyCumulativeNumberOfUsersDGV.Rows[index].Cells[2].Value = total;
        }

        void ThreadLoadDailyCumulativeNumberOfUsersData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDailyCumulativeNumberOfUsersData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }

        //加载每日关卡统计
        void LoadDailyCheckoutStatisticsDataFunc(int id, string time, string level_id, string total_users, string total_into, string total_error, string avg_step)
        {
            int index = this.DailyCheckoutStatisticsDGV.Rows.Add();
            this.DailyCheckoutStatisticsDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DailyCheckoutStatisticsDGV.Rows[index].Cells[1].Value = time;
            this.DailyCheckoutStatisticsDGV.Rows[index].Cells[2].Value = level_id;
            this.DailyCheckoutStatisticsDGV.Rows[index].Cells[3].Value = total_users;
            this.DailyCheckoutStatisticsDGV.Rows[index].Cells[4].Value = total_into;
            this.DailyCheckoutStatisticsDGV.Rows[index].Cells[5].Value = total_error;
            this.DailyCheckoutStatisticsDGV.Rows[index].Cells[6].Value = avg_step;
        }

        void ThreadLoadDailyCheckoutStatisticsData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDailyCheckoutStatisticsData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString(), t.Rows[n][2].ToString(), t.Rows[n][3].ToString(), t.Rows[n][4].ToString(), t.Rows[n][5].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }

        //加载每日道具统计
        void LoadDailyPropsStatisticsDataFunc(int id, string time, string prop_id, string uses, string buys)
        {
            int index = this.DailyPropsStatisticsDGV.Rows.Add();
            this.DailyPropsStatisticsDGV.Rows[index].Cells[0].Value = (id + 1).ToString();
            this.DailyPropsStatisticsDGV.Rows[index].Cells[1].Value = time;
            this.DailyPropsStatisticsDGV.Rows[index].Cells[2].Value = prop_id;
            this.DailyPropsStatisticsDGV.Rows[index].Cells[3].Value = uses;
            this.DailyPropsStatisticsDGV.Rows[index].Cells[4].Value = buys;
        }

        void ThreadLoadDailyPropsStatisticsData(DataTable t)
        {
            for (int n = 0; n < t.Rows.Count; n++)
            {
                if (IsDisposed || !IsHandleCreated) return;
                this.BeginInvoke(loadDailyPropsStatisticsData, n, t.Rows[n][0].ToString(), t.Rows[n][1].ToString(), t.Rows[n][2].ToString(), t.Rows[n][3].ToString());
                if (n >= pageSize - 1)
                {
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            //跳转到第一页
            if (myDataSet == null) return;
            //如果已经处于第一页则不需要处理
            if (pageIndex[mainTabPage.SelectedIndex] == 0) return;
            //找到当前所在tabpage的datagridview
            DataGridView dgv = null;
            foreach (Control ct in mainTabPage.SelectedTab.Controls)
            {
                if (ct.GetType().ToString() == "System.Windows.Forms.DataGridView")
                {
                    dgv = (System.Windows.Forms.DataGridView)ct; break;
                }
            }
            if (dgv == null) return;
            dgv.Rows.Clear();
            DataTable dt = myDataSet.Tables[mainTabPage.SelectedIndex];
            for (int n = 0; n < dt.Rows.Count; n++)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells[0].Value = (n + 1).ToString();
                for (int i = 1; i < dgv.ColumnCount; i++)
                {
                    dgv.Rows[index].Cells[i].Value = dt.Rows[n][i - 1];
                }
                if (n >= pageSize - 1) break;
            }
            pageIndex[mainTabPage.SelectedIndex] = 0;
            textBox1.Text = (pageIndex[mainTabPage.SelectedIndex] + 1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //跳转到上一页
            if (myDataSet == null) return;
            //如果已经处于第一页则不需要处理
            int curPage = pageIndex[mainTabPage.SelectedIndex];
            if (curPage == 0) return;
            //找到当前所在tabpage的datagridview
            DataGridView dgv = null;
            foreach (Control ct in mainTabPage.SelectedTab.Controls)
            {
                if (ct.GetType().ToString() == "System.Windows.Forms.DataGridView")
                {
                    dgv = (System.Windows.Forms.DataGridView)ct; break;
                }
            }
            if (dgv == null) return;
            DataTable dt = myDataSet.Tables[mainTabPage.SelectedIndex];
            int startIndex = (curPage - 1) * pageSize;
            if (dt.Rows.Count < startIndex) return;
            dgv.Rows.Clear();
            int c = 0;
            for (int n = startIndex; n < dt.Rows.Count; n++)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells[0].Value = (n + 1).ToString();
                for (int i = 1; i < dgv.ColumnCount; i++)
                {
                    dgv.Rows[index].Cells[i].Value = dt.Rows[n][i - 1];
                }
                if (c >= pageSize - 1) break;
                c += 1;
            }
            pageIndex[mainTabPage.SelectedIndex] = curPage - 1;
            textBox1.Text = (pageIndex[mainTabPage.SelectedIndex] + 1).ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //跳转到下一页
            if (myDataSet == null) return;
            int curPage = pageIndex[mainTabPage.SelectedIndex];

            //找到当前所在tabpage的datagridview
            DataGridView dgv = null;
            foreach (Control ct in mainTabPage.SelectedTab.Controls)
            {
                if (ct.GetType().ToString() == "System.Windows.Forms.DataGridView")
                {
                    dgv = (System.Windows.Forms.DataGridView)ct; break;
                }
            }
            if (dgv == null) return;
            DataTable dt = myDataSet.Tables[mainTabPage.SelectedIndex];
            int startIndex = (curPage + 1) * pageSize;
            if (dt.Rows.Count < startIndex) return;
            //如果已经处于最后一页则不需要处理
            if (curPage == dt.Rows.Count / pageSize) return;
            dgv.Rows.Clear();
            int c = 0;
            for (int n = startIndex; n < dt.Rows.Count; n++)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells[0].Value = (n + 1).ToString();
                for (int i = 1; i < dgv.ColumnCount; i++)
                {
                    dgv.Rows[index].Cells[i].Value = dt.Rows[n][i - 1];
                }
                if (c >= pageSize - 1) break;
                c += 1;
            }
            pageIndex[mainTabPage.SelectedIndex] = curPage + 1;
            textBox1.Text = (pageIndex[mainTabPage.SelectedIndex] + 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //跳转到最后一页
            if (myDataSet == null) return;
            int curPage = pageIndex[mainTabPage.SelectedIndex];
            //找到当前所在tabpage的datagridview
            DataGridView dgv = null;
            foreach (Control ct in mainTabPage.SelectedTab.Controls)
            {
                if (ct.GetType().ToString() == "System.Windows.Forms.DataGridView")
                {
                    dgv = (System.Windows.Forms.DataGridView)ct; break;
                }
            }
            if (dgv == null) return;

            DataTable dt = myDataSet.Tables[mainTabPage.SelectedIndex];
            //如果已经处于最后一页则不需要处理
            if (curPage == dt.Rows.Count / pageSize) return;
            int startIndex = dt.Rows.Count / pageSize * pageSize;
            dgv.Rows.Clear();
            int c = 0;
            for (int n = startIndex; n < dt.Rows.Count; n++)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells[0].Value = (n + 1).ToString();
                for (int i = 1; i < dgv.ColumnCount; i++)
                {
                    dgv.Rows[index].Cells[i].Value = dt.Rows[n][i - 1];
                }
                if (c >= pageSize - 1) break;
                c += 1;
            }
            pageIndex[mainTabPage.SelectedIndex] = dt.Rows.Count / pageSize;
            textBox1.Text = (pageIndex[mainTabPage.SelectedIndex] + 1).ToString();
        }

        private void mainTabPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = (pageIndex[mainTabPage.SelectedIndex] + 1).ToString();
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            //数据导出excel
            try
            {
                if (myDataSet == null || myDataSet.Tables.Count != pageIndex.Length)
                {
                    return;
                }
                btnToExcel.Enabled = false;

                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), DateTime.Now.ToString("yyyyMMddhhmmss"));
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日付费")), myDataSet.Tables[0], new string[] { "日期", "每日付费" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日新增用户数")), myDataSet.Tables[1], new string[] { "日期", "新增用户数量" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日挑战关卡")), myDataSet.Tables[2], new string[] { "日期", "今日参加人数", "今日参加总次数" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日比赛")), myDataSet.Tables[3], new string[] { "日期", "今日参赛人数", "今日参赛总次数" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日邀新")), myDataSet.Tables[4], new string[] { "日期", "今日邀新人数" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日微信登陆")), myDataSet.Tables[5], new string[] { "日期", "微信unionid", "今日微信登陆次数" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日玩家剩余金币")), myDataSet.Tables[6], new string[] { "日期", "玩家uid", "今日剩余金币" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "当前玩家红包数据")), myDataSet.Tables[7], new string[] { "玩家uid", "玩家昵称", "当前红包池", "当前红包" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日玩家最大关卡")), myDataSet.Tables[8], new string[] { "日期", "玩家uid", "今日最大关卡" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日玩家观看广告")), myDataSet.Tables[9], new string[] { "日期", "玩家uid", "今日观看广告次数" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日付费人数")), myDataSet.Tables[10], new string[] { "日期", "每日付费人数" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日活跃玩家uid")), myDataSet.Tables[11], new string[] { "日期", "玩家uid" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日分时在线人数")), myDataSet.Tables[12], new string[] { "日期", "小时", "在线人数" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日新增用户uid")), myDataSet.Tables[13], new string[] { "日期", "新增用户uid" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日登录次数")), myDataSet.Tables[14], new string[] { "日期", "登录次数" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日累计用户数")), myDataSet.Tables[15], new string[] { "日期", "累计用户数" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日关卡统计")), myDataSet.Tables[16], new string[] { "日期", "关卡", "进入人数", "进入次数", "失败次数", "通关平均步数" });
                common.doExport(Path.Combine(path, string.Format("{0}.xls", "每日道具统计")), myDataSet.Tables[17], new string[] { "日期", "道具id", "使用次数", "购买次数" });
                MessageBox.Show(string.Format("导出excel成功(路径:{0})", path), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnToExcel.Enabled = true;
            }
        }
    }
}

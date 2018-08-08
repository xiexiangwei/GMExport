namespace GMExport
{
    partial class Mail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mail));
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtUid = new System.Windows.Forms.TextBox();
            this.TxtMailTitle = new System.Windows.Forms.TextBox();
            this.TxtMailContent = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtPropNum4 = new System.Windows.Forms.TextBox();
            this.TxtPropNum3 = new System.Windows.Forms.TextBox();
            this.TxtPropNum2 = new System.Windows.Forms.TextBox();
            this.TxtPropNum1 = new System.Windows.Forms.TextBox();
            this.CBProp4 = new System.Windows.Forms.ComboBox();
            this.CBProp3 = new System.Windows.Forms.ComboBox();
            this.CBProp2 = new System.Windows.Forms.ComboBox();
            this.CBProp1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSendMail = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button1.Location = new System.Drawing.Point(552, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "发送邮件";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 32);
            this.panel1.TabIndex = 8;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "玩家uid：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "邮件标题：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "邮件内容：";
            // 
            // TxtUid
            // 
            this.TxtUid.Location = new System.Drawing.Point(167, 48);
            this.TxtUid.Name = "TxtUid";
            this.TxtUid.Size = new System.Drawing.Size(112, 21);
            this.TxtUid.TabIndex = 12;
            // 
            // TxtMailTitle
            // 
            this.TxtMailTitle.Location = new System.Drawing.Point(167, 87);
            this.TxtMailTitle.Name = "TxtMailTitle";
            this.TxtMailTitle.Size = new System.Drawing.Size(208, 21);
            this.TxtMailTitle.TabIndex = 13;
            // 
            // TxtMailContent
            // 
            this.TxtMailContent.Location = new System.Drawing.Point(167, 123);
            this.TxtMailContent.Name = "TxtMailContent";
            this.TxtMailContent.Size = new System.Drawing.Size(405, 21);
            this.TxtMailContent.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TxtPropNum4);
            this.groupBox1.Controls.Add(this.TxtPropNum3);
            this.groupBox1.Controls.Add(this.TxtPropNum2);
            this.groupBox1.Controls.Add(this.TxtPropNum1);
            this.groupBox1.Controls.Add(this.CBProp4);
            this.groupBox1.Controls.Add(this.CBProp3);
            this.groupBox1.Controls.Add(this.CBProp2);
            this.groupBox1.Controls.Add(this.CBProp1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(97, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 155);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "道具列表";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(271, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 30;
            this.label12.Text = "个";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(270, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "个";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(270, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "个";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "个";
            // 
            // TxtPropNum4
            // 
            this.TxtPropNum4.Location = new System.Drawing.Point(197, 114);
            this.TxtPropNum4.Name = "TxtPropNum4";
            this.TxtPropNum4.Size = new System.Drawing.Size(68, 21);
            this.TxtPropNum4.TabIndex = 26;
            this.TxtPropNum4.Text = "0";
            // 
            // TxtPropNum3
            // 
            this.TxtPropNum3.Location = new System.Drawing.Point(197, 89);
            this.TxtPropNum3.Name = "TxtPropNum3";
            this.TxtPropNum3.Size = new System.Drawing.Size(68, 21);
            this.TxtPropNum3.TabIndex = 25;
            this.TxtPropNum3.Text = "0";
            // 
            // TxtPropNum2
            // 
            this.TxtPropNum2.Location = new System.Drawing.Point(197, 57);
            this.TxtPropNum2.Name = "TxtPropNum2";
            this.TxtPropNum2.Size = new System.Drawing.Size(68, 21);
            this.TxtPropNum2.TabIndex = 24;
            this.TxtPropNum2.Text = "0";
            // 
            // TxtPropNum1
            // 
            this.TxtPropNum1.Location = new System.Drawing.Point(197, 28);
            this.TxtPropNum1.Name = "TxtPropNum1";
            this.TxtPropNum1.Size = new System.Drawing.Size(68, 21);
            this.TxtPropNum1.TabIndex = 23;
            this.TxtPropNum1.Text = "0";
            // 
            // CBProp4
            // 
            this.CBProp4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBProp4.FormattingEnabled = true;
            this.CBProp4.Items.AddRange(new object[] {
            "金币",
            "锤子",
            "刷新道具",
            "纵向鱼雷",
            "横向鱼雷",
            "水雷",
            "消除器",
            "加3步",
            "加5步",
            "体力瓶",
            "大体力瓶",
            "超级体力瓶"});
            this.CBProp4.Location = new System.Drawing.Point(70, 115);
            this.CBProp4.Name = "CBProp4";
            this.CBProp4.Size = new System.Drawing.Size(121, 20);
            this.CBProp4.TabIndex = 22;
            // 
            // CBProp3
            // 
            this.CBProp3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBProp3.FormattingEnabled = true;
            this.CBProp3.Items.AddRange(new object[] {
            "金币",
            "锤子",
            "刷新道具",
            "纵向鱼雷",
            "横向鱼雷",
            "水雷",
            "消除器",
            "加3步",
            "加5步",
            "体力瓶",
            "大体力瓶",
            "超级体力瓶"});
            this.CBProp3.Location = new System.Drawing.Point(70, 86);
            this.CBProp3.Name = "CBProp3";
            this.CBProp3.Size = new System.Drawing.Size(121, 20);
            this.CBProp3.TabIndex = 21;
            // 
            // CBProp2
            // 
            this.CBProp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBProp2.FormattingEnabled = true;
            this.CBProp2.Items.AddRange(new object[] {
            "金币",
            "锤子",
            "刷新道具",
            "纵向鱼雷",
            "横向鱼雷",
            "水雷",
            "消除器",
            "加3步",
            "加5步",
            "体力瓶",
            "大体力瓶",
            "超级体力瓶"});
            this.CBProp2.Location = new System.Drawing.Point(70, 57);
            this.CBProp2.Name = "CBProp2";
            this.CBProp2.Size = new System.Drawing.Size(121, 20);
            this.CBProp2.TabIndex = 20;
            // 
            // CBProp1
            // 
            this.CBProp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBProp1.FormattingEnabled = true;
            this.CBProp1.Items.AddRange(new object[] {
            "金币",
            "锤子",
            "刷新道具",
            "纵向鱼雷",
            "横向鱼雷",
            "水雷",
            "消除器",
            "加3步",
            "加5步",
            "体力瓶",
            "大体力瓶",
            "超级体力瓶"});
            this.CBProp1.Location = new System.Drawing.Point(70, 28);
            this.CBProp1.Name = "CBProp1";
            this.CBProp1.Size = new System.Drawing.Size(121, 20);
            this.CBProp1.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "道具4：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "道具3：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "道具2：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "道具1：";
            // 
            // BtnSendMail
            // 
            this.BtnSendMail.Location = new System.Drawing.Point(497, 327);
            this.BtnSendMail.Name = "BtnSendMail";
            this.BtnSendMail.Size = new System.Drawing.Size(75, 23);
            this.BtnSendMail.TabIndex = 16;
            this.BtnSendMail.Text = "发送";
            this.BtnSendMail.UseVisualStyleBackColor = true;
            this.BtnSendMail.Click += new System.EventHandler(this.BtnSendMail_Click);
            // 
            // Mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 352);
            this.Controls.Add(this.BtnSendMail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TxtMailContent);
            this.Controls.Add(this.TxtMailTitle);
            this.Controls.Add(this.TxtUid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtUid;
        private System.Windows.Forms.TextBox TxtMailTitle;
        private System.Windows.Forms.TextBox TxtMailContent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSendMail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBProp4;
        private System.Windows.Forms.ComboBox CBProp3;
        private System.Windows.Forms.ComboBox CBProp2;
        private System.Windows.Forms.ComboBox CBProp1;
        private System.Windows.Forms.TextBox TxtPropNum1;
        private System.Windows.Forms.TextBox TxtPropNum4;
        private System.Windows.Forms.TextBox TxtPropNum3;
        private System.Windows.Forms.TextBox TxtPropNum2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

    }
}
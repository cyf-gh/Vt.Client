namespace Vt.Client.App {
    partial class CreateLobby {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_lobby_name = new System.Windows.Forms.TextBox();
            this.lobby_name = new System.Windows.Forms.Label();
            this.btn_create_lobby = new System.Windows.Forms.Button();
            this.ddd_maxOffset = new System.Windows.Forms.DomainUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_lbpswd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.lb_video_url = new System.Windows.Forms.Label();
            this.cb_is_share_cookie = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_lobby_name
            // 
            this.tb_lobby_name.Location = new System.Drawing.Point(111, 10);
            this.tb_lobby_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_lobby_name.Name = "tb_lobby_name";
            this.tb_lobby_name.Size = new System.Drawing.Size(444, 25);
            this.tb_lobby_name.TabIndex = 0;
            this.tb_lobby_name.Text = "Lobby";
            this.tb_lobby_name.TextChanged += new System.EventHandler(this.tb_lobby_name_TextChanged);
            // 
            // lobby_name
            // 
            this.lobby_name.AutoSize = true;
            this.lobby_name.Location = new System.Drawing.Point(3, 12);
            this.lobby_name.Name = "lobby_name";
            this.lobby_name.Size = new System.Drawing.Size(67, 15);
            this.lobby_name.TabIndex = 1;
            this.lobby_name.Text = "房间名：";
            // 
            // btn_create_lobby
            // 
            this.btn_create_lobby.Location = new System.Drawing.Point(462, 130);
            this.btn_create_lobby.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_create_lobby.Name = "btn_create_lobby";
            this.btn_create_lobby.Size = new System.Drawing.Size(91, 32);
            this.btn_create_lobby.TabIndex = 4;
            this.btn_create_lobby.Text = "创建";
            this.btn_create_lobby.UseVisualStyleBackColor = true;
            this.btn_create_lobby.Click += new System.EventHandler(this.btn_create_lobby_Click);
            // 
            // ddd_maxOffset
            // 
            this.ddd_maxOffset.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ddd_maxOffset.Items.Add("5");
            this.ddd_maxOffset.Items.Add("4");
            this.ddd_maxOffset.Items.Add("3");
            this.ddd_maxOffset.Items.Add("2");
            this.ddd_maxOffset.Location = new System.Drawing.Point(149, 100);
            this.ddd_maxOffset.Name = "ddd_maxOffset";
            this.ddd_maxOffset.Size = new System.Drawing.Size(51, 25);
            this.ddd_maxOffset.TabIndex = 1;
            this.ddd_maxOffset.Text = "2";
            this.ddd_maxOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "密码：";
            // 
            // tb_lbpswd
            // 
            this.tb_lbpswd.Location = new System.Drawing.Point(111, 39);
            this.tb_lbpswd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_lbpswd.Name = "tb_lbpswd";
            this.tb_lbpswd.Size = new System.Drawing.Size(444, 25);
            this.tb_lbpswd.TabIndex = 0;
            this.tb_lbpswd.Text = "123456";
            this.tb_lbpswd.TextChanged += new System.EventHandler(this.tb_lobby_name_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "最大可接受同步偏差";
            // 
            // tb_url
            // 
            this.tb_url.Location = new System.Drawing.Point(111, 69);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(442, 25);
            this.tb_url.TabIndex = 6;
            this.tb_url.Text = "https://www.bilibili.com/video/av5433439?p=3";
            this.tb_url.TextChanged += new System.EventHandler(this.tb_url_TextChanged);
            // 
            // lb_video_url
            // 
            this.lb_video_url.AutoSize = true;
            this.lb_video_url.Location = new System.Drawing.Point(3, 72);
            this.lb_video_url.Name = "lb_video_url";
            this.lb_video_url.Size = new System.Drawing.Size(76, 15);
            this.lb_video_url.TabIndex = 7;
            this.lb_video_url.Text = "视频URL：";
            this.lb_video_url.Click += new System.EventHandler(this.lb_video_url_Click);
            // 
            // cb_is_share_cookie
            // 
            this.cb_is_share_cookie.AutoSize = true;
            this.cb_is_share_cookie.Checked = true;
            this.cb_is_share_cookie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_is_share_cookie.Location = new System.Drawing.Point(434, 106);
            this.cb_is_share_cookie.Name = "cb_is_share_cookie";
            this.cb_is_share_cookie.Size = new System.Drawing.Size(119, 19);
            this.cb_is_share_cookie.TabIndex = 8;
            this.cb_is_share_cookie.Text = "共享登录状态";
            this.cb_is_share_cookie.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "秒";
            // 
            // CreateLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 175);
            this.Controls.Add(this.cb_is_share_cookie);
            this.Controls.Add(this.lb_video_url);
            this.Controls.Add(this.tb_url);
            this.Controls.Add(this.ddd_maxOffset);
            this.Controls.Add(this.btn_create_lobby);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lobby_name);
            this.Controls.Add(this.tb_lbpswd);
            this.Controls.Add(this.tb_lobby_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CreateLobby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "创建房间";
            this.Load += new System.EventHandler(this.CreateLobby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_lobby_name;
        private System.Windows.Forms.Label lobby_name;
        private System.Windows.Forms.Button btn_create_lobby;
        private System.Windows.Forms.DomainUpDown ddd_maxOffset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_lbpswd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_url;
        private System.Windows.Forms.Label lb_video_url;
        private System.Windows.Forms.CheckBox cb_is_share_cookie;
        private System.Windows.Forms.Label label3;
    }
}
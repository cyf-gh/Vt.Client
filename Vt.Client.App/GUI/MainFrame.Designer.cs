namespace Vt.Client.App {
    partial class MainFrame {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createLobbyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BiliBiliToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearLoginStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestCurrentServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.version_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.brwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chromeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocalChromeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NoLocalChromeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_nick_name = new System.Windows.Forms.TextBox();
            this.lb_lobs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.brwToolStripMenuItem,
            this.登录ToolStripMenuItem,
            this.serversToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.version_btn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(741, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createLobbyToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.newToolStripMenuItem.Text = "新建";
            // 
            // createLobbyToolStripMenuItem
            // 
            this.createLobbyToolStripMenuItem.Name = "createLobbyToolStripMenuItem";
            this.createLobbyToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.createLobbyToolStripMenuItem.Text = "房间";
            this.createLobbyToolStripMenuItem.Click += new System.EventHandler(this.createLobbyToolStripMenuItem_Click);
            // 
            // 登录ToolStripMenuItem
            // 
            this.登录ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BiliBiliToolStrip,
            this.ClearLoginStatusToolStripMenuItem});
            this.登录ToolStripMenuItem.Name = "登录ToolStripMenuItem";
            this.登录ToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.登录ToolStripMenuItem.Text = "登录视频网站";
            // 
            // BiliBiliToolStrip
            // 
            this.BiliBiliToolStrip.Name = "BiliBiliToolStrip";
            this.BiliBiliToolStrip.Size = new System.Drawing.Size(182, 26);
            this.BiliBiliToolStrip.Text = "哔哩哔哩";
            this.BiliBiliToolStrip.Click += new System.EventHandler(this.BiliBiliToolStrip_Click);
            // 
            // ClearLoginStatusToolStripMenuItem
            // 
            this.ClearLoginStatusToolStripMenuItem.Name = "ClearLoginStatusToolStripMenuItem";
            this.ClearLoginStatusToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.ClearLoginStatusToolStripMenuItem.Text = "清空登陆状态";
            this.ClearLoginStatusToolStripMenuItem.Click += new System.EventHandler(this.ClearLoginStatusToolStripMenuItem_Click);
            // 
            // serversToolStripMenuItem
            // 
            this.serversToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverConfigToolStripMenuItem,
            this.TestCurrentServerToolStripMenuItem});
            this.serversToolStripMenuItem.Name = "serversToolStripMenuItem";
            this.serversToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.serversToolStripMenuItem.Text = "服务器";
            this.serversToolStripMenuItem.Click += new System.EventHandler(this.serversToolStripMenuItem_Click);
            // 
            // serverConfigToolStripMenuItem
            // 
            this.serverConfigToolStripMenuItem.Name = "serverConfigToolStripMenuItem";
            this.serverConfigToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.serverConfigToolStripMenuItem.Text = "选择";
            this.serverConfigToolStripMenuItem.Click += new System.EventHandler(this.serverConfigToolStripMenuItem_Click);
            // 
            // TestCurrentServerToolStripMenuItem
            // 
            this.TestCurrentServerToolStripMenuItem.Name = "TestCurrentServerToolStripMenuItem";
            this.TestCurrentServerToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.TestCurrentServerToolStripMenuItem.Text = "测试当前";
            this.TestCurrentServerToolStripMenuItem.Click += new System.EventHandler(this.testCurrentServer_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem});
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.refreshToolStripMenuItem.Text = "关于";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.updateToolStripMenuItem.Text = "软件更新";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // version_btn
            // 
            this.version_btn.Name = "version_btn";
            this.version_btn.Size = new System.Drawing.Size(53, 24);
            this.version_btn.Text = "版本";
            this.version_btn.Click += new System.EventHandler(this.version_btn_Click);
            // 
            // brwToolStripMenuItem
            // 
            this.brwToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectBrowserToolStripMenuItem});
            this.brwToolStripMenuItem.Name = "brwToolStripMenuItem";
            this.brwToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.brwToolStripMenuItem.Text = "快速配置⚠";
            // 
            // selectBrowserToolStripMenuItem
            // 
            this.selectBrowserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edgeToolStripMenuItem,
            this.chromeToolStripMenuItem});
            this.selectBrowserToolStripMenuItem.Name = "selectBrowserToolStripMenuItem";
            this.selectBrowserToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.selectBrowserToolStripMenuItem.Text = "选择浏览器";
            // 
            // edgeToolStripMenuItem
            // 
            this.edgeToolStripMenuItem.Name = "edgeToolStripMenuItem";
            this.edgeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.edgeToolStripMenuItem.Text = "Edge";
            this.edgeToolStripMenuItem.Click += new System.EventHandler(this.edgeToolStripMenuItem_Click);
            // 
            // chromeToolStripMenuItem
            // 
            this.chromeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocalChromeToolStripMenuItem,
            this.NoLocalChromeToolStripMenuItem});
            this.chromeToolStripMenuItem.Name = "chromeToolStripMenuItem";
            this.chromeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.chromeToolStripMenuItem.Text = "Chrome";
            // 
            // LocalChromeToolStripMenuItem
            // 
            this.LocalChromeToolStripMenuItem.Name = "LocalChromeToolStripMenuItem";
            this.LocalChromeToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.LocalChromeToolStripMenuItem.Text = "我电脑上安装了Chrome";
            this.LocalChromeToolStripMenuItem.Click += new System.EventHandler(this.LocalChromeToolStripMenuItem_Click);
            // 
            // NoLocalChromeToolStripMenuItem
            // 
            this.NoLocalChromeToolStripMenuItem.Name = "NoLocalChromeToolStripMenuItem";
            this.NoLocalChromeToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.NoLocalChromeToolStripMenuItem.Text = "我电脑上没有安装Chrome";
            this.NoLocalChromeToolStripMenuItem.Click += new System.EventHandler(this.NoLocalChromeToolStripMenuItem_Click);
            // 
            // tb_nick_name
            // 
            this.tb_nick_name.Location = new System.Drawing.Point(553, 3);
            this.tb_nick_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_nick_name.Name = "tb_nick_name";
            this.tb_nick_name.Size = new System.Drawing.Size(176, 25);
            this.tb_nick_name.TabIndex = 2;
            this.tb_nick_name.TextChanged += new System.EventHandler(this.tb_nickname_TextChange);
            this.tb_nick_name.MouseLeave += new System.EventHandler(this.tb_nick_name_MouseLeave);
            // 
            // lb_lobs
            // 
            this.lb_lobs.BackColor = System.Drawing.SystemColors.Menu;
            this.lb_lobs.Font = new System.Drawing.Font("宋体", 12F);
            this.lb_lobs.ForeColor = System.Drawing.Color.Black;
            this.lb_lobs.FormattingEnabled = true;
            this.lb_lobs.ItemHeight = 20;
            this.lb_lobs.Location = new System.Drawing.Point(12, 31);
            this.lb_lobs.Name = "lb_lobs";
            this.lb_lobs.Size = new System.Drawing.Size(717, 524);
            this.lb_lobs.TabIndex = 4;
            this.lb_lobs.SelectedIndexChanged += new System.EventHandler(this.lb_lobs_SelectedIndexChanged);
            this.lb_lobs.DoubleClick += new System.EventHandler(this.lb_lobs_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "昵称";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(12, 561);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(130, 33);
            this.btn_refresh.TabIndex = 6;
            this.btn_refresh.Text = "刷新房间列表";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 607);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_lobs);
            this.Controls.Add(this.tb_nick_name);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrame_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrame_FormClosed);
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createLobbyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serversToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_nick_name;
        private System.Windows.Forms.ToolStripMenuItem serverConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ListBox lb_lobs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TestCurrentServerToolStripMenuItem;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BiliBiliToolStrip;
        private System.Windows.Forms.ToolStripMenuItem ClearLoginStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem version_btn;
        private System.Windows.Forms.ToolStripMenuItem brwToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chromeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LocalChromeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NoLocalChromeToolStripMenuItem;
    }
}


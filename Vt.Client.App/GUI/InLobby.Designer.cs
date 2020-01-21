namespace Vt.Client.App {
    partial class InLobby {
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
            this.tb_video_url = new System.Windows.Forms.TextBox();
            this.bt_start = new System.Windows.Forms.Button();
            this.lb_viewerList = new System.Windows.Forms.ListBox();
            this.bgw_viewers_syncer = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // tb_video_url
            // 
            this.tb_video_url.Location = new System.Drawing.Point(12, 11);
            this.tb_video_url.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_video_url.Name = "tb_video_url";
            this.tb_video_url.Size = new System.Drawing.Size(689, 25);
            this.tb_video_url.TabIndex = 0;
            this.tb_video_url.TextChanged += new System.EventHandler(this.tb_video_url_TextChanged);
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(601, 317);
            this.bt_start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(100, 33);
            this.bt_start.TabIndex = 1;
            this.bt_start.Text = "启动";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // lb_viewerList
            // 
            this.lb_viewerList.FormattingEnabled = true;
            this.lb_viewerList.ItemHeight = 15;
            this.lb_viewerList.Location = new System.Drawing.Point(11, 38);
            this.lb_viewerList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lb_viewerList.Name = "lb_viewerList";
            this.lb_viewerList.Size = new System.Drawing.Size(690, 274);
            this.lb_viewerList.TabIndex = 2;
            this.lb_viewerList.SelectedIndexChanged += new System.EventHandler(this.lb_viewerList_SelectedIndexChanged);
            // 
            // bgw_viewers_syncer
            // 
            this.bgw_viewers_syncer.WorkerSupportsCancellation = true;
            this.bgw_viewers_syncer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_viewers_syncer_DoWork);
            // 
            // InLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 361);
            this.Controls.Add(this.lb_viewerList);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.tb_video_url);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InLobby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InLobby";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InLobby_FormClosing);
            this.Load += new System.EventHandler(this.InLobby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_video_url;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.ListBox lb_viewerList;
        private System.ComponentModel.BackgroundWorker bgw_viewers_syncer;
    }
}
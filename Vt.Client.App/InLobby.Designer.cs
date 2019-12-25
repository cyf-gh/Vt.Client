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
            this.button1 = new System.Windows.Forms.Button();
            this.lb_viewerList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tb_video_url
            // 
            this.tb_video_url.Location = new System.Drawing.Point(165, 12);
            this.tb_video_url.Name = "tb_video_url";
            this.tb_video_url.Size = new System.Drawing.Size(623, 28);
            this.tb_video_url.TabIndex = 0;
            this.tb_video_url.TextChanged += new System.EventHandler(this.tb_video_url_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(676, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lb_viewerList
            // 
            this.lb_viewerList.FormattingEnabled = true;
            this.lb_viewerList.ItemHeight = 18;
            this.lb_viewerList.Location = new System.Drawing.Point(12, 46);
            this.lb_viewerList.Name = "lb_viewerList";
            this.lb_viewerList.Size = new System.Drawing.Size(776, 328);
            this.lb_viewerList.TabIndex = 2;
            // 
            // InLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 433);
            this.Controls.Add(this.lb_viewerList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_video_url);
            this.Name = "InLobby";
            this.Text = "InLobby";
            this.Load += new System.EventHandler(this.InLobby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_video_url;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lb_viewerList;
    }
}
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
            this.lb_server_info = new System.Windows.Forms.Label();
            this.btn_create_lobby = new System.Windows.Forms.Button();
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
            this.lobby_name.Size = new System.Drawing.Size(103, 15);
            this.lobby_name.TabIndex = 1;
            this.lobby_name.Text = "Lobby Name :";
            // 
            // lb_server_info
            // 
            this.lb_server_info.AutoSize = true;
            this.lb_server_info.Location = new System.Drawing.Point(27, 38);
            this.lb_server_info.Name = "lb_server_info";
            this.lb_server_info.Size = new System.Drawing.Size(79, 15);
            this.lb_server_info.TabIndex = 3;
            this.lb_server_info.Text = "Servers :";
            // 
            // btn_create_lobby
            // 
            this.btn_create_lobby.Location = new System.Drawing.Point(464, 203);
            this.btn_create_lobby.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_create_lobby.Name = "btn_create_lobby";
            this.btn_create_lobby.Size = new System.Drawing.Size(91, 32);
            this.btn_create_lobby.TabIndex = 4;
            this.btn_create_lobby.Text = "Create";
            this.btn_create_lobby.UseVisualStyleBackColor = true;
            this.btn_create_lobby.Click += new System.EventHandler(this.btn_create_lobby_Click);
            // 
            // CreateLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 245);
            this.Controls.Add(this.btn_create_lobby);
            this.Controls.Add(this.lb_server_info);
            this.Controls.Add(this.lobby_name);
            this.Controls.Add(this.tb_lobby_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CreateLobby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateLobby";
            this.Load += new System.EventHandler(this.CreateLobby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_lobby_name;
        private System.Windows.Forms.Label lobby_name;
        private System.Windows.Forms.Label lb_server_info;
        private System.Windows.Forms.Button btn_create_lobby;
    }
}
namespace DurakEnhanced.Controls
{
    partial class JoinableGamesListControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private System.Windows.Forms.Button GoBackButon;
        private System.Windows.Forms.PictureBox GameLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button JoinButton;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label portLabel;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoinableGamesListControl));
            this.GoBackButon = new System.Windows.Forms.Button();
            this.GameLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.JoinButton = new System.Windows.Forms.Button();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.GameLogo)).BeginInit();
            this.SuspendLayout();

            // 
            // GoBackButon
            // 
            this.GoBackButon.BackColor = System.Drawing.Color.Transparent;
            this.GoBackButon.BackgroundImage = global::DurakEnhanced.Properties.Resources.ESCButton;
            this.GoBackButon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GoBackButon.FlatAppearance.BorderSize = 0;
            this.GoBackButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoBackButon.Location = new System.Drawing.Point(3, 3);
            this.GoBackButon.Name = "GoBackButon";
            this.GoBackButon.Size = new System.Drawing.Size(74, 76);
            this.GoBackButon.TabIndex = 0;
            this.GoBackButon.UseVisualStyleBackColor = false;
            this.GoBackButon.Click += new System.EventHandler(this.GoBackButon_Click);

            // 
            // GameLogo
            // 
            this.GameLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GameLogo.Image = global::DurakEnhanced.Properties.Resources.DurakLogo;
            this.GameLogo.Location = new System.Drawing.Point(561, 3);
            this.GameLogo.Name = "GameLogo";
            this.GameLogo.Size = new System.Drawing.Size(275, 280);
            this.GameLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GameLogo.TabIndex = 1;
            this.GameLogo.TabStop = false;

            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(248, 225, 186);
            this.label1.Font = new System.Drawing.Font("Inknut Antiqua SemiBold", 21.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(94, 94, 94);
            this.label1.Location = new System.Drawing.Point(158, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(850, 68);
            this.label1.TabIndex = 2;
            this.label1.Text = "John Doe's game";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);

            // 
            // JoinButton
            // 
            this.JoinButton.BackColor = System.Drawing.Color.FromArgb(156, 139, 94);
            this.JoinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinButton.Font = new System.Drawing.Font("Inknut Antiqua", 21F);
            this.JoinButton.ForeColor = System.Drawing.Color.White;
            this.JoinButton.Location = new System.Drawing.Point(1014, 347);
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.Size = new System.Drawing.Size(204, 68);
            this.JoinButton.TabIndex = 3;
            this.JoinButton.Text = "Join game";
            this.JoinButton.UseVisualStyleBackColor = false;
            this.JoinButton.Click += new System.EventHandler(this.JoinButton_Click);

            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ipLabel.Location = new System.Drawing.Point(160, 440);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(73, 21);
            this.ipLabel.TabIndex = 4;
            this.ipLabel.Text = "IP-adres:";

            // 
            // ipTextBox
            // 
            this.ipTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ipTextBox.Location = new System.Drawing.Point(240, 437);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(200, 29);
            this.ipTextBox.TabIndex = 5;
            this.ipTextBox.Text = "127.0.0.1";

            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.portLabel.Location = new System.Drawing.Point(460, 440);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(47, 21);
            this.portLabel.TabIndex = 6;
            this.portLabel.Text = "Poort:";

            // 
            // portTextBox
            // 
            this.portTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.portTextBox.Location = new System.Drawing.Point(510, 437);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 29);
            this.portTextBox.TabIndex = 7;
            this.portTextBox.Text = "5000";

            // 
            // JoinableGamesListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 236, 212);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.JoinButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GameLogo);
            this.Controls.Add(this.GoBackButon);
            this.MinimumSize = new System.Drawing.Size(1400, 900);
            this.Name = "JoinableGamesListControl";
            this.Size = new System.Drawing.Size(1400, 900);
            this.Load += new System.EventHandler(this.JoinableGamesList_Load);

            ((System.ComponentModel.ISupportInitialize)(this.GameLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

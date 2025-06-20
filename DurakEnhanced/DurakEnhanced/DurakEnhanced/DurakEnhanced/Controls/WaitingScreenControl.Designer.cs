namespace DurakEnhanced.Controls
{
    partial class WaitingScreenControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingScreenControl));
            this.label1 = new System.Windows.Forms.Label();
            this.labelConnectionInfo = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.GameLogo = new System.Windows.Forms.PictureBox();
            this.play = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GameLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(532, 605);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1084, 197);
            this.label1.TabIndex = 17;
            this.label1.Text = "Waiting for player to join...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelConnectionInfo
            // 
            this.labelConnectionInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelConnectionInfo.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.labelConnectionInfo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelConnectionInfo.Location = new System.Drawing.Point(532, 846);
            this.labelConnectionInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConnectionInfo.Name = "labelConnectionInfo";
            this.labelConnectionInfo.Size = new System.Drawing.Size(1084, 231);
            this.labelConnectionInfo.TabIndex = 20;
            this.labelConnectionInfo.Text = "IP: -\nPort: -";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.ExitButton.Location = new System.Drawing.Point(4, 5);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(214, 114);
            this.ExitButton.TabIndex = 18;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // GameLogo
            // 
            this.GameLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GameLogo.Image = global::DurakEnhanced.Properties.Resources.DurakLogo;
            this.GameLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("GameLogo.InitialImage")));
            this.GameLogo.Location = new System.Drawing.Point(843, 5);
            this.GameLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GameLogo.Name = "GameLogo";
            this.GameLogo.Size = new System.Drawing.Size(412, 431);
            this.GameLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GameLogo.TabIndex = 16;
            this.GameLogo.TabStop = false;
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(1558, 448);
            this.play.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(112, 35);
            this.play.TabIndex = 19;
            this.play.Text = "play";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // WaitingScreenControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(236)))), ((int)(((byte)(212)))));
            this.Controls.Add(this.labelConnectionInfo);
            this.Controls.Add(this.play);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GameLogo);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(2100, 1385);
            this.Name = "WaitingScreenControl";
            this.Size = new System.Drawing.Size(2100, 1385);
            ((System.ComponentModel.ISupportInitialize)(this.GameLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GameLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelConnectionInfo;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button play;
    }
}

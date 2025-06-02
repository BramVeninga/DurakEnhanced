namespace DurakEnhanced.Controls
{
    partial class JoinGameControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoinGameControl));
            this.CreateGameButton = new System.Windows.Forms.Button();
            this.JoinGameButton = new System.Windows.Forms.Button();
            this.GoBackButon = new System.Windows.Forms.Button();
            this.GameLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateGameButton
            // 
            this.CreateGameButton.BackColor = System.Drawing.Color.Transparent;
            this.CreateGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateGameButton.FlatAppearance.BorderSize = 0;
            this.CreateGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateGameButton.Font = new System.Drawing.Font("Inknut Antiqua", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateGameButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.CreateGameButton.Location = new System.Drawing.Point(3, 296);
            this.CreateGameButton.Name = "CreateGameButton";
            this.CreateGameButton.Size = new System.Drawing.Size(537, 140);
            this.CreateGameButton.TabIndex = 7;
            this.CreateGameButton.Text = "Create game";
            this.CreateGameButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateGameButton.UseVisualStyleBackColor = false;
            this.CreateGameButton.Click += new System.EventHandler(this.CreateGameButton_Click);
            // 
            // JoinGameButton
            // 
            this.JoinGameButton.BackColor = System.Drawing.Color.Transparent;
            this.JoinGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JoinGameButton.FlatAppearance.BorderSize = 0;
            this.JoinGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinGameButton.Font = new System.Drawing.Font("Inknut Antiqua", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinGameButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.JoinGameButton.Location = new System.Drawing.Point(3, 155);
            this.JoinGameButton.Name = "JoinGameButton";
            this.JoinGameButton.Size = new System.Drawing.Size(431, 135);
            this.JoinGameButton.TabIndex = 6;
            this.JoinGameButton.Text = "Join game";
            this.JoinGameButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.JoinGameButton.UseVisualStyleBackColor = false;
            this.JoinGameButton.Click += new System.EventHandler(this.JoinGameButton_Click);
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
            this.GoBackButon.TabIndex = 9;
            this.GoBackButon.UseVisualStyleBackColor = false;
            this.GoBackButon.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // GameLogo
            // 
            this.GameLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GameLogo.Image = global::DurakEnhanced.Properties.Resources.DurakLogo;
            this.GameLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("GameLogo.InitialImage")));
            this.GameLogo.Location = new System.Drawing.Point(920, 3);
            this.GameLogo.Name = "GameLogo";
            this.GameLogo.Size = new System.Drawing.Size(383, 383);
            this.GameLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.GameLogo.TabIndex = 8;
            this.GameLogo.TabStop = false;
            // 
            // JoinGameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(236)))), ((int)(((byte)(212)))));
            this.Controls.Add(this.GoBackButon);
            this.Controls.Add(this.GameLogo);
            this.Controls.Add(this.CreateGameButton);
            this.Controls.Add(this.JoinGameButton);
            this.MinimumSize = new System.Drawing.Size(1400, 900);
            this.Name = "JoinGameControl";
            this.Size = new System.Drawing.Size(1400, 900);
            this.Load += new System.EventHandler(this.JoinGameControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GameLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameLogo;
        private System.Windows.Forms.Button CreateGameButton;
        private System.Windows.Forms.Button JoinGameButton;
        private System.Windows.Forms.Button GoBackButon;
    }
}

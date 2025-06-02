namespace DurakEnhanced.Controls
{
    partial class JoinableGamesListControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoinableGamesListControl));
            this.GoBackButon = new System.Windows.Forms.Button();
            this.GameLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.JoinButton = new System.Windows.Forms.Button();
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
            this.GoBackButon.TabIndex = 13;
            this.GoBackButon.UseVisualStyleBackColor = false;
            this.GoBackButon.Click += new System.EventHandler(this.GoBackButon_Click);
            // 
            // GameLogo
            // 
            this.GameLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GameLogo.Image = global::DurakEnhanced.Properties.Resources.DurakLogo;
            this.GameLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("GameLogo.InitialImage")));
            this.GameLogo.Location = new System.Drawing.Point(561, 3);
            this.GameLogo.Name = "GameLogo";
            this.GameLogo.Size = new System.Drawing.Size(275, 280);
            this.GameLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GameLogo.TabIndex = 14;
            this.GameLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(225)))), ((int)(((byte)(186)))));
            this.label1.Font = new System.Drawing.Font("Inknut Antiqua SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(158, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(850, 68);
            this.label1.TabIndex = 15;
            this.label1.Text = "John Doe\'s game";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // JoinButton
            // 
            this.JoinButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(139)))), ((int)(((byte)(94)))));
            this.JoinButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(139)))), ((int)(((byte)(94)))));
            this.JoinButton.FlatAppearance.BorderSize = 0;
            this.JoinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinButton.Font = new System.Drawing.Font("Inknut Antiqua", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinButton.ForeColor = System.Drawing.Color.White;
            this.JoinButton.Location = new System.Drawing.Point(1014, 347);
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.Size = new System.Drawing.Size(204, 68);
            this.JoinButton.TabIndex = 16;
            this.JoinButton.Text = "Join game";
            this.JoinButton.UseVisualStyleBackColor = false;
            // 
            // JoinableGamesListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(236)))), ((int)(((byte)(212)))));
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

        }

        #endregion

        private System.Windows.Forms.Button GoBackButon;
        private System.Windows.Forms.PictureBox GameLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button JoinButton;
    }
}

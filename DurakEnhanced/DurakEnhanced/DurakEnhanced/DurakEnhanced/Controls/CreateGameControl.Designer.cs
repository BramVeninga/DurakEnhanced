namespace DurakEnhanced.Controls
{
    partial class CreateGameControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateGameControl));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CreateGameButton = new System.Windows.Forms.Button();
            this.GoBackButon = new System.Windows.Forms.Button();
            this.GameLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(225)))), ((int)(((byte)(186)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Inknut Antiqua", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(382, 345);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(600, 96);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Enter name";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CreateGameButton
            // 
            this.CreateGameButton.BackColor = System.Drawing.Color.Transparent;
            this.CreateGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateGameButton.Font = new System.Drawing.Font("Inknut Antiqua", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateGameButton.Location = new System.Drawing.Point(411, 463);
            this.CreateGameButton.Name = "CreateGameButton";
            this.CreateGameButton.Size = new System.Drawing.Size(545, 138);
            this.CreateGameButton.TabIndex = 11;
            this.CreateGameButton.Text = "Create game";
            this.CreateGameButton.UseVisualStyleBackColor = false;
            this.CreateGameButton.Click += new System.EventHandler(this.CreateGameButton_Click);
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
            this.GoBackButon.TabIndex = 12;
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
            this.GameLogo.TabIndex = 9;
            this.GameLogo.TabStop = false;
            this.GameLogo.Click += new System.EventHandler(this.GameLogo_Click);
            // 
            // CreateGameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(236)))), ((int)(((byte)(212)))));
            this.Controls.Add(this.GoBackButon);
            this.Controls.Add(this.CreateGameButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GameLogo);
            this.MinimumSize = new System.Drawing.Size(1400, 900);
            this.Name = "CreateGameControl";
            this.Size = new System.Drawing.Size(1400, 900);
            this.Load += new System.EventHandler(this.CreateGameControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GameLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameLogo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CreateGameButton;
        private System.Windows.Forms.Button GoBackButon;
    }
}

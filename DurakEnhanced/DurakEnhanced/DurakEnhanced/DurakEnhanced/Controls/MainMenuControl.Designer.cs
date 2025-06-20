namespace DurakEnhanced.Controls
{
    partial class MainMenuControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuControl));
            this.ActionCardsButton = new System.Windows.Forms.Button();
            this.RulesButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ActionCardsButton
            // 
            this.ActionCardsButton.BackColor = System.Drawing.Color.Transparent;
            this.ActionCardsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ActionCardsButton.FlatAppearance.BorderSize = 0;
            this.ActionCardsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActionCardsButton.Font = new System.Drawing.Font("Inknut Antiqua", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionCardsButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ActionCardsButton.Location = new System.Drawing.Point(0, 393);
            this.ActionCardsButton.Name = "ActionCardsButton";
            this.ActionCardsButton.Size = new System.Drawing.Size(527, 117);
            this.ActionCardsButton.TabIndex = 6;
            this.ActionCardsButton.Text = "Action cards";
            this.ActionCardsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ActionCardsButton.UseVisualStyleBackColor = false;
            this.ActionCardsButton.Click += new System.EventHandler(this.ActionCardsButton_Click);
            // 
            // RulesButton
            // 
            this.RulesButton.BackColor = System.Drawing.Color.Transparent;
            this.RulesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RulesButton.FlatAppearance.BorderSize = 0;
            this.RulesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RulesButton.Font = new System.Drawing.Font("Inknut Antiqua", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RulesButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.RulesButton.Location = new System.Drawing.Point(0, 270);
            this.RulesButton.Name = "RulesButton";
            this.RulesButton.Size = new System.Drawing.Size(286, 117);
            this.RulesButton.TabIndex = 5;
            this.RulesButton.Text = "Rules";
            this.RulesButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RulesButton.UseVisualStyleBackColor = false;
            this.RulesButton.Click += new System.EventHandler(this.RulesButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.Transparent;
            this.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayButton.FlatAppearance.BorderSize = 0;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Font = new System.Drawing.Font("Inknut Antiqua", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.PlayButton.Location = new System.Drawing.Point(-17, 66);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(345, 198);
            this.PlayButton.TabIndex = 4;
            this.PlayButton.Text = "Play";
            this.PlayButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::DurakEnhanced.Properties.Resources.DurakLogo;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(944, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 383);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(236)))), ((int)(((byte)(212)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ActionCardsButton);
            this.Controls.Add(this.RulesButton);
            this.Controls.Add(this.PlayButton);
            this.MinimumSize = new System.Drawing.Size(1400, 900);
            this.Name = "MainMenuControl";
            this.Size = new System.Drawing.Size(1400, 900);
            this.Load += new System.EventHandler(this.MainMenuControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ActionCardsButton;
        private System.Windows.Forms.Button RulesButton;
        private System.Windows.Forms.Button PlayButton;
    }
}

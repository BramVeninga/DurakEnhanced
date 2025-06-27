namespace DurakEnhanced.Controls
{
    partial class PlaygroundControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaygroundControl));
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rollResultLabel = new System.Windows.Forms.Label();
            this.rollDiceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox8.Image = global::DurakEnhanced.Properties.Resources.backdeck;
            this.pictureBox8.Location = new System.Drawing.Point(3, 300);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(135, 199);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 13;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 286);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rollResultLabel
            // 
            this.rollResultLabel.AutoSize = true;
            this.rollResultLabel.Location = new System.Drawing.Point(1117, 355);
            this.rollResultLabel.Name = "rollResultLabel";
            this.rollResultLabel.Size = new System.Drawing.Size(55, 13);
            this.rollResultLabel.TabIndex = 14;
            this.rollResultLabel.Text = "RollResult";
            this.rollResultLabel.Click += new System.EventHandler(this.rollResultLabel_Click);
            // 
            // rollDiceButton
            // 
            this.rollDiceButton.Location = new System.Drawing.Point(1107, 371);
            this.rollDiceButton.Name = "rollDiceButton";
            this.rollDiceButton.Size = new System.Drawing.Size(75, 23);
            this.rollDiceButton.TabIndex = 15;
            this.rollDiceButton.Text = "Roll D20";
            this.rollDiceButton.UseVisualStyleBackColor = true;
            this.rollDiceButton.Click += new System.EventHandler(this.rollDiceButton_Click);
            // 
            // PlaygroundControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(236)))), ((int)(((byte)(212)))));
            this.Controls.Add(this.rollDiceButton);
            this.Controls.Add(this.rollResultLabel);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(1400, 900);
            this.Name = "PlaygroundControl";
            this.Size = new System.Drawing.Size(1400, 900);
            this.Load += new System.EventHandler(this.PlaygroundControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label rollResultLabel;
        private System.Windows.Forms.Button rollDiceButton;
    }
}

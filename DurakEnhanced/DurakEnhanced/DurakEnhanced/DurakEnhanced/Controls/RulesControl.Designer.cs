namespace DurakEnhanced.Controls
{
    partial class RulesControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesControl));
            this.RulesLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GoBackButon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RulesLabel
            // 
            this.RulesLabel.BackColor = System.Drawing.Color.Transparent;
            this.RulesLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RulesLabel.Font = new System.Drawing.Font("Inknut Antiqua SemiBold", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RulesLabel.ForeColor = System.Drawing.Color.Black;
            this.RulesLabel.Location = new System.Drawing.Point(74, 82);
            this.RulesLabel.Name = "RulesLabel";
            this.RulesLabel.Size = new System.Drawing.Size(723, 128);
            this.RulesLabel.TabIndex = 18;
            this.RulesLabel.Text = "Rules";
            this.RulesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DurakEnhanced.Properties.Resources.Rectangle_6;
            this.pictureBox1.Location = new System.Drawing.Point(35, 213);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(854, 599);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
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
            this.GoBackButon.TabIndex = 10;
            this.GoBackButon.UseVisualStyleBackColor = false;
            this.GoBackButon.Click += new System.EventHandler(this.GoBackButon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(225)))), ((int)(((byte)(186)))));
            this.label1.Font = new System.Drawing.Font("Inknut Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(643, 492);
            this.label1.TabIndex = 20;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // RulesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(236)))), ((int)(((byte)(212)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RulesLabel);
            this.Controls.Add(this.GoBackButon);
            this.MinimumSize = new System.Drawing.Size(1400, 900);
            this.Name = "RulesControl";
            this.Size = new System.Drawing.Size(1400, 900);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GoBackButon;
        private System.Windows.Forms.Label RulesLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

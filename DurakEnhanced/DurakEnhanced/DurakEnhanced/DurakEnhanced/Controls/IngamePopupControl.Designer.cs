namespace DurakEnhanced.Controls
{
    partial class IngamePopupControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRules = new System.Windows.Forms.Button();
            this.btnActionCards = new System.Windows.Forms.Button();
            this.btnLeaveGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRules
            // 
            this.btnRules.BackColor = System.Drawing.Color.Transparent;
            this.btnRules.BackgroundImage = global::DurakEnhanced.Properties.Resources.Rectangle_2;
            this.btnRules.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRules.FlatAppearance.BorderSize = 0;
            this.btnRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRules.Font = new System.Drawing.Font("Inknut Antiqua", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRules.Location = new System.Drawing.Point(44, 41);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(111, 37);
            this.btnRules.TabIndex = 0;
            this.btnRules.Text = "Rules";
            this.btnRules.UseVisualStyleBackColor = false;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // btnActionCards
            // 
            this.btnActionCards.BackColor = System.Drawing.Color.Transparent;
            this.btnActionCards.BackgroundImage = global::DurakEnhanced.Properties.Resources.Rectangle_2;
            this.btnActionCards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnActionCards.FlatAppearance.BorderSize = 0;
            this.btnActionCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActionCards.Font = new System.Drawing.Font("Inknut Antiqua", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActionCards.Location = new System.Drawing.Point(44, 94);
            this.btnActionCards.Name = "btnActionCards";
            this.btnActionCards.Size = new System.Drawing.Size(111, 37);
            this.btnActionCards.TabIndex = 1;
            this.btnActionCards.Text = "Action Cards";
            this.btnActionCards.UseVisualStyleBackColor = false;
            this.btnActionCards.Click += new System.EventHandler(this.btnActionCards_Click);
            // 
            // btnLeaveGame
            // 
            this.btnLeaveGame.BackColor = System.Drawing.Color.Transparent;
            this.btnLeaveGame.BackgroundImage = global::DurakEnhanced.Properties.Resources.Rectangle_2;
            this.btnLeaveGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeaveGame.FlatAppearance.BorderSize = 0;
            this.btnLeaveGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveGame.Font = new System.Drawing.Font("Inknut Antiqua", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaveGame.Location = new System.Drawing.Point(44, 178);
            this.btnLeaveGame.Name = "btnLeaveGame";
            this.btnLeaveGame.Size = new System.Drawing.Size(111, 37);
            this.btnLeaveGame.TabIndex = 2;
            this.btnLeaveGame.Text = "Leave Game";
            this.btnLeaveGame.UseVisualStyleBackColor = false;
            this.btnLeaveGame.Click += new System.EventHandler(this.btnLeaveGame_Click);
            // 
            // IngamePopupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.Controls.Add(this.btnLeaveGame);
            this.Controls.Add(this.btnActionCards);
            this.Controls.Add(this.btnRules);
            this.Name = "IngamePopupControl";
            this.Size = new System.Drawing.Size(200, 268);
            this.Load += new System.EventHandler(this.IngamePopupControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRules;
        private System.Windows.Forms.Button btnActionCards;
        private System.Windows.Forms.Button btnLeaveGame;
    }
}

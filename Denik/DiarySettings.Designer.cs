namespace Denik
{
    partial class DiarySettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
           
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.edInitRemain = new System.Windows.Forms.TextBox();
            this.edWarnLimit = new System.Windows.Forms.TextBox();
            this.edRemainLimit = new System.Windows.Forms.TextBox();
            this.edDiaryHeader = new System.Windows.Forms.TextBox();
            this.ndIncomeCount = new System.Windows.Forms.NumericUpDown();
            this.ndOutcomeCount = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ndIncomeCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndOutcomeCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Počet příjmových dokladů:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Počet výdajových dokladů:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Počáteční zůstatek:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Limit pokladny:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Varovat při překročení:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hlavička v knize:";
            // 
            // edInitRemain
            // 
            this.edInitRemain.Location = new System.Drawing.Point(214, 64);
            this.edInitRemain.Name = "edInitRemain";
            this.edInitRemain.Size = new System.Drawing.Size(120, 20);
            this.edInitRemain.TabIndex = 2;
            // 
            // edWarnLimit
            // 
            this.edWarnLimit.Location = new System.Drawing.Point(214, 118);
            this.edWarnLimit.Name = "edWarnLimit";
            this.edWarnLimit.Size = new System.Drawing.Size(120, 20);
            this.edWarnLimit.TabIndex = 4;
            // 
            // edRemainLimit
            // 
            this.edRemainLimit.Location = new System.Drawing.Point(214, 91);
            this.edRemainLimit.Name = "edRemainLimit";
            this.edRemainLimit.Size = new System.Drawing.Size(120, 20);
            this.edRemainLimit.TabIndex = 3;
            // 
            // edDiaryHeader
            // 
            this.edDiaryHeader.Location = new System.Drawing.Point(14, 158);
            this.edDiaryHeader.MaxLength = 30;
            this.edDiaryHeader.Name = "edDiaryHeader";
            this.edDiaryHeader.Size = new System.Drawing.Size(320, 20);
            this.edDiaryHeader.TabIndex = 5;
            // 
            // ndIncomeCount
            // 
            this.ndIncomeCount.Location = new System.Drawing.Point(214, 9);
            this.ndIncomeCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ndIncomeCount.Name = "ndIncomeCount";
            this.ndIncomeCount.Size = new System.Drawing.Size(120, 20);
            this.ndIncomeCount.TabIndex = 0;
            this.ndIncomeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ndOutcomeCount
            // 
            this.ndOutcomeCount.Location = new System.Drawing.Point(214, 37);
            this.ndOutcomeCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ndOutcomeCount.Name = "ndOutcomeCount";
            this.ndOutcomeCount.Size = new System.Drawing.Size(120, 20);
            this.ndOutcomeCount.TabIndex = 1;
            this.ndOutcomeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(241, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 24);
            this.button2.TabIndex = 7;
            this.button2.Text = "Zrušit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DiarySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 219);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ndOutcomeCount);
            this.Controls.Add(this.ndIncomeCount);
            this.Controls.Add(this.edDiaryHeader);
            this.Controls.Add(this.edRemainLimit);
            this.Controls.Add(this.edWarnLimit);
            this.Controls.Add(this.edInitRemain);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DiarySettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nastavení deníku";
            ((System.ComponentModel.ISupportInitialize)(this.ndIncomeCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndOutcomeCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edInitRemain;
        private System.Windows.Forms.TextBox edWarnLimit;
        private System.Windows.Forms.TextBox edRemainLimit;
        private System.Windows.Forms.TextBox edDiaryHeader;
        private System.Windows.Forms.NumericUpDown ndIncomeCount;
        private System.Windows.Forms.NumericUpDown ndOutcomeCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
namespace Denik
{
    partial class AutocompleteSettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbOutcome = new System.Windows.Forms.RadioButton();
            this.rbIncome = new System.Windows.Forms.RadioButton();
            this.btnNote = new System.Windows.Forms.Button();
            this.btnName = new System.Windows.Forms.Button();
            this.btnContent = new System.Windows.Forms.Button();
            this.btnRecipient = new System.Windows.Forms.Button();
            this.gridAC = new Denik.FastDataGridView();
            this.hint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAC)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOutcome);
            this.groupBox1.Controls.Add(this.rbIncome);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(81, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbOutcome
            // 
            this.rbOutcome.AutoSize = true;
            this.rbOutcome.Location = new System.Drawing.Point(6, 42);
            this.rbOutcome.Name = "rbOutcome";
            this.rbOutcome.Size = new System.Drawing.Size(68, 17);
            this.rbOutcome.TabIndex = 1;
            this.rbOutcome.Text = "Výdajový";
            this.rbOutcome.UseVisualStyleBackColor = true;
            this.rbOutcome.CheckedChanged += new System.EventHandler(this.rbIncome_CheckedChanged);
            // 
            // rbIncome
            // 
            this.rbIncome.AutoSize = true;
            this.rbIncome.Checked = true;
            this.rbIncome.Location = new System.Drawing.Point(6, 16);
            this.rbIncome.Name = "rbIncome";
            this.rbIncome.Size = new System.Drawing.Size(67, 17);
            this.rbIncome.TabIndex = 0;
            this.rbIncome.TabStop = true;
            this.rbIncome.Text = "Příjmový";
            this.rbIncome.UseVisualStyleBackColor = true;
            this.rbIncome.CheckedChanged += new System.EventHandler(this.rbIncome_CheckedChanged);
            // 
            // btnNote
            // 
            this.btnNote.Location = new System.Drawing.Point(12, 104);
            this.btnNote.Name = "btnNote";
            this.btnNote.Size = new System.Drawing.Size(75, 23);
            this.btnNote.TabIndex = 1;
            this.btnNote.Text = "Poznámka";
            this.btnNote.UseVisualStyleBackColor = true;
            this.btnNote.Click += new System.EventHandler(this.btnNote_Click);
            // 
            // btnName
            // 
            this.btnName.Location = new System.Drawing.Point(12, 133);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(75, 23);
            this.btnName.TabIndex = 2;
            this.btnName.Text = "Jméno";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // btnContent
            // 
            this.btnContent.Location = new System.Drawing.Point(12, 162);
            this.btnContent.Name = "btnContent";
            this.btnContent.Size = new System.Drawing.Size(75, 23);
            this.btnContent.TabIndex = 3;
            this.btnContent.Text = "Účel";
            this.btnContent.UseVisualStyleBackColor = true;
            this.btnContent.Click += new System.EventHandler(this.btnContent_Click);
            // 
            // btnRecipient
            // 
            this.btnRecipient.Location = new System.Drawing.Point(12, 191);
            this.btnRecipient.Name = "btnRecipient";
            this.btnRecipient.Size = new System.Drawing.Size(75, 23);
            this.btnRecipient.TabIndex = 4;
            this.btnRecipient.Text = "Příjemce";
            this.btnRecipient.UseVisualStyleBackColor = true;
            this.btnRecipient.Click += new System.EventHandler(this.btnRecipient_Click);
            // 
            // gridAC
            // 
            this.gridAC.AllowUserToAddRows = false;
            this.gridAC.AllowUserToDeleteRows = false;
            this.gridAC.AllowUserToResizeColumns = false;
            this.gridAC.AllowUserToResizeRows = false;
            this.gridAC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAC.ColumnHeadersVisible = false;
            this.gridAC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hint});
            this.gridAC.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridAC.Location = new System.Drawing.Point(99, 12);
            this.gridAC.Name = "gridAC";
            this.gridAC.RowHeadersVisible = false;
            this.gridAC.Size = new System.Drawing.Size(173, 238);
            this.gridAC.TabIndex = 5;
            // 
            // hint
            // 
            this.hint.HeaderText = "";
            this.hint.Name = "hint";
            // 
            // AutocompleteSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.gridAC);
            this.Controls.Add(this.btnRecipient);
            this.Controls.Add(this.btnContent);
            this.Controls.Add(this.btnName);
            this.Controls.Add(this.btnNote);
            this.Controls.Add(this.groupBox1);
            this.Name = "AutocompleteSettingsForm";
            this.Text = "Editace doplňování";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbOutcome;
        private System.Windows.Forms.RadioButton rbIncome;
        private System.Windows.Forms.Button btnNote;
        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.Button btnContent;
        private System.Windows.Forms.Button btnRecipient;
        private FastDataGridView gridAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn hint;
    }
}
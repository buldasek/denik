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
            this.tabControls = new System.Windows.Forms.TabControl();
            this.tabNote = new System.Windows.Forms.TabPage();
            this.tabName = new System.Windows.Forms.TabPage();
            this.tabFor = new System.Windows.Forms.TabPage();
            this.tabRecipient = new System.Windows.Forms.TabPage();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.gridNote = new Denik.FastDataGridView();
            this.hint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new Denik.FastDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFor = new Denik.FastDataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRecipient = new Denik.FastDataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tabControls.SuspendLayout();
            this.tabNote.SuspendLayout();
            this.tabName.SuspendLayout();
            this.tabFor.SuspendLayout();
            this.tabRecipient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecipient)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbOutcome);
            this.groupBox1.Controls.Add(this.rbIncome);
            this.groupBox1.Location = new System.Drawing.Point(247, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(81, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.btnNote.Location = new System.Drawing.Point(274, 227);
            this.btnNote.Name = "btnNote";
            this.btnNote.Size = new System.Drawing.Size(75, 23);
            this.btnNote.TabIndex = 1;
            this.btnNote.Text = "Poznámka";
            this.btnNote.UseVisualStyleBackColor = true;
            this.btnNote.Visible = false;
            this.btnNote.Click += new System.EventHandler(this.btnNote_Click);
            // 
            // btnName
            // 
            this.btnName.Location = new System.Drawing.Point(274, 256);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(75, 23);
            this.btnName.TabIndex = 2;
            this.btnName.Text = "Jméno";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Visible = false;
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // btnContent
            // 
            this.btnContent.Location = new System.Drawing.Point(274, 285);
            this.btnContent.Name = "btnContent";
            this.btnContent.Size = new System.Drawing.Size(75, 23);
            this.btnContent.TabIndex = 3;
            this.btnContent.Text = "Účel";
            this.btnContent.UseVisualStyleBackColor = true;
            this.btnContent.Visible = false;
            this.btnContent.Click += new System.EventHandler(this.btnContent_Click);
            // 
            // btnRecipient
            // 
            this.btnRecipient.Location = new System.Drawing.Point(274, 314);
            this.btnRecipient.Name = "btnRecipient";
            this.btnRecipient.Size = new System.Drawing.Size(75, 23);
            this.btnRecipient.TabIndex = 4;
            this.btnRecipient.Text = "Příjemce";
            this.btnRecipient.UseVisualStyleBackColor = true;
            this.btnRecipient.Visible = false;
            this.btnRecipient.Click += new System.EventHandler(this.btnRecipient_Click);
            // 
            // tabControls
            // 
            this.tabControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControls.Controls.Add(this.tabNote);
            this.tabControls.Controls.Add(this.tabName);
            this.tabControls.Controls.Add(this.tabFor);
            this.tabControls.Controls.Add(this.tabRecipient);
            this.tabControls.HotTrack = true;
            this.tabControls.Location = new System.Drawing.Point(0, 0);
            this.tabControls.Name = "tabControls";
            this.tabControls.SelectedIndex = 0;
            this.tabControls.Size = new System.Drawing.Size(237, 479);
            this.tabControls.TabIndex = 6;
            // 
            // tabNote
            // 
            this.tabNote.Controls.Add(this.gridNote);
            this.tabNote.Location = new System.Drawing.Point(4, 22);
            this.tabNote.Name = "tabNote";
            this.tabNote.Padding = new System.Windows.Forms.Padding(3);
            this.tabNote.Size = new System.Drawing.Size(229, 453);
            this.tabNote.TabIndex = 0;
            this.tabNote.Text = "Poznámka";
            this.tabNote.UseVisualStyleBackColor = true;
            // 
            // tabName
            // 
            this.tabName.Controls.Add(this.gridName);
            this.tabName.Location = new System.Drawing.Point(4, 22);
            this.tabName.Name = "tabName";
            this.tabName.Padding = new System.Windows.Forms.Padding(3);
            this.tabName.Size = new System.Drawing.Size(229, 453);
            this.tabName.TabIndex = 1;
            this.tabName.Text = "Jméno";
            this.tabName.UseVisualStyleBackColor = true;
            // 
            // tabFor
            // 
            this.tabFor.Controls.Add(this.gridFor);
            this.tabFor.Location = new System.Drawing.Point(4, 22);
            this.tabFor.Name = "tabFor";
            this.tabFor.Size = new System.Drawing.Size(229, 453);
            this.tabFor.TabIndex = 2;
            this.tabFor.Text = "Účel";
            this.tabFor.UseVisualStyleBackColor = true;
            // 
            // tabRecipient
            // 
            this.tabRecipient.Controls.Add(this.gridRecipient);
            this.tabRecipient.Location = new System.Drawing.Point(4, 22);
            this.tabRecipient.Name = "tabRecipient";
            this.tabRecipient.Size = new System.Drawing.Size(229, 453);
            this.tabRecipient.TabIndex = 3;
            this.tabRecipient.Text = "Příjemce";
            this.tabRecipient.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSelected.Location = new System.Drawing.Point(247, 89);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(81, 39);
            this.btnDeleteSelected.TabIndex = 7;
            this.btnDeleteSelected.Text = "Smazat vybrané";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Location = new System.Drawing.Point(247, 447);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(81, 24);
            this.btnFinish.TabIndex = 8;
            this.btnFinish.Text = "Ukončit";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // gridNote
            // 
            this.gridNote.AllowUserToAddRows = false;
            this.gridNote.AllowUserToDeleteRows = false;
            this.gridNote.AllowUserToResizeColumns = false;
            this.gridNote.AllowUserToResizeRows = false;
            this.gridNote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNote.ColumnHeadersVisible = false;
            this.gridNote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hint});
            this.gridNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNote.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridNote.Location = new System.Drawing.Point(3, 3);
            this.gridNote.Name = "gridNote";
            this.gridNote.RowHeadersVisible = false;
            this.gridNote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridNote.Size = new System.Drawing.Size(223, 447);
            this.gridNote.TabIndex = 5;
            this.gridNote.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNote_CellContentClick);
            // 
            // hint
            // 
            this.hint.HeaderText = "";
            this.hint.Name = "hint";
            // 
            // gridName
            // 
            this.gridName.AllowUserToAddRows = false;
            this.gridName.AllowUserToDeleteRows = false;
            this.gridName.AllowUserToResizeColumns = false;
            this.gridName.AllowUserToResizeRows = false;
            this.gridName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridName.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridName.ColumnHeadersVisible = false;
            this.gridName.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.gridName.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridName.Location = new System.Drawing.Point(0, 0);
            this.gridName.Name = "gridName";
            this.gridName.RowHeadersVisible = false;
            this.gridName.Size = new System.Drawing.Size(229, 457);
            this.gridName.TabIndex = 6;
            this.gridName.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridName_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // gridFor
            // 
            this.gridFor.AllowUserToAddRows = false;
            this.gridFor.AllowUserToDeleteRows = false;
            this.gridFor.AllowUserToResizeColumns = false;
            this.gridFor.AllowUserToResizeRows = false;
            this.gridFor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFor.ColumnHeadersVisible = false;
            this.gridFor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.gridFor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridFor.Location = new System.Drawing.Point(0, 0);
            this.gridFor.Name = "gridFor";
            this.gridFor.RowHeadersVisible = false;
            this.gridFor.Size = new System.Drawing.Size(229, 453);
            this.gridFor.TabIndex = 6;
            this.gridFor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFor_CellContentClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // gridRecipient
            // 
            this.gridRecipient.AllowUserToAddRows = false;
            this.gridRecipient.AllowUserToDeleteRows = false;
            this.gridRecipient.AllowUserToResizeColumns = false;
            this.gridRecipient.AllowUserToResizeRows = false;
            this.gridRecipient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRecipient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRecipient.ColumnHeadersVisible = false;
            this.gridRecipient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            this.gridRecipient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRecipient.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRecipient.Location = new System.Drawing.Point(0, 0);
            this.gridRecipient.Name = "gridRecipient";
            this.gridRecipient.RowHeadersVisible = false;
            this.gridRecipient.Size = new System.Drawing.Size(229, 453);
            this.gridRecipient.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // AutocompleteSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 479);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.btnRecipient);
            this.Controls.Add(this.btnNote);
            this.Controls.Add(this.btnContent);
            this.Controls.Add(this.tabControls);
            this.Controls.Add(this.btnName);
            this.Controls.Add(this.groupBox1);
            this.Name = "AutocompleteSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editace doplňování";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControls.ResumeLayout(false);
            this.tabNote.ResumeLayout(false);
            this.tabName.ResumeLayout(false);
            this.tabFor.ResumeLayout(false);
            this.tabRecipient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecipient)).EndInit();
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
        private FastDataGridView gridNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn hint;
        private System.Windows.Forms.TabControl tabControls;
        private System.Windows.Forms.TabPage tabNote;
        private System.Windows.Forms.TabPage tabName;
        private System.Windows.Forms.TabPage tabFor;
        private System.Windows.Forms.TabPage tabRecipient;
        private FastDataGridView gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private FastDataGridView gridFor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private FastDataGridView gridRecipient;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnFinish;
    }
}
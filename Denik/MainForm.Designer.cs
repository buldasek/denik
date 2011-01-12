namespace Denik
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vytvořitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otevřítDeníkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.změnitJménoDeníkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.printerSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tiskDeníkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveníToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveníDeníkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nasteveníRazítkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveníDoplňováníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIncome = new System.Windows.Forms.Button();
            this.btnExpense = new System.Windows.Forms.Button();
            this.lbPageId = new System.Windows.Forms.Label();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.saveDialogDiary = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gridHistory = new Denik.FastDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incomes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expenses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.nastaveníToolStripMenuItem1});
            resources.ApplyResources(this.mainMenu, "mainMenu");
            this.mainMenu.Name = "mainMenu";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vytvořitToolStripMenuItem,
            this.otevřítDeníkToolStripMenuItem,
            this.změnitJménoDeníkuToolStripMenuItem,
            this.toolStripMenuItem1,
            this.printerSettings,
            this.tiskDeníkuToolStripMenuItem,
            this.toolStripMenuItem2,
            this.konecToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            resources.ApplyResources(this.souborToolStripMenuItem, "souborToolStripMenuItem");
            // 
            // vytvořitToolStripMenuItem
            // 
            this.vytvořitToolStripMenuItem.Name = "vytvořitToolStripMenuItem";
            resources.ApplyResources(this.vytvořitToolStripMenuItem, "vytvořitToolStripMenuItem");
            this.vytvořitToolStripMenuItem.Click += new System.EventHandler(this.vytvořitToolStripMenuItem_Click);
            // 
            // otevřítDeníkToolStripMenuItem
            // 
            this.otevřítDeníkToolStripMenuItem.Name = "otevřítDeníkToolStripMenuItem";
            resources.ApplyResources(this.otevřítDeníkToolStripMenuItem, "otevřítDeníkToolStripMenuItem");
            this.otevřítDeníkToolStripMenuItem.Click += new System.EventHandler(this.otevřítDeníkToolStripMenuItem_Click);
            // 
            // změnitJménoDeníkuToolStripMenuItem
            // 
            this.změnitJménoDeníkuToolStripMenuItem.Name = "změnitJménoDeníkuToolStripMenuItem";
            resources.ApplyResources(this.změnitJménoDeníkuToolStripMenuItem, "změnitJménoDeníkuToolStripMenuItem");
            this.změnitJménoDeníkuToolStripMenuItem.Click += new System.EventHandler(this.změnitJménoDeníkuToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // printerSettings
            // 
            this.printerSettings.Name = "printerSettings";
            resources.ApplyResources(this.printerSettings, "printerSettings");
            this.printerSettings.Click += new System.EventHandler(this.printerSettings_Click);
            // 
            // tiskDeníkuToolStripMenuItem
            // 
            this.tiskDeníkuToolStripMenuItem.Name = "tiskDeníkuToolStripMenuItem";
            resources.ApplyResources(this.tiskDeníkuToolStripMenuItem, "tiskDeníkuToolStripMenuItem");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            resources.ApplyResources(this.konecToolStripMenuItem, "konecToolStripMenuItem");
            this.konecToolStripMenuItem.Click += new System.EventHandler(this.konecToolStripMenuItem_Click);
            // 
            // nastaveníToolStripMenuItem1
            // 
            this.nastaveníToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nastaveníDeníkuToolStripMenuItem,
            this.nasteveníRazítkaToolStripMenuItem,
            this.nastaveníDoplňováníToolStripMenuItem});
            this.nastaveníToolStripMenuItem1.Name = "nastaveníToolStripMenuItem1";
            resources.ApplyResources(this.nastaveníToolStripMenuItem1, "nastaveníToolStripMenuItem1");
            // 
            // nastaveníDeníkuToolStripMenuItem
            // 
            this.nastaveníDeníkuToolStripMenuItem.Name = "nastaveníDeníkuToolStripMenuItem";
            resources.ApplyResources(this.nastaveníDeníkuToolStripMenuItem, "nastaveníDeníkuToolStripMenuItem");
            this.nastaveníDeníkuToolStripMenuItem.Click += new System.EventHandler(this.nastaveníDeníkuToolStripMenuItem_Click);
            // 
            // nasteveníRazítkaToolStripMenuItem
            // 
            this.nasteveníRazítkaToolStripMenuItem.Name = "nasteveníRazítkaToolStripMenuItem";
            resources.ApplyResources(this.nasteveníRazítkaToolStripMenuItem, "nasteveníRazítkaToolStripMenuItem");
            this.nasteveníRazítkaToolStripMenuItem.Click += new System.EventHandler(this.nasteveníRazítkaToolStripMenuItem_Click);
            // 
            // nastaveníDoplňováníToolStripMenuItem
            // 
            this.nastaveníDoplňováníToolStripMenuItem.Name = "nastaveníDoplňováníToolStripMenuItem";
            resources.ApplyResources(this.nastaveníDoplňováníToolStripMenuItem, "nastaveníDoplňováníToolStripMenuItem");
            this.nastaveníDoplňováníToolStripMenuItem.Click += new System.EventHandler(this.nastaveníDoplňováníToolStripMenuItem_Click);
            // 
            // btnIncome
            // 
            resources.ApplyResources(this.btnIncome, "btnIncome");
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // btnExpense
            // 
            resources.ApplyResources(this.btnExpense, "btnExpense");
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.UseVisualStyleBackColor = true;
            this.btnExpense.Click += new System.EventHandler(this.btnExpense_Click);
            // 
            // lbPageId
            // 
            resources.ApplyResources(this.lbPageId, "lbPageId");
            this.lbPageId.Name = "lbPageId";
            // 
            // btnPrevPage
            // 
            resources.ApplyResources(this.btnPrevPage, "btnPrevPage");
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnNextPage
            // 
            resources.ApplyResources(this.btnNextPage, "btnNextPage");
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // saveDialogDiary
            // 
            resources.ApplyResources(this.saveDialogDiary, "saveDialogDiary");
            this.saveDialogDiary.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // gridHistory
            // 
            this.gridHistory.AllowUserToAddRows = false;
            this.gridHistory.AllowUserToDeleteRows = false;
            this.gridHistory.AllowUserToResizeRows = false;
            resources.ApplyResources(this.gridHistory, "gridHistory");
            this.gridHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridHistory.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.checkNumber,
            this.content,
            this.incomes,
            this.expenses,
            this.remain,
            this.note});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridHistory.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridHistory.MultiSelect = false;
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridHistory.RowHeadersVisible = false;
            this.gridHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridHistory_CellMouseUp);
            this.gridHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHistory_CellDoubleClick);
            this.gridHistory.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridHistory_CellMouseDown);
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.FillWeight = 40F;
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.FillWeight = 50F;
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // checkNumber
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.checkNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.checkNumber.FillWeight = 50F;
            resources.ApplyResources(this.checkNumber, "checkNumber");
            this.checkNumber.Name = "checkNumber";
            this.checkNumber.ReadOnly = true;
            // 
            // content
            // 
            this.content.FillWeight = 300F;
            resources.ApplyResources(this.content, "content");
            this.content.Name = "content";
            this.content.ReadOnly = true;
            // 
            // incomes
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.incomes.DefaultCellStyle = dataGridViewCellStyle5;
            this.incomes.FillWeight = 80F;
            resources.ApplyResources(this.incomes, "incomes");
            this.incomes.Name = "incomes";
            this.incomes.ReadOnly = true;
            // 
            // expenses
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.expenses.DefaultCellStyle = dataGridViewCellStyle6;
            this.expenses.FillWeight = 80F;
            resources.ApplyResources(this.expenses, "expenses");
            this.expenses.Name = "expenses";
            this.expenses.ReadOnly = true;
            // 
            // remain
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.remain.DefaultCellStyle = dataGridViewCellStyle7;
            this.remain.FillWeight = 90F;
            resources.ApplyResources(this.remain, "remain");
            this.remain.Name = "remain";
            this.remain.ReadOnly = true;
            // 
            // note
            // 
            this.note.FillWeight = 150F;
            resources.ApplyResources(this.note, "note");
            this.note.Name = "note";
            this.note.ReadOnly = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.btnExpense);
            this.Controls.Add(this.lbPageId);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnIncome);
            this.Controls.Add(this.gridHistory);
            this.Controls.Add(this.btnPrevPage);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vytvořitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otevřítDeníkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem změnitJménoDeníkuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tiskDeníkuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem;
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Button btnExpense;
        private System.Windows.Forms.Label lbPageId;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private FastDataGridView gridHistory;
        public System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripMenuItem printerSettings;
        private System.Windows.Forms.ToolStripMenuItem nastaveníToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nastaveníDeníkuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nasteveníRazítkaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nastaveníDoplňováníToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveDialogDiary;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn content;
        private System.Windows.Forms.DataGridViewTextBoxColumn incomes;
        private System.Windows.Forms.DataGridViewTextBoxColumn expenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn remain;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;

    }
}


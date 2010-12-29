namespace Denik
{
    partial class outcomeForm
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
            this.btnPrintTwice = new System.Windows.Forms.Button();
            this.cbNoteToNumber = new System.Windows.Forms.ComboBox();
            this.cbOther = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.edDate = new System.Windows.Forms.TextBox();
            this.edMoney = new System.Windows.Forms.TextBox();
            this.edNote = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbContent = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrintTwice
            // 
            this.btnPrintTwice.Location = new System.Drawing.Point(94, 300);
            this.btnPrintTwice.Name = "btnPrintTwice";
            this.btnPrintTwice.Size = new System.Drawing.Size(74, 39);
            this.btnPrintTwice.TabIndex = 39;
            this.btnPrintTwice.Text = "Tisk dvakrát";
            this.btnPrintTwice.UseVisualStyleBackColor = true;
            this.btnPrintTwice.Click += new System.EventHandler(this.btnPrintTwice_Click);
            // 
            // cbNoteToNumber
            // 
            this.cbNoteToNumber.AutoCompleteCustomSource.AddRange(new string[] {
            "ddddf"});
            this.cbNoteToNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbNoteToNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNoteToNumber.FormattingEnabled = true;
            this.cbNoteToNumber.Location = new System.Drawing.Point(221, 41);
            this.cbNoteToNumber.Name = "cbNoteToNumber";
            this.cbNoteToNumber.Size = new System.Drawing.Size(128, 21);
            this.cbNoteToNumber.TabIndex = 38;
            // 
            // cbOther
            // 
            this.cbOther.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbOther.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbOther.FormattingEnabled = true;
            this.cbOther.Location = new System.Drawing.Point(159, 268);
            this.cbOther.Name = "cbOther";
            this.cbOther.Size = new System.Drawing.Size(189, 21);
            this.cbOther.TabIndex = 37;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(258, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 39);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Zrušit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(172, 300);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(84, 39);
            this.btnStore.TabIndex = 35;
            this.btnStore.Text = "Uložit";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(16, 300);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 39);
            this.btnPrint.TabIndex = 34;
            this.btnPrint.Text = "Tisk";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // edDate
            // 
            this.edDate.Location = new System.Drawing.Point(116, 70);
            this.edDate.Name = "edDate";
            this.edDate.Size = new System.Drawing.Size(233, 20);
            this.edDate.TabIndex = 33;
            // 
            // edMoney
            // 
            this.edMoney.Location = new System.Drawing.Point(116, 100);
            this.edMoney.Name = "edMoney";
            this.edMoney.Size = new System.Drawing.Size(233, 20);
            this.edMoney.TabIndex = 32;
            // 
            // edNote
            // 
            this.edNote.Location = new System.Drawing.Point(108, 233);
            this.edNote.Name = "edNote";
            this.edNote.Size = new System.Drawing.Size(241, 20);
            this.edNote.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Příjemce hotovosti:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "Poznámka:";
            // 
            // cbContent
            // 
            this.cbContent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbContent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbContent.FormattingEnabled = true;
            this.cbContent.Location = new System.Drawing.Point(17, 203);
            this.cbContent.Name = "cbContent";
            this.cbContent.Size = new System.Drawing.Size(332, 21);
            this.cbContent.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Účel platby:";
            // 
            // cbFrom
            // 
            this.cbFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFrom.FormattingEnabled = true;
            this.cbFrom.Location = new System.Drawing.Point(18, 151);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(331, 21);
            this.cbFrom.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Vyplaceno komu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Částka:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Datum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Poznámka k číslu dokladu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(13, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 26);
            this.label1.TabIndex = 21;
            this.label1.Text = "Výdajový doklad číslo ";
            // 
            // outcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 350);
            this.Controls.Add(this.btnPrintTwice);
            this.Controls.Add(this.cbNoteToNumber);
            this.Controls.Add(this.cbOther);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.edDate);
            this.Controls.Add(this.edMoney);
            this.Controls.Add(this.edNote);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbContent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "outcomeForm";
            this.Text = "outForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintTwice;
        private System.Windows.Forms.ComboBox cbNoteToNumber;
        private System.Windows.Forms.ComboBox cbOther;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox edDate;
        private System.Windows.Forms.TextBox edMoney;
        private System.Windows.Forms.TextBox edNote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbContent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
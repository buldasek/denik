namespace Denik
{
    partial class incomeForm
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
            this.lbHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.cbContent = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.edNote = new System.Windows.Forms.TextBox();
            this.edMoney = new System.Windows.Forms.TextBox();
            this.edDate = new System.Windows.Forms.TextBox();
            this.cbNoteToNumber = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.Red;
            this.lbHeader.Location = new System.Drawing.Point(12, 9);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(245, 26);
            this.lbHeader.TabIndex = 0;
            this.lbHeader.Text = "Příjmový doklad číslo ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Poznámka k číslu dokladu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Částka:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Přijato od:";
            // 
            // cbFrom
            // 
            this.cbFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFrom.FormattingEnabled = true;
            this.cbFrom.Location = new System.Drawing.Point(17, 158);
            this.cbFrom.MaxLength = 45;
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(331, 21);
            this.cbFrom.TabIndex = 1;
            // 
            // cbContent
            // 
            this.cbContent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbContent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbContent.FormattingEnabled = true;
            this.cbContent.Location = new System.Drawing.Point(16, 210);
            this.cbContent.MaxLength = 32;
            this.cbContent.Name = "cbContent";
            this.cbContent.Size = new System.Drawing.Size(332, 21);
            this.cbContent.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Účel výplaty:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Poznámka:";
            // 
            // edNote
            // 
            this.edNote.Location = new System.Drawing.Point(107, 240);
            this.edNote.MaxLength = 10;
            this.edNote.Name = "edNote";
            this.edNote.Size = new System.Drawing.Size(241, 20);
            this.edNote.TabIndex = 3;
            // 
            // edMoney
            // 
            this.edMoney.Location = new System.Drawing.Point(115, 107);
            this.edMoney.Name = "edMoney";
            this.edMoney.Size = new System.Drawing.Size(233, 20);
            this.edMoney.TabIndex = 0;
            // 
            // edDate
            // 
            this.edDate.Location = new System.Drawing.Point(115, 77);
            this.edDate.MaxLength = 6;
            this.edDate.Name = "edDate";
            this.edDate.Size = new System.Drawing.Size(233, 20);
            this.edDate.TabIndex = 8;
            // 
            // cbNoteToNumber
            // 
            this.cbNoteToNumber.Location = new System.Drawing.Point(220, 48);
            this.cbNoteToNumber.Name = "cbNoteToNumber";
            this.cbNoteToNumber.Size = new System.Drawing.Size(128, 20);
            this.cbNoteToNumber.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(254, 276);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 39);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Zrušit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(153, 276);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(95, 39);
            this.btnStore.TabIndex = 5;
            this.btnStore.Text = "Uložit";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(15, 276);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(132, 39);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Tisk";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // incomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 331);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cbNoteToNumber);
            this.Controls.Add(this.edDate);
            this.Controls.Add(this.edMoney);
            this.Controls.Add(this.edNote);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbContent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbHeader);
            this.Name = "incomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Pokladní deník 2.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.ComboBox cbContent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edNote;
        private System.Windows.Forms.TextBox edMoney;
        private System.Windows.Forms.TextBox edDate;
        private System.Windows.Forms.TextBox cbNoteToNumber;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnPrint;
    }
}
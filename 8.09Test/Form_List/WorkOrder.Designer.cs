
namespace Form_List
{
    partial class JAG
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.btCreate = new System.Windows.Forms.Button();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.cboOoDate = new System.Windows.Forms.GroupBox();
            this.cbodtPic = new System.Windows.Forms.DateTimePicker();
            this.cboPlantCode = new System.Windows.Forms.ComboBox();
            this.txtMaker = new System.Windows.Forms.TextBox();
            this.cboBanCode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.odGrid2 = new System.Windows.Forms.DataGridView();
            this.btDelete = new System.Windows.Forms.Button();
            this.btInsert = new System.Windows.Forms.Button();
            this.cboItemCode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.cboOoDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.odGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("한컴산뜻돋움", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(67, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "작업지시등록";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("한컴산뜻돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(325, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "작업지시번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("한컴산뜻돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(27, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "작업장";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtOrderNo.Location = new System.Drawing.Point(430, 24);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(150, 27);
            this.txtOrderNo.TabIndex = 3;
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("한컴산뜻돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btSearch.Location = new System.Drawing.Point(696, 22);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 36);
            this.btSearch.TabIndex = 5;
            this.btSearch.Text = "조회";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btCreate
            // 
            this.btCreate.Font = new System.Drawing.Font("한컴산뜻돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btCreate.Location = new System.Drawing.Point(778, 22);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(75, 36);
            this.btCreate.TabIndex = 6;
            this.btCreate.Text = "등록";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid1.ColumnHeadersHeight = 29;
            this.Grid1.Location = new System.Drawing.Point(12, 224);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersVisible = false;
            this.Grid1.RowHeadersWidth = 51;
            this.Grid1.RowTemplate.Height = 27;
            this.Grid1.Size = new System.Drawing.Size(926, 261);
            this.Grid1.TabIndex = 7;
            // 
            // cboOoDate
            // 
            this.cboOoDate.BackColor = System.Drawing.Color.OldLace;
            this.cboOoDate.Controls.Add(this.cbodtPic);
            this.cboOoDate.Controls.Add(this.cboPlantCode);
            this.cboOoDate.Controls.Add(this.txtMaker);
            this.cboOoDate.Controls.Add(this.cboItemCode);
            this.cboOoDate.Controls.Add(this.cboBanCode);
            this.cboOoDate.Controls.Add(this.label9);
            this.cboOoDate.Controls.Add(this.label6);
            this.cboOoDate.Controls.Add(this.label4);
            this.cboOoDate.Controls.Add(this.label8);
            this.cboOoDate.Controls.Add(this.label5);
            this.cboOoDate.Controls.Add(this.txtItemName);
            this.cboOoDate.Controls.Add(this.label2);
            this.cboOoDate.Controls.Add(this.label3);
            this.cboOoDate.Controls.Add(this.txtOrderNo);
            this.cboOoDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboOoDate.Location = new System.Drawing.Point(12, 73);
            this.cboOoDate.Name = "cboOoDate";
            this.cboOoDate.Size = new System.Drawing.Size(926, 145);
            this.cboOoDate.TabIndex = 9;
            this.cboOoDate.TabStop = false;
            // 
            // cbodtPic
            // 
            this.cbodtPic.CustomFormat = "yyyy-MM-dd";
            this.cbodtPic.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cbodtPic.Location = new System.Drawing.Point(113, 25);
            this.cbodtPic.Name = "cbodtPic";
            this.cbodtPic.Size = new System.Drawing.Size(150, 25);
            this.cbodtPic.TabIndex = 19;
            this.cbodtPic.Value = new System.DateTime(2022, 8, 22, 0, 0, 0, 0);
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.FormattingEnabled = true;
            this.cboPlantCode.Location = new System.Drawing.Point(113, 97);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(150, 23);
            this.cboPlantCode.TabIndex = 18;
            // 
            // txtMaker
            // 
            this.txtMaker.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMaker.Location = new System.Drawing.Point(430, 64);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(150, 27);
            this.txtMaker.TabIndex = 17;
            // 
            // cboBanCode
            // 
            this.cboBanCode.FormattingEnabled = true;
            this.cboBanCode.Location = new System.Drawing.Point(113, 61);
            this.cboBanCode.Name = "cboBanCode";
            this.cboBanCode.Size = new System.Drawing.Size(150, 23);
            this.cboBanCode.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("한컴산뜻돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(27, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 19);
            this.label9.TabIndex = 10;
            this.label9.Text = "공장";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("한컴산뜻돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(357, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "등록자";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("한컴산뜻돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(650, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "품목코드";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("한컴산뜻돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(27, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 19);
            this.label8.TabIndex = 9;
            this.label8.Text = "등록일자";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("한컴산뜻돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(664, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "품목명";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemName.Location = new System.Drawing.Point(736, 64);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(150, 27);
            this.txtItemName.TabIndex = 8;
            // 
            // odGrid2
            // 
            this.odGrid2.BackgroundColor = System.Drawing.Color.White;
            this.odGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.odGrid2.Location = new System.Drawing.Point(12, 491);
            this.odGrid2.Name = "odGrid2";
            this.odGrid2.RowHeadersWidth = 51;
            this.odGrid2.RowTemplate.Height = 27;
            this.odGrid2.Size = new System.Drawing.Size(926, 203);
            this.odGrid2.TabIndex = 8;
            // 
            // btDelete
            // 
            this.btDelete.Font = new System.Drawing.Font("한컴산뜻돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btDelete.Location = new System.Drawing.Point(859, 22);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 36);
            this.btDelete.TabIndex = 10;
            this.btDelete.Text = "삭제";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btInsert
            // 
            this.btInsert.Font = new System.Drawing.Font("한컴산뜻돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btInsert.Location = new System.Drawing.Point(615, 22);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(75, 36);
            this.btInsert.TabIndex = 5;
            this.btInsert.Text = "추가";
            this.btInsert.UseVisualStyleBackColor = true;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            // 
            // cboItemCode
            // 
            this.cboItemCode.FormattingEnabled = true;
            this.cboItemCode.Location = new System.Drawing.Point(736, 30);
            this.cboItemCode.Name = "cboItemCode";
            this.cboItemCode.Size = new System.Drawing.Size(150, 23);
            this.cboItemCode.TabIndex = 16;
            // 
            // JAG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 706);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.odGrid2);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.btInsert);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboOoDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(250, 70);
            this.Name = "JAG";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.JAG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.cboOoDate.ResumeLayout(false);
            this.cboOoDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.odGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.GroupBox cboOoDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.DataGridView odGrid2;
        private System.Windows.Forms.ComboBox cboBanCode;
        private System.Windows.Forms.TextBox txtMaker;
        private System.Windows.Forms.ComboBox cboPlantCode;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.DateTimePicker cbodtPic;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.ComboBox cboItemCode;
    }
}
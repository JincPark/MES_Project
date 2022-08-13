
namespace Form_List
{
    partial class ItemMaster
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
            this.label1 = new System.Windows.Forms.Label();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbItem = new System.Windows.Forms.ComboBox();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.btCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btSearch = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(44, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "품목정보관리";
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Location = new System.Drawing.Point(51, 177);
            this.Grid1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 51;
            this.Grid1.RowTemplate.Height = 27;
            this.Grid1.Size = new System.Drawing.Size(726, 341);
            this.Grid1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Tan;
            this.groupBox1.Controls.Add(this.cbItem);
            this.groupBox1.Controls.Add(this.cbItemType);
            this.groupBox1.Controls.Add(this.btCreate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btSearch);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(51, 94);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(726, 58);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // cbItem
            // 
            this.cbItem.FormattingEnabled = true;
            this.cbItem.Location = new System.Drawing.Point(252, 26);
            this.cbItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(106, 20);
            this.cbItem.TabIndex = 8;
            // 
            // cbItemType
            // 
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.Location = new System.Drawing.Point(87, 26);
            this.cbItemType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(106, 20);
            this.cbItemType.TabIndex = 7;
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(569, 24);
            this.btCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(66, 18);
            this.btCreate.TabIndex = 6;
            this.btCreate.Text = "등록";
            this.btCreate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "품목구분";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "품목";
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(498, 24);
            this.btSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(66, 18);
            this.btSearch.TabIndex = 5;
            this.btSearch.Text = "조회";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(363, 25);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(88, 21);
            this.txtItemName.TabIndex = 4;
            // 
            // ItemMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(113)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(831, 565);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ItemMaster";
            this.Text = "ItemMaster";
            this.Load += new System.EventHandler(this.ItemMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbItem;
        private System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox txtItemName;
    }
}
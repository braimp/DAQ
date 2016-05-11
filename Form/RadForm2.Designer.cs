namespace Form
{
    partial class RadForm2
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.EnName = new Telerik.WinControls.UI.RadTextBox();
            this.ChName = new Telerik.WinControls.UI.RadTextBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.labelId = new Telerik.WinControls.UI.RadLabel();
            this.ExpId = new Telerik.WinControls.UI.RadLabel();
            this.ExpText = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.radGridView1);
            this.radGroupBox1.HeaderText = "表达式信息";
            this.radGroupBox1.Location = new System.Drawing.Point(370, 28);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(450, 200);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "表达式信息";
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView1.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(4, 31);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.HeaderText = "选择";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "column1";
            gridViewCheckBoxColumn1.Width = 179;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "编号";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "column2";
            gridViewTextBoxColumn1.Width = 68;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "英文";
            gridViewTextBoxColumn2.Name = "column3";
            gridViewTextBoxColumn2.Width = 81;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ChinaName";
            gridViewTextBoxColumn3.HeaderText = "中文";
            gridViewTextBoxColumn3.Name = "column4";
            gridViewTextBoxColumn3.Width = 81;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Exp";
            gridViewTextBoxColumn4.HeaderText = "表达式";
            gridViewTextBoxColumn4.Name = "column5";
            gridViewTextBoxColumn4.Width = 82;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(440, 150);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.Click += new System.EventHandler(this.radGridView1_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(21, 41);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(101, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "采集字段英文名称";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(21, 77);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(101, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "采集字段中文名称";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(57, 111);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(65, 18);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "采集表达式";
            // 
            // EnName
            // 
            this.EnName.Location = new System.Drawing.Point(139, 40);
            this.EnName.Name = "EnName";
            this.EnName.Size = new System.Drawing.Size(200, 20);
            this.EnName.TabIndex = 3;
            // 
            // ChName
            // 
            this.ChName.Location = new System.Drawing.Point(139, 77);
            this.ChName.Name = "ChName";
            this.ChName.Size = new System.Drawing.Size(200, 20);
            this.ChName.TabIndex = 4;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(139, 234);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 6;
            this.radButton1.Text = "保存";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // labelId
            // 
            this.labelId.Location = new System.Drawing.Point(57, 13);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(2, 2);
            this.labelId.TabIndex = 7;
            this.labelId.Visible = false;
            // 
            // ExpId
            // 
            this.ExpId.Location = new System.Drawing.Point(182, 16);
            this.ExpId.Name = "ExpId";
            this.ExpId.Size = new System.Drawing.Size(2, 2);
            this.ExpId.TabIndex = 8;
            this.ExpId.Visible = false;
            // 
            // ExpText
            // 
            this.ExpText.AutoSize = false;
            this.ExpText.Location = new System.Drawing.Point(139, 111);
            this.ExpText.Multiline = true;
            this.ExpText.Name = "ExpText";
            this.ExpText.Size = new System.Drawing.Size(200, 81);
            this.ExpText.TabIndex = 9;
            // 
            // RadForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 270);
            this.Controls.Add(this.ExpText);
            this.Controls.Add(this.ExpId);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.ChName);
            this.Controls.Add(this.EnName);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "RadForm2";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "表达式";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox EnName;
        private Telerik.WinControls.UI.RadTextBox ChName;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadLabel labelId;
        private Telerik.WinControls.UI.RadLabel ExpId;
        private Telerik.WinControls.UI.RadTextBox ExpText;
    }
}

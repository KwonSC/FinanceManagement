namespace FinanceManagement {
    partial class 재정관리 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.등록 = new System.Windows.Forms.ToolStripMenuItem();
            this.register = new System.Windows.Forms.ToolStripMenuItem();
            this.검색 = new System.Windows.Forms.ToolStripMenuItem();
            this.search = new System.Windows.Forms.ToolStripMenuItem();
            this.환경설정 = new System.Windows.Forms.ToolStripMenuItem();
            this.budgetSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.carryoverSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.테이블1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet1 = new FinanceManagement.Database1DataSet1();
            this.database1DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new FinanceManagement.Database1DataSet();
            this.테이블1TableAdapter = new FinanceManagement.Database1DataSet1TableAdapters.테이블1TableAdapter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.테이블1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일,
            this.등록,
            this.검색,
            this.환경설정});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(700, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일
            // 
            this.파일.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileCreate,
            this.fileOpen});
            this.파일.Name = "파일";
            this.파일.Size = new System.Drawing.Size(43, 20);
            this.파일.Text = "파일";
            // 
            // fileCreate
            // 
            this.fileCreate.Name = "fileCreate";
            this.fileCreate.Size = new System.Drawing.Size(190, 22);
            this.fileCreate.Text = "새 금전출납부 만들기";
            this.fileCreate.Click += new System.EventHandler(this.fileCreate_Click);
            // 
            // fileOpen
            // 
            this.fileOpen.Name = "fileOpen";
            this.fileOpen.Size = new System.Drawing.Size(190, 22);
            this.fileOpen.Text = "다른 금전출납부 열기";
            // 
            // 등록
            // 
            this.등록.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.register});
            this.등록.Name = "등록";
            this.등록.Size = new System.Drawing.Size(43, 20);
            this.등록.Text = "등록";
            // 
            // register
            // 
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(163, 22);
            this.register.Text = "수입 / 지출 등록";
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // 검색
            // 
            this.검색.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.search});
            this.검색.Name = "검색";
            this.검색.Size = new System.Drawing.Size(43, 20);
            this.검색.Text = "검색";
            // 
            // search
            // 
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(154, 22);
            this.search.Text = "수입 지출 검색";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // 환경설정
            // 
            this.환경설정.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.budgetSetting,
            this.carryoverSetting});
            this.환경설정.Name = "환경설정";
            this.환경설정.Size = new System.Drawing.Size(67, 20);
            this.환경설정.Text = "환경설정";
            // 
            // budgetSetting
            // 
            this.budgetSetting.Name = "budgetSetting";
            this.budgetSetting.Size = new System.Drawing.Size(138, 22);
            this.budgetSetting.Text = "예산 설정";
            this.budgetSetting.Click += new System.EventHandler(this.budgetSetting_Click);
            // 
            // carryoverSetting
            // 
            this.carryoverSetting.Name = "carryoverSetting";
            this.carryoverSetting.Size = new System.Drawing.Size(138, 22);
            this.carryoverSetting.Text = "이월금 변경";
            this.carryoverSetting.Click += new System.EventHandler(this.carryoverSetting_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.테이블1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 26);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(408, 204);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // 테이블1BindingSource
            // 
            this.테이블1BindingSource.DataMember = "테이블1";
            this.테이블1BindingSource.DataSource = this.database1DataSet1;
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet1";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // database1DataSetBindingSource
            // 
            this.database1DataSetBindingSource.DataSource = this.database1DataSet;
            this.database1DataSetBindingSource.Position = 0;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // 테이블1TableAdapter
            // 
            this.테이블1TableAdapter.ClearBeforeFill = true;
            // 
            // 재정관리
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 360);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "재정관리";
            this.Text = "Zacchaeus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.재정관리_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.테이블1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일;
        private System.Windows.Forms.ToolStripMenuItem fileCreate;
        private System.Windows.Forms.ToolStripMenuItem fileOpen;
        private System.Windows.Forms.ToolStripMenuItem 등록;
        private System.Windows.Forms.ToolStripMenuItem register;
        private System.Windows.Forms.ToolStripMenuItem 검색;
        private System.Windows.Forms.ToolStripMenuItem search;
        private System.Windows.Forms.ToolStripMenuItem 환경설정;
        private System.Windows.Forms.ToolStripMenuItem budgetSetting;
        private System.Windows.Forms.ToolStripMenuItem carryoverSetting;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource database1DataSetBindingSource;
        private Database1DataSet database1DataSet;
        private Database1DataSet1 database1DataSet1;
        private System.Windows.Forms.BindingSource 테이블1BindingSource;
        private Database1DataSet1TableAdapters.테이블1TableAdapter 테이블1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn field1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn field2DataGridViewTextBoxColumn;
    }
}


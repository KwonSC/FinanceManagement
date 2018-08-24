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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(재정관리));
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sfdCreateDB = new System.Windows.Forms.SaveFileDialog();
            this.openDB = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.fileOpen.Click += new System.EventHandler(this.fileOpen_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(786, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sfdCreateDB
            // 
            this.sfdCreateDB.Filter = "MS Access 파일|*.accdb";
            // 
            // openDB
            // 
            this.openDB.Filter = "MS Access 파일|*.accdb";
            // 
            // 재정관리
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 483);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "재정관리";
            this.Text = "Zacchaeus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SaveFileDialog sfdCreateDB;
        private System.Windows.Forms.OpenFileDialog openDB;
    }
}


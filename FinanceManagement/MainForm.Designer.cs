﻿namespace FinanceManagement {
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.등록 = new System.Windows.Forms.ToolStripMenuItem();
            this.register = new System.Windows.Forms.ToolStripMenuItem();
            this.검색 = new System.Windows.Forms.ToolStripMenuItem();
            this.search = new System.Windows.Forms.ToolStripMenuItem();
            this.환경설정 = new System.Windows.Forms.ToolStripMenuItem();
            this.budgetSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.carryoverSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일
            // 
            this.파일.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileCreate,
            this.fileOpen,
            this.fileDelete});
            this.파일.Name = "파일";
            this.파일.Size = new System.Drawing.Size(51, 24);
            this.파일.Text = "파일";
            // 
            // fileCreate
            // 
            this.fileCreate.Name = "fileCreate";
            this.fileCreate.Size = new System.Drawing.Size(229, 26);
            this.fileCreate.Text = "새 금전출납부 만들기";
            this.fileCreate.Click += new System.EventHandler(this.fileCreate_Click);
            // 
            // fileOpen
            // 
            this.fileOpen.Name = "fileOpen";
            this.fileOpen.Size = new System.Drawing.Size(229, 26);
            this.fileOpen.Text = "다른 금전출납부 열기";
            // 
            // fileDelete
            // 
            this.fileDelete.Name = "fileDelete";
            this.fileDelete.Size = new System.Drawing.Size(229, 26);
            this.fileDelete.Text = "금전출납부 삭제";
            // 
            // 등록
            // 
            this.등록.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.register});
            this.등록.Name = "등록";
            this.등록.Size = new System.Drawing.Size(51, 24);
            this.등록.Text = "등록";
            // 
            // register
            // 
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(195, 26);
            this.register.Text = "수입 / 지출 등록";
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // 검색
            // 
            this.검색.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.search});
            this.검색.Name = "검색";
            this.검색.Size = new System.Drawing.Size(51, 24);
            this.검색.Text = "검색";
            // 
            // search
            // 
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(184, 26);
            this.search.Text = "수입 지출 검색";
            // 
            // 환경설정
            // 
            this.환경설정.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.budgetSetting,
            this.carryoverSetting});
            this.환경설정.Name = "환경설정";
            this.환경설정.Size = new System.Drawing.Size(81, 24);
            this.환경설정.Text = "환경설정";
            // 
            // budgetSetting
            // 
            this.budgetSetting.Name = "budgetSetting";
            this.budgetSetting.Size = new System.Drawing.Size(164, 26);
            this.budgetSetting.Text = "예산 설정";
            // 
            // carryoverSetting
            // 
            this.carryoverSetting.Name = "carryoverSetting";
            this.carryoverSetting.Size = new System.Drawing.Size(164, 26);
            this.carryoverSetting.Text = "이월금 변경";
            // 
            // 재정관리
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "재정관리";
            this.Text = "재정관리";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일;
        private System.Windows.Forms.ToolStripMenuItem fileCreate;
        private System.Windows.Forms.ToolStripMenuItem fileOpen;
        private System.Windows.Forms.ToolStripMenuItem 등록;
        private System.Windows.Forms.ToolStripMenuItem fileDelete;
        private System.Windows.Forms.ToolStripMenuItem register;
        private System.Windows.Forms.ToolStripMenuItem 검색;
        private System.Windows.Forms.ToolStripMenuItem search;
        private System.Windows.Forms.ToolStripMenuItem 환경설정;
        private System.Windows.Forms.ToolStripMenuItem budgetSetting;
        private System.Windows.Forms.ToolStripMenuItem carryoverSetting;
    }
}


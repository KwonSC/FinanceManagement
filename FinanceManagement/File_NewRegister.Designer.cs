namespace FinanceManagement {
    partial class File_NewRegister {
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
            System.Windows.Forms.Button button1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(File_NewRegister));
            this.file_name = new System.Windows.Forms.TextBox();
            this.file_name_l = new System.Windows.Forms.Label();
            this.file_carryover_l = new System.Windows.Forms.Label();
            this.file_carryover = new System.Windows.Forms.TextBox();
            this.sfdCreateDB = new System.Windows.Forms.SaveFileDialog();
            button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(566, 12);
            button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(87, 29);
            button1.TabIndex = 4;
            button1.TabStop = false;
            button1.Text = "확인";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // file_name
            // 
            this.file_name.Location = new System.Drawing.Point(134, 16);
            this.file_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.file_name.Name = "file_name";
            this.file_name.Size = new System.Drawing.Size(191, 25);
            this.file_name.TabIndex = 0;
            // 
            // file_name_l
            // 
            this.file_name_l.AutoSize = true;
            this.file_name_l.Location = new System.Drawing.Point(11, 19);
            this.file_name_l.Name = "file_name_l";
            this.file_name_l.Size = new System.Drawing.Size(127, 15);
            this.file_name_l.TabIndex = 1;
            this.file_name_l.Text = "금전출납부 이름 :";
            // 
            // file_carryover_l
            // 
            this.file_carryover_l.AutoSize = true;
            this.file_carryover_l.Location = new System.Drawing.Point(333, 20);
            this.file_carryover_l.Name = "file_carryover_l";
            this.file_carryover_l.Size = new System.Drawing.Size(102, 15);
            this.file_carryover_l.TabIndex = 3;
            this.file_carryover_l.Text = "초기 이월금 : ";
            // 
            // file_carryover
            // 
            this.file_carryover.Location = new System.Drawing.Point(432, 16);
            this.file_carryover.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.file_carryover.Name = "file_carryover";
            this.file_carryover.Size = new System.Drawing.Size(126, 25);
            this.file_carryover.TabIndex = 2;
            this.file_carryover.Text = "0";
            this.file_carryover.TextChanged += new System.EventHandler(this.file_carryover_TextChanged);
            this.file_carryover.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.file_carryover_KeyPress);
            // 
            // sfdCreateDB
            // 
            this.sfdCreateDB.Filter = "MS Access 파일|*.accdb";
            // 
            // File_NewRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 56);
            this.Controls.Add(button1);
            this.Controls.Add(this.file_carryover_l);
            this.Controls.Add(this.file_carryover);
            this.Controls.Add(this.file_name_l);
            this.Controls.Add(this.file_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "File_NewRegister";
            this.Text = "새 금전출납부 만들기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox file_name;
        private System.Windows.Forms.Label file_name_l;
        private System.Windows.Forms.Label file_carryover_l;
        private System.Windows.Forms.TextBox file_carryover;
        private System.Windows.Forms.SaveFileDialog sfdCreateDB;
    }
}
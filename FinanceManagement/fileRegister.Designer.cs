namespace FinanceManagement {
    partial class FileRegister {
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
            this.file_name_t = new System.Windows.Forms.TextBox();
            this.file_name_l = new System.Windows.Forms.Label();
            this.file_carryover_l = new System.Windows.Forms.Label();
            this.file_carryover_t = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // file_name_t
            // 
            this.file_name_t.Location = new System.Drawing.Point(145, 16);
            this.file_name_t.Name = "file_name_t";
            this.file_name_t.Size = new System.Drawing.Size(192, 25);
            this.file_name_t.TabIndex = 0;
            // 
            // file_name_l
            // 
            this.file_name_l.AutoSize = true;
            this.file_name_l.Location = new System.Drawing.Point(12, 19);
            this.file_name_l.Name = "file_name_l";
            this.file_name_l.Size = new System.Drawing.Size(127, 15);
            this.file_name_l.TabIndex = 1;
            this.file_name_l.Text = "금전출납부 이름 :";
            // 
            // file_carryover_l
            // 
            this.file_carryover_l.AutoSize = true;
            this.file_carryover_l.Location = new System.Drawing.Point(366, 19);
            this.file_carryover_l.Name = "file_carryover_l";
            this.file_carryover_l.Size = new System.Drawing.Size(102, 15);
            this.file_carryover_l.TabIndex = 3;
            this.file_carryover_l.Text = "초기 이월금 : ";
            // 
            // file_carryover_t
            // 
            this.file_carryover_t.Location = new System.Drawing.Point(474, 16);
            this.file_carryover_t.Name = "file_carryover_t";
            this.file_carryover_t.Size = new System.Drawing.Size(126, 25);
            this.file_carryover_t.TabIndex = 2;
            // 
            // file
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 54);
            this.Controls.Add(this.file_carryover_l);
            this.Controls.Add(this.file_carryover_t);
            this.Controls.Add(this.file_name_l);
            this.Controls.Add(this.file_name_t);
            this.Name = "file";
            this.Text = "새 금전출납부 만들기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox file_name_t;
        private System.Windows.Forms.Label file_name_l;
        private System.Windows.Forms.Label file_carryover_l;
        private System.Windows.Forms.TextBox file_carryover_t;
    }
}
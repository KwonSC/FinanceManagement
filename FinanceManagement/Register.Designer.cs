namespace FinanceManagement {
    partial class Register {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.Income = new System.Windows.Forms.Button();
            this.Expenditure = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Note = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Sum = new System.Windows.Forms.TextBox();
            this.Name3 = new System.Windows.Forms.TextBox();
            this.Name2 = new System.Windows.Forms.TextBox();
            this.Name1 = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Income
            // 
            this.Income.Location = new System.Drawing.Point(12, 16);
            this.Income.Name = "Income";
            this.Income.Size = new System.Drawing.Size(69, 62);
            this.Income.TabIndex = 1;
            this.Income.Text = "수입";
            this.Income.UseVisualStyleBackColor = true;
            this.Income.Click += new System.EventHandler(this.Income_Click);
            // 
            // Expenditure
            // 
            this.Expenditure.Location = new System.Drawing.Point(12, 84);
            this.Expenditure.Name = "Expenditure";
            this.Expenditure.Size = new System.Drawing.Size(69, 64);
            this.Expenditure.TabIndex = 2;
            this.Expenditure.Text = "지출";
            this.Expenditure.UseVisualStyleBackColor = true;
            this.Expenditure.Click += new System.EventHandler(this.Expenditure_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.listBox3);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Note);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Sum);
            this.panel1.Controls.Add(this.Name3);
            this.panel1.Controls.Add(this.Name2);
            this.panel1.Controls.Add(this.Name1);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Location = new System.Drawing.Point(88, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 470);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(271, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 12);
            this.label10.TabIndex = 50;
            this.label10.Text = "이름1을 기재하지 않을시 무명으로 등록됨";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 49;
            this.label9.Text = "관";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 12;
            this.listBox3.Location = new System.Drawing.Point(61, 54);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 16);
            this.listBox3.TabIndex = 48;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 312);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(761, 142);
            this.dataGridView1.TabIndex = 47;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(196, 257);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(55, 46);
            this.button6.TabIndex = 46;
            this.button6.Text = "정렬";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(135, 257);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 46);
            this.button5.TabIndex = 45;
            this.button5.Text = "삭제";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(74, 257);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 46);
            this.button4.TabIndex = 44;
            this.button4.Text = "수정";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 257);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 46);
            this.button3.TabIndex = 43;
            this.button3.Text = "저장";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 42;
            this.label8.Text = "항";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 41;
            this.label7.Text = "날짜";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "목";
            // 
            // Note
            // 
            this.Note.Location = new System.Drawing.Point(268, 190);
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(508, 21);
            this.Note.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 38;
            this.label5.Text = "비고";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "금액";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "이름3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "이름2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "이름1";
            // 
            // Sum
            // 
            this.Sum.Location = new System.Drawing.Point(268, 150);
            this.Sum.Name = "Sum";
            this.Sum.Size = new System.Drawing.Size(120, 21);
            this.Sum.TabIndex = 33;
            // 
            // Name3
            // 
            this.Name3.Location = new System.Drawing.Point(61, 229);
            this.Name3.Name = "Name3";
            this.Name3.Size = new System.Drawing.Size(120, 21);
            this.Name3.TabIndex = 32;
            this.Name3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Name2
            // 
            this.Name2.Location = new System.Drawing.Point(61, 190);
            this.Name2.Name = "Name2";
            this.Name2.Size = new System.Drawing.Size(120, 21);
            this.Name2.TabIndex = 31;
            this.Name2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Name1
            // 
            this.Name1.Location = new System.Drawing.Point(61, 150);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(120, 21);
            this.Name1.TabIndex = 30;
            this.Name1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(61, 85);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 16);
            this.listBox2.TabIndex = 29;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(61, 119);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 16);
            this.listBox1.TabIndex = 28;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(61, 17);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 21);
            this.dateTimePicker1.TabIndex = 27;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 497);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Expenditure);
            this.Controls.Add(this.Income);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Register";
            this.Text = "수입 지출 등록";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Income;
        private System.Windows.Forms.Button Expenditure;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Note;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Sum;
        private System.Windows.Forms.TextBox Name3;
        private System.Windows.Forms.TextBox Name2;
        private System.Windows.Forms.TextBox Name1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
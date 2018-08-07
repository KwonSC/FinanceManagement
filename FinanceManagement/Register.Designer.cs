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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Register_choice = new System.Windows.Forms.Label();
            this.imcomePanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.Register_choice);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(6, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(119, 553);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Gulim", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(6, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 93);
            this.button1.TabIndex = 0;
            this.button1.Text = "수입부";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Gulim", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(6, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 93);
            this.button2.TabIndex = 1;
            this.button2.Text = "지출부";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Register_choice
            // 
            this.Register_choice.AutoSize = true;
            this.Register_choice.BackColor = System.Drawing.SystemColors.Info;
            this.Register_choice.Font = new System.Drawing.Font("Gulim", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Register_choice.ForeColor = System.Drawing.Color.Black;
            this.Register_choice.Location = new System.Drawing.Point(33, 7);
            this.Register_choice.Name = "Register_choice";
            this.Register_choice.Size = new System.Drawing.Size(58, 24);
            this.Register_choice.TabIndex = 2;
            this.Register_choice.Text = "선택";
            // 
            // imcomePanel
            // 
            this.imcomePanel.Location = new System.Drawing.Point(131, 46);
            this.imcomePanel.Name = "imcomePanel";
            this.imcomePanel.Size = new System.Drawing.Size(849, 349);
            this.imcomePanel.TabIndex = 1;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.imcomePanel);
            this.Controls.Add(this.panel1);
            this.Name = "Register";
            this.Text = "수입 지출 등록";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Register_choice;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel imcomePanel;
    }
}
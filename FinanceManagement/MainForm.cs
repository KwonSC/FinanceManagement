using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement {
    public partial class 재정관리 : Form {
        string strFilePath;
        public 재정관리() {
            InitializeComponent();
        }

        private void fileCreate_Click(object sender, EventArgs e) {
            if (sfdCreateDB.ShowDialog() == DialogResult.OK) { //실험
                strFilePath = sfdCreateDB.FileName;
                cDBControl cdbc = new cDBControl(strFilePath); 
                cdbc.funcAccessCreate(); 
                cdbc.dbCreate();
                MessageBox.Show(strFilePath + "를 열었습니다.");
            }
        }

        private void register_Click(object sender, EventArgs e) {
            if (strFilePath == null)
            {
                MessageBox.Show("파일을 열여야 합니다.");
            }
            else
            {
                Register form = new Register(strFilePath);
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(250, 200);
                form.Show();
            }
        }

        private void search_Click(object sender, EventArgs e) {
            Search form = new Search();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(250, 200);
            form.Show();
        }

        private void budgetSetting_Click(object sender, EventArgs e) {
            if (strFilePath == null) {
                MessageBox.Show("파일을 열여야 합니다.");
            }
            else {
                Setting_budget form = new Setting_budget(strFilePath);
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(250, 200);
                form.Show();
            }
        }

        private void carryoverSetting_Click(object sender, EventArgs e) {
            Setting_Carryover form = new Setting_Carryover(strFilePath);
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(250, 200);
            form.Show();
        }

        private void fileOpen_Click(object sender, EventArgs e) {
            if (openDB.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                System.IO.StreamReader sr = new System.IO.StreamReader(openDB.FileName);
                strFilePath = openDB.FileName;
                MessageBox.Show(strFilePath+"를 열었습니다.");
                sr.Close();
            }
        }
    }
}

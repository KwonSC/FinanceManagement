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
            if (sfdCreateDB.ShowDialog() == DialogResult.OK) {
                strFilePath = sfdCreateDB.FileName;
                cDBControl cdbc = new cDBControl(strFilePath);
                cdbc.funcAccessCreate();
                cdbc.dbCreate();
                MessageBox.Show(strFilePath + "를 열었습니다.", "Zacchaeus");
            }
        }

        private void register_Click(object sender, EventArgs e) {
            if (strFilePath == null)
            {
                MessageBox.Show("파일을 열여야 합니다.","오류");
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
            if (strFilePath == null) {
                MessageBox.Show("파일을 열여야 합니다.", "오류");
            }
            else {
                Search form = new Search(strFilePath);
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(250, 200);
                form.Show();
            }
        }

        private void budgetSetting_Click(object sender, EventArgs e) {
            if (strFilePath == null) {
                MessageBox.Show("파일을 열여야 합니다.","오류");
            }
            else {
                Setting_budget form = new Setting_budget(strFilePath);
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(250, 200);
                form.Show();
            }
        }

        private void carryoverSetting_Click(object sender, EventArgs e) {
            if (strFilePath == null) {
                MessageBox.Show("파일을 열여야 합니다.", "오류");
            }
            else {
                Setting_Carryover form = new Setting_Carryover(strFilePath);
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(250, 200);
                form.Show();
            }
        }

        private void fileOpen_Click(object sender, EventArgs e) {
            if (openDB.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                try {
                    System.IO.StreamReader sr = new System.IO.StreamReader(openDB.FileName);
                    strFilePath = openDB.FileName;
                    MessageBox.Show(strFilePath+"를 열었습니다.", "Zacchaeus");
                    sr.Close();
                }
                catch (Exception) {
                    MessageBox.Show("파일이 다른곳에서 열려있습니다. 파일을 종료시키십시오","오류");
                }
            }
        }
    }
}

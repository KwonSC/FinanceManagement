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

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void fileCreate_Click(object sender, EventArgs e) {
            if (sfdCreateDB.ShowDialog() == DialogResult.OK) {
                strFilePath = sfdCreateDB.FileName;
                cDBControl cdbc = new cDBControl(strFilePath);  // DBControl 클래스 생성
                cdbc.funcAccessCreate();    // Access DB를 생성
                cdbc.dbCreate();
                
            }
        }

        private void register_Click(object sender, EventArgs e) {
            Register form = new Register(strFilePath);
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(250, 200);
            form.Show();

        }

        private void search_Click(object sender, EventArgs e) {
            Search form = new Search();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(250, 200);
            form.Show();
        }

        private void budgetSetting_Click(object sender, EventArgs e) {
            Setting_budget form = new Setting_budget(strFilePath);
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(250, 200);
            form.Show();
        }

        private void carryoverSetting_Click(object sender, EventArgs e) {
            Setting_Carryover form = new Setting_Carryover();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(250, 200);
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void fileOpen_Click(object sender, EventArgs e) {
            if (openDB.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                System.IO.StreamReader sr = new System.IO.StreamReader(openDB.FileName);
                strFilePath = openDB.FileName;
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }
        }
    }
}

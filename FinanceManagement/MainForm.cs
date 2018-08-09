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
        public 재정관리() {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void fileCreate_Click(object sender, EventArgs e) {
            if (sfdCreateDB.ShowDialog() == DialogResult.OK) {
                string strFilePath = sfdCreateDB.FileName;
                cDBControl cdbc = new cDBControl(strFilePath);  // DBControl 클래스 생성
                cdbc.funcAccessCreate();    // Access DB를 생성
                cdbc.dbOpen();
            }
        }

        private void register_Click(object sender, EventArgs e) {
            Register form = new Register();
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
            Setting_budget form = new Setting_budget();
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
    }
}

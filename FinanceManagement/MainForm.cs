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
            File_NewRegister form = new File_NewRegister();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(100, 100);
            form.Show();
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

        private void 재정관리_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'database1DataSet1.테이블1' table. You can move, or remove it, as needed.
            this.테이블1TableAdapter.Fill(this.database1DataSet1.테이블1);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}

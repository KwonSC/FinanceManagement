using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FinanceManagement {
    public partial class Setting_budget : Form {

        DBHandling currentDB;

        public Setting_budget(String path) {
            InitializeComponent();
            currentDB = new DBHandling(path);

            DataSet dsG = new DataSet();
            DataSet dsH = new DataSet();
            DataSet dsM = new DataSet();
            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";";
            string sql1 = "SELECT * FROM 수입관";
            string sql2 = "SELECT * FROM 수입항";
            string sql3 = "SELECT * FROM 수입목";
            OleDbConnection conn = new OleDbConnection(connStr);
            OleDbDataAdapter adp1 = new OleDbDataAdapter(sql1, conn);
            OleDbDataAdapter adp2 = new OleDbDataAdapter(sql2, conn);
            OleDbDataAdapter adp3 = new OleDbDataAdapter(sql3, conn);
            adp1.Fill(dsG);
            adp2.Fill(dsH);
            adp3.Fill(dsM);
            관data.DataSource = dsG.Tables[0];
            항data.DataSource = dsH.Tables[0];
            목data.DataSource = dsM.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e) {
            String name = "관 추가";
            Setting_budget_add addForm = new Setting_budget_add(name);
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = new Point(250, 300);
            addForm.Show();
        }

        private void button8_Click(object sender, EventArgs e) {
            String name = "항 추가";
            Setting_budget_add addForm = new Setting_budget_add(name);
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = new Point(250, 300);
            addForm.Show();
        }

        private void button11_Click(object sender, EventArgs e) {
            
        }

        private void button4_Click(object sender, EventArgs e) {
            String name = "관 수정";
            Setting_budget_add addForm = new Setting_budget_add(name);
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = new Point(250, 300);
            addForm.Show();
        }

        private void button7_Click(object sender, EventArgs e) {
            String name = "항 수정";
            Setting_budget_add addForm = new Setting_budget_add(name);
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = new Point(250, 300);
            addForm.Show();
        }

        private void button10_Click(object sender, EventArgs e) {

        }

        private void button5_Click(object sender, EventArgs e) {
            String name = "관 삭제";
            Setting_budget_delete deleteForm = new Setting_budget_delete(name);
            deleteForm.StartPosition = FormStartPosition.Manual;
            deleteForm.Location = new Point(250, 300);
            deleteForm.Show();
        }

        private void button6_Click(object sender, EventArgs e) {
            String name = "항 삭제";
            Setting_budget_delete deleteForm = new Setting_budget_delete(name);
            deleteForm.StartPosition = FormStartPosition.Manual;
            deleteForm.Location = new Point(250, 300);
            deleteForm.Show();
        }

        private void button9_Click(object sender, EventArgs e) {

        }
    }
}

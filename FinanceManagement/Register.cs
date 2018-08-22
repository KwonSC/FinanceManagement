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
using System.IO;

namespace FinanceManagement {
    public partial class Register : Form {
        string filepath;
        OleDbDataAdapter adp;
        OleDbDataAdapter adp2;
        DataSet ds;
        DataSet ds2;
        string sql = "SELECT * FROM 수입";
        string sql2 = "SELECT * FROM 지출";
        OleDbConnection conn;
        string connStr;
        DataGridViewCellEventArgs k_i = null;
        DataGridViewCellEventArgs k_e = null;
        int incom_rowcount;
        int expen_rowcount;


        public Register(string path)  {
            filepath = path;
            InitializeComponent();
            load_data();
        }

        public void load_data() {
            ds = new DataSet();
            ds2 = new DataSet();
            DBHandling dbhand = new DBHandling(filepath);
            connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";";
            conn = new OleDbConnection(connStr);
            adp = new OleDbDataAdapter(sql, conn);
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            incom_rowcount = ds.Tables[0].Rows.Count;
            adp2 = new OleDbDataAdapter(sql2, conn);
            adp2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            expen_rowcount = ds2.Tables[0].Rows.Count;
        }
        

        private void button3_Click(object sender, EventArgs e) { //수입 저장
            DBHandling currentDB = new DBHandling(filepath);
            DateTime currentDate = dateTimePicker1.Value.Date;
            if (Sum.Text == String.Empty) {
                MessageBox.Show("금액을 입력해야합니다.");
            }
            else {
                if (Name1.Text == String.Empty) {
                    currentDB.add(incom_rowcount,currentDate, "무명", Name2.Text, Int64.Parse(Sum.Text.Replace(",", "")), Note.Text);
                    Name2.Text = "";
                    Sum.Text = "";
                    Note.Text = "";
                }
                else {
                    currentDB.add(incom_rowcount,currentDate, Name1.Text, Name2.Text, Int64.Parse(Sum.Text.Replace(",", "")), Note.Text);
                    Name1.Text = "";
                    Name2.Text = "";
                    Sum.Text = "";
                    Note.Text = "";
                }
                load_data();
            }
        }

        private void button10_Click(object sender, EventArgs e) { //지출 저장
            DBHandling currentDB = new DBHandling(filepath);
            DateTime currentDate = dateTimePicker2.Value.Date;
            if (Sum2.Text == String.Empty) {
                MessageBox.Show("금액을 입력해야합니다.");
            }
            else {
                currentDB.exp(expen_rowcount,currentDate, Int64.Parse(Sum2.Text.Replace(",","")), Note2.Text);
                Sum2.Text = "";
                Note2.Text = "";
                load_data();
            }
        }

        private void Sum_KeyPress(object sender, KeyPressEventArgs e)  {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))  {  //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            incomepanel.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e) {
            expanel.BringToFront();
        }

        private void Sum2_KeyPress(object sender, KeyPressEventArgs e) {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) {  //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e) { //수입 수정버튼
            if (k_i == null) {
                MessageBox.Show("지정된 자료가 없습니다.");
            }
            else {
                DateTime dt = DateTime.Parse(dataGridView1.Rows[k_i.RowIndex].Cells[1].Value.ToString());
                Register_income_modify form = new Register_income_modify(filepath,k_i.RowIndex,dt,dataGridView1.Rows[k_i.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[k_i.RowIndex].Cells[3].Value.ToString(), dataGridView1.Rows[k_i.RowIndex].Cells[4].Value.ToString(), dataGridView1.Rows[k_i.RowIndex].Cells[5].Value.ToString(),this);
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(250, 200);
                form.Show();
                k_i = null;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            k_i = e;
        }

        private void button9_Click(object sender, EventArgs e) { //지출 수정버튼
            if (k_e == null) {
                MessageBox.Show("지정된 자료가 없습니다.");
            }
            else {
                DateTime dt = DateTime.Parse(dataGridView2.Rows[k_e.RowIndex].Cells[1].Value.ToString());
                Register_expen_modify form = new Register_expen_modify(filepath,k_e.RowIndex,dt, dataGridView2.Rows[k_e.RowIndex].Cells[2].Value.ToString(), dataGridView2.Rows[k_e.RowIndex].Cells[3].Value.ToString(),this);
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(250, 200);
                form.Show();
                k_e = null;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) {
            k_e = e;
        }

        private void button5_Click(object sender, EventArgs e) { //수입 삭제 버튼
            if (k_i == null) {
                MessageBox.Show("지정된 자료가 없습니다.");
            }
            else {
                if (MessageBox.Show("해당 자료를 삭제 하시겠습니까?", "주의", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    DBHandling currentDB = new DBHandling(filepath);
                    currentDB.add_delete(k_i.RowIndex);
                    load_data();
                    k_i = null;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e) { //지출 삭제 버튼
            if (k_e == null) {
                MessageBox.Show("지정된 자료가 없습니다.");
            }
            else {
                if (MessageBox.Show("해당 자료를 삭제 하시겠습니까?", "주의", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    DBHandling currentDB = new DBHandling(filepath);
                    currentDB.exp_delete(k_e.RowIndex);
                    load_data();
                    k_e = null;
                }
            }
        }

        private void Sum_TextChanged(object sender, EventArgs e) { //수입금액 세자리 콤마
            if (Sum.Text != "") {
                string lgsText;
                lgsText = Sum.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                Sum.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                Sum.SelectionStart = Sum.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                Sum.SelectionLength = 0;
            }
        }

        private void Sum2_TextChanged(object sender, EventArgs e) { //지출금액 세자리 콤마
            if (Sum2.Text != "") {
                string lgsText;
                lgsText = Sum2.Text.Replace(",", "");
                Sum2.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                Sum2.SelectionStart = Sum.TextLength; 
                Sum2.SelectionLength = 0;
            }
        }
    }
}

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
        string igwan = "수입관";
        string egwan = "지출관";
        OleDbConnection conn;
        string connStr;
        DataGridViewCellEventArgs k_i = null;
        DataGridViewCellEventArgs k_e = null;
        int incom_rowcount;
        int expen_rowcount;
        DateTime today_date;
        DBHandling dbhand;

        public Register(string path)  {
            filepath = path;
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
            today_date = dateTimePicker1.Value.Date;
            load_data();
            int igwan_count = dbhand.count_row(igwan);
            for (int i = 0; i < igwan_count; i++) {

            }
            int egwan_count = dbhand.count_row(egwan);
            for (int i = 0; i < egwan_count; i++) {

            }
        }

        public void load_data() {
            ds = new DataSet();
            ds2 = new DataSet();
            dbhand = new DBHandling(filepath);
            connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";";
            conn = new OleDbConnection(connStr);
            adp = new OleDbDataAdapter(sql, conn);
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            incom_rowcount = ds.Tables[0].Rows.Count;
            adp2 = new OleDbDataAdapter(sql2, conn);
            adp2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            dataGridView2.Columns[2].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            expen_rowcount = ds2.Tables[0].Rows.Count;
            today_income.Text = dbhand.today_income_sum(today_date).ToString(); //금일수입금액
            today_expend.Text = dbhand.today_expend_sum(today_date).ToString(); //금일지출금액
            all_income.Text = dbhand.all_income_sum(today_date).ToString(); //총 수입 금액
            all_expend.Text = dbhand.all_expend_sum(today_date).ToString(); //총 지출 금액
            today_differ.Text = dbhand.today_difference(today_date).ToString(); //금일차액
            Now_differ.Text = dbhand.all_difference(today_date).ToString(); //총 차액
            yesterday.Text = dbhand.yesterday_sum(today_date.AddDays(-1)).ToString(); //이월금액
        }


        private void button3_Click(object sender, EventArgs e) { //수입 저장
            DBHandling currentDB = new DBHandling(filepath);
            if (Sum.Text == String.Empty) {
                MessageBox.Show("금액을 입력해야합니다.","오류");
            }
            else {
                if (Name1.Text == String.Empty) {
                    currentDB.add(incom_rowcount,today_date, "무명", Name2.Text, Int64.Parse(Sum.Text.Replace(",", "")), Note.Text);
                    Name2.Text = "";
                    Sum.Text = "";
                    Note.Text = "";
                }
                else {
                    currentDB.add(incom_rowcount,today_date, Name1.Text, Name2.Text, Int64.Parse(Sum.Text.Replace(",", "")), Note.Text);
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
            if (Sum2.Text == String.Empty) {
                MessageBox.Show("금액을 입력해야합니다.","오류");
            }
            else {
                currentDB.exp(expen_rowcount,today_date, Int64.Parse(Sum2.Text.Replace(",","")), Note2.Text);
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
                MessageBox.Show("지정된 자료가 없습니다.","오류");
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
                MessageBox.Show("지정된 자료가 없습니다.","오류");
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
                MessageBox.Show("지정된 자료가 없습니다.","오류");
            }
            else {
                if (MessageBox.Show("해당 자료를 삭제 하시겠습니까?", "주의", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    DBHandling currentDB = new DBHandling(filepath);
                    currentDB.add_delete(k_i.RowIndex);
                    if (incom_rowcount != 0) { //1씩 코드 내리기
                        for (int i = k_i.RowIndex + 1; i <= incom_rowcount; i++) {
                            currentDB.add_iterdel(i);
                        }
                    }
                    load_data();
                    k_i = null;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e) { //지출 삭제 버튼
            if (k_e == null) {
                MessageBox.Show("지정된 자료가 없습니다.","오류");
            }
            else {
                if (MessageBox.Show("해당 자료를 삭제 하시겠습니까?", "주의", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    DBHandling currentDB = new DBHandling(filepath);
                    currentDB.exp_delete(k_e.RowIndex);
                    if (expen_rowcount != 0) { //1씩 코드 내리기
                        for (int i = k_e.RowIndex + 1; i <= expen_rowcount; i++) {
                            currentDB.exp_iterdel(i);
                        }
                    }
                    load_data();
                    k_e = null;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) {//종료버튼
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            today_date = dateTimePicker1.Value.Date;
            load_data();
        }
        //----------------------------------------세자리마다 콤마찍기-----------------------------------------------------

        private void Sum_TextChanged(object sender, EventArgs e) { //수입금액 세자리 콤마
            if (Sum.Text != "") {
                string lgsText;
                lgsText = Sum.Text.Replace(",", "");
                Sum.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                Sum.SelectionStart = Sum.TextLength;
                Sum.SelectionLength = 0;
            }
        }

        private void Sum2_TextChanged(object sender, EventArgs e) { //지출금액 세자리 콤마
            if (Sum2.Text != "") {
                string lgsText;
                lgsText = Sum2.Text.Replace(",", "");
                Sum2.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                Sum2.SelectionStart = Sum2.TextLength; 
                Sum2.SelectionLength = 0;
            }
        }

        private void yesterday_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = yesterday.Text.Replace(",", "");
            if (lgsText != "") {
                yesterday.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                yesterday.SelectionStart = yesterday.TextLength;
                yesterday.SelectionLength = 0;
            }
        }

        private void today_income_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = today_income.Text.Replace(",", "");
            if (lgsText != "") {
                today_income.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                today_income.SelectionStart = today_income.TextLength;
                today_income.SelectionLength = 0;
            }
        }

        private void today_expend_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = today_expend.Text.Replace(",", "");
            if (lgsText != "") {
                today_expend.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                today_expend.SelectionStart = today_expend.TextLength;
                today_expend.SelectionLength = 0;
            }
        }

        private void today_differ_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = today_differ.Text.Replace(",", "");
            if (lgsText != "") {
                today_differ.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                today_differ.SelectionStart = today_differ.TextLength;
                today_differ.SelectionLength = 0;
            }
        }

        private void all_income_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = all_income.Text.Replace(",", "");
            if (lgsText != "") {
                all_income.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                all_income.SelectionStart = all_income.TextLength;
                all_income.SelectionLength = 0;
            }
        }

        private void all_expend_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = all_expend.Text.Replace(",", "");
            if (lgsText != "") {
                all_expend.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                all_expend.SelectionStart = all_expend.TextLength;
                all_expend.SelectionLength = 0;
            }
        }

        private void Now_differ_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = Now_differ.Text.Replace(",", "");
            if (lgsText != "") {
                Now_differ.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                Now_differ.SelectionStart = Now_differ.TextLength;
                Now_differ.SelectionLength = 0;
            }
        }

    }
}

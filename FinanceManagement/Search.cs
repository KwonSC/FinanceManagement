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
    public partial class Search : Form {
        string filepath;
        OleDbDataAdapter i_1, i_2, i_3, i_4, e_1, e_2, e_3, e_4;
        string connStr;
        string sql_i_1 = "SELECT * FROM 수입관";
        string sql_i_2 = "SELECT * FROM 수입항";
        string sql_i_3 = "SELECT * FROM 수입목";
        string sql_i_4 = "SELECT * FROM 수입";
        string sql_e_1 = "SELECT * FROM 지출관";
        string sql_e_2 = "SELECT * FROM 지출항";
        string sql_e_3 = "SELECT * FROM 지출목";
        string sql_e_4 = "SELECT * FROM 지출";
        Int64 sumi, sume;
        DataSet ds1, ds2;
        DateTime today = DateTime.Today;
        DateTime rdt,backtime;
        OleDbConnection conn;
        bool power = true;
        
        public Search(string path) { //생성자
            InitializeComponent();
            filepath = path;
            load_data();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            dataGridView2.Columns[8].Visible = false;
            dataGridView2.Columns[9].Visible = false;
            dataGridView2.Columns[10].Visible = false;
            dataGridView2.Columns[11].Visible = false;
            dataGridView2.Columns[12].Visible = false;
            i_week.Checked = true;
            income_date1.Value = set_Sunday(today);
            income_date2.Value = set_Sunday(today).AddDays(6);
            income_date2.Enabled = false;
            e_week.Checked = true;
            expend_date1.Value = set_Sunday(today);
            expend_date2.Value = set_Sunday(today).AddDays(6);
            expend_date2.Enabled = false;
        }

        public void load_data() {
            connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";";
            conn = new OleDbConnection(connStr);
            i_1 = new OleDbDataAdapter(sql_i_1, conn);
            i_2 = new OleDbDataAdapter(sql_i_2, conn);
            i_3 = new OleDbDataAdapter(sql_i_3, conn);
            i_4 = new OleDbDataAdapter(sql_i_4, conn);
            e_1 = new OleDbDataAdapter(sql_e_1, conn);
            e_2 = new OleDbDataAdapter(sql_e_2, conn);
            e_3 = new OleDbDataAdapter(sql_e_3, conn);
            e_4 = new OleDbDataAdapter(sql_e_4, conn);
            ds1 = new DataSet();
            ds2 = new DataSet();
            i_1.Fill(ds1);
            i_2.Fill(ds1);
            i_3.Fill(ds1);
            i_4.Fill(ds1);
            e_1.Fill(ds2);
            e_2.Fill(ds2);
            e_3.Fill(ds2);
            e_4.Fill(ds2);
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView2.DataSource = ds2.Tables[0];
            numberofsearch();
        }

        private void button6_Click(object sender, EventArgs e) { //수입_검색버튼 클릭
            if (income_searchbox.Text == "") {
                load_data();
            }
            else {
                DataView dvi = new DataView(ds1.Tables[0]);
                dvi.RowFilter = string.Format("비고 LIKE '%{0}%'", income_searchbox.Text);
                dataGridView1.DataSource = dvi;
            }
            numberofsearch();
        }

        private void button15_Click(object sender, EventArgs e) { //지출_검색버튼 클릭
            if (expend_searchbox.Text == "") {
                load_data();
            }
            else {
                DataView dve = new DataView(ds2.Tables[0]);
                dve.RowFilter = string.Format("비고 LIKE '%{0}%'", expend_searchbox.Text);
                dataGridView1.DataSource = dve;
            }
            numberofsearch();
        }

        public void numberofsearch() { //검색건수, 합계금액 표시
            sumi = 0;
            sume = 0;
            income_numberofsear.Text = dataGridView1.RowCount.ToString();
            for (int i = 0; i < dataGridView1.RowCount; i++) {
                sumi = sumi + Int64.Parse(dataGridView1.Rows[i].Cells["금액"].Value.ToString());
            }
            income_sumofsear.Text = sumi.ToString();
            expend_numberofsear.Text = dataGridView2.RowCount.ToString();
            for (int i = 0; i < dataGridView2.RowCount; i++) {
                sume = sume + Int64.Parse(dataGridView2.Rows[i].Cells["금액"].Value.ToString());
            }
            expend_sumofsear.Text = sume.ToString();
        }

        private void button7_Click(object sender, EventArgs e) { //수입 << 버튼 클릭
            power = false;
            if (i_week.Checked == true) {
                income_date1.Value = income_date1.Value.AddDays(-21);
                income_date2.Value = income_date2.Value.AddDays(-21);
            }
            else if (i_month.Checked == true) {
                income_date1.Value = set_firstday(income_date1.Value.AddMonths(-3));
                income_date2.Value = set_lastday(income_date2.Value.AddMonths(-3));
            }
            power = true;
        }

        private void button8_Click(object sender, EventArgs e) { //수입 < 버튼클릭
            power = false;
            if (i_week.Checked == true) {
                income_date1.Value = income_date1.Value.AddDays(-7);
                income_date2.Value = income_date2.Value.AddDays(-7);
            }
            else if (i_month.Checked == true) {
                income_date1.Value = set_firstday(income_date1.Value.AddMonths(-1));
                income_date2.Value = set_lastday(income_date2.Value.AddMonths(-1));
            }
            power = true;
        }

        private void button9_Click(object sender, EventArgs e) { //수입  > 버튼 클릭
            power = false;
            if (i_week.Checked == true) {
                income_date1.Value = income_date1.Value.AddDays(7);
                income_date2.Value = income_date2.Value.AddDays(7);
            }
            else if (i_month.Checked == true) {
                income_date1.Value = set_firstday(income_date1.Value.AddMonths(1));
                income_date2.Value = set_lastday(income_date2.Value.AddMonths(1));
            }
            power = true;
        }
        
        private void button10_Click(object sender, EventArgs e) { //수입 >> 버튼 클릭
            power = false;
            if (i_week.Checked == true) {
                income_date1.Value = income_date1.Value.AddDays(21);
                income_date2.Value = income_date2.Value.AddDays(21);
            }
            else if (i_month.Checked == true) {
                income_date1.Value = set_firstday(income_date1.Value.AddMonths(3));
                income_date2.Value = set_lastday(income_date2.Value.AddMonths(3));
            }
            power = true;
        }

        private void button14_Click(object sender, EventArgs e) { //지출 << 클릭
            power = false;
            if (e_week.Checked == true) {
                expend_date1.Value = expend_date1.Value.AddDays(-21);
                expend_date2.Value = expend_date2.Value.AddDays(-21);
            }
            else if (e_month.Checked == true) {
                expend_date1.Value = set_firstday(expend_date1.Value.AddMonths(-3));
                expend_date2.Value = set_lastday(expend_date2.Value.AddMonths(-3));
            }
            power = true;
        }

        private void button13_Click(object sender, EventArgs e) { //지출 < 클릭
            power = false;
            if (e_week.Checked == true) {
                expend_date1.Value = expend_date1.Value.AddDays(-7);
                expend_date2.Value = expend_date2.Value.AddDays(-7);
            }
            else if (e_month.Checked == true) {
                expend_date1.Value = set_firstday(expend_date1.Value.AddMonths(-1));
                expend_date2.Value = set_lastday(expend_date2.Value.AddMonths(-1));
            }
            power = true;
        }

        private void button12_Click(object sender, EventArgs e) { //지출 > 클릭
            power = false;
            if (e_week.Checked == true) {
                expend_date1.Value = expend_date1.Value.AddDays(7);
                expend_date2.Value = expend_date2.Value.AddDays(7);
            }
            else if (e_month.Checked == true) {
                expend_date1.Value = set_firstday(expend_date1.Value.AddMonths(1));
                expend_date2.Value = set_lastday(expend_date2.Value.AddMonths(1));
            }
            power = true;
        }

        private void button11_Click(object sender, EventArgs e) { //지출 >> 클릭
            power = false;
            if (e_week.Checked == true) {
                expend_date1.Value = expend_date1.Value.AddDays(21);
                expend_date2.Value = expend_date2.Value.AddDays(21);
            }
            else if (e_month.Checked == true) {
                expend_date1.Value = set_firstday(expend_date1.Value.AddMonths(3));
                expend_date2.Value = set_lastday(expend_date2.Value.AddMonths(3));
            }
            power = true;
        }

        private void expend_date1_ValueChanged(object sender, EventArgs e) { //지출_날짜 강제변경
            if (power == true) {
                if (i_week.Checked == true) {
                    expend_date1.Value = set_Sunday(expend_date1.Value);
                    expend_date2.Value = expend_date1.Value.AddDays(6);
                }
                else if (i_month.Checked == true) {
                    expend_date1.Value = set_firstday(expend_date1.Value);
                    expend_date2.Value = set_lastday(expend_date1.Value);
                }
            }
        }

        private void income_date1_ValueChanged(object sender, EventArgs e) { //수입_날짜 강제변경
            if (power == true) {
                if (i_week.Checked == true) {
                    income_date1.Value = set_Sunday(income_date1.Value);
                    income_date2.Value = income_date1.Value.AddDays(6);
                }
                else if (i_month.Checked == true) {
                    income_date1.Value = set_firstday(income_date1.Value);
                    income_date2.Value = set_lastday(income_date1.Value);
                }
            }
        }

        private void i_month_CheckedChanged(object sender, EventArgs e) { //수입_월간검색 체크
            power = false;
            income_date1.Value = set_firstday(today);
            income_date2.Value = set_lastday(today);
            income_date2.Enabled = false;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            power = true;
        }

        public DateTime set_lastday(DateTime dt) { //월간검색_강제 월말 변경
            rdt = dt;
            rdt = set_firstday(rdt.AddMonths(1)).AddDays(-1);
            return rdt;
        }

        private void i_week_CheckedChanged(object sender, EventArgs e) { //수입_주간검색 체크
            power = false;
            income_date1.Value = set_Sunday(today);
            income_date2.Value = set_Sunday(today).AddDays(6);
            income_date2.Enabled = false;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            power = true;
        }

        private void i_want_CheckedChanged(object sender, EventArgs e) { //수입_임의지정 체크
            income_date2.Enabled = true;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
        }

        private void e_week_CheckedChanged(object sender, EventArgs e) { //지출_주간검색 체크
            power = false;
            expend_date1.Value = set_Sunday(today);
            expend_date2.Value = set_Sunday(today).AddDays(6);
            expend_date2.Enabled = false;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            power = true;
        }

        private void e_month_CheckedChanged(object sender, EventArgs e) { //지출_월간검색 체크
            power = false;
            expend_date1.Value = set_firstday(today);
            expend_date2.Value = set_lastday(today);
            expend_date2.Enabled = false;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            power = true;
        }

        private void e_want_CheckedChanged(object sender, EventArgs e) { //지출_임의지정 체크
            expend_date2.Enabled = true;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
        }

        

        public DateTime set_firstday(DateTime dt) { //월간검색_강제 1일 변경
            rdt = dt;
            if (rdt.Day != 1) {
                do {
                    rdt = rdt.AddDays(-1);
                } while (rdt.Day != 1);
            }
            return rdt;
        }

        public DateTime set_Sunday(DateTime dt) { //주간검색_강제일요일 변경
            if (dt.DayOfWeek == DayOfWeek.Monday) {
                rdt = dt.AddDays(-1);
            }
            else if (dt.DayOfWeek == DayOfWeek.Tuesday) {
                rdt = dt.AddDays(-2);
            }
            else if (dt.DayOfWeek == DayOfWeek.Wednesday) {
                rdt = dt.AddDays(-3);
            }
            else if (dt.DayOfWeek == DayOfWeek.Thursday) {
                rdt = dt.AddDays(-4);
            }
            else if (dt.DayOfWeek == DayOfWeek.Friday) {
                rdt = dt.AddDays(-5);
            }
            else if (dt.DayOfWeek == DayOfWeek.Saturday) {
                rdt = dt.AddDays(-6);
            }
            return rdt;
        }

        private void button3_Click(object sender, EventArgs e) { //종료버튼
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) { //지출 변환
            expend_panel.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e) { //수입 변환
            income_panel.BringToFront();
        }
        
        private void income_date2_ValueChanged(object sender, EventArgs e) { //수입_date1 < date2 조건
            if (income_date1.Value >= income_date2.Value) {
                MessageBox.Show("날짜범위가 유효하지 않습니다.", "오류");
                income_date2.Value = backtime;
            }
            else {
                backtime = income_date2.Value;
            }
        }


        private void expend_date2_ValueChanged(object sender, EventArgs e) { //지출_date1 < date2 조건
            if (expend_date1.Value >= expend_date2.Value) {
                MessageBox.Show("날짜범위가 유효하지 않습니다.", "오류");
                income_date2.Value = backtime;
            }
            else {
                backtime = income_date2.Value;
            }
        }
    }
}

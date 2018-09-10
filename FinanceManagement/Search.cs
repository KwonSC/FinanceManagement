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
        OleDbDataAdapter i,e;
        string connStr;
        string sql_i = "SELECT * FROM 수입";
        string sql_e = "SELECT * FROM 지출";
        string igwan = "수입관";
        string egwan = "지출관";
        string ihang = "수입항";
        string ehang = "지출항";
        string imok = "수입목";
        string emok = "지출목";
        Int64 sumi, sume;
        DataSet ds1, ds2;
        DateTime today = DateTime.Today;
        DateTime rdt,backtime;
        OleDbConnection conn;
        bool power = true;
        DataView idv,edv;
        int igcode, ihcode, imcode, egcode, ehcode, emcode;
        DBHandling dbhand;

        public Search(string path) { //생성자
            InitializeComponent();
            filepath = path;
            load_data();
            i_week.Checked = true;
            e_week.Checked = true;
            i_viewall.Checked = true;
            e_viewall.Checked = true;
            numberofsearch();
            int igwan_count = dbhand.count_row(igwan);
            for (int i = 1; i <= igwan_count; i++) {
                combo1.Items.Add(dbhand.gwan(igwan, i));
            }
            int egwan_count = dbhand.count_row(egwan);
            for (int i = 1; i <= egwan_count; i++) {
                combo4.Items.Add(dbhand.gwan(egwan, i));
            }
        }

        public void load_data() {
            dbhand = new DBHandling(filepath);
            connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";";
            conn = new OleDbConnection(connStr);
            i = new OleDbDataAdapter(sql_i, conn);
            e = new OleDbDataAdapter(sql_e, conn);
            ds1 = new DataSet();
            ds2 = new DataSet();
            i.Fill(ds1);
            e.Fill(ds2);
            dataGridView1.DataSource = ds1.Tables[0];
            income_date1.Value = set_Sunday(today);
            income_date2.Value = set_Sunday(today).AddDays(6);
            income_date2.Enabled = false;
            between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
            idv = new DataView(ds1.Tables[0]);
            dataGridView2.DataSource = ds2.Tables[0];
            expend_date1.Value = set_Sunday(today);
            expend_date2.Value = set_Sunday(today).AddDays(6);
            expend_date2.Enabled = false;
            between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
            edv = new DataView(ds2.Tables[0]);
            numberofsearch();
        }

        private void combo1_TextChanged(object sender, EventArgs e) { //수입_관선택
            combo2.Items.Clear();
            combo3.Items.Clear();
            igcode = dbhand.get_gwancode(igwan, combo1.Text.ToString());
            int ihang_count = dbhand.count_row(ihang);
            for (int i = 1; i <= ihang_count; i++) {
                if (dbhand.hang(ihang, igcode, i) != "") {
                    combo2.Items.Add(dbhand.hang(ihang, igcode, i));
                }
            }
            if (i_gwan.Checked == true) {
                DataView dvi = idv;
                dvi.RowFilter = "관코드 = " + dbhand.get_gwancode(igwan, combo1.Text);
                dataGridView1.DataSource = dvi;
            }
        }

        private void combo2_TextChanged(object sender, EventArgs e) { //수입_항선택
            combo3.Items.Clear();
            ihcode = dbhand.get_hangcode(ihang, combo2.Text.ToString());
            int imok_count = dbhand.count_row(imok);
            for (int i = 1; i <= imok_count; i++) {
                if (dbhand.mok(imok, igcode, ihcode, i) != "") {
                    combo3.Items.Add(dbhand.mok(imok, igcode, ihcode, i));
                }
            }
            if (i_hang.Checked == true) {
                DataView dvi = idv;
                dvi.RowFilter = "항코드 = " + dbhand.get_hangcode(ihang, combo2.Text);
                dataGridView1.DataSource = dvi;
            }
        }

        private void combo3_TextChanged(object sender, EventArgs e) { //수입_목선택
            imcode = dbhand.get_mokcode(imok, combo3.Text.ToString());
            if (i_mok.Checked == true) {
                DataView dvi = idv;
                dvi.RowFilter = "목코드 = " + dbhand.get_mokcode(imok, combo3.Text);
                dataGridView1.DataSource = dvi;
            }
        }

        private void combo4_TextChanged(object sender, EventArgs e) { //지출_관선택
            combo5.Items.Clear();
            combo6.Items.Clear();
            egcode = dbhand.get_gwancode(egwan, combo4.Text.ToString());
            int ehang_count = dbhand.count_row(ehang);
            for (int i = 1; i <= ehang_count; i++) {
                if (dbhand.hang(ehang, egcode, i) != "") {
                    combo5.Items.Add(dbhand.hang(ehang, egcode, i));
                }
            }
            if (e_gwan.Checked == true) {
                DataView dve = edv;
                dve.RowFilter = "관코드 = " + dbhand.get_gwancode(egwan, combo4.Text);
                dataGridView2.DataSource = dve;
            }
        }

        private void combo5_TextChanged(object sender, EventArgs e) { //지출_항선택
            combo6.Items.Clear();
            ehcode = dbhand.get_hangcode(ehang, combo4.Text.ToString());
            int emok_count = dbhand.count_row(emok);
            for (int i = 1; i <= emok_count; i++) {
                if (dbhand.mok(emok, egcode, ehcode, i) != "") {
                    combo6.Items.Add(dbhand.mok(emok, egcode, ehcode, i));
                }
            }
            if(e_hang.Checked == true) {
                DataView dve = edv;
                dve.RowFilter = "항코드 = " + dbhand.get_hangcode(ehang, combo5.Text);
                dataGridView2.DataSource = dve;
            }
        }

        private void combo6_TextChanged(object sender, EventArgs e) { //지출_목선택
            emcode = dbhand.get_mokcode(emok, combo6.Text.ToString());
            if (e_mok.Checked == true) {
                DataView dve = edv;
                dve.RowFilter = "목코드 = " + dbhand.get_mokcode(emok, combo6.Text);
                dataGridView2.DataSource = dve;
            }
        }

        private void i_gwan_CheckedChanged(object sender, EventArgs e) { //수입_관체크
            if (combo1.Text != "" && i_gwan.Checked == true) {
                DataView dvi = idv;
                dvi.RowFilter = "관코드 = " + dbhand.get_gwancode(igwan, combo1.Text);
                dataGridView1.DataSource = dvi;
            }
        }

        private void i_hang_CheckedChanged(object sender, EventArgs e) { //수입_항체크
            if (combo2.Text != "" && i_hang.Checked == true) {
                DataView dvi = idv;
                dvi.RowFilter = "항코드 = " + dbhand.get_hangcode(ihang, combo2.Text);
                dataGridView1.DataSource = dvi;
            }
        }

        private void i_mok_CheckedChanged(object sender, EventArgs e) { //수입_목체크
            if (combo3.Text != "" && i_mok.Checked == true) {
                DataView dvi = idv;
                dvi.RowFilter = "목코드 = " + dbhand.get_mokcode(imok, combo3.Text);
                dataGridView1.DataSource = dvi;
            }
        }

        private void e_gwan_CheckedChanged(object sender, EventArgs e) { //지출_관체크
            if (combo4.Text != "" && e_gwan.Checked == true) {
                DataView dve = edv;
                dve.RowFilter = "관코드 = " + dbhand.get_gwancode(egwan, combo4.Text);
                dataGridView2.DataSource = dve;
            }
        }

        private void e_hang_CheckedChanged(object sender, EventArgs e) { //지출_항체크
            if (combo5.Text != "" && e_hang.Checked == true) {
                DataView dve = edv;
                dve.RowFilter = "항코드 = " + dbhand.get_hangcode(ehang, combo5.Text);
                dataGridView2.DataSource = dve;
            }
        }

        private void e_mok_CheckedChanged(object sender, EventArgs e) { //지출_목체크
            if (combo6.Text != "" && e_mok.Checked == true) {
                DataView dve = edv;
                dve.RowFilter = "목코드 = " + dbhand.get_mokcode(emok, combo6.Text);
                dataGridView2.DataSource = dve;
            }
        }
        public void numberofsearch() { //검색건수, 합계금액 표시
            dbhand = new DBHandling(filepath);
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
            //------------수입------------
            income_carry.Text = dbhand.yesterday_sum(income_date1.Value.AddDays(-1)).ToString(); //이월금액
            income_income.Text = sumi.ToString(); ; //수입금액
            income_expend.Text = sume.ToString(); ; //지출금액
            income_differ.Text = (sumi - sume).ToString(); ; //현 차액
            income_now.Text = (dbhand.yesterday_sum(income_date1.Value.AddDays(-1)) + (sumi - sume)).ToString(); //현 잔액
            //------------지출-------------------
            expend_carry.Text = dbhand.yesterday_sum(expend_date1.Value.AddDays(-1)).ToString();//이월금액
            expend_income.Text = sumi.ToString(); ; //수입금액
            expend_expend.Text = sume.ToString(); ; //지출금액
            expend_differ.Text = (sumi - sume).ToString(); ; //현 차액
            expend_now.Text = (dbhand.yesterday_sum(income_date1.Value.AddDays(-1)) + (sumi - sume)).ToString(); //현 잔액
        }

        public void add_Days(int a) { //입력하는 수만큼 일 더하기
            income_date1.Value = income_date1.Value.AddDays(a);
            income_date2.Value = income_date2.Value.AddDays(a);
            expend_date1.Value = expend_date1.Value.AddDays(a);
            expend_date2.Value = expend_date2.Value.AddDays(a);
        }

        public void add_Month(int a) { //입력하는 수만큼 달 더하기
            income_date1.Value = set_firstday(income_date1.Value.AddMonths(a));
            income_date2.Value = set_lastday(income_date2.Value.AddMonths(a));
            expend_date1.Value = set_firstday(expend_date1.Value.AddMonths(a));
            expend_date2.Value = set_lastday(expend_date2.Value.AddMonths(a));
        }

        public void between_date(DateTime dt1, DateTime dt2,DataSet ds, DataGridView dgv) { //날짜 사이 검색
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = " (날짜 >= #" + dt1.ToString("MM/dd/yyyy") + "# AND 날짜 <= #" + dt2.ToString("MM/dd/yyyy") + "# ) ";
            dgv.DataSource = dv;
            if (ds == ds1) {
                idv = dv;
            }
            else if (ds == ds2) {
                edv = dv;
            }
        }

        private void button6_Click(object sender, EventArgs e) { //수입_검색버튼 클릭
            if (income_searchbox.Text == "") {
                load_data();
            }
            else {
                DataView dvi = idv;
                dvi.RowFilter = " (날짜 >= #" + income_date1.Value.ToString("MM/dd/yyyy") + "# AND 날짜 <= #" + income_date2.Value.ToString("MM/dd/yyyy") + "# ) "+" AND "+string.Format("(비고 LIKE '%{0}%')", income_searchbox.Text);
                dataGridView1.DataSource = dvi;
            }
            numberofsearch();
        }

        private void button15_Click(object sender, EventArgs e) { //지출_검색버튼 클릭
            if (expend_searchbox.Text == "") {
                load_data();
            }
            else {
                DataView dve = edv;
                dve.RowFilter = " (날짜 >= #" + expend_date1.Value.ToString("MM/dd/yyyy") + "# AND 날짜 <= #" + expend_date2.Value.ToString("MM/dd/yyyy") + "# ) " + " AND " + string.Format("(비고 LIKE '%{0}%')", expend_searchbox.Text);
                dataGridView1.DataSource = dve;
            }
            numberofsearch();
        }


        private void button7_Click(object sender, EventArgs e) { //수입 << 버튼 클릭
            power = false;
            if (i_week.Checked == true) {
                add_Days(-21);
            }
            else if (i_month.Checked == true) {
                add_Month(-3);
            }
            power = true;
            between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
            between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
            numberofsearch();
        }

        private void button8_Click(object sender, EventArgs e) { //수입 < 버튼클릭
            power = false;
            if (i_week.Checked == true) {
                add_Days(-7);
            }
            else if (i_month.Checked == true) {
                add_Month(1);
            }
            power = true;
            between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
            between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
            numberofsearch();
        }

        private void button9_Click(object sender, EventArgs e) { //수입  > 버튼 클릭
            power = false;
            if (i_week.Checked == true) {
                add_Days(7);
            }
            else if (i_month.Checked == true) {
                add_Month(1);
            }
            power = true;
            between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
            between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
            numberofsearch();
        }
        
        private void button10_Click(object sender, EventArgs e) { //수입 >> 버튼 클릭
            power = false;
            if (i_week.Checked == true) {
                add_Days(21);
            }
            else if (i_month.Checked == true) {
                add_Month(3);
            }
            power = true;
            between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
            between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
            numberofsearch();
        }

        private void button14_Click(object sender, EventArgs e) { //지출 << 클릭
            power = false;
            if (e_week.Checked == true) {
                add_Days(-21);
            }
            else if (e_month.Checked == true) {
                add_Month(-3);
            }
            power = true;
            between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
            between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
            numberofsearch();
        }

        private void button13_Click(object sender, EventArgs e) { //지출 < 클릭
            power = false;
            if (e_week.Checked == true) {
                add_Days(-7);
            }
            else if (e_month.Checked == true) {
                add_Month(-1);
            }
            power = true;
            between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
            between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
            numberofsearch();
        }

        private void button12_Click(object sender, EventArgs e) { //지출 > 클릭
            power = false;
            if (e_week.Checked == true) {
                add_Days(7);
            }
            else if (e_month.Checked == true) {
                add_Month(1);
            }
            power = true;
            between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
            between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
            numberofsearch();
        }

        private void button11_Click(object sender, EventArgs e) { //지출 >> 클릭
            power = false;
            if (e_week.Checked == true) {
                add_Days(21);
            }
            else if (e_month.Checked == true) {
                add_Month(3);
            }
            power = true;
            between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
            between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
            numberofsearch();
        }

        private void expend_date1_ValueChanged(object sender, EventArgs e) { //지출_날짜 강제변경
            if (power == true) {
                if (e_week.Checked == true) {
                    income_date1.Value = set_Sunday(expend_date1.Value);
                    income_date2.Value = expend_date1.Value.AddDays(6);
                    expend_date1.Value = set_Sunday(expend_date1.Value);
                    expend_date2.Value = expend_date1.Value.AddDays(6);
                }
                else if (e_month.Checked == true) {
                    income_date1.Value = set_firstday(expend_date1.Value);
                    income_date2.Value = set_lastday(expend_date1.Value);
                    expend_date1.Value = set_firstday(expend_date1.Value);
                    expend_date2.Value = set_lastday(expend_date1.Value);
                }
                between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
                between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
                numberofsearch();
            }
        }

        private void income_date1_ValueChanged(object sender, EventArgs e) { //수입_날짜 강제변경
            if (power == true) {
                if (i_week.Checked == true) {
                    income_date1.Value = set_Sunday(income_date1.Value);
                    income_date2.Value = income_date1.Value.AddDays(6);
                    expend_date1.Value = set_Sunday(income_date1.Value);
                    expend_date2.Value = income_date1.Value.AddDays(6);
                }
                else if (i_month.Checked == true) {
                    income_date1.Value = set_firstday(income_date1.Value);
                    income_date2.Value = set_lastday(income_date1.Value);
                    expend_date1.Value = set_firstday(income_date1.Value);
                    expend_date2.Value = set_lastday(income_date1.Value);
                }
                between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
                between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
                numberofsearch();
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
            rdt = dt;
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
            if (power == true) {
                if (income_date1.Value >= income_date2.Value) {
                    MessageBox.Show("날짜범위가 유효하지 않습니다.", "오류");
                    income_date2.Value = backtime;
                }
                else {
                    backtime = income_date2.Value;
                    between_date(income_date1.Value, income_date2.Value, ds1, dataGridView1);
                    numberofsearch();
                }
            }
        }


        private void expend_date2_ValueChanged(object sender, EventArgs e) { //지출_date1 < date2 조건
            if (power == true) {
                if (expend_date1.Value >= expend_date2.Value) {
                    MessageBox.Show("날짜범위가 유효하지 않습니다.", "오류");
                    income_date2.Value = backtime;
                }
                else {
                    backtime = income_date2.Value;
                    between_date(expend_date1.Value, expend_date2.Value, ds2, dataGridView2);
                    numberofsearch();
                }
            }
        }
        //----------------------------------------세자리마다 콤마찍기-----------------------------------------------------

        private void income_sumofsear_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = income_sumofsear.Text.Replace(",", "");
            if (lgsText != "") {
                income_sumofsear.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                income_sumofsear.SelectionStart = income_sumofsear.TextLength;
                income_sumofsear.SelectionLength = 0;
            }
        }


        private void income_carry_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = income_carry.Text.Replace(",", "");
            if (lgsText != "") {
                income_carry.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                income_carry.SelectionStart = income_carry.TextLength;
                income_carry.SelectionLength = 0;
            }
        }

        private void i_viewall_CheckedChanged(object sender, EventArgs e) { //수입_전체보기 값변경
            if (i_viewall.Checked == true) {
                i_gwan.Enabled = false;
                i_hang.Enabled = false;
                i_mok.Enabled = false;
                combo1.Enabled = false;
                combo2.Enabled = false;
                combo3.Enabled = false;
            }
            else {
                i_gwan.Enabled = true;
                i_hang.Enabled = true;
                i_mok.Enabled = true;
                combo1.Enabled = true;
                combo2.Enabled = true;
                combo3.Enabled = true;
            }
        }

        private void e_viewall_CheckedChanged(object sender, EventArgs e) { //지출_전체보기 값변경
            if (e_viewall.Checked == true) {
                e_gwan.Enabled = false;
                e_hang.Enabled = false;
                e_mok.Enabled = false;
                combo4.Enabled = false;
                combo5.Enabled = false;
                combo6.Enabled = false;
            }
            else {
                e_gwan.Enabled = true;
                e_hang.Enabled = true;
                e_mok.Enabled = true;
                combo4.Enabled = true;
                combo5.Enabled = true;
                combo6.Enabled = true;
            }
        }

        private void income_income_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = income_income.Text.Replace(",", "");
            if (lgsText != "") {
                income_income.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                income_income.SelectionStart = income_income.TextLength;
                income_income.SelectionLength = 0;
            }
        }

        private void income_expend_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = income_expend.Text.Replace(",", "");
            if (lgsText != "") {
                income_expend.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                income_expend.SelectionStart = income_expend.TextLength;
                income_expend.SelectionLength = 0;
            }
        }

        private void income_differ_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = income_differ.Text.Replace(",", "");
            if (lgsText != "") {
                income_differ.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                income_differ.SelectionStart = income_differ.TextLength;
                income_differ.SelectionLength = 0;
            }
        }

        private void income_now_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = income_now.Text.Replace(",", "");
            if (lgsText != "") {
                income_now.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                income_now.SelectionStart = income_now.TextLength;
                income_now.SelectionLength = 0;
            }
        }

        private void expend_sumofsear_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = expend_sumofsear.Text.Replace(",", "");
            if (lgsText != "") {
                expend_sumofsear.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                expend_sumofsear.SelectionStart = expend_sumofsear.TextLength;
                expend_sumofsear.SelectionLength = 0;
            }
        }

        private void expend_carry_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = expend_carry.Text.Replace(",", "");
            if (lgsText != "") {
                expend_carry.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                expend_carry.SelectionStart = expend_carry.TextLength;
                expend_carry.SelectionLength = 0;
            }
        }

        private void expend_income_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = expend_income.Text.Replace(",", "");
            if (lgsText != "") {
                expend_income.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                expend_income.SelectionStart = expend_income.TextLength;
                expend_income.SelectionLength = 0;
            }
        }

        private void expend_expend_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = expend_expend.Text.Replace(",", "");
            if (lgsText != "") {
                expend_expend.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                expend_expend.SelectionStart = expend_expend.TextLength;
                expend_expend.SelectionLength = 0;
            }
        }

        private void expend_differ_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = expend_differ.Text.Replace(",", "");
            if (lgsText != "") {
                expend_differ.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                expend_differ.SelectionStart = expend_differ.TextLength;
                expend_differ.SelectionLength = 0;
            }
        }

        private void expend_now_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = expend_now.Text.Replace(",", "");
            if (lgsText != "") {
                expend_now.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                expend_now.SelectionStart = expend_now.TextLength;
                expend_now.SelectionLength = 0;
            }
        }

    }
}

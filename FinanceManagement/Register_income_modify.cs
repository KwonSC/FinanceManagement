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
    public partial class Register_income_modify : Form {

        Register temp;
        string file;
        int row;
        public Register_income_modify(string path,int rowindex,DateTime dat, string nam1, string nam2, string su, string not, Register rg) {
            InitializeComponent();
            dateTimePicker1.Value = dat;
            name1.Text = nam1;
            name2.Text = nam2;
            sum.Text = su;
            note.Text = not;
            temp = rg;
            file = path;
            row = rowindex;
        }

        private void button2_Click(object sender, EventArgs e) { //취소버튼
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) { //저장버튼
            DBHandling currentDB = new DBHandling(file);
            currentDB.add_modify(row, dateTimePicker1.Value, name1.Text, name2.Text, Int64.Parse(sum.Text.Replace(",","")), note.Text);
            temp.load_data();
            this.Close();
        }

        private void sum_TextChanged(object sender, EventArgs e) {
            if (sum.Text != "") {
                string lgsText;
                lgsText = sum.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                sum.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                sum.SelectionStart = sum.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                sum.SelectionLength = 0;
            }
        }

        private void sum_KeyPress(object sender, KeyPressEventArgs e) {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) {  //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
            }
        }
    }
}

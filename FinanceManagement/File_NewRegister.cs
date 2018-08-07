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
    public partial class File_NewRegister : Form {
        int carryover;

        string name;

        public int get_carryover()
        {
            return carryover;
        }

        public string get_name()
        {
            return name;
        }

        public File_NewRegister() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (file_name.Text == "")
            {
                MessageBox.Show("이름을 입력하시오.","오류");
            }
            else if (file_name.Text.Length > 10)
            {
                MessageBox.Show("이름이 너무 깁니다.", "오류");
            }
            else
            {
                this.name = file_name.Text;
                this.carryover = Int32.Parse(file_carryover.Text);
                this.Close();
            }
        }

        private void file_carryover_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                if (file_carryover.Text == "" && e.KeyChar == Convert.ToChar(Keys.Back))
                {
                    e.Handled = false;
                }
                e.Handled = true;
            }
        }

        private void file_carryover_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            lgsText = file_carryover.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지
            if (file_carryover.Text != "")
            {
                file_carryover.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));
            }
            file_carryover.SelectionStart = file_carryover.TextLength; //** 캐럿을 맨 뒤로 보낸다
            file_carryover.SelectionLength = 0;
        }
    }
}

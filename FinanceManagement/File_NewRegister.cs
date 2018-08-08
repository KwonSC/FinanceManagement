using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADOX;
using System.IO;

namespace FinanceManagement {
    public partial class File_NewRegister : Form {
        int carryover;

        string name;

        public File_NewRegister() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            this.Hide();

            if (sfdCreateDB.ShowDialog() == DialogResult.OK) {
                string strFilePath = sfdCreateDB.FileName;
                cDBControl cdbc = new cDBControl(strFilePath);  // DBControl 클래스 생성
                cdbc.funcAccessCreate();    // Access DB를 생성
            }
        }

        private void file_carryover_KeyPress(object sender, KeyPressEventArgs e) {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                if (file_carryover.Text == "" && e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Back)) {
                    e.Handled = false;
                }
                e.Handled = true;
            }
        }

        private void file_carryover_TextChanged(object sender, EventArgs e) {
            string lgsText;
            lgsText = file_carryover.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지
            file_carryover.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));
            file_carryover.SelectionStart = file_carryover.TextLength; //** 캐럿을 맨 뒤로 보낸다
            file_carryover.SelectionLength = 0;
        }
    }
}

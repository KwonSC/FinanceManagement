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
    public partial class Setting_Carryover : Form {

        DBHandling currentDB;

        public Setting_Carryover(String path) {
            InitializeComponent();
            currentDB = new DBHandling(path);
            carryOverText.Text = currentDB.carryover().ToString();
        }

        private void confirm_Click(object sender, EventArgs e) {
            currentDB.carryOverAdd(Int64.Parse(carryOverText.Text.Replace(",", "")));
            Setting_Carryover.ActiveForm.Close();
        }

        private void cancel_Click(object sender, EventArgs e) {
            Setting_Carryover.ActiveForm.Close();
        }

        private void carryOverText_TextChanged(object sender, EventArgs e) {
            if (carryOverText.Text != "") {
                string lgsText;
                lgsText = carryOverText.Text.Replace(",", "");
                carryOverText.Text = String.Format("{0:#,##0}", Convert.ToInt64(lgsText));
                carryOverText.SelectionStart = carryOverText.TextLength;
                carryOverText.SelectionLength = 0;
            }
        }

        private void carryOverText_KeyPress(object sender, KeyPressEventArgs e) {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) {  //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
            }
        }
    }
}

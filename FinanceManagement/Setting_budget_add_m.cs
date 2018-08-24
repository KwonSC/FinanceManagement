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
    public partial class Setting_budget_add_m : Form {

        String strPath;
        Setting_budget k;
        DBHandling db;

        public Setting_budget_add_m(int code, String name, String path, Setting_budget sb) {
            InitializeComponent();

            strPath = path;
            this.Text = name;
            k = sb;
            sb = new Setting_budget(path);
            db = new DBHandling(strPath);
        }

        private void button1_Click(object sender, EventArgs e) {
            db.addM(name.Text, long.Parse(budget.Text), etc.Text, int.Parse(order.Text));
            k.load_data();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void order_KeyPress(object sender, KeyPressEventArgs e) {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) {  //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
            }
        }

        private void budget_KeyPress(object sender, KeyPressEventArgs e) {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) {  //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
            }
        }
    }
}

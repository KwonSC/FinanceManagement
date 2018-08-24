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
    public partial class Setting_budget_add : Form {

        String strPath;
        String sortName;
        Setting_budget k;
        DBHandling db;
        int codeCount;

        public Setting_budget_add(int code, String name, String path, Setting_budget sb) {
            InitializeComponent();

            strPath = path;
            this.Text = name;
            sortName = name;
            k = sb;
            codeCount = code;
            sb = new Setting_budget(path);
            db = new DBHandling(strPath);
            order.Text = codeCount.ToString();
        }

        public Setting_budget_add(String name, String path, Setting_budget sb) {
            InitializeComponent();

            strPath = path;
            this.Text = name;
            sortName = name;
            k = sb;
            sb = new Setting_budget(path);
            db = new DBHandling(strPath);
            order.Text = codeCount.ToString();
        }

        private bool orderValid(int orderText) {
            if (orderText > codeCount) { // 레코드 수 보다 큰 순서를 입력했을 경우
                MessageBox.Show(codeCount.ToString() + "까지만 입력 가능합니다.");
                return false;
            }
            else if (orderText < codeCount) { // 레코드 중간에 삽입해야 하는 경우
                k.orderSort(sortName, codeCount, orderText);
                return true;
            }
            else // 제일 뒤쪽에 삽입해도 되는 경우
                return true;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (!orderValid(int.Parse(order.Text))) {

            }
            else {
                if (sortName == "관 추가") {
                    db.addG(codeCount, name.Text, int.Parse(order.Text));
                }
                else if (sortName == "항 추가") {
                    db.addH(codeCount, name.Text, int.Parse(order.Text));
                }
                else if (sortName == "관 수정") {
                    
                }
                else { // 항 수정

                }
                k.load_data();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void order_KeyPress(object sender, KeyPressEventArgs e) {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) {  //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
            }
        }

        private void name_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.button1_Click(sender, e); // 특별히 sender 와 e 를 쓰지 않아 입력함
            }
        }

        private void order_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.button1_Click(sender, e); // 특별히 sender 와 e 를 쓰지 않아 입력함
            }
        }
    }
}

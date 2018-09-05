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

        int inner_order; // 목코드
        int mgCode;
        int mhCode;
        int codeCount;
        int currentOrder;
        string currentName;
        string strPath;
        string sortName;
        Setting_budget _sb;
        DBHandling _db;


        public Setting_budget_add_m(int code, int gCode, int hCode, Setting_budget.cellContent content, String name, String path, Setting_budget sb) {
            InitializeComponent();

            this.inner_order = code;
            this.mgCode = gCode;
            this.mhCode = hCode;
            this.codeCount = content.cellCount + 1; // 추가는 1을 추가해야함
            this.currentOrder = content.cellOrder;
            this.currentName = content.cellName;
            this.sortName = name;
            this.strPath = path;
            this._sb = sb;
            this._db = new DBHandling(strPath);

            this.Text = name;
            order.Text = this.codeCount.ToString();
        }

        private bool orderValid(int orderText) {
            if (orderText > codeCount) { // 레코드 수 보다 큰 순서를 입력했을 경우
                MessageBox.Show(codeCount.ToString() + "까지만 입력 가능합니다.");
                return false;
            }
            else if (orderText < codeCount) { // 레코드 중간에 삽입해야 하는 경우
                this._sb.orderSort(sortName, codeCount, orderText, this.currentOrder);
                return true;
            }
            else if ((sortName == "목 수정") && orderText == codeCount) {
                this._sb.orderSort(sortName, codeCount, orderText, this.currentOrder);
                return true;
            }

            else // 제일 뒤쪽에 삽입해도 되는 경우
                return true;
        }

        private bool duplicatedName(string sort, string name) {
            return this._sb.dupName(sort, name);
        }

        private void button1_Click(object sender, EventArgs e) {
            string etc = sortName;

            if (this.duplicatedName(sortName, name_text.Text)) {
                MessageBox.Show("이름이 중복되니 다시 설정하세요");
            }
            else {
                if (!orderValid(int.Parse(order.Text))) {

                }
                else {
                    if (sortName == "목 추가") { /*
                        if (this.codeCount == int.Parse(order.Text)) {
                            etc = "마지막 항 추가";
                        }
                        this._sb.setClickArgs(int.Parse(order.Text));
                        */
                        this._db.addM(inner_order, mgCode, mhCode, name_text.Text, int.Parse(order.Text), Int64.Parse(budget.Text), etcAdd.Text);
                    }
                    /*
                    else if (sortName == "항 수정") {
                        this._sb.setClickArgs(int.Parse(order.Text) - 1);
                        db.altName(sortName, this.currentName, name_text.Text);
                    }*/
                    this._sb.load_data();
                    this._sb.initCell(etc);
                    this.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void order_KeyPress(object sender, KeyPressEventArgs e)     {
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

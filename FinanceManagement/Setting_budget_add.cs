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

        string strPath;
        string sortName;
        Setting_budget _sb;
        DBHandling db;
        int codeCount;
        int hgCode;
        int inner_order;
        int currentOrder;
        string currentName;

        public Setting_budget_add(int code, Setting_budget.cellContent content, string name, string path, Setting_budget sb) { // 관 추가 생성자, 항 수정 생성자
            InitializeComponent();

            strPath = path;
            this.Text = name;
            sortName = name;
            this._sb = sb;
            codeCount = content.maxOrder + 1;
            inner_order = code;
            db = new DBHandling(strPath);
            order.Text = codeCount.ToString();

            if (sortName == "항 수정") {
                name_text.Text = content.cellName;
                order.Text = content.cellOrder.ToString();
            }
        }
        public Setting_budget_add(int code, int gCode, string name, int orderCount, string path, Setting_budget sb) { // 항 추가 생성자
            InitializeComponent();

            strPath = path;
            this.Text = name;
            sortName = name;
            this._sb = sb;
            codeCount = code;
            inner_order = orderCount;
            db = new DBHandling(strPath);
            hgCode = gCode;
            order.Text = orderCount.ToString();
        }

        public Setting_budget_add(string name, Setting_budget.cellContent content, String path, Setting_budget sb) { // 관 수정 생성자
            InitializeComponent();

            strPath = path;
            this.Text = name;
            sortName = name;
            this._sb = sb;
            this.inner_order = content.cellCount;
            this.currentOrder = content.cellOrder;
            this.currentName = content.cellName;
            db = new DBHandling(strPath);

            if (name == "관 수정") {
                name_text.Text = content.cellName;
                order.Text = content.cellOrder.ToString();
            }
            
        }

        private bool orderValid(int orderText) {
            if (orderText > inner_order) { // 레코드 수 보다 큰 순서를 입력했을 경우
                MessageBox.Show(inner_order.ToString() + "까지만 입력 가능합니다.");
                return false;
            }
            else if (orderText < inner_order) { // 레코드 중간에 삽입해야 하는 경우
                this._sb.orderSort(sortName, inner_order, orderText, this.currentOrder);
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
                    db.addG(inner_order, name_text.Text, int.Parse(order.Text));
                }
                else if (sortName == "항 추가") {
                    db.addH(inner_order, hgCode, name_text.Text, int.Parse(order.Text));
                }
                else if (sortName == "관 수정") {
                    db.altName(sortName, this.currentName, name_text.Text);
                }
                this._sb.load_data();
                this._sb.initCell("");
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

        private void name_KeyDown(object sender, KeyEventArgs e){
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

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
    public partial class Setting_budget_delete : Form {

        string strPath;
        string sortName;
        DBHandling _db;
        Setting_budget _sb;
        Setting_budget.cellContent clickContent;

        public Setting_budget_delete(string name, string path, Setting_budget.cellContent content, Setting_budget sb) {
            InitializeComponent();

            strPath = path;
            sortName = name;
            this._db = new DBHandling(strPath);
            this._sb = sb;
            clickContent = content;

            this.Name = name;
            this.label1.Text = "정말 " + content.cellName + " 을(를) 삭제하시겠습니까?";
        }

        private void button1_Click(object sender, EventArgs e) {
            if (sortName == "관 삭제") {
                this._sb.orderSort(sortName, clickContent.cellCount, 0, clickContent.cellOrder);
                this._db.budget_delete("관", clickContent.cellName);
            }
            else if (sortName == "항 삭제") {
                this._sb.orderSort(sortName, clickContent.cellCount, 0, clickContent.cellOrder);
                this._db.budget_delete("항", clickContent.cellName);
            }
            this._sb.load_data();
            this._sb.initCell(sortName);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}

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

        public Setting_budget_add_m(String name, String path, Setting_budget sb) {
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
    }
}

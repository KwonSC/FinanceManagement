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
        }

        private void confirm_Click(object sender, EventArgs e) {
            currentDB.carryOverAdd(long.Parse(carryOverText.Text));
            Setting_Carryover.ActiveForm.Close();
        }

        private void cancel_Click(object sender, EventArgs e) {
            Setting_Carryover.ActiveForm.Close();
        }
    }
}

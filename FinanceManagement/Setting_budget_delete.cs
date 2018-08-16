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
        public Setting_budget_delete(String name) {
            InitializeComponent();

            this.Name = name;
            this.label1.Text = "정말 이름1을 삭제하시겠습니까?";
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}

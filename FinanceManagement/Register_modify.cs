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
    public partial class Register_modify : Form {

        public Register_modify(DateTime dat, string nam1, string nam2, string su, string not) {
            InitializeComponent();
            dateTimePicker1.Value = dat;
            name1.Text = nam1;
            name2.Text = nam2;
            sum.Text = su;
            note.Text = not;
        }

        private void button2_Click(object sender, EventArgs e) { //취소버튼
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) { //저장버튼
            
        }
    }
}

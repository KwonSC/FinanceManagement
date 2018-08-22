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
    public partial class Register_expen_modify : Form {
        Register temp;
        string file;
        int row;
        public Register_expen_modify(string path,int rowindex,DateTime dat, string su, string not, Register rg) {
            InitializeComponent();
            dateTimePicker1.Value = dat;
            sum.Text = su;
            note.Text = not;
            temp = rg;
            file = path;
            row = rowindex;
        }

        private void button2_Click(object sender, EventArgs e) { //취소버튼
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) { //저장버튼
            DBHandling currentDB = new DBHandling(file);
            currentDB.exp_modify(row, dateTimePicker1.Value,Int64.Parse(sum.Text.Replace(",","")), note.Text);
            temp.load_data();
            this.Close();
        }
    }
}

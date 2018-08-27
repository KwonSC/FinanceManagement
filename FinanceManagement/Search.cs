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
    public partial class Search : Form {
        string filepath;
        public Search(string path) {
            InitializeComponent();
            filepath = path;
        }

        private void button3_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            expend_panel.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e) {
            income_panel.BringToFront();
        }
    }
}

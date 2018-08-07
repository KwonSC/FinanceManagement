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
    public partial class 재정관리 : Form {
        public 재정관리() {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void fileCreate_Click(object sender, EventArgs e) {
            File_NewRegister form = new File_NewRegister();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(100, 100);
            form.Show();
        }

        private void register_Click(object sender, EventArgs e) {
            Register form = new Register();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(250, 200);
            form.Show();
        }
    }
}

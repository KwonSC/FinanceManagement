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
using ADOX;
using System.IO;

namespace FinanceManagement {
    public partial class Register : Form {
        DataSet ds = new DataSet();
        static string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Master\Documents\TestData\1.accdb";
        static OleDbConnection conn = new OleDbConnection(connStr);
        static string sql = "SELECT * FROM 수입";
        OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);

        public Register() {
            InitializeComponent();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}

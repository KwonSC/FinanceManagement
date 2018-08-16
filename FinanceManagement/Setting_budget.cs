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
    public partial class Setting_budget : Form {
        public Setting_budget(String path) {
            InitializeComponent();
            DataSet ds = new DataSet();
            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";";
            string sql = "SELECT * FROM 수입관";
            OleDbConnection conn = new OleDbConnection(connStr);
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            adp.Fill(ds);
            관data.DataSource = ds.Tables[0];

        }

        private void 관data_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}

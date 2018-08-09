﻿using System;
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
        string filepath;
        public Register(string path) {
            filepath = path;
            InitializeComponent();
            DataSet ds = new DataSet();
            DBHandling dbhand = new DBHandling(path);
            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";";
            OleDbConnection conn = new OleDbConnection(connStr);
            string sql = "SELECT * FROM 수입";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            DBHandling currentDB = new DBHandling(filepath);
            DateTime currentDate = new DateTime(2018, 09, 03);
            currentDB.add(currentDate, "육근일", 30000, "예비군");
        }
    }
}

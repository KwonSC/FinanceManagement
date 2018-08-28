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
using System.IO;

namespace FinanceManagement {
    public partial class Search : Form {
        string filepath;
        OleDbDataAdapter i_1, i_2, i_3, i_4, e_1, e_2, e_3, e_4;
        string connStr;
        string sql_i_1 = "SELECT * FROM 수입관";
        string sql_i_2 = "SELECT * FROM 수입항";
        string sql_i_3 = "SELECT * FROM 수입목";
        string sql_i_4 = "SELECT * FROM 수입";
        string sql_e_1 = "SELECT * FROM 지출관";
        string sql_e_2 = "SELECT * FROM 지출항";
        string sql_e_3 = "SELECT * FROM 지출목";
        string sql_e_4 = "SELECT * FROM 지출";
        DataSet ds1, ds2;
        OleDbConnection conn;


        public Search(string path) {
            InitializeComponent();
            filepath = path;
            load_data();
        }

        public void load_data() {
            connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";";
            conn = new OleDbConnection(connStr);
            i_1 = new OleDbDataAdapter(sql_i_1, conn);
            i_2 = new OleDbDataAdapter(sql_i_2, conn);
            i_3 = new OleDbDataAdapter(sql_i_3, conn);
            i_4 = new OleDbDataAdapter(sql_i_4, conn);
            e_1 = new OleDbDataAdapter(sql_e_1, conn);
            e_2 = new OleDbDataAdapter(sql_e_2, conn);
            e_3 = new OleDbDataAdapter(sql_e_3, conn);
            e_4 = new OleDbDataAdapter(sql_e_4, conn);
            ds1 = new DataSet();
            ds2 = new DataSet();
            i_1.Fill(ds1);
            i_2.Fill(ds1);
            i_3.Fill(ds1);
            i_4.Fill(ds1);
            e_1.Fill(ds2);
            e_2.Fill(ds2);
            e_3.Fill(ds2);
            e_4.Fill(ds2);
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView2.DataSource = ds2.Tables[0];
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            dataGridView2.Columns[8].Visible = false;
            dataGridView2.Columns[9].Visible = false;
            dataGridView2.Columns[10].Visible = false;
            dataGridView2.Columns[11].Visible = false;
            dataGridView2.Columns[12].Visible = false;
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

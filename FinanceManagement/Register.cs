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
    public partial class Register : Form {
        string filepath;
        OleDbDataAdapter adp;
        OleDbDataAdapter adp2;
        DataSet ds;
        DataSet ds2;
        string sql = "SELECT * FROM 수입";
        string sql2 = "SELECT * FROM 지출";
        OleDbConnection conn;
        string connStr;

        public Register(string path)  {
            filepath = path;
            InitializeComponent();
            load_data();
        }

        public void load_data() {
            ds = new DataSet();
            ds2 = new DataSet();
            DBHandling dbhand = new DBHandling(filepath);
            connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";";
            conn = new OleDbConnection(connStr);
            adp = new OleDbDataAdapter(sql, conn);
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            adp2 = new OleDbDataAdapter(sql2, conn);
            adp2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
        }
        

        private void button3_Click(object sender, EventArgs e) { //수입 저장
            DBHandling currentDB = new DBHandling(filepath);
            DateTime currentDate = DateTime.Today;
            if (Sum.Text == String.Empty) {
                MessageBox.Show("금액을 입력해야합니다.");
            }
            else {
                if (Name1.Text == String.Empty) {
                    currentDB.add(currentDate, "무명", Name2.Text, Name3.Text, long.Parse(Sum.Text), Note.Text);
                    Name2.Text = "";
                    Name3.Text = "";
                    Sum.Text = "";
                    Note.Text = "";
                }
                else {
                    currentDB.add(currentDate, Name1.Text, Name2.Text, Name3.Text, long.Parse(Sum.Text), Note.Text);
                    Name1.Text = "";
                    Name2.Text = "";
                    Name3.Text = "";
                    Sum.Text = "";
                    Note.Text = "";
                }
                load_data();
            }
        }

        private void button10_Click(object sender, EventArgs e) { //지출 저장
            DBHandling currentDB = new DBHandling(filepath);
            DateTime currentDate = DateTime.Today;
            if (Sum2.Text == String.Empty) {
                MessageBox.Show("금액을 입력해야합니다.");
            }
            else {
                currentDB.exp(currentDate, long.Parse(Sum2.Text), Note2.Text);
                Sum2.Text = "";
                Note2.Text = "";
                load_data();
            }
        }

        private void Sum_KeyPress(object sender, KeyPressEventArgs e)  {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))  {  //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            incomepanel.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e) {
            expanel.BringToFront();
        }

        private void Sum2_KeyPress(object sender, KeyPressEventArgs e) {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) {  //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
            }
        }

        
    }
}

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
using System.IO;

namespace FinanceManagement {
    public partial class Register : Form {
        string filepath;

        public Register(string path)  {
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

        private void button3_Click(object sender, EventArgs e)  {
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
            }
            
        }

        private void Sum_KeyPress(object sender, KeyPressEventArgs e)  {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))  {  //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
            }
        }
    }
}

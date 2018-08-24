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

namespace FinanceManagement {
    public partial class Setting_budget : Form {

        DBHandling currentDB;
        String strPath;
        OleDbConnection conn;
        OleDbDataAdapter adp1;
        OleDbDataAdapter adp2;
        OleDbDataAdapter adp3;
        DataSet dsG;
        DataSet dsH;
        DataSet dsM;
        DataGridViewCellEventArgs k = null;
        string connStr;
        string sql1 = "SELECT 관 FROM 수입관";
        string sql2 = "SELECT 항 FROM 수입항";
        string sql3 = "SELECT 목,예산액,예산비고 FROM 수입목";
        int g_CodeNumber;
        int m_CodeNumber;
        int h_CodeNumber;


        public Setting_budget(String path) {
            InitializeComponent();
            strPath = path;
            load_data();
        }

        public void load_data() {
            currentDB = new DBHandling(strPath);
            connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strPath + ";";
            dsG = new DataSet();
            dsH = new DataSet();
            dsM = new DataSet();
            conn = new OleDbConnection(connStr);
            adp1 = new OleDbDataAdapter(sql1, conn);
            adp2 = new OleDbDataAdapter(sql2, conn);
            adp3 = new OleDbDataAdapter(sql3, conn);
            adp1.Fill(dsG);
            adp2.Fill(dsH);
            adp3.Fill(dsM);
            관data.DataSource = dsG.Tables[0];
            항data.DataSource = dsH.Tables[0];
            목data.DataSource = dsM.Tables[0];
            g_CodeNumber = dsG.Tables[0].Rows.Count + 1;
            h_CodeNumber = dsH.Tables[0].Rows.Count + 1;
            m_CodeNumber = dsM.Tables[0].Rows.Count + 1;
        }

        public void orderSort(String sortName, int codeCount, int order) {
            int number = codeCount - 1;
            String name = "";
            if (sortName == "관 추가") {
                name = "수입관";
            }
            else if (sortName == "항 추가") {
                name = "수입항";
            }
            else { // 항 수정

            }
            while (number >= order) {
                currentDB.addG_order(name, number);
                number--;
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            String name = "관 추가";
            Setting_budget_add addForm = new Setting_budget_add(g_CodeNumber, name, strPath, this);
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = new Point(250, 300);
            addForm.Show();

        }

        private void button8_Click(object sender, EventArgs e) {
            String name = "항 추가";
            Setting_budget_add addForm = new Setting_budget_add(h_CodeNumber, name, strPath, this);
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = new Point(250, 300);
            addForm.Show();
        }

        private void button11_Click(object sender, EventArgs e) {
            String name = "목 추가";
            Setting_budget_add_m addForm = new Setting_budget_add_m(m_CodeNumber, name, strPath, this);
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = new Point(250, 300);
            addForm.Show();
        }

        private void button4_Click(object sender, EventArgs e) {
            String name = "관 수정";

            if (k == null) {
                MessageBox.Show("지정된 자료가 없습니다.", "오류");
            }
            else {
                Setting_budget_add addForm = new Setting_budget_add(name, strPath, this);
                addForm.StartPosition = FormStartPosition.Manual;
                addForm.Location = new Point(250, 300);
                addForm.Show();
                k = null;
            }
        }

        private void button7_Click(object sender, EventArgs e) {
            String name = "항 수정";
            Setting_budget_add addForm = new Setting_budget_add(h_CodeNumber, name, strPath, this);
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = new Point(250, 300);
            addForm.Show();
        }

        private void button10_Click(object sender, EventArgs e) {

        }

        private void button5_Click(object sender, EventArgs e) {
            String name = "관 삭제";
            Setting_budget_delete deleteForm = new Setting_budget_delete(name);
            deleteForm.StartPosition = FormStartPosition.Manual;
            deleteForm.Location = new Point(250, 300);
            deleteForm.Show();
        }

        private void button6_Click(object sender, EventArgs e) {
            String name = "항 삭제";
            Setting_budget_delete deleteForm = new Setting_budget_delete(name);
            deleteForm.StartPosition = FormStartPosition.Manual;
            deleteForm.Location = new Point(250, 300);
            deleteForm.Show();
        }

        private void button9_Click(object sender, EventArgs e) {
            String name = "목 삭제";
            Setting_budget_delete deleteForm = new Setting_budget_delete(name);
            deleteForm.StartPosition = FormStartPosition.Manual;
            deleteForm.Location = new Point(250, 300);
            deleteForm.Show();
        }

        private void 관data_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            k = e;
        }
    }
}

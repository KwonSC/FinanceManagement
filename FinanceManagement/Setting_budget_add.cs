﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement {
    public partial class Setting_budget_add : Form {

        String strPath;
        String sortName;
        Setting_budget k;
        DBHandling db;

        public Setting_budget_add(String name, String path,Setting_budget sb) {
            InitializeComponent();

            strPath = path;
            this.Text = name;
            sortName = name;
            k = sb;
            sb = new Setting_budget(path);
            db = new DBHandling(strPath);
        }

        private void button1_Click(object sender, EventArgs e) {
            if (sortName == "관 추가") {
                db.addG(name.Text, int.Parse(order.Text));
            }
            else if (sortName == "항 추가") {
                db.addH(name.Text, int.Parse(order.Text));
            }
            else {

            }
            k.load_data();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}

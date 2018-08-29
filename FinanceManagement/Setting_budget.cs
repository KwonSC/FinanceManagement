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

        private DBHandling currentDB;
        private String strPath;
        private OleDbConnection conn;
        private OleDbDataAdapter adp1;
        private OleDbDataAdapter adp2;
        private OleDbDataAdapter adp3;
        private DataSet dsG;
        private DataSet dsH;
        private DataSet dsM;
        private DataGridViewCellEventArgs k = null;
        private DataGridViewCellEventArgs h = null;
        private string connStr;
        private string sql1 = "SELECT 관코드, 관, 순서 FROM 수입관";
        private string sql2 = "SELECT 항코드, 항, 순서, 항관코드 FROM 수입항";
        private string sql3 = "SELECT 목,예산액,예산비고 FROM 수입목";
        private int g_CodeNumber;
        private int h_CodeNumber;
        private int m_CodeNumber;
        private int _clickCellOrderNumber;
        private int _sameGNumber;


        public Setting_budget(String path) {
            InitializeComponent();
            strPath = path;
            load_data();
        }

        private void setClickCellOrder(int number) {
            this._clickCellOrderNumber = number;
        }
        public int clickCellOrderNumber() {
            return this._clickCellOrderNumber;
        }
        private void setSameGNumber(int number) {
            this._sameGNumber = number;
        }
        public int sameGNumber() {
            return this._sameGNumber;
        }
        public struct cellContent {
            public string cellName;
            public int cellCount;
            public int cellOrder;

            public cellContent(string anName, int number, int anOrder) {
                cellName = anName;
                cellCount = number;
                cellOrder = anOrder;
            }
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

            this.관data.Sort(this.관data.Columns[2], ListSortDirection.Ascending);
            /*this.관data.Columns[0].Visible = false;
            this.관data.Columns[2].Visible = false;*/
            this.항data.Sort(this.항data.Columns[2], ListSortDirection.Ascending);
        }

        public void initCell(string function) {
            // 관코드 설정

            try {
                this.g_CodeNumber = int.Parse(this.관data.Rows[this.관data.RowCount - 1].Cells[0].Value.ToString()) + 1;
            }
            catch {
                this.g_CodeNumber = 1;
                MessageBox.Show("(관) 셀 없음");
            }
            // 항코드 설정
            try {
                this.항data.Sort(this.항data.Columns[0], ListSortDirection.Ascending);

                String hCodeNumber = this.항data.Rows[this.항data.RowCount - 1].Cells[0].Value.ToString();
                this.h_CodeNumber = int.Parse(this.항data.Rows[this.항data.RowCount - 1].Cells[0].Value.ToString()) + 1;

                this.항data.Sort(this.항data.Columns[2], ListSortDirection.Ascending);
            }
            catch {
                this.h_CodeNumber = 1;
                MessageBox.Show("(항) 셀 없음");
            }

            if (k == null || function == "삭제") {
                var args = new DataGridViewCellEventArgs(0, 0);
                this.관data_CellClick(항data, args);
            }
            else {
                this.관data_CellClick(항data, k);
                this.관data.Rows[k.RowIndex].Cells[1].Selected = true;
            }
            if (h != null) {
                try {
                    this.항data_CellClick(목data, k);
                    this.항data.Rows[h.RowIndex].Cells[1].Selected = true;
                }
                catch {

                }
            }
        }



        public void orderSort(String sortName, int codeCount, int order, int currentOrder) {
            int number = codeCount - 1;
            String name = "";
            if (sortName == "관 추가" || sortName == "관 수정" || sortName == "관 삭제") {
                name = "수입관";
            }
            else if (sortName == "항 추가" || sortName == "항 수정") {
                name = "수입항";
            }

            if (order < currentOrder) {
                switch (sortName) {
                    case "관 삭제":
                    case "목 삭제":
                        while (currentOrder <= codeCount) {
                            currentDB.altOrder(name, currentOrder + 1, currentOrder);
                            currentOrder++;
                        }
                        break;
                    default:
                        if (sortName == "관 추가") {
                            this.orderPlus(name, number, order);
                        }
                        else if (sortName == "관 수정" || sortName == "항 수정") { // 바꾸는 셀의 우선순위를 먼저 0으로 설정 한 후에 1씩 증가 시키고, 0의 셀을 올바른 순서에 입력
                            currentDB.altOrder(name, currentOrder, 0);
                            number = currentOrder - 1;
                            this.orderPlus(name, number, order);
                            currentDB.altOrder(name, 0, order);
                        }
                        else if (sortName == "항 추가") {
                            foreach (DataGridViewRow row in this.항data.Rows) {
                                if (row.Cells[3].Value.ToString() == this.관data.Rows[k.RowIndex].Cells[0].Value.ToString()) {
                                    this.orderPlus(name, number, order);
                                }
                            }
                        }
                        break;
                }
            }

            else if (order > currentOrder) {
                switch (sortName) {
                    case "관 삭제":
                    case "목 삭제":
                        while (currentOrder <= codeCount) {
                            currentDB.altOrder(name, currentOrder + 1, currentOrder);
                            currentOrder++;
                        }
                        break;
                    default:
                        if (sortName == "관 추가") {
                            this.orderPlus(name, number, order);
                        }
                        else if (sortName == "관 수정" || sortName == "항 수정") { // 바꾸는 셀의 우선순위를 먼저 0으로 설정 한 후에 1씩 증가 시키고, 0의 셀을 올바른 순서에 입력
                            currentDB.altOrder(name, currentOrder, 0);
                            number = currentOrder - 1;
                            this.orderPlus(name, number, order);
                            currentDB.altOrder(name, 0, order);
                        }
                        else if (sortName == "항 추가") {
                            foreach (DataGridViewRow row in this.항data.Rows) {
                                if (row.Cells[3].Value.ToString() == this.관data.Rows[k.RowIndex].Cells[0].Value.ToString()) {
                                    this.orderPlus(name, number, order);
                                }
                            }
                        }
                        break;
                }
            }            
        }

        private void orderPlus(string name, int number, int order) {
            while (number >= order) {
                currentDB.altOrder(name, number, number + 1);
                number--;
            }
        }
        // currentNumber, newNumber
        private void orderMinus(string name, int number, int order) {
            while (number < order) {
                currentDB.altOrder(name, number+1, number);
                number++;
            }
        }

        public bool dupName(string sortName, string name) {

            bool duplicated = false;

            if (sortName == "관 추가" || sortName == "관 수정") {
                foreach (DataGridViewRow row in this.관data.Rows) {

                    if (row.Cells[0].Value.ToString() == this.관data.Rows[k.RowIndex].Cells[0].Value.ToString())
                        continue;

                    if (name == row.Cells[1].Value.ToString()) {
                        duplicated = true;

                        if (duplicated)
                            break;
                    }
                }
            }
            else if (sortName == "항 추가" || sortName == "항 수정") {
                foreach (DataGridViewRow row in this.항data.Rows) {
                    if (name == row.Cells[1].Value.ToString()) {
                        duplicated = true;

                        if (duplicated)
                            break;
                    }
                }
            }
            else {

            }

            return duplicated;
        }

        // 관항목 '추가'
        private void button3_Click(object sender, EventArgs e) {
            String name = "관 추가";

            cellContent gCell = new cellContent("", this.관data.RowCount, 0);

            Setting_budget_add addForm = new Setting_budget_add(g_CodeNumber, 0, gCell, name, strPath, this);
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = new Point(250, 300);
            addForm.Show();
        }

        private void button8_Click(object sender, EventArgs e) {
            String name = "항 추가";

            if (k == null) {
                MessageBox.Show("지정된 자료가 없습니다.", "오류");
            }
            else {
                int cellCount = 0;
                int gCode = int.Parse(this.관data.Rows[k.RowIndex].Cells[0].Value.ToString());

                foreach (DataGridViewRow row in this.항data.Rows) {
                    if (int.Parse(row.Cells[3].Value.ToString()) == gCode) {
                        cellCount++;
                    }
                }

                cellContent gCell = new cellContent("", cellCount, 0);

                Setting_budget_add addForm = new Setting_budget_add(h_CodeNumber, gCode, gCell, name, strPath, this);
                addForm.StartPosition = FormStartPosition.Manual;
                addForm.Location = new Point(250, 300);
                addForm.Show();
            }
        }

        private void button11_Click(object sender, EventArgs e) {
            String name = "목 추가";
            Setting_budget_add_m addForm = new Setting_budget_add_m(m_CodeNumber, name, strPath, this);
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = new Point(250, 300);
            addForm.Show();
        }

        // 관항목 '수정'
        private void button4_Click(object sender, EventArgs e) {
            String name = "관 수정";

            if (k == null) {
                MessageBox.Show("지정된 자료가 없습니다.", "오류");
            }
            else {
                string cell_name = this.관data.Rows[k.RowIndex].Cells[1].Value.ToString();
                string cell_order = this.관data.Rows[k.RowIndex].Cells[2].Value.ToString();
                cellContent gCell = new cellContent(cell_name, this.관data.RowCount, int.Parse(cell_order));

                Setting_budget_add addForm = new Setting_budget_add(name, gCell, strPath, this);
                addForm.StartPosition = FormStartPosition.Manual;
                addForm.Location = new Point(250, 300);
                addForm.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e) {
            String name = "항 수정";

            if (h == null) {
                MessageBox.Show("지정된 자료가 없습니다.", "오류");
            }
            else {
                string cell_name = this.항data.Rows[this.h.RowIndex].Cells[1].Value.ToString();
                string cell_order = this.항data.Rows[this.h.RowIndex].Cells[2].Value.ToString();
                cellContent gCell = new cellContent(cell_name, this.항data.RowCount, int.Parse(cell_order));

                Setting_budget_add addForm = new Setting_budget_add(h_CodeNumber, 0, gCell, name, strPath, this);
                addForm.StartPosition = FormStartPosition.Manual;
                addForm.Location = new Point(250, 300);
                addForm.Show();
            }
        }

        private void button10_Click(object sender, EventArgs e) {

        }

        private void button5_Click(object sender, EventArgs e) {
            if (k == null) {
                MessageBox.Show("지정된 자료가 없습니다.", "오류");
            }
            else {
                try {
                    String name = "관 삭제";
                    string cell_name = this.관data.Rows[k.RowIndex].Cells[1].Value.ToString();
                    string cell_order = this.관data.Rows[k.RowIndex].Cells[2].Value.ToString();
                    cellContent gCell = new cellContent(cell_name, this.관data.RowCount, int.Parse(cell_order));
                    Setting_budget_delete deleteForm = new Setting_budget_delete(name, strPath, gCell, this);
                    deleteForm.StartPosition = FormStartPosition.Manual;
                    deleteForm.Location = new Point(250, 300);
                    deleteForm.Show();
                }
                catch {

                }
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            String name = "항 삭제";
            string cell_name = this.관data.Rows[k.RowIndex].Cells[1].Value.ToString();
            string cell_order = this.관data.Rows[k.RowIndex].Cells[2].Value.ToString();
            cellContent gCell = new cellContent(cell_name, this.관data.RowCount, int.Parse(cell_order));
            Setting_budget_delete deleteForm = new Setting_budget_delete(name, strPath, gCell, this);
            deleteForm.StartPosition = FormStartPosition.Manual;
            deleteForm.Location = new Point(250, 300);
            deleteForm.Show();
        }

        private void button9_Click(object sender, EventArgs e) {
            String name = "목 삭제";
            string cell_name = this.관data.Rows[k.RowIndex].Cells[1].Value.ToString();
            string cell_order = this.관data.Rows[k.RowIndex].Cells[2].Value.ToString();
            cellContent gCell = new cellContent(cell_name, this.관data.RowCount, int.Parse(cell_order));
            Setting_budget_delete deleteForm = new Setting_budget_delete(name, strPath, gCell, this);
            deleteForm.StartPosition = FormStartPosition.Manual;
            deleteForm.Location = new Point(250, 300);
            deleteForm.Show();
        }

        private void 관data_CellClick(object sender, DataGridViewCellEventArgs e) {
            k = e;
            int i = 0;
            try {
                this._clickCellOrderNumber = int.Parse(this.관data.Rows[k.RowIndex].Cells[0].Value.ToString());

                foreach (DataGridViewRow row in this.항data.Rows) {
                    if (int.Parse(row.Cells[3].Value.ToString()) == this._clickCellOrderNumber) {
                        row.Visible = true;

                        if (i == 0) {
                            var args = new DataGridViewCellEventArgs(1, row.Index);
                            row.Cells[1].Selected = true;
                            this.항data_CellClick(관data, args);
                            i++;
                        }
                    }
                    else {
                        CurrencyManager cm = (CurrencyManager)BindingContext[this.항data.DataSource];
                        cm.SuspendBinding();
                        row.Visible = false;
                        cm.ResumeBinding();
                    }
                }
                if (i == 0) {
                    this.h = null;
                }
            }
            catch {
            }
            
        }

        private void 항data_CellClick(object sender, DataGridViewCellEventArgs e) {
            this.h = e;
            int number = 0;

            foreach (DataGridViewRow row in this.항data.Rows) {

                if (e.RowIndex == -1) {
                    continue;
                }

                if (row.Cells[3].Value.ToString() == this.항data.Rows[e.RowIndex].Cells[3].Value.ToString()) {
                    number++;
                }
            }
            this.setSameGNumber(number);
        }
    }
}

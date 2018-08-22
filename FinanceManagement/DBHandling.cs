using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace FinanceManagement {
    public class DBHandling {

        private string _strFilePath;
        private string _strDBConnection;

        OleDbConnection conn = new OleDbConnection();
        OleDbCommand connCmd = new OleDbCommand();

        public DBHandling(string filePath) {
            this._strFilePath = filePath;
            this._strDBConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";";
        }

        public String strFilePath() {
            return this._strFilePath;
        }
        public void setStrFilePath(String aFilePath) {
            this._strFilePath = aFilePath;
        }
        private String strDBConnection() {
            return this._strDBConnection;
        }

        public void add(int count, DateTime aDate, String nam1,String nam2, long number, String etc) { //수입 저장
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 수입(코드, 날짜, 이름1, 이름2, 금액, 비고) VALUES('"+count+"', '" + aDate + "', '" + nam1 + "', '"+nam2+"', '" + number + "', '" + etc + "')";
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void add_modify(int rowindex,DateTime aDate, String nam1, String nam2, long number, String etc) { //수입 수정
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "UPDATE 수입 SET 날짜 = '" + aDate.Date + "', 이름1 ='" + nam1 + "', 이름2 ='" + nam2 + "',금액 ='" + number + "',비고 ='" + etc+"' WHERE 코드="+rowindex;
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void add_delete(int rowindex) { //수입 삭제
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "DELETE FROM 수입 WHERE 코드 =" + rowindex;
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void exp(int count, DateTime aDate, long number, String etc) { // 지출 저장

            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 지출(코드, 날짜, 금액, 비고) VALUES('" + count + "', '" + aDate + "', '" + number + "', '" + etc + "')";
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void exp_modify(int rowindex,DateTime aDate, long number, String etc) { //지출 수정
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "UPDATE 지출 SET 날짜 = '" + aDate.Date + "',금액 ='" + number + "',비고 ='" + etc + "' WHERE 코드=" + rowindex;
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void exp_delete(int rowindex) { //지출 삭제
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "DELETE FROM 지출 WHERE 코드 =" + rowindex;
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void carryOverAdd(long number) {
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "SELECT 이월금 FROM 환경";
            connCmd.CommandText = "UPDATE 환경 SET 이월금 = " + number;
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void addG(String name, int order) {
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 수입관(관코드, 관, 순서) VALUES('1', '" + name + "', '" + order + "')";
            connCmd.ExecuteNonQuery();
            conn.Close();
        }
        public void addH(String name, int order) {
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 수입항(항코드, 항, 순서) VALUES('1', '" + name + "', '" + order + "')";
            connCmd.ExecuteNonQuery();
            conn.Close();
        }
        public void addM(String name, long budget, String etc, int order) {
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 수입목(목코드, 목, 예산액, 예산비고, 순서) VALUES('1', '" + name + "', '" + budget + "', '" + etc + "', '" + order + "')";
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

       
    }
}

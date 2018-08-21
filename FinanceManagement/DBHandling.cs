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

        public void add(DateTime aDate, String nam1,String nam2, long number, String etc) {
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 수입(코드, 날짜, 이름1, 이름2, 금액, 비고) VALUES('1', '" + aDate + "', '" + nam1 + "', '"+nam2+"', '" + number + "', '" + etc + "')";
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

        public void exp(DateTime aDate, long number, String etc) {

            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 지출(코드, 날짜, 금액, 비고) VALUES('1', '" + aDate + "', '" + number + "', '" + etc + "')";
            connCmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

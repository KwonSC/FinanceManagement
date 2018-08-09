using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;

namespace FinanceManagement {
    public class DBHandling {

        private string _strFilePath;
        private string _strDBConnection;

        public DBHandling(string filePath) {
            this._strFilePath = filePath;
            this._strDBConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";";
        }

        public String strFilePath() {
            return this._strFilePath;
        }
        private String strDBConnection() {
            return this._strDBConnection;
        }

        public void add(DateTime aDate, String aName, int number, String etc) {
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand connCmd = new OleDbCommand();

            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 수입(코드, 날짜, 이름1, 이름2, 이름3, 금액, 비고) VALUES('1', '" + aDate + "', '" + aName + "', 'ss', 'ss', '" + number + "', '" + etc + "')";
            connCmd.ExecuteNonQuery();
        }
    }
}

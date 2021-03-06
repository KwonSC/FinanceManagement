﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;

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

        public string mok(string str1, int gcode,int hcode, int i) { //목이름 가져오기
            string c;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT 목 FROM " + str1 + " WHERE 목관코드 = " + gcode + "AND 목항코드 = " + hcode + " AND 목코드 = " + i;
            object a = connCmd.ExecuteScalar();
            if (a != null) {
                c = a.ToString();
            }
            else {
                c = "";
            }
            connCmd.ExecuteNonQuery();
            conn.Close();
            return c;
        }

        public int get_mokcode(string str1, string str2) { //목코드 검색
            int x;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT 목코드 FROM " + str1 + " WHERE 목 = '" + str2 + "'";
            object a = connCmd.ExecuteScalar();
            int.TryParse(a.ToString(), out x);
            connCmd.ExecuteNonQuery();
            conn.Close();
            return x;
        }

        public int get_hangcode(string str1, string str2) { //항코드 검색
            int x;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT 항코드 FROM " + str1 + " WHERE 항 = '" + str2 + "'";
            object a = connCmd.ExecuteScalar();
            int.TryParse(a.ToString(), out x);
            connCmd.ExecuteNonQuery();
            conn.Close();
            return x;
        }

        public int get_gwancode(string str1, string str2) { //관코드 검색
            int x;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT 관코드 FROM " + str1 + " WHERE 관 = '" + str2+"'";
            object a = connCmd.ExecuteScalar();
            int.TryParse(a.ToString(), out x);
            connCmd.ExecuteNonQuery();
            conn.Close();
            return x;
        }

        public string hang(string str1, int code, int i) { //항이름 가져오기
            string c;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT 항 FROM " + str1 + " WHERE 항관코드 = " + code + " AND 항코드 = "+i;
            object a = connCmd.ExecuteScalar();
            if (a != null) {
                c = a.ToString();
            }
            else {
                c = "";
            }
            connCmd.ExecuteNonQuery();
            conn.Close();
            return c;
        }

        public string gwan(string str1, int i) { //관이름 가져오기
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT 관 FROM "+str1+" WHERE 관코드 = "+i;
            object a = connCmd.ExecuteScalar();
            string c = a.ToString();
            connCmd.ExecuteNonQuery();
            conn.Close();
            return c;
        }
        
        public int count_row(string str) { //행 개수세기
            int x;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT COUNT(*) FROM "+ str;
            object a = connCmd.ExecuteScalar();
            int.TryParse(a.ToString(), out x);
            connCmd.ExecuteNonQuery();
            conn.Close();
            return x;
        }

        public Int64 all_difference(DateTime dt) { //총 차액
            Int64 w, x, y, z;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT 이월금 FROM 환경";
            object e = connCmd.ExecuteScalar();
            string f = e.ToString();
            Int64.TryParse(f, out w);
            connCmd.CommandText = "SELECT SUM(금액) FROM 수입 WHERE 날짜 <= (@value)";
            connCmd.Parameters.AddWithValue("@value", dt);
            object a = connCmd.ExecuteScalar();
            string c = a.ToString();
            Int64.TryParse(c, out x);
            connCmd.CommandText = "SELECT SUM(금액) FROM 지출 WHERE 날짜 <= (@value)";
            connCmd.Parameters.AddWithValue("@value", dt);
            object b = connCmd.ExecuteScalar();
            string d = b.ToString();
            Int64.TryParse(d, out y);
            z = w + x - y;
            connCmd.ExecuteNonQuery();
            conn.Close();
            return z;
        }

        public Int64 today_difference(DateTime dt) { //금일 차액
            Int64 x, y, z;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT SUM(금액) FROM 수입 WHERE 날짜 = (@value)";
            connCmd.Parameters.AddWithValue("@value", dt);
            object a = connCmd.ExecuteScalar();
            string c = a.ToString();
            Int64.TryParse(c, out x);
            connCmd.CommandText = "SELECT SUM(금액) FROM 지출 WHERE 날짜 = (@value)";
            connCmd.Parameters.AddWithValue("@value", dt);
            object b = connCmd.ExecuteScalar();
            string d = b.ToString();
            Int64.TryParse(d, out y);
            z =x - y;
            connCmd.ExecuteNonQuery();
            conn.Close();
            return z;
        }

        public Int64 yesterday_sum(DateTime dt) { //전일이월금액
            Int64 w, x, y, z;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT 이월금 FROM 환경";
            object e = connCmd.ExecuteScalar();
            string f = e.ToString();
            Int64.TryParse(f, out w);
            connCmd.CommandText = "SELECT SUM(금액) FROM 수입 WHERE 날짜 < (@value)";
            connCmd.Parameters.AddWithValue("@value", dt);
            object a = connCmd.ExecuteScalar();
            string c = a.ToString();
            Int64.TryParse(c, out x);
            connCmd.CommandText = "SELECT SUM(금액) FROM 지출 WHERE 날짜 < (@value)";
            connCmd.Parameters.AddWithValue("@value", dt);
            object b = connCmd.ExecuteScalar();
            string d = b.ToString();
            Int64.TryParse(d, out y);
            z = w + x - y;
            connCmd.ExecuteNonQuery();
            conn.Close();
            return z;
        }

        public Int64 carryover() { //초기이월금액
            Int64 z;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT 이월금 FROM 환경";
            object a = connCmd.ExecuteScalar();
            string b = a.ToString();
            Int64.TryParse(b, out z);
            connCmd.ExecuteNonQuery();
            conn.Close();
            return z;
        }

        public object all_expend_sum(DateTime dt) { //총 지출 합계구하기
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT SUM(금액) FROM 지출 WHERE 날짜 <= (@value)";
            connCmd.Parameters.AddWithValue("@value", dt);
            object count = connCmd.ExecuteScalar();
            connCmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }

        public object all_income_sum(DateTime dt) { //총 수입 합계구하기
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT SUM(금액) FROM 수입 WHERE 날짜 <= (@value)";
            connCmd.Parameters.AddWithValue("@value", dt);
            object count = connCmd.ExecuteScalar();
            connCmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }

        public object today_income_sum(DateTime dt) { //금일수입 합계구하기
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT SUM(금액) FROM 수입 WHERE 날짜 = (@value)";
            connCmd.Parameters.AddWithValue("@value", dt);
            object count = connCmd.ExecuteScalar();
            connCmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }

        public object today_expend_sum(DateTime dt) { //금일지출 합계 구하기
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "SELECT SUM(금액) FROM 지출 WHERE 날짜 = (@value)";
            connCmd.Parameters.AddWithValue("@value", dt);
            object count = connCmd.ExecuteScalar();
            connCmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }

        public void exp_iterdel(int count) { //지출_삭제전 코드땡기기
            int mcount = count - 1;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "UPDATE 지출 SET 코드 ='" + mcount+"' WHERE 코드="+count;
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void add_iterdel(int count) { //수입_삭제전 코드땡기기
            int mcount = count - 1;
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            connCmd.CommandText = "UPDATE 수입 SET 코드 ='" + mcount + "' WHERE 코드=" + count;
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void add(int count, DateTime aDate, String nam1,String nam2, Int64 number, String etc, int g, int h, int m) { //수입 저장
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 수입(코드, 날짜, 이름1, 이름2, 금액, 비고, 관코드, 항코드, 목코드) VALUES('"+count+"', '" + aDate + "', '" + nam1 + "', '"+nam2+"', '" + number + "', '" + etc + "', '" + g + "' , '" + h +"', '" + m + "')";
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void add_modify(int rowindex,DateTime aDate, String nam1, String nam2, Int64 number, String etc) { //수입 수정
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

        public void exp(int count, DateTime aDate, Int64 number, String etc,int g, int h, int m) { // 지출 저장

            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 지출(코드, 날짜, 금액, 비고, 관코드, 항코드, 목코드) VALUES('" + count + "', '" + aDate + "', '" + number + "', '" + etc + "', '" + g + "' , '" + h + "', '" + m + "')";
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void exp_modify(int rowindex,DateTime aDate, Int64 number, String etc) { //지출 수정
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

        public void carryOverAdd(Int64 number) {
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "UPDATE 환경 SET 이월금 = " + number;
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void addG(int code, String name, int order) {
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 수입관(관코드, 관, 순서) VALUES('" + code + "', '" + name + "', '" + order + "')";
            connCmd.ExecuteNonQuery();
            conn.Close();
        }
        public void addH(int code, int hgCode, String name, int order) {
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 수입항(항코드, 항, 순서, 항관코드) VALUES('" + code + "', '" + name + "', '" + order + "', '" + hgCode + "')";
            connCmd.ExecuteNonQuery();
            conn.Close();
        }
        public void altOrder(String sortName, int currentNumber, int newNumber, int HGCode) { // 순서 최신화
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            
            if (sortName == "관 추가" || sortName == "관 수정" || sortName == "관 삭제") {
                connCmd.CommandText = "UPDATE 수입관 SET 순서 = " + newNumber + " where 순서 = " + currentNumber;
                connCmd.ExecuteNonQuery();
            }
            else if (sortName == "항 추가" || sortName == "항 수정" || sortName == "항 삭제") {
                connCmd.CommandText = "UPDATE 수입항 SET 순서 = " + newNumber + " where 순서 = " + currentNumber + " AND 항관코드 = " + HGCode;
                connCmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public void altOrder(String sortName, int currentNumber, int newNumber, int MGCode, int MHCode) { // 순서 최신화
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "UPDATE 수입목 SET 순서 = " + newNumber + " where 순서 = " + currentNumber + " AND 목관코드 = " + MGCode + " AND 목항코드 = " + MHCode;
            connCmd.ExecuteNonQuery();
            conn.Close();
        }

        public void altName(string sortName, string currentName, string newName) {
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            string query = "";

            if (sortName == "관 수정") {
                query = @"UPDATE 수입관 SET 관 = ? WHERE 관 = ?";
                connCmd = new OleDbCommand(query, conn);
                connCmd.Parameters.AddWithValue("@관", newName);
                connCmd.Parameters.AddWithValue("@관", currentName);
            }
            else if (sortName == "항 수정") {
                query = @"UPDATE 수입항 SET 항 = ? WHERE 항 = ?";
                connCmd = new OleDbCommand(query, conn);
                connCmd.Parameters.AddWithValue("@항", newName);
                connCmd.Parameters.AddWithValue("@항", currentName);
            }

            connCmd.ExecuteNonQuery();
            conn.Close();
        }
        public void addM(int code, int mgCode, int mhCode, string name, int order, Int64 budget, String etc) {
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;

            connCmd.CommandText = "INSERT INTO 수입목(목코드, 목, 예산액, 예산비고, 순서, 목관코드, 목항코드) VALUES(" + code + ", '" + name + "', '" + budget + "', '" + etc + "', '" + order + "', '" + mgCode + "', '" + mhCode + "')";
            connCmd.ExecuteNonQuery();
            conn.Close();
        }
        public void budget_delete(string sortName, string cellName) { // 순서 최신화
            conn.ConnectionString = this.strDBConnection();
            conn.Open();
            connCmd.Connection = conn;
            string query = "";

            if (sortName == "관") {
                query = @"DELETE FROM 수입관 WHERE 관 = ?";
                connCmd = new OleDbCommand(query, conn);
                connCmd.Parameters.AddWithValue("@관", cellName);
                connCmd.ExecuteNonQuery();
            }
            else if (sortName == "항") {
                query = @"DELETE FROM 수입항 WHERE 항 = ?";
                connCmd = new OleDbCommand(query, conn);
                connCmd.Parameters.AddWithValue("@항", cellName);
                connCmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOX;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;

namespace FinanceManagement {
    public class cDBControl {
        private string strFilePath = "";
        private string strDBConnection = "";

        public cDBControl(string strPath) {
            // 파일의 경로를 저장
            this.strFilePath = strPath;
            // DB에 연결하기위한 명령줄 생성
            this.strDBConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + ";";
            // 데이터베이스에 암호를 설정하고 싶다면 아래내용을 strDBConnection에 추가하면된다.
            // 예시)
            // this.strDBConnection += "Jet OLEDB:Database Password=1234";
        }

        public void funcAccessCreate() {
            try {
                FileInfo fiStaticDB = new FileInfo(this.strFilePath);
                if (!fiStaticDB.Exists) // 파일의 유무를 확인, 없으면
                {
                    // 생성
                    funcCreate();
                }
                else    // 있으면
                {
                    // 기존 파일을 제거
                    fiStaticDB.Delete();
                    // 생성
                    funcCreate();
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private void funcCreate() {
            try {
                // MDB파일을 동적으로 생성
                ADOX.CatalogClass adoxCC = new ADOX.CatalogClass();
                adoxCC.Create(strDBConnection);

                // 연결을 끊기위해 null을 할당.
                adoxCC.ActiveConnection = null;
                adoxCC = null;

                // 연결을 끊었다고 adoxCC = null을 해줘도 가비지컬렉션이 작동안하면,
                // 프로그램 실행 중에는 언제될지 모른다. 수동으로 가비지컬렉션 작동
                GC.Collect();
            }
            catch (Exception ex) {
                throw new Exception("데이터베이스를 생성 중 에러 발생.", ex);
            }
        }

        public void dbCreate() {
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand connCmd = new OleDbCommand();

            try {
                conn.ConnectionString = strDBConnection;
                conn.Open();
                connCmd.Connection = conn;

                connCmd.CommandText = "CREATE TABLE 수입(코드 number, 날짜 date, 이름1 text, 이름2 text, 금액 money, 비고 text)";
                connCmd.ExecuteNonQuery();
                connCmd.CommandText = "CREATE TABLE 수입관(관코드 number, 관 text, 순서 number)";
                connCmd.ExecuteNonQuery();
                connCmd.CommandText = "CREATE TABLE 수입항(항코드 number, 항 text, 순서 number, 항관코드 number)";
                connCmd.ExecuteNonQuery();
                connCmd.CommandText = "CREATE TABLE 수입목(목코드 number, 목 text, 예산액 number, 예산비고 text, 순서 number, 목관코드 number, 목항코드 number)";
                connCmd.ExecuteNonQuery();
                connCmd.CommandText = "CREATE TABLE 일결산(날짜 date, 항목 text, 금액 number)";
                connCmd.ExecuteNonQuery();
                connCmd.CommandText = "CREATE TABLE 지출(코드 number, 날짜 date, 금액 money, 비고 text)";
                connCmd.ExecuteNonQuery();
                connCmd.CommandText = "CREATE TABLE 지출관(관코드 number, 관 text, 순서 number)";
                connCmd.ExecuteNonQuery();
                connCmd.CommandText = "CREATE TABLE 지출항(항코드 number, 항 text, 순서 number, 항관코드 number)";
                connCmd.ExecuteNonQuery();
                connCmd.CommandText = "CREATE TABLE 지출목(목코드 number, 목 text, 예산액 money, 예산비고 text, 순서 number, 목관코드 number, 목항코드 number)";
                connCmd.ExecuteNonQuery();
                connCmd.CommandText = "CREATE TABLE 환경(이월금 money)";
                connCmd.ExecuteNonQuery();
                connCmd.CommandText = "INSERT INTO 환경(이월금) VALUES(0)";
                connCmd.ExecuteNonQuery();
            }
            catch (Exception) {
                MessageBox.Show("테이블이 생성되지 않았습니다.");
            }
            finally {
                conn.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOX;
using System.IO;

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
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Assemble;

namespace _8._09Test
{
    public partial class LogIn : Form
    {
        private MySqlConnection Connect;  // 데이터베이스에 접속하는 정보를 관리하는 클래스.

        // 2. Select (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private MySqlDataAdapter Adapter;

        // 3. insert, update, delete 의 명령을 전달할 클래스.
        private MySqlTransaction tran;    // 데이터베이스 데이터관리(승인, 복구) 권한 부여.
        private MySqlCommand cmd;         // 데이터베이스에 Insert Update Delete 명령을 전달할 클래스.

        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DoLogIn();
        }

        //사용자 ID와 PW 정보를 받아와 로그인 여부 결정 MySqlConnection 이용.
        private void DoLogIn() //로그인 할 때 이 메소드 실행
        {
            //sql서버 데이터 베이스 불러오기  + DB 끊어주는 것도 같이 와야함. 
            try
            {
                // 로그인 정보 확인 후 로그인 가능 여부 체크 

                // 1. DB 접속 경로 설정.


                // 2. Connect 에 접속 경로 매핑.
                Connect = new MySqlConnection(Commons.conn); // 어디 주소로 접속을 할지 가지고 있을 거임

                // 3. DB 연결 상태 확인.
                Connect.Open();

                if (Connect.State != ConnectionState.Open)
                {
                    MessageBox.Show("데이터베이스 연결에 실패 하였습니다.");
                    return;
                }

                #region < 사용자 ID와 비밀번호가 동시에 맞지 않을 경우 체크>
                //사용자 ID와 비밀번호 일치 여부 확인 후 이름과 비밀번호 찾는 SQL 구문 작성.
                string sFindUserImfo = " SELECT USERID, USERNAME, PW         " +
                                       " FROM  LOGIN                         " +
                                      $" WHERE USERID = '{txtUserId.Text}'   ";

                // 데이터 베이스에 SQL 구문 전달 후 반환되는 값 받아오기. 
                MySqlDataAdapter Adapter = new MySqlDataAdapter(sFindUserImfo, Connect);

                // Adapter 실행 및 결과값 반환. -> 데이터가 들어 있으면 ID와 패스워드를 잘 입력함 
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);               //행이 없을 경우 ID가 없다.

                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("아이디가 존재하지 않습니다.");
                    return;
                }
                else if (txtPw.Text != Convert.ToString(dtTemp.Rows[0]["PW"]))      //dtTemp.Rows[0]["PW"].ToString() 도 가능 앞에는 null처리시 조금 더 유동적임 뒤는 null값일 경우 오류 발생 
                    {
                        MessageBox.Show("비밀번호가 일치하지 않습니다.");
                        return;
                    }
 
                #endregion

                Commons.cLogInId = txtUserId.Text;
                Commons.cUserName = Convert.ToString(dtTemp.Rows[0]["USERNAME"]);
                MessageBox.Show($"{dtTemp.Rows[0]["USERNAME"]} 님 반갑습니다.");

                Commons.cLogInSF = true;
                this.Close();

                //로그인 성공 시 메인화면을 뜨워줌.
            }
            //오류 내용을 받아 어떤 오류인지 메세지로 보여줄 것임. 
            catch (Exception ex)
            {
                //소스 코딩 내용이 오류가 떴을때
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // DB 와 접속을 끊어준다. 
                Connect.Close();
            }

        }

        private void txtPw_KeyDown(object sender, KeyEventArgs e)
        {
            // 비밀번호 입력 후 enter key 입력 시 로그인 기능 구현
            if (e.KeyCode == Keys.Enter)
            {
                DoLogIn();
            }
        }

    }
}
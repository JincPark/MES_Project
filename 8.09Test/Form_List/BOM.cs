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
namespace Form_List
{
    public partial class BOM : Form
    {
        private MySqlConnection Connect;  // 데이터베이스에 접속하는 정보를 관리하는 클래스.

        // 2. Select (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private MySqlDataAdapter Adapter;

        // 3. insert, update, delete 의 명령을 전달할 클래스.
        private MySqlTransaction tran;    // 데이터베이스 데이터관리(승인, 복구) 권한 부여.
        private MySqlCommand cmd;         // 데이터베이스에 Insert Update Delete 명령을 전달할 클래스.

        public BOM()
        {
            InitializeComponent();
        }

        private void BOM_Load(object sender, EventArgs e)
        {
            /*************************** 기본 그리드 내역 세팅 ******************************/
            DataTable dtGrid1 = new DataTable();
            DataTable dtGrid2 = new DataTable();

            dtGrid1.Columns.Add("icode", typeof(string));    // 품목코드
            dtGrid1.Columns.Add("name",  typeof(string));    // 품목명
            dtGrid1.Columns.Add("bigo",  typeof(string));    // 비고
            dtGrid2.Columns.Add("icode", typeof(string));    // 품목코드
            dtGrid2.Columns.Add("name",  typeof(string));    // 품목명
            dtGrid2.Columns.Add("ccode", typeof(string));    // 자재코드
            dtGrid2.Columns.Add("cname", typeof(string));    // 자재명
            dtGrid2.Columns.Add("cbigo", typeof(string));    // 비고

            // 빈 컬럼 테이블 그리드에 매핑.
            Grid1.DataSource = dtGrid1;
            Grid2.DataSource = dtGrid2;

            // 그리드 컬럼 명칭(Text) 설정
            Grid1.Columns[0].HeaderText = "품목코드 ";
            Grid1.Columns[1].HeaderText = "품목명 ";
            Grid1.Columns[2].HeaderText = "비고 ";
            Grid2.Columns[0].HeaderText = "품목코드 ";
            Grid2.Columns[1].HeaderText = "품목명 ";
            Grid2.Columns[2].HeaderText = "자재코드 ";
            Grid2.Columns[3].HeaderText = "자재명 ";
            Grid2.Columns[4].HeaderText = "비고 ";

            // 컬럼의 폭 지정
            Grid1.Columns[0].Width = 200;
            Grid1.Columns[1].Width = 200;
            Grid1.Columns[2].Width = 210;

            Grid2.Columns[0].Width = 120;
            Grid2.Columns[1].Width = 120;
            Grid2.Columns[2].Width = 120;
            Grid2.Columns[3].Width = 120;
            Grid2.Columns[4].Width = 130;

            Inquire();
        }
        public void Inquire()
        {
            /************************ 사용자 내역 조회 ********************/

            //// 1. 데이터베이스 접속
            //Connect = new SqlConnection(Commons.cDbCon);

            //// 2. 데이터베이스 오픈
            //Connect.Open();

            //if (Connect.State != ConnectionState.Open)
            //{
            //    MessageBox.Show("데이터베이스 연결에 실패하였습니다.");
            //    return;
            //}
            if (!DBHelper(false)) return;

            try
            {
                // 사용자 정보 조회

                // Adapter 에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new MySqlDataAdapter("BM_BOM_S1", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                //Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                //// 데이터베이스 처리 시 C#으로 반환할 값을 담는 변수.
                //Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                //Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행.
                DataTable dtTemp1 = new DataTable();
                Adapter.Fill(dtTemp1);
                // 결과값을 그리드뷰에 표현.
                Grid1.DataSource = dtTemp1;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        public bool DBHelper(bool Tran)
        {
            Connect = new MySqlConnection(Commons.conn);
            // 2. 데이터베이스 오픈
            Connect.Open();

            if (Connect.State != ConnectionState.Open)
            {
                MessageBox.Show("데이터베이스 연결에 실패하였습니다.");
                return false;
            }
            if (Tran) tran = Connect.BeginTransaction();
            return true;
        }
    }
}

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
using System.Data.SqlClient;

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

            dtGrid1.Columns.Add("icode", typeof(string));        // 품목코드
            dtGrid1.Columns.Add("name",  typeof(string));        // 품목명
            dtGrid1.Columns.Add("bigo",  typeof(string));        // 비고

            dtGrid2.Columns.Add("mcode", typeof(string));       // 자재코드
            dtGrid2.Columns.Add("mname", typeof(string));       // 자재명
            dtGrid2.Columns.Add("CQTY", typeof(string));        // 필요자재수량
            dtGrid2.Columns.Add("CUNIT", typeof(string));       // 자재단위
            dtGrid2.Columns.Add("mbi", typeof(string));         // 비고

            // 빈 컬럼 테이블 그리드에 매핑.
            Grid1.DataSource = dtGrid1;
            Grid2.DataSource = dtGrid2;

            // 그리드 컬럼 명칭(Text) 설정
            Grid1.Columns[0].HeaderText = "품목코드";
            Grid1.Columns[1].HeaderText = "품목명";
            Grid1.Columns[2].HeaderText = "비고";
            
            Grid2.Columns[0].HeaderText = "자재코드";
            Grid2.Columns[1].HeaderText = "자재명";
            Grid2.Columns[2].HeaderText = "필요자재수량";
            Grid2.Columns[3].HeaderText = "자재단위";
            Grid2.Columns[4].HeaderText = "비고";

            //// 컬럼의 폭 지정
            Grid1.Columns[0].Width = 90;
            Grid1.Columns[1].Width = 110;
            Grid1.Columns[2].Width = 250;

            //Grid2.Columns[0].Width = 120;
            //Grid2.Columns[1].Width = 120;
            //Grid2.Columns[2].Width = 120;
            //Grid2.Columns[3].Width = 120;
            //Grid2.Columns[4].Width = 130;

            Inquire();

            // cbItemName 콤보박스에 데이터 넣기

            if (!DBHelper(false)) return;

            try
            {
                Adapter = new MySqlDataAdapter("BOM_COMBO_Select_01", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                // Adapter 실행.
                DataTable dtTemp0 = new DataTable();
                Adapter.Fill(dtTemp0);
                // 결과값을 그리드뷰에 표현.
                cbItemName.DataSource = dtTemp0;
                cbItemName.ValueMember = "VL";
                cbItemName.DisplayMember = "DP";




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
                //Adapter = new MySqlDataAdapter("BM_BOM_S1", Connect);
                Adapter = new MySqlDataAdapter("BOM_Select_01", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                Adapter.SelectCommand.Parameters.AddWithValue("ICODE", Convert.ToString(cbItemName.SelectedValue));
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

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //((DataTable)Grid2.DataSource).Rows.Clear();
            string Pacode = Grid1.CurrentRow.Cells[0].Value.ToString();
            if (!DBHelper(false)) return;

            try
            {
                // Adapter 에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new MySqlDataAdapter("BOM_Select_02", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                Adapter.SelectCommand.Parameters.AddWithValue("ICODE", Pacode);

                //Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                //// 데이터베이스 처리 시 C#으로 반환할 값을 담는 변수.
                //Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                //Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행.
                DataTable dtTemp2 = new DataTable();
                Adapter.Fill(dtTemp2);
                // 결과값을 그리드뷰에 표현.
                Grid2.DataSource = dtTemp2;

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

        private void button1_Click(object sender, EventArgs e)
        {
            Inquire();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataTable)Grid2.DataSource).NewRow();
            ((DataTable)Grid2.DataSource).Rows.Add(dr);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // 사용자 내역 행에서 삭제
            // Removeat ( 행 자체를 DataSource 에서도 삭제)
            if (Grid2.Rows.Count == 0) return;
            int iSelectRowIndex = Grid2.CurrentRow.Index;
            DataTable dtTemp = (DataTable)Grid2.DataSource;
            //dtTemp.Rows.RemoveAt(iSelectRowIndex);

            // 눈에 보인느 행은 삭제가 되면서 DataSource에는 삭제된 행이라는 정보를 남기기.
            // Delete() 삭제한 데이터를 DataSource에는 남긴다.
            string smcode = Convert.ToString(Grid2.Rows[iSelectRowIndex].Cells["mcode"].Value);
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                if (dtTemp.Rows[i].RowState == DataRowState.Deleted) continue;
                if (smcode == Convert.ToString(dtTemp.Rows[i]["mcode"])) dtTemp.Rows[i].Delete();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            // 1. 데이터베이스 접속
            if (!DBHelper(true)) return;
            // 2. Insert Update Delete 전달 SqlCommand 클래스 객체 생성.
            cmd = new MySqlCommand();
            // 3. 생성한 트랜잭션 등록
            cmd.Transaction = tran;
            // 4. 데이터베이스 접속 경로 연결
            cmd.Connection = Connect;
            // 5. 프로시져형태로 호출함을 선언.
            cmd.CommandType = CommandType.StoredProcedure;




            string sMessage = string.Empty;
            try
            {
                // 그리드조회 후 변경된 행의 정보만 추출.
                DataTable dtChange = ((DataTable)Grid2.DataSource).GetChanges();
                if (dtChange == null) return;

                // 변경된 그리드의 데이터 추출 내역 중 상위로부터 하나의 행씩 뽑아온다.
                foreach (DataRow drrow in dtChange.Rows)
                {
                    switch (drrow.RowState)
                    {
                        case DataRowState.Deleted:
                            drrow.RejectChanges();
                            // 사용자 정보를 삭제하는 저장 프로시져 호출
                            cmd.CommandText = "BOM_Delete_01";
                            cmd.Parameters.AddWithValue("pco", Convert.ToString(Grid1.CurrentRow.Cells["icode"].Value));
                            cmd.Parameters.AddWithValue("mco", drrow["mcode"]);


                            cmd.ExecuteNonQuery();
                            break;
                        case DataRowState.Added:
                            if (Convert.ToString(drrow["mcode"]) == "") sMessage += "자재코드 ";
                            if (Convert.ToString(drrow["CQTY"]) == "") sMessage += "정미수량 ";
                            if (sMessage != "")
                            {
                                throw new Exception($"필수 정보({sMessage})을/를 입력하지 않았습니다.");
                            }
                            cmd.CommandText = "BOM_Insert_01";
                            cmd.Parameters.AddWithValue("pco", Convert.ToString(Grid1.CurrentRow.Cells["icode"].Value));
                            cmd.Parameters.AddWithValue("mco", drrow["mcode"]);
                            cmd.Parameters.AddWithValue("QT", drrow["CQTY"]);
                            cmd.Parameters.AddWithValue("No", drrow["mbi"]);

                            cmd.ExecuteNonQuery();

                            break;

                    }
                    
                    cmd.Parameters.Clear();
                }
                tran.Commit();
                MessageBox.Show("정상적으로 등록되었습니다.");
                Inquire();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void DGV_ComboBox()
        {
            DataGridViewComboBoxCell cbcell = new DataGridViewComboBoxCell();
            cbcell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

            if (!DBHelper(false)) return;

            try
            {
                Adapter = new MySqlDataAdapter("BOM_GRIDVIEW_COMBO_Select_01", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                // Adapter 실행.
                DataTable dtTemp4 = new DataTable();
                Adapter.Fill(dtTemp4);
                // 결과값을 그리드뷰에 표현.
                cbcell.DataSource = dtTemp4;

                cbcell.ValueMember = "VL";
                cbcell.DisplayMember = "DP";
                Grid2.CurrentRow.Cells["mcode"] = cbcell;




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
    }
}

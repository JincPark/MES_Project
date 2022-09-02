using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assemble;
using System.Data.SqlClient;

namespace Form_List
{

    public partial class ItemMaster : Form
    {

        private SqlConnection Connect;  // 데이터베이스에 접속하는 정보를 관리하는 클래스.

        // 2. Select (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. insert, update, delete 의 명령을 전달할 클래스.
        private SqlTransaction tran;    // 데이터베이스 데이터관리(승인, 복구) 권한 부여.
        private SqlCommand cmd;         // 데이터베이스에 Insert Update Delete 명령을 전달할 클래스.

        public ItemMaster()
        {
            InitializeComponent();
        }

        private void ItemMaster_Load(object sender, EventArgs e)
        {


            /*************************** 기본 그리드 내역 세팅 ******************************/
            DataTable dtGrid1 = new DataTable();

            dtGrid1.Columns.Add("ItemType",     typeof(string));    // 품목구분
            dtGrid1.Columns.Add("ItemCode",     typeof(string));    // 품목코드
            dtGrid1.Columns.Add("ItemName",     typeof(string));    // 품목명
            dtGrid1.Columns.Add("Unit",         typeof(string));    // 기본단위
            dtGrid1.Columns.Add("Note",         typeof(string));    // 비고
            dtGrid1.Columns.Add("Maker",        typeof(string));    // 등록자
            dtGrid1.Columns.Add("MakeDate",     typeof(string));    // 등록일시

            // 빈 컬럼 테이블 그리드에 매핑.
            Grid1.DataSource = dtGrid1;

            // 그리드 컬럼 명칭(Text) 설정
            Grid1.Columns[0].HeaderText = "품목구분";
            Grid1.Columns[1].HeaderText = "품목코드";
            Grid1.Columns[2].HeaderText = "품목명";
            Grid1.Columns[3].HeaderText = "단위";
            Grid1.Columns[4].HeaderText = "비고";
            Grid1.Columns[5].HeaderText = "등록자";
            Grid1.Columns[6].HeaderText = "등록일시";

            //// 컬럼의 폭 지정
            //Grid1.Columns[0].Width = 90;
            //Grid1.Columns[1].Width = 90;
            //Grid1.Columns[2].Width = 110;
            //Grid1.Columns[3].Width = 70;
            //Grid1.Columns[4].Width = 188;
            //Grid1.Columns[5].Width = 80;
            //Grid1.Columns[6].Width = 100;

            //// 콤보박스 값 초기화
            //cbItemType.DisplayMember = "Display";
            //cbItemType.ValueMember = "Value";

            //cbItemType.Items.Add(new { Display = "선택", Value = "" });
            //cbItemType.Items.Add(new { Display = "완제품", Value = "FERT" });
            //cbItemType.Items.Add(new { Display = "자재", Value = "ROH" });

            // ********************* 부서 정보 콤보박스 셋팅. ******************
            // 시스템 코드(공통코드)
            // 시스템 운영시 데이터가 코드로 관리되는 항목들의 리스트.
            // 일반적으로 마스터 데이터 보다관리할 내용이 적은 항목들을 공토으로 관리하며 
            // 공통코드 관리테이블에서 일괄적으로 관리한다.
            Commons Com = new Commons();
            DataTable dtTemp = Com.Combo1();
            cbItem.DataSource = dtTemp;
            cbItem.ValueMember = "cbItemCode";
            cbItem.DisplayMember = "cbItemName";

            Commons Com2 = new Commons();

            DataTable dtTemp1 = Com2.Combo2();
            cbItemType.DataSource = dtTemp1;
            cbItemType.ValueMember = "ValueType";
            cbItemType.DisplayMember = "DPType";

            Inquire();
        }
        public void Inquire()
        {
            /************************ 사용자 내역 조회 ********************/

            if (!DBHelper(false)) return;

            try
            {
                // 사용자 정보 조회

                // Adapter 에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("ItemMaster_Select_01", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                Adapter.SelectCommand.Parameters.AddWithValue("@ItemType", cbItemType.SelectedValue) ;
                Adapter.SelectCommand.Parameters.AddWithValue("@ItemCode", cbItem.SelectedValue);
                Adapter.SelectCommand.Parameters.AddWithValue("@ItemName", txtItemName.Text);


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
            Connect = new SqlConnection(Commons.conn);
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

        private void btSearch_Click(object sender, EventArgs e)
        {
            Inquire();
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            grid2_Inquire();
            //DataRow dr = ((DataTable)Grid1.DataSource).NewRow();
            //((DataTable)Grid1.DataSource).Rows.Add(dr);
            ////ItemMaster_POP AddPop = new ItemMaster_POP();
            ////AddPop.ShowDialog();
            ////Inquire();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (Grid1.Rows.Count == 0) return;
            int iSelectRowIndex = Grid1.CurrentRow.Index;
            DataTable dtTemp = (DataTable)Grid1.DataSource;
            string sItemCode = Convert.ToString(Grid1.Rows[iSelectRowIndex].Cells["ItemCode"].Value);
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                if (dtTemp.Rows[i].RowState == DataRowState.Deleted) continue;
                if (sItemCode == Convert.ToString(dtTemp.Rows[i]["ItemCode"])) dtTemp.Rows[i].Delete();
            }

        }
        private void cbItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Inquire();
            }
        }

        private void cbItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Inquire();
            }
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Inquire();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!DBHelper(true)) return;
            // 2. Insert Update Delete 전달 SqlCommand 클래스 객체 생성.
            cmd = new SqlCommand();
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
                DataTable dtChange = ((DataTable)Grid1.DataSource).GetChanges();
                if (dtChange == null) return;

                // 변경된 그리드의 데이터 추출 내역 중 상위로부터 하나의 행씩 뽑아온다.
                foreach (DataRow drrow in dtChange.Rows)
                {
                    switch (drrow.RowState)
                    {
                        case DataRowState.Deleted:
                            drrow.RejectChanges();

                            
                            cmd.CommandText = "ItemMaster_Delete_01";
                            cmd.Parameters.AddWithValue("@ItemCode", drrow["ItemCode"]);

                            cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                            cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;


                            cmd.ExecuteNonQuery();
                            break;
                        //case DataRowState.Modified:
                        //    // 사용자 정보가 수정된 상태이면.
                        //    if (Convert.ToString(drrow["USERID"]) == "") sMessage += "사용자ID ";
                        //    if (Convert.ToString(drrow["USERNAME"]) == "") sMessage += "사용자명 ";
                        //    if (Convert.ToString(drrow["PW"]) == "") sMessage += "비밀번호 ";
                        //    if (sMessage != "")
                        //    {
                        //        throw new Exception($"필수 정보({sMessage}를 입력하지 않았습니다.");
                        //    }

                        //    // 사용자 정보를 변경하는 저장 프로시져 호출
                        //    cmd.CommandText = "BM_UserMaster_U";
                        //    cmd.Parameters.AddWithValue("USERID", drrow["USERID"]);
                        //    cmd.Parameters.AddWithValue("USERNAME", drrow["USERNAME"]);
                        //    cmd.Parameters.AddWithValue("PASSWORD", drrow["PW"]);
                        //    cmd.Parameters.AddWithValue("DEPTCODE", drrow["DEPTCODE"]);
                        //    cmd.Parameters.AddWithValue("EDITOR", Commons.cLogInId);
                        //    cmd.Parameters.AddWithValue("LANG", "KO");
                        //    cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                        //    cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                        //    cmd.ExecuteNonQuery();
                        //    break;
                        case DataRowState.Added:


                            cmd.CommandText = "ItemMaster_Insert_01";
                            cmd.Parameters.AddWithValue("@ItemType", drrow["ItemType"]);
                            cmd.Parameters.AddWithValue("@ItemCode", drrow["ItemCode"]);
                            cmd.Parameters.AddWithValue("@ItemName", drrow["ItemName"]);
                            cmd.Parameters.AddWithValue("@Unit",     drrow["Unit"]);
                            cmd.Parameters.AddWithValue("@Note",     drrow["Note"]);
                            cmd.Parameters.AddWithValue("@Maker", Commons.cUserName);

                            cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                            cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();



                            break;

                    }
                    if (Convert.ToString(cmd.Parameters["RS_CODE"].Value) != "S")
                    {
                        throw new Exception("품목 정보 등록 중 오류가 발생하였습니다.");
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


        private void grid2_Inquire()
        {
            // 그리드에 행 추가
            DataRow Drrow = ((DataTable)Grid1.DataSource).NewRow();
            ((DataTable)Grid1.DataSource).Rows.Add(Drrow);

            // 그리드 타입과 유닛에 콤보박스 추가
            DataGridViewComboBoxCell cCell = new DataGridViewComboBoxCell();
            DataGridViewComboBoxCell cCell1 = new DataGridViewComboBoxCell();
            cCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            cCell1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;


            // 데이터 베이스 접속
            if (DBHelper(false) == false) return;

            try
            {
                DataTable dtTemp = new DataTable();
                DataTable dtTemp1 = new DataTable();


                // Adapter 에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("ItemMaster_Combo_Type", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                Adapter.Fill(dtTemp);
                // Adapter 에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("ItemMaster_Combo_Unit", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                Adapter.Fill(dtTemp1);

                // Adapter 실행.             

                // 그리드 콤보박스 등록하기

                if (dtTemp.Rows.Count == 0) return;
                if (dtTemp1.Rows.Count == 0) return;

                // 콤보박스에 데이터 등록
                cCell.DataSource = dtTemp;
                cCell1.DataSource = dtTemp1;

                // 프로시져를 통해 콤보박스에 보여지는 값
                cCell.DisplayMember = "VL";
                cCell1.DisplayMember = "VL";

                // 콤보박스에 실제 들어있는 값 
                cCell.ValueMember = "VL";
                cCell1.ValueMember = "VL";


                // 추가한 열 위치의 품번 셀에 생성한 콤보박스 값 넣기
                Grid1.Rows[Grid1.Rows.Count - 1].Cells["ItemType"] = cCell;
                Grid1.Rows[Grid1.Rows.Count - 1].Cells["Unit"] = cCell1;

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

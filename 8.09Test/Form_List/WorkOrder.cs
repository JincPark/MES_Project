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
    public partial class JAG : Form
    {

        
        private SqlConnection Connect;
        private SqlDataAdapter Adapter;
        private SqlTransaction tran;    // 데이터베이스 데이터관리(승인, 복구) 권한 부여.
        private SqlCommand cmd;

        //DataTable dtGrid = new DataTable();
        


        public JAG()
        {
            InitializeComponent();

        }

        

            //public void GridViewFill()
            //{
            //    Connect = new SqlConnection(Commons.conn);
            //    // 2. 데이터베이스 오픈
            //    Connect.Open();

            //    DataTable dtTemp = new DataTable();
            //    Adapter.Fill(dtTemp);

            //    // 결과값을 그리드뷰에 표현.
            //    odGrid1.DataSource = dtTemp;

            //    Connect.Close();
            //}

            // 작업지시등록에서 조회 버튼 누르면 품목 검색할 수 있는 보조창 팝업




        private void JAG_Load(object sender, EventArgs e)
        {
            // 그리드 내역
            DataTable dtGrid = new DataTable(); 
            Grid1.DataSource = dtGrid;

            dtGrid.Columns.Add("ORDERNO", typeof(string));
            dtGrid.Columns.Add("ITEMTYPE", typeof(string));
            dtGrid.Columns.Add("ITEMCODE", typeof(string));
            dtGrid.Columns.Add("ITEMNAME", typeof(string));
            dtGrid.Columns.Add("UNIT", typeof(string));
            dtGrid.Columns.Add("ORDERQTY", typeof(double));
            dtGrid.Columns.Add("ORDERFLAG", typeof(string));
            dtGrid.Columns.Add("SIZE", typeof(string));
            dtGrid.Columns.Add("WORKCENTERCODE", typeof(string));
            dtGrid.Columns.Add("MAKER", typeof(string));
            dtGrid.Columns.Add("MAKEDATE", typeof(string));
            dtGrid.Columns.Add("NOTE", typeof(string));



            Grid1.Columns[0].HeaderText = "작업지시번호";
            Grid1.Columns[1].HeaderText = "품목구분";
            Grid1.Columns[2].HeaderText = "품목코드";
            Grid1.Columns[3].HeaderText = "품목명";
            Grid1.Columns[4].HeaderText = "단위";
            Grid1.Columns[5].HeaderText = "지시수량";
            Grid1.Columns[6].HeaderText = "확정여부";
            Grid1.Columns[7].HeaderText = "규격";
            Grid1.Columns[8].HeaderText = "작업장";
            Grid1.Columns[9].HeaderText =  "등록자";;
            Grid1.Columns[10].HeaderText = "등록일자";
            Grid1.Columns[11].HeaderText = "비고";


            Grid1.Columns[0].Width  = 100;
            Grid1.Columns[1].Width  = 80;
            Grid1.Columns[2].Width  = 80;
            Grid1.Columns[3].Width  = 80;
            Grid1.Columns[4].Width  = 80;
            Grid1.Columns[5].Width  = 80;
            Grid1.Columns[6].Width  = 80;
            Grid1.Columns[7].Width  = 80;
            Grid1.Columns[8].Width  = 80;
            Grid1.Columns[9].Width  = 80;
            Grid1.Columns[10].Width = 80;
            Grid1.Columns[11].Width = 80;

            
            // 수정할 수 없는 칼럼
            //Grid1.Columns["ORDERNO"].ReadOnly = true;
            Grid1.Columns["ITEMTYPE"].ReadOnly = true;
            Grid1.Columns["MAKER"].ReadOnly = true;                 
            Grid1.Columns["MAKEDATE"].ReadOnly = true;


           
            //Grid1.Rows.Add();


        }


       
        // 조회 버튼 클릭시 
        private void btSearch_Click(object sender, EventArgs e)
        {
            Inquire();
        }

        public void Inquire()
        {
            if (DBHelper(false) == false) return;
            
            try
            {
                // 사용자 정보 조회

                // Adapter 에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("WorkOrder_Select_01", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                Adapter.SelectCommand.Parameters.AddWithValue("ORDERN", "");
               



                // Adapter 실행.
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);
                // 결과값을 그리드뷰에 표현.
                Grid1.DataSource = dtTemp;


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


        // 등록 버튼 누르면 프로시져 작동 - 프로시져 수정중(TEST 프로시져)
        private void btCreate_Click(object sender, EventArgs e)
        {
            if (DBHelper(true) == false) return;
            cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = Connect;
            cmd.CommandType = CommandType.StoredProcedure;

            string sMSG = string.Empty;

            try
            {
                DataTable dtCng = ((DataTable)Grid1.DataSource).GetChanges();
                if (dtCng == null) return;

                foreach (DataRow drrow in dtCng.Rows)
                {
                    switch (drrow.RowState)
                    {
                        case DataRowState.Deleted:
                            drrow.RejectChanges();
                            cmd.CommandText = "TEST_WO_D1";
                            cmd.Parameters.AddWithValue("ORDERNO", drrow["ORDERNO"]);
 

                            cmd.ExecuteNonQuery();

                            break;
                        case DataRowState.Modified:
                            string sOrderFlag = "N";
                            if (Convert.ToString(drrow["CHK"]) == "1") sOrderFlag = "Y";
                            if (Convert.ToString(drrow["ITEMCODE"]) == "") sMSG += "품목코드";
                            if (sMSG != "")
                            {
                                throw new Exception($"{sMSG}을(를) 입력하세요.");
                            }
                            cmd.CommandText = "AP_WORKORDER_U";

                            cmd.Parameters.AddWithValue("PLANTCODE", drrow["PLANTCODE"]);
                            cmd.Parameters.AddWithValue("ITEMCODE",  drrow["ITEMCODE"]);
                            cmd.Parameters.AddWithValue("ORDERFLAG", sOrderFlag);
                            cmd.Parameters.AddWithValue("WORKCENTERCODE",   drrow["WORKCENTERCODE"]);
                            cmd.Parameters.AddWithValue("MAKER",     Commons.cLogInId);

                            cmd.ExecuteNonQuery();
                            break;

                        case DataRowState.Added:
                            cmd.CommandText = "TEST_WO_I1";

                            cmd.Parameters.AddWithValue("ORDERNO", drrow["ORDERNO"]);
                            cmd.Parameters.AddWithValue("ITEMCODE", drrow["ITEMCODE"]);
                            cmd.Parameters.AddWithValue("ORDERQTY", Convert.ToString(drrow["ORDERQTY"]).Replace(",",""));
                            cmd.Parameters.AddWithValue("WORKCENTERCODE", drrow["WORKCENTERCODE"]);
                            cmd.Parameters.AddWithValue("MAKER", Commons.cLogInId);

                            cmd.ExecuteNonQuery();
                            break;
                    }
                    cmd.Parameters.Clear();
                }
                tran.Commit();
                MessageBox.Show("정상적으로 저장되었습니다.");
                Inquire();
            }
            catch(Exception ex)
            {
                tran.Rollback(); 
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }

            
        }


        // 삭제 버튼 클릭 시
        private void btDelete_Click(object sender, EventArgs e)
        {

            if (Grid1.Rows.Count == 0) return;

            int iCrow = Grid1.CurrentRow.Index;
            DataTable dtTemp = (DataTable)Grid1.DataSource;

            //string sORDERN = Convert.ToString(Grid1.Rows[iCrow].Cells["CHK"].Value);

            string sOrderNo = Convert.ToString(Grid1.Rows[iCrow].Cells["ORDERNO"].Value);
            for (int i = 0; i < dtTemp.Rows.Count; i++ )
            {
                if (dtTemp.Rows[i].RowState == DataRowState.Deleted) continue;   // 데이터 소스와 비교 도중 삭제된 행이 있으면 다음 로직으로 넘어감
                if (sOrderNo == Convert.ToString(dtTemp.Rows[i]["ORDERNO"]))
                {
                    dtTemp.Rows[i].Delete();
                }
            }
            



        }


        // 추가 버튼 
        private void btInsert_Click(object sender, EventArgs e)
        {
            // 그리드에 행 추가
            DataRow Drrow = ((DataTable)Grid1.DataSource).NewRow();
            ((DataTable)Grid1.DataSource).Rows.Add(Drrow);

            // 그리드 콤보박스 추가
            DataGridViewComboBoxCell cCell = new DataGridViewComboBoxCell();
            cCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;


            // 데이터 베이스 접속
            if (DBHelper(false) == false) return;

            try
            {

                DataTable dtTemp = new DataTable();
                
                
                // Adapter 에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("WorkOrder_cbo_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                
                // Adapter 실행.             
                Adapter.Fill(dtTemp);

                // 그리드 콤보박스 등록하기

                if (dtTemp.Rows.Count == 0) return;
                
                // 콤보박스에 데이터 등록
                cCell.DataSource = dtTemp;

                // 프로시져를 통해 콤보박스에 보여지는 값
                cCell.DisplayMember = "ItemCode";

                // 콤보박스에 실제 들어있는 값 
                cCell.ValueMember = "ItemName";


                // 추가한 열 위치의 품번 셀에 생성한 콤보박스 값 넣기
                Grid1.Rows[Grid1.Rows.Count - 1].Cells["ITEMCODE"] = cCell;

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

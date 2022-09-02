using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assemble;


namespace Form_List
{
    public partial class BOM_POP : Form
    {
        // 1. 공통 클래스(데이터베이스 커넥터)
        private SqlConnection Connect;  // 데이터베이스에 접속하는 정보를 관리하는 클래스.

        // 2. Select (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. insert, update, delete 의 명령을 전달할 클래스.
        private SqlTransaction tran;    // 데이터베이스 데이터관리(승인, 복구) 권한 부여.
        private SqlCommand cmd;         // 데이터베이스에 Insert Update Delete 명령을 전달할 클래스.

        bool On;
        Point Pos;
        DataTable dtGrid1;
        public BOM_POP()
        {
            InitializeComponent();
            MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { On = true; Pos = e.Location; } };
            MouseMove += (o, e) => { if (On) Location = new Point(Location.X + (e.X - Pos.X), Location.Y + (e.Y - Pos.Y)); };
            MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { On = false; Pos = e.Location; } };
        }

        private void BOM_POP_Load(object sender, EventArgs e)
        {
            /*************************** 기본 그리드 내역 세팅 ******************************/
            dtGrid1 = new DataTable();

            dtGrid1.Columns.Add("PCode",    typeof(string));    // 모품목
            dtGrid1.Columns.Add("ItemCode", typeof(string));    // 자품목
            dtGrid1.Columns.Add("QTY",      typeof(string));    // 정미수량
            dtGrid1.Columns.Add("NOTE",     typeof(string));    // 비고


            // 빈 컬럼 테이블 그리드에 매핑.
            Grid.DataSource = dtGrid1;

            // 그리드 컬럼 명칭(Text) 설정
            Grid.Columns[0].HeaderText = "모품목";
            Grid.Columns[1].HeaderText = "자품목";
            Grid.Columns[2].HeaderText = "정미수량";
            Grid.Columns[3].HeaderText = "비고";


            //// 컬럼의 폭 지정
            //Grid.Columns[0].Width = 90;
            //Grid.Columns[1].Width = 90;
            //Grid.Columns[2].Width = 110;
            //Grid.Columns[3].Width = 70;
            //// 컬럼의 폭 지정
            //Grid1.Columns[0].Width = 200;
            //Grid1.Columns[1].Width = 200;
            //Grid1.Columns[2].Width = 210;

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

            //Commons Com1 = new Commons();

            //DataTable dtTemp1 = Com1.Combo2();
            //cbType.DataSource = dtTemp1;
            //cbType.ValueMember = "ValueType";
            //cbType.DisplayMember = "DPType";

            //cbUnit.Items.Add("EA");
            //cbUnit.Items.Add("KG");

            //cbType.SelectedIndex = 0;
            //cbUnit.SelectedIndex = 0;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            // 그리드에 행 추가
            DataRow Drrow = ((DataTable)Grid.DataSource).NewRow();
            ((DataTable)Grid.DataSource).Rows.Add(Drrow);

            // 그리드 콤보박스 추가
            DataGridViewComboBoxCell cCell1 = new DataGridViewComboBoxCell();
            cCell1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            // 그리드 콤보박스 추가
            DataGridViewComboBoxCell cCell2 = new DataGridViewComboBoxCell();
            cCell2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;


            // 데이터 베이스 접속`
            if (DBHelper(false) == false) return;

            try
            {

                DataTable dtTemp1 = new DataTable();
                DataTable dtTemp2 = new DataTable();
                // Adapter 에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BOM_POP_COMBO_SELECT_01", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Adapter 실행.             
                Adapter.Fill(dtTemp1);

                // Adapter 에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BOM_POP_COMBO_SELECT_02", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Adapter 실행.             
                Adapter.Fill(dtTemp2);

                // 그리드 콤보박스 등록하기

                if (dtTemp1.Rows.Count == 0) return;
                if (dtTemp2.Rows.Count == 0) return;

                // 콤보박스에 데이터 등록
                cCell1.DataSource = dtTemp1;
                cCell2.DataSource = dtTemp2;

                // 프로시져를 통해 콤보박스에 보여지는 값
                cCell1.DisplayMember = "DP";

                // 콤보박스에 실제 들어있는 값 
                cCell1.ValueMember = "VL";
                // 프로시져를 통해 콤보박스에 보여지는 값
                cCell2.DisplayMember = "DP";

                // 콤보박스에 실제 들어있는 값 
                cCell2.ValueMember = "VL";
                // 추가한 열 위치의 품번 셀에 생성한 콤보박스 값 넣기
                Grid.Rows[Grid.Rows.Count - 1].Cells["PCode"] = cCell1;
                Grid.Rows[Grid.Rows.Count - 1].Cells["ItemCode"] = cCell2;
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

        private void btEnter_Click(object sender, EventArgs e)
        {
            // 1. 데이터베이스 접속
            if (!DBHelper(true)) return;
            // 2. Insert Update Delete 전달 SqlCommand 클래스 객체 생성.
            cmd = new SqlCommand();
            // 3. 생성한 트랜잭션 등록
            cmd.Transaction = tran;
            // 4. 데이터베이스 접속 경로 연결
            cmd.Connection = Connect;
            // 5. 프로시져형태로 호출함을 선언.
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (Grid.Rows.Count == 0) return;

                //// Adapter 에 SQL 프로시져 이름과 접속 정보 등록.
                //Adapter = new SqlDataAdapter("BOM_POP_Insert_01", Connect);
                //Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                //Adapter 실행.
                //DataTable dtTemp2 = new DataTable();
                //Adapter.Fill(dtTemp2);
                //dtTemp2
                

                foreach (DataGridViewRow row in Grid.Rows)
                {
                    //    string checkRow = row.Cells[1].Value.ToString();
                    //    bool contains = dtTemp2.AsEnumerable().Where(c => c.Field<string>("ItemCode").Equals(checkRow)).Count() > 0;
                    //    //bool contains = dtTemp2.AsEnumerable().Any(row => checkRow == row.Field<String>("ItemCode"));
                    //    if (contains)
                    //    {
                    //        throw new Exception($"{checkRow} 은/는 이미 존재하는 품목코드 입니다.");
                    //    }
                    if (row.Cells[0].Value.ToString().Equals(row.Cells[1].Value.ToString()))
                    {
                        throw new Exception("모품목과 자품목은 같을 수 없습니다.");
                    }

                    cmd.CommandText = "BOM_POP_Insert_01";
                    cmd.Parameters.AddWithValue("@PCODE",       row.Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@CCODE",       row.Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@QTY",         row.Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@NOTE",        row.Cells[3].Value.ToString());


                    //cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    //if (Convert.ToString(cmd.Parameters["RS_CODE"].Value) != "S")
                    //{
                    //    throw new Exception("품목정보 등록 중 오류가 발생하였습니다.");
                    //}
                    cmd.Parameters.Clear();
                }
                tran.Commit();
                MessageBox.Show("성공적으로 등록하셨습니다.");
                Close();
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
        //private Point mousePoint;

        //// 마우스 누를때 현재 마우스 좌표를 저장한다 
        //private void Form1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    mousePoint = new Point(e.X, e.Y); //현재 마우스 좌표 저장
        //}

        //// 마우스 왼쪽 버튼을 누르고 움직이면 폼을 이동시킨다
        //private void Form1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if ((e.Button & MouseButtons.Left) == MouseButtons.Left) //마우스 왼쪽 클릭 시에만 실행
        //    {
        //        //폼의 위치를 드래그중인 마우스의 좌표로 이동 
        //        Location = new Point(Left - (mousePoint.X - e.X), Top - (mousePoint.Y - e.Y));
        //    }
        //}
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

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count == 0) return;
            DataTable dtTemp = (DataTable)Grid.DataSource;
            dtTemp.Rows.RemoveAt(Grid.CurrentRow.Index);
        }
    }
}

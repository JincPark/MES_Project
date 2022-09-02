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
    public partial class Pop_WorkOrder : Form
    {

        private SqlConnection Connect;  // 데이터베이스에 접속하는 정보를 관리하는 클래스.

        // 2. Select (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. insert, update, delete 의 명령을 전달할 클래스.
        private SqlTransaction tran;    // 데이터베이스 데이터관리(승인, 복구) 권한 부여.


        private Point mousePoint;

        // 마우스 누를때 현재 마우스 좌표를 저장한다 
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y); //현재 마우스 좌표 저장
        }

        // 마우스 왼쪽 버튼을 누르고 움직이면 폼을 이동시킨다
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) //마우스 왼쪽 클릭 시에만 실행
            {
                //폼의 위치를 드래그중인 마우스의 좌표로 이동 
                Location = new Point(Left - (mousePoint.X - e.X), Top - (mousePoint.Y - e.Y));
            }
        }
        public Pop_WorkOrder()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Pop_WorkOrder_Load(object sender, EventArgs e)
        {

            var chkCol = new DataGridViewCheckBoxColumn
            {
                Name = "chk",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
               
            };

            Grid1.Columns.Add(chkCol);

            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("ItemType", typeof(string));
            dtGrid.Columns.Add("ItemCode", typeof(string));
            dtGrid.Columns.Add("ItemName", typeof(string));
            dtGrid.Columns.Add("Unit", typeof(string));
            dtGrid.Columns.Add("Note", typeof(string));

            Grid1.DataSource = dtGrid;

            Grid1.Columns[1].HeaderText = "품목구분";
            Grid1.Columns[2].HeaderText = "품목코드";
            Grid1.Columns[3].HeaderText = "품목명";
            Grid1.Columns[4].HeaderText = "단위";
            Grid1.Columns[5].HeaderText = "비고";

            Grid1.Columns[0].Width = 30;
            Grid1.Columns[1].Width = 80;
            Grid1.Columns[2].Width = 80;
            Grid1.Columns[3].Width = 80;
            Grid1.Columns[4].Width = 80;
            Grid1.Columns[5].Width = 80;

           

            Inquire();
        }

        public void Inquire()
        {
            if (DBHelper(false) == false) return;

            try
            {
                // 사용자 정보 조회

                // Adapter 에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_ITEM_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                Adapter.SelectCommand.Parameters.AddWithValue("ItemType","FERT");
                Adapter.SelectCommand.Parameters.AddWithValue("ItemCode", "");
               

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
    }
}

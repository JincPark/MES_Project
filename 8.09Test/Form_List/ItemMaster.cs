﻿using MySql.Data.MySqlClient;
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

namespace Form_List
{

    public partial class ItemMaster : Form
    {

        private MySqlConnection Connect;  // 데이터베이스에 접속하는 정보를 관리하는 클래스.

        // 2. Select (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private MySqlDataAdapter Adapter;

        // 3. insert, update, delete 의 명령을 전달할 클래스.
        private MySqlTransaction tran;    // 데이터베이스 데이터관리(승인, 복구) 권한 부여.
        private MySqlCommand cmd;         // 데이터베이스에 Insert Update Delete 명령을 전달할 클래스.

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

            // 컬럼의 폭 지정
            Grid1.Columns[0].Width = 90;
            Grid1.Columns[1].Width = 90;
            Grid1.Columns[2].Width = 110;
            Grid1.Columns[3].Width = 70;
            Grid1.Columns[4].Width = 188;
            Grid1.Columns[5].Width = 80;
            Grid1.Columns[6].Width = 100;

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
                Adapter = new MySqlDataAdapter("ItemMaster_Select_01", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                Adapter.SelectCommand.Parameters.AddWithValue("Type", cbItemType.SelectedValue) ;
                Adapter.SelectCommand.Parameters.AddWithValue("Code", cbItem.SelectedValue);
                Adapter.SelectCommand.Parameters.AddWithValue("Name", txtItemName.Text);

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

        private void btSearch_Click(object sender, EventArgs e)
        {
            Inquire();
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            ItemMaster_POP AddPop = new ItemMaster_POP();
            AddPop.ShowDialog();
            Inquire();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (!DBHelper(true)) return;
            cmd = new MySqlCommand
            {
                Transaction = tran,
                Connection = Connect,
                CommandType = CommandType.StoredProcedure
            };
            try
            {

            cmd.CommandText = "ItemMaster_Delete_01";
                cmd.Parameters.AddWithValue("PCODE", Grid1.CurrentRow.Cells[1].Value.ToString()) ;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            tran.Commit();
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
            Inquire();
        }
    }
    
}

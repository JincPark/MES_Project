using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_List
{
    public partial class Pop_WorkOrder : Form
    {

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
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("품목코드", typeof(string));    
            dtGrid.Columns.Add("품목명",   typeof(string));    
            dtGrid.Columns.Add("입고창고", typeof(string));    
            dtGrid.Columns.Add("비고",     typeof(string));

            Grid1.DataSource = dtGrid;

            Grid1.Columns["품목코드"].HeaderText = "품목코드";
            Grid1.Columns["품목명"].HeaderText = "품목명";
            Grid1.Columns["입고창고"].HeaderText = "입고창고";
            Grid1.Columns["비고"].HeaderText = "비고";

            Grid1.Columns["품목코드"].Width = 80;
            Grid1.Columns[1].Width = 80;                      
            Grid1.Columns[2].Width = 80;                    
            Grid1.Columns[3].Width = 80;
        }




    }
}

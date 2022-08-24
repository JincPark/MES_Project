using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Assemble;
using Form_List;

namespace _8._09Test
{
    public partial class MainForm : Form
    {
        //int testNo = 0;
        public MainForm()
        {
            LogIn FormLog = new LogIn();      // 로그인 화면 만들기
            FormLog.ShowDialog();             // 로그인 창만 띄움
            if (Commons.cLogInSF != true)
            {

                Environment.Exit(0);
            }

            InitializeComponent();
        }

        #region <종료버튼 및 종료시>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)

        {

            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Cancel)

                e.Cancel = true;

        }

        private void btnExit_Click(object sender, EventArgs e)

        {

            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)

                Application.Exit();

        }
        #endregion

        private void button3_Click(object sender, EventArgs e) // MES기준정보 버튼
        {
            P1.Visible = !P1.Visible;                       // MES기준정보 하단버튼패널 활성화 및 비활성화
            //if (P1.Visible) button3.Image = global::8.09Test.Properties.Resources
            if (P1.Visible) this.button3.Image = _8._09Test.Properties.Resources._16up;
            else this.button3.Image = _8._09Test.Properties.Resources._16down;


        }

        private void button8_Click(object sender, EventArgs e) // 영업관리 버튼
        {
            P2.Visible = !P2.Visible;                       // 영업관리 하단버튼패널 활성화 및 비활성화
            if (P2.Visible) this.button8.Image = _8._09Test.Properties.Resources._16up;
            else this.button8.Image = _8._09Test.Properties.Resources._16down;
        }

        private void button13_Click(object sender, EventArgs e) // 생산관리 버튼
        {

            P3.Visible = !P3.Visible;                       // 생산관리 하단버튼패널 활성화 및 비활성화
            if (P3.Visible) this.button13.Image = _8._09Test.Properties.Resources._16up;
            else this.button13.Image = _8._09Test.Properties.Resources._16down;
        }

        private void Form1_Load(object sender, EventArgs e) // 메인 폼 로드
        {

            // 폼 로드시 모든 패널 비활성화
            P1.Visible = false; 
            P2.Visible = false;
            P3.Visible = false;
            btnUserName.Text = Commons.cUserName;
        }

        #region <서브메뉴 색 변경>
        private void subMenuButtonColor(Button btn)
        {
            // 색상 초기화
            JAG.BackColor = Color.FromArgb(207, 202, 186);
            SANG.BackColor = Color.FromArgb(207, 202, 186);
            BOM.BackColor = Color.FromArgb(207, 202, 186);
            ItemMaster.BackColor = Color.FromArgb(207, 202, 186);
            JAG.ForeColor = Color.FromArgb(0, 0, 0);
            SANG.ForeColor = Color.FromArgb(0, 0, 0);
            BOM.ForeColor = Color.FromArgb(0, 0, 0);
            ItemMaster.ForeColor = Color.FromArgb(0, 0, 0);
            

            // 누른 버튼 색상 변경
            btn.BackColor = Color.FromArgb(140, 113, 94);
            btn.ForeColor = Color.FromArgb(255, 255, 255);

        }
        #endregion

        #region <메뉴 색 변경>
        private void menuButtonColor(Button btn)
        {
            // 색상 초기화
            button3.BackColor = Color.FromArgb(153, 113, 73);
            button8.BackColor = Color.FromArgb(153, 113, 73);
            button13.BackColor = Color.FromArgb(153, 113, 73);

            // 누른 버튼 색상 변경
            btn.BackColor = Color.FromArgb(77, 52, 27);
        }
        #endregion


        private void btJ_Click(object sender, EventArgs e) // 작업지시등록 버튼
        {
            subMenuButtonColor((Button)sender);             // 서브메뉴버튼색 변경
            OpenForm((Button)sender);


        }

        private void btS_Click(object sender, EventArgs e) // 생산실적관리 버튼
        {
            subMenuButtonColor((Button)sender);             // 서브메뉴버튼색 변경
            OpenForm((Button)sender);

        }

        private void button7_Click(object sender, EventArgs e) // BOM 버튼
        {
            subMenuButtonColor((Button)sender);             // 서브메뉴버튼색 변경

            OpenForm((Button)sender);
        }

        private void OpenForm(Button btn)
        {

            // 중복화면 호출 시 기존 화면 활성화. 

            // 1. 클릭한 메뉴의 CS 이름. 
            string sCmenuName = btn.Name.ToString();

            for (int i = 0; i < pnForm.Controls.Count; i++)
            {
                // 2. 오픈되어있는 페이지의 이름.
                string openedName = pnForm.Controls[i].Name.ToString();

                if (sCmenuName.Equals(openedName))
                {
                    pnForm.Controls[i].BringToFront();
                    return;
                }
            }

            // ------------열려있는 화면이 없을 경우---------- 폼 생성

            // 2번째 방법 -어셈블리 프로그램 파일로 클래스 호출. Form_LIST.DLL을 호출하여 클래스 표현
            Assembly assem = Assembly.LoadFrom($"{Application.StartupPath}\\Form_List.DLL");
            // 클릭한 메뉴의 CS 타입 확인.
            Type typeForm = assem.GetType($"Form_List.{btn.Name}", true);
            // Form 형식으로 전환.
            Form FormMDI = (Form)Activator.CreateInstance(typeForm);
            // MDI 설정
            FormMDI.MdiParent = this;
            //최초 윈도우 크기 설정
            FormMDI.WindowState = FormWindowState.Maximized;
            //윈도우 초기 스타일 설정
            FormMDI.FormBorderStyle = FormBorderStyle.None; 
            // 독스타일
            FormMDI.Dock = DockStyle.Fill; 
            // 최상위 폼 X
            FormMDI.TopLevel = false;
            // 패널에 폼 넣기
            pnForm.Controls.Add(FormMDI);
            // 폼 Show
            FormMDI.Show();
        }

        private void ItemMaster_Click(object sender, EventArgs e)
        {
            subMenuButtonColor((Button)sender);             // 서브메뉴버튼색 변경

            OpenForm((Button)sender);
        }

        private void pnForm_Resize(object sender, EventArgs e)
        {
            ////////testNo++;
            //label1.Text = Convert.ToString(pnForm.Size);
            //////// 1. 클릭한 메뉴의 CS 이름. 
            //string sCmenuName = ItemMaster.Name.ToString();

            //for (int i = 0; i < pnForm.Controls.Count; i++)
            //{
            //    // 2. 오픈되어있는 페이지의 이름.
            //    string openedName = pnForm.Controls[i].Name.ToString();

            //    if (sCmenuName.Equals(openedName))
            //    {
            //        pnForm.Controls[i].Size = new Size(pnForm.Size.Width, pnForm.Size.Height);
            //        return;
            //    }
            //}
            ////foreach (Form c in this.MdiChildren)
            ////{
            ////    c.Size = new Size(pnForm.Size.Width, pnForm.Size.Height);
            ////}
        }
    }
}

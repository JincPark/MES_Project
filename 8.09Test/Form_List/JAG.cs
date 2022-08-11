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
    public partial class JAG : Form
    {
        public JAG()
        {
            InitializeComponent();
        }


        // 작업지시등록에서 조회 버튼 누르면 품목 검색할 수 있는 보조창 팝업
        private void btSearch_Click(object sender, EventArgs e)
        {
            Pop_WorkOrder order = new Pop_WorkOrder();
 
            order.ShowDialog();                         
        }
    }
}

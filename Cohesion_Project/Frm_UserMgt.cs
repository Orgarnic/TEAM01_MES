using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cohesion_Project
{
    public partial class Frm_UserMgt : Frm_Base_2
    {
        public Frm_UserMgt()
        {
            InitializeComponent();
        }

        private void Frm_User_Load(object sender, EventArgs e)
        {
            DgvInit();
        }
        private void DgvInit()
        {
            DgvUtil.DgvInit(DgvUser);
            DgvUtil.AddTextCol(DgvUser,  "사용자 코드", "USER_ID", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "사용자 이름", "USER_NAME", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "사용자 그룹", "USER_GROUP_CODE",  120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "암호 ", "USER_PASSWORD", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "부서 ", "USER_DEPARTMENT",  120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "생성 시간 ", "CREATE_TIME", 120, true, align: 2);
            DgvUtil.AddTextCol(DgvUser, "사용자", "CREATE_USER_ID", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "수정 시간", "UPDATE_TIME",  120, true, align: 2);
            DgvUtil.AddTextCol(DgvUser, "사용자 ", "UPDATE_USER_ID",  120, true, align: 1);
        }
        

    }
}

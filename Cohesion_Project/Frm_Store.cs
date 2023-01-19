using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cohesion_Project
{
    public partial class Frm_Store : Cohesion_Project.Frm_Base_2
    {
        private PropertyGrid pg = new PropertyGrid();
        public Frm_Store()
        {
            InitializeComponent();
        }

        private void Frm_Store_Load(object sender, EventArgs e)
        {
            //lblSearch.Text = "창고명";
            //label1.Text = "창고 유형";
            lbl4.Text = "▶ 창고 목록";
            lbl3.Text = "▶ 창고 속성";
            //label2.Visible = false;
            //Cbo_Search2.Visible = false;

            DgvUtil.DgvInit(dataGridView1);
            DgvUtil.AddTextCol(dataGridView1, "창고코드", "STORE_CODE", 150, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dataGridView1, "창고명", "STORE_NAME", 150, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dataGridView1, "창고유형", "STORE_TYPE", 150, readOnly: true, align: 0);
            //DgvUtil.AddTextCol(dataGridView1, "선입선출 여부", "FIFO_FLAG", 180, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dataGridView1, "생성시간", "CREATE_TIME", 150, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dataGridView1, "생성 사용자", "CREATE_USER_ID", 150, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dataGridView1, "변경시간", "UPDATE_TIME", 150, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dataGridView1, "변경 사용자", "UPDATE_USER_ID", 150, readOnly: true, align: 0);

            propertyGrid1.PropertySort = PropertySort.NoSort;
            propertyGrid1.SelectedObject = pg;
        }

        //public static void ComboBoxBinding(ComboBox cbo, List<CommoncodeDTO> items, string category, bool blank = true, string blankText = "선택", string secondcategory = null, string thirdcategory = null)
        //{
        //    var list = items.FindAll((item) => item.Code_Category.Equals(category)).ToList();
        //    if (secondcategory != null)
        //    {
        //        var list2 = items.FindAll((item) => item.Code_Category.Equals(secondcategory)).ToList();
        //        var list3 = items.FindAll((item) => item.Code_Category.Equals(thirdcategory)).ToList();
        //        list = list.Union(list2).ToList();
        //        list = list.Union(list3).ToList();
        //    }
        //    if (blank)
        //    {
        //        CommoncodeDTO dto = new CommoncodeDTO
        //        {
        //            Code_Category = "",
        //            Code = "",
        //            Code_Name = blankText
        //        };
        //        list.Insert(0, dto);
        //    }
        //    cbo.DisplayMember = "Code_Name";
        //    cbo.ValueMember = "Code";
        //    cbo.DataSource = list;
        //}
    }

    public class PropertyGrid
    {
        [Category("속성"), DisplayName("창고코드")]
        public string STORE_CODE { get; set; }


        [Category("속성"), DisplayName("창고명")]
        public string STORE_NAME { get; set; }


        [Category("속성"), DisplayName("창고유형")]
        public string STORE_TYPE { get; set; }


        //[Category("속성"), Description("FIFO_FLAG"), DisplayName("선입선출 여부")]
        //public string FIFO_FLAG { get; set; }


        [Category("속성"), DisplayName("생성시간")]
        public string CREATE_TIME { get; set; }


        [Category("속성"), DisplayName("생성 사용자")]
        public string CREATE_USER_ID { get; set; }


        [Category("속성"), DisplayName("변경시간")]
        public string UPDATE_TIME { get; set; }


        [Category("속성"), DisplayName("변경 사용자")]
        public string UPDATE_USER_ID { get; set; }
    }
}

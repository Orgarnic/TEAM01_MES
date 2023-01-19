using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Cohesion_DAO;
using Cohesion_DTO;
using Cohesion_Project.Service;

namespace Cohesion_Project
{
    public partial class Frm_Equipment : Cohesion_Project.Frm_Base_2
    {
        Srv_Equipment srv = new Srv_Equipment();
        private PropertyGridEquipment pg = new PropertyGridEquipment();
        List<Equipment_DTO> srvList;
        public Frm_Equipment()
        {
            InitializeComponent();
        }

        private void Frm_Equipment_Load(object sender, EventArgs e)
        {
            lbl4.Text = "▶ 설비 목록";
            lbl3.Text = "▶ 설비 속성";

            ppg_Equipment.PropertySort = PropertySort.NoSort;
            ppg_Equipment.SelectedObject = pg;

            DataGridViewBinding();
        }
        private void DataGridViewBinding()
        {
            DgvUtil.DgvInit(dgv_Equipment);
            DgvUtil.AddTextCol(dgv_Equipment, "설비코드", "EQUIPMENT_CODE", 200, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgv_Equipment, "설비명", "EQUIPMENT_NAME", 150, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgv_Equipment, "설비유형", "EQUIPMENT_TYPE", 150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Equipment, "설비상태", "EQUIPMENT_STATUS", 150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Equipment, "최근 다운시간", "LAST_DOWN_TIME", 250, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Equipment, "생성 시간", "CREATE_TIME", 250, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Equipment, "생성 사용자", "CREATE_USER_ID", 150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Equipment, "변경 시간", "UPDATE_TIME", 250, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Equipment, "변경 사용자", "UPDATE_USER_ID", 150, readOnly: true, align: 1);

            srvList = srv.SelectEquipmentList();
            dgv_Equipment.DataSource = srvList;
        }

        private void dgv_Equipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string sTableName = dgv_Equipment["설비코드", e.RowIndex].Value.ToString();
            var target = srvList.Find((s) => s.EQUIPMENT_CODE.Equals(dgv_Equipment["설비코드", e.RowIndex].Value));
            SelectedRowData(target);
            ppg_Equipment.SelectedObject = pg;
        }
        private void SelectedRowData(Equipment_DTO target)
        {
            TypeConverter typeConverter = new TypeConverter();

            for (int i = 0; i < target.GetType().GetProperties().Length; i++)
            {
                string propertyName = target.GetType().GetProperties()[i].Name;
                Type propertyType = target.GetType().GetProperties()[i].PropertyType;
                for (int j = 0; j < pg.GetType().GetProperties().Length; j++)
                {
                    if (target.GetType().GetProperties()[i].GetValue(target) == null)
                        continue;

                    else if (propertyName == pg.GetType().GetProperties()[j].Name)
                    {
                        if (propertyType != pg.GetType().GetProperties()[j].PropertyType)
                        {
                            pg.GetType().GetProperties()[j].SetValue(pg, typeConverter.ConvertTo(target.GetType().GetProperties()[i].GetValue(target), pg.GetType().GetProperties()[j].PropertyType));
                            break;
                        }

                        else
                        {
                            pg.GetType().GetProperties()[j].SetValue(pg, target.GetType().GetProperties()[i].GetValue(target));
                            break;
                        }
                    }
                }
            }
        }

        //PropertyGrid 속성값 DTO 만들기
        private T1 PropertyToDto<T, T1>(T data) where T1 : class, new()
        {
            T1 dto = new T1();

            for (int i = 0; i < data.GetType().GetProperties().Length - 1; i++)
            {
                for (int j = 0; j < dto.GetType().GetProperties().Length - 1; j++)
                {
                    if (data.GetType().GetProperties()[i].Name.Equals(dto.GetType().GetProperties()[i].Name, StringComparison.OrdinalIgnoreCase))
                    {
                        dto.GetType().GetProperties()[i].SetValue(dto, data.GetType().GetProperties()[i].GetValue(data));
                        break;
                    }
                }
            }
            return dto;
        }

        
    }
    public class PropertyGridEquipment
    {
        [Category("속성"), DisplayName("설비코드")]
        public string EQUIPMENT_CODE { get; set; }


        [Category("속성"), DisplayName("설비명")]
        public string EQUIPMENT_NAME { get; set; }


        [Category("속성"), DisplayName("설비유형")]
        public string EQUIPMENT_TYPE { get; set; }

        [Category("속성"), DisplayName("설비상태")]
        public string EQUIPMENT_STATUS { get; set; }


        [Category("속성"), ReadOnlyAttribute(true), DisplayName("다운시간")]
        public DateTime LAST_DOWN_TIME { get; set; }


        [Category("속성"), ReadOnlyAttribute(true), DisplayName("생성 시간")]
        public DateTime CREATE_TIME { get; set; }


        [Category("속성"), DisplayName("생성 사용자")]
        public string CREATE_USER_ID { get; set; }


        [Category("속성"), ReadOnlyAttribute(true), DisplayName("변경 시간")]
        public DateTime UPDATE_TIME { get; set; }


        [Category("속성"), DisplayName("변경 사용자")]
        public string UPDATE_USER_ID { get; set; }
    }
}

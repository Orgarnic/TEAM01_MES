﻿using System;
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
    public partial class Frm_Store : Cohesion_Project.Frm_Base_2
    {
        Srv_Store srv = new Srv_Store();
        private PropertyGridStore pg = new PropertyGridStore();
        List<Store_DTO> srvList;
        public Frm_Store()
        {
            InitializeComponent();
        }

        private void Frm_Store_Load(object sender, EventArgs e)
        {
            lbl4.Text = "▶ 창고 목록";
            lbl3.Text = "▶ 창고 속성";

            DataGridViewBinding();

            ppg_Store.PropertySort = PropertySort.NoSort;
            ppg_Store.SelectedObject = pg;
        }
        private void DataGridViewBinding()
        {
            DgvUtil.DgvInit(dgv_Store);
            DgvUtil.AddTextCol(dgv_Store, "창고코드", "STORE_CODE", 190, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Store, "창고명", "STORE_NAME", 250, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgv_Store, "창고유형", "STORE_TYPE", 140, readOnly: true, align: 1);
            //DgvUtil.AddTextCol(dataGridView1, "선입선출 여부", "FIFO_FLAG", 180, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgv_Store, "생성시간", "CREATE_TIME", 250, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Store, "생성 사용자", "CREATE_USER_ID", 160, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgv_Store, "변경시간", "UPDATE_TIME", 250, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Store, "변경 사용자", "UPDATE_USER_ID", 160, readOnly: true, align: 0);
            srvList = srv.SelectStoreList();
            dgv_Store.DataSource = srvList;
        }

        private void dgv_Store_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string sTableName = dgv_Store["창고코드", e.RowIndex].Value.ToString();
            var target = srvList.Find((s) => s.STORE_CODE.Equals(dgv_Store["창고코드", e.RowIndex].Value));
            SelectedRowData(target);
            ppg_Store.SelectedObject = pg;
        }

        private void SelectedRowData(Store_DTO target)
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

    public class PropertyGridStore
    {
        [Category("속성"), DisplayName("창고코드")]
        public string STORE_CODE { get; set; }


        [Category("속성"), DisplayName("창고명")]
        public string STORE_NAME { get; set; }


        [Category("속성"), DisplayName("창고유형")]
        public string STORE_TYPE { get; set; }


        //[Category("속성"), Description("FIFO_FLAG"), DisplayName("선입선출 여부")]
        //public string FIFO_FLAG { get; set; }


        [Category("속성"), ReadOnlyAttribute(true), DisplayName("생성시간")]
        public DateTime CREATE_TIME { get; set; }


        [Category("속성"), DisplayName("생성 사용자")]
        public string CREATE_USER_ID { get; set; }


        [Category("속성"), ReadOnlyAttribute(true), DisplayName("변경시간")]
        public DateTime UPDATE_TIME { get; set; }


        [Category("속성"), DisplayName("변경 사용자")]
        public string UPDATE_USER_ID { get; set; }
    }
}

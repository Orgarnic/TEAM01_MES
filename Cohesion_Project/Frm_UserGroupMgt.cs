﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cohesion_DTO;

namespace Cohesion_Project
{
    public partial class Frm_UserGroup : Frm_Base_2
    {
        Srv_UserGroup srv_UG = new Srv_UserGroup();
        Srv_UserGroup Srv_UserGroup;
        List<UserGroup_DTO> UGroupList;
        private UGdate ugd = new UGdate();
        public Frm_UserGroup()
        {
            InitializeComponent();
        }
        bool state = false;
        private void Frm_UserGroup_Load(object sender, EventArgs e)
        {
            Srv_UserGroup = new Srv_UserGroup();
            DgvInit();
            DataGridViewFill();

        }
        private void DgvInit()
        {
            DgvUtil.DgvInit(DgvUserGroup);
            DgvUtil.AddTextCol(DgvUserGroup, "사용자 그룹 코드", "USER_GROUP_CODE", 150, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "사용자 그룹 명", "USER_GROUP_NAME", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "사용자 그룹 유형", "USER_GROUP_TYPE", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "생선 시간 ", "CREATE_TIME", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "생성 사용자 ", "CREATE_USER_ID", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "수정 시간 ", "UPDATE_TIME", 120, true, align: 2);
            DgvUtil.AddTextCol(DgvUserGroup, "수정 사용자", "UPDATE_USER_ID", 120, true, align: 1);


            //프로퍼티 그리드 초기 설정
            Ppg_UserGourp.PropertySort = PropertySort.Categorized;
            Ppg_UserGourp.SelectedObject = ugd;
        }


        private void DataGridViewFill()
        {
            UGroupList = Srv_UserGroup.SelectUserGroup();
            DgvUserGroup.DataSource = UGroupList;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DgvUserGroup.SelectedRows.Count < 1)
                return;
            if (MessageBox.Show($"{DgvUserGroup[1, DgvUserGroup.CurrentRow.Index].Value.ToString()} 사용자구룹을 삭제하시겠습니까 ?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            int userGroupCode = Convert.ToInt32(DgvUserGroup[0, DgvUserGroup.CurrentRow.Index].Value);
            bool result = Srv_UserGroup.DeleteUserGroup(userGroupCode);
            if (!result)
            {
                MessageBox.Show("권한 저장정보가 삭제되었습니다.", "알람", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewFill();
                DgvUserGroup.ClearSelection();
            }
        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (state)
            {
                Ppg_UserGourp.SelectedObject = ugd;
                state = false;
            }
            else
            {
                Ppg_UserGourp.SelectedObject = ugd;
                state = true;
            }
        }






        public class UGdate
        {
            [Category("속성"), Description("USER_GROUP_CODE"), DisplayName("사용자 그룹 코드")]
            public string USER_GROUP_CODE { get; set; }

            [Category("속성"), Description("USER_GROUP_NAME"), DisplayName("사용자 그룹 명")]
            public string USER_GROUP_NAME { get; set; }

            [Category("속성"), Description("USER_GROUP_TYPE"), DisplayName("사용자 그룹 유형")]
            public string USER_GROUP_TYPE { get; set; }

            [Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간")]
            public DateTime CREATE_TIME { get; set; }

            [Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성자")]
            public string CREATE_USER_ID { get; set; }

            [Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간")]
            public DateTime UPDATE_TIME { get; set; }

            [Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경자")]
            public string UPDATE_USER_ID { get; set; }
        }

        private void DgvUserGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string sTableName = DgvUserGroup["사용자 그룹 코드", e.RowIndex].Value.ToString();
            var target = UGroupList.Find((s) => s.USER_GROUP_CODE.Equals(DgvUserGroup["사용자 그룹 코드", e.RowIndex].Value));
            SelectedRowData(target);
            Ppg_UserGourp.SelectedObject = ugd;
        }

        private void SelectedRowData(UserGroup_DTO target)
        {
            TypeConverter typeConverter = new TypeConverter();

            for (int i = 0; i < target.GetType().GetProperties().Length; i++)
            {
                string propertyName = target.GetType().GetProperties()[i].Name;
                Type propertyType = target.GetType().GetProperties()[i].PropertyType;
                for (int j = 0; j < ugd.GetType().GetProperties().Length; j++)
                {
                    if (target.GetType().GetProperties()[i].GetValue(target) == null)
                        continue;

                    else if (propertyName == ugd.GetType().GetProperties()[j].Name)
                    {
                        if (propertyType != ugd.GetType().GetProperties()[j].PropertyType)
                        {
                            ugd.GetType().GetProperties()[j].SetValue(ugd, typeConverter.ConvertTo(target.GetType().GetProperties()[i].GetValue(target), ugd.GetType().GetProperties()[j].PropertyType));
                            break;
                        }

                        else
                        {
                            ugd.GetType().GetProperties()[j].SetValue(ugd, target.GetType().GetProperties()[i].GetValue(target));
                            break;
                        }
                    }
                }
            }
        }

        private T1 PropertyToDto<T, T1>(T data) where T1 : class, new()
        {
            T1 dto = new T1();

            for (int i = 0; i < data.GetType().GetProperties().Length; i++)
            {
                for (int j = 0; j < dto.GetType().GetProperties().Length; j++)
                {
                    if (data.GetType().GetProperties()[i].Name.Equals(dto.GetType().GetProperties()[j].Name, StringComparison.OrdinalIgnoreCase))
                    {
                        dto.GetType().GetProperties()[j].SetValue(dto, data.GetType().GetProperties()[i].GetValue(data));
                        break;
                    }
                }
            }
            return dto;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UGdate data = Ppg_UserGourp.SelectedObject as UGdate;
            var dto = PropertyToDto<UGdate, UserGroup_DTO>(data);
            bool result = srv_UG.InsertUserGroup(dto);
            if (result)
            {
                MessageBox.Show("입력 성공");
                DataGridViewFill();
            }
            else
            {
                MessageBox.Show("입력 실패");
            }
        }
    }
}

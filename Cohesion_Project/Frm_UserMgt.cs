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
    public partial class Frm_UserMgt : Frm_Base_2
    {
        Srv_User srv_U = new Srv_User();
        Srv_User Srv_User;
        List<User_DTO> UserList;

     //   private SearchCondition condtion = new SearchCondition();
        private Udate ud = new Udate();
        private SearchData sd = new SearchData();

        public Frm_UserMgt()
        {
            InitializeComponent();
        }
        private void Frm_UserMgt_Load(object sender, EventArgs e)
        {
            Srv_User = new Srv_User();
            DgvInit();
            DataGridViewFill();

        }

        private void DgvInit()

        { 

            DgvUtil.DgvInit(DgvUser);
            DgvUtil.AddTextCol(DgvUser, "사용자 코드", "USER_ID", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "사용자 이름", "USER_NAME", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "사용자 그룹", "USER_GROUP_CODE", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "암호 ", "USER_PASSWORD", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "부서 ", "USER_DEPARTMENT", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "생성 시간 ", "CREATE_TIME", 120, true, align: 2);
            DgvUtil.AddTextCol(DgvUser, "생성 사용자", "CREATE_USER_ID", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "수정 시간", "UPDATE_TIME", 120, true, align: 2);
            DgvUtil.AddTextCol(DgvUser, "변경 사용자 ", "UPDATE_USER_ID", 120, true, align: 1);
      



            //프로퍼티 그리드 초기 설정
            Ppg_User.PropertySort = PropertySort.Categorized;
            Ppg_User.SelectedObject = ud;

        }

        private void DataGridViewFill()
        {
            UserList = Srv_User.SelectUser();
            DgvUser.DataSource = UserList;

        }



        public class Udate
        {
            [Category("속성"), Description("USER_ID"), DisplayName("사용자 코드")]
            public string USER_ID { get; set; }

            [Category("속성"), Description("USER_NAME"), DisplayName("사용자 이름")]
            public string USER_NAME { get; set; }

            [Category("속성"), Description("USER_GROUP_CODE"), DisplayName("사용자 그룹")]
            public string USER_GROUP_CODE { get; set; }

            [Category("추적"), Description("USER_PASSWORD"), DisplayName("암호")]
            public DateTime USER_PASSWORD { get; set; }

            [Category("추적"), Description("USER_DEPARTMENT"), DisplayName("부서")]
            public string USER_DEPARTMENT { get; set; }

            [Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간")]
            public DateTime CREATE_TIME { get; set; }

            [Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자")]
            public string CREATE_USER_ID { get; set; }
            [Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간")]
            public string UPDATE_TIME { get; set; }
            [Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자")]
            public string UPDATE_USER_ID { get; set; }
        }
        //테이블 정보 그리드뷰에 보여주기
        private void DgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string sTableName = DgvUser["사용자 코드", e.RowIndex].Value.ToString();
            var target = UserList.Find((s) => s.USER_GROUP_CODE.Equals(DgvUser["사용자 코드", e.RowIndex].Value));
            SelectedRowData(target);
            Ppg_User.SelectedObject = ud;
        }





        private void SelectedRowData(User_DTO target)
        {
            TypeConverter typeConverter = new TypeConverter();

            for (int i = 0; i < target.GetType().GetProperties().Length; i++)
            {
                string propertyName = target.GetType().GetProperties()[i].Name;
                Type propertyType = target.GetType().GetProperties()[i].PropertyType;
                for (int j = 0; j < ud.GetType().GetProperties().Length; j++)
                {
                    if (target.GetType().GetProperties()[i].GetValue(target) == null)
                        continue;

                    else if (propertyName == ud.GetType().GetProperties()[j].Name)
                    {
                        if (propertyType != ud.GetType().GetProperties()[j].PropertyType)
                        {
                            ud.GetType().GetProperties()[j].SetValue(ud, typeConverter.ConvertTo(target.GetType().GetProperties()[i].GetValue(target), ud.GetType().GetProperties()[j].PropertyType));
                            break;
                        }

                        else
                        {
                            ud.GetType().GetProperties()[j].SetValue(ud, target.GetType().GetProperties()[i].GetValue(target));
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

    }
}

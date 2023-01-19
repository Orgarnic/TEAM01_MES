using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cohesion_Project
{
    class CommonUtil
    {
        public static void ResetControls(params object[] controls)
        {
            foreach (var control in controls)
            {
                if (control is TextBox txt)
                    txt.Text = string.Empty;
                if (control is ComboBox cbo)
                    cbo.SelectedIndex = 0;
                if (control is DateTimePicker dtp)
                    dtp.Value = DateTime.Now;
                if (control is NumericUpDown nud)
                    nud.Value = 0;
                if (control is ListBox lst)
                    lst.Items.Clear();
                if (control is TreeView tvw)
                    tvw.Nodes.Clear();
                if (control is DataGridView dgv)
                    dgv.DataSource = null;
            }
        }

        public static bool VelidControls(params object[] controls)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var control in controls)
            {
                if (control is TextBox txt && string.IsNullOrWhiteSpace(txt.Text))
                {
                    sb.Append($"[{txt.Tag}], ");
                }
                if (control is ComboBox cbo && cbo.SelectedIndex <= 0)
                    sb.Append($"[{cbo.Tag}], ");
            }
            if (sb.Length > 0)
            {
                MboxUtil.MboxWarn(sb.ToString().Trim().TrimEnd(',') + Environment.NewLine + "목록은 필수 입력사항입니다.");
                return false;
            }
            return true;
        }

        public static T1 PropertyToDto<T, T1>(T data) where T1 : class, new()
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

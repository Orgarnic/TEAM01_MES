using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
    public class ComboUtil
    {
        public static Dictionary<string, List<string>> searchDic = new Dictionary<string, List<string>>();
        public static List<char> Answer = new List<char> { 'Y', 'N' };
    }

    public class ComboStringConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(ComboUtil.searchDic[context.PropertyDescriptor.Description]);
        }
    }

   // 검사 데이터 같은 char 타입은 바인딩이 안되서 유기현이 추가함
   public class ComboCharConverter : CharConverter
   {
      public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
      {
         return true;
      }

      public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
      {
         return new StandardValuesCollection(ComboUtil.Answer);
      }
   }
}

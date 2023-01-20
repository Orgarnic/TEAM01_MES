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
}

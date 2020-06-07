using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCWorkbench.Tools;

namespace TMCWorkbench.Database.Extensions
{
    public static class RowExtensions
    {
        public static object GetValue(this Row row, C col)
        {
            return row.GetType().GetField(col.Member.Name).GetValue(row);
        }

        public static int GetValueInt32(this Row row, C col)
        {
            return Converter.ToInt32(GetValue(row, col));
        }

        public static object GetValueDbNull(this Row row, C col)
        {
            var value = GetValue(row, col);

            if (value == null)
            {
                value = DBNull.Value;
            }

            return value;
        }
    }
}

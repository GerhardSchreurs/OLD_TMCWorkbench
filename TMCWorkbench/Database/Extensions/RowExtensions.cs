using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Database.Extensions
{
    public static class RowExtensions
    {
        public static object GetValue(this Row row, C col)
        {
            return row.GetType().GetField(col.Member.Name).GetValue(row);
        }
    }
}

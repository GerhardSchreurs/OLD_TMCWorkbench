using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Model
{
    public class TableStyles : Database.Table<RowStyle>
    {
        public TableStyles() : base("styles")
        {

        }

        public RowStyle FindById(Int16 id)
        {
            return Rows.Where(x => x.Style_id == id).First();
        }
    }
}

using System;
using System.Data;
using TMCWorkbench.Database;
using TMCWorkbench.Database.Attributes;

namespace TMCWorkbench.Model
{
    public class RowStyle : Row
    {
        public override void Init(DataRow row)
        {
            Style_id = SetInt16(row, 0);
            Alt_style_id = SetInt16Null(row, 1);
            Parent_style_id = SetInt16Null(row, 2);
            Name = SetString(row, 3);
            Weight = SetSByte(row, 4);
        }

        [Col(IsAutoIncrement =true, IsPrimaryKey =true)]
        public Int16 Style_id { get; set; }

        [Col]
        public Int16? Alt_style_id { get; set; }

        [Col]
        public Int16? Parent_style_id { get; set; }

        [Col]
        public string Name { get; set; }

        [Col]
        public sbyte Weight { get; set; }
    }
}

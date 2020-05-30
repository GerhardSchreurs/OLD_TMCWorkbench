﻿using System;
using System.Data;
using TMCWorkbench.Tools;

namespace TMCWorkbench.Database
{
    public abstract class Row
    {
        public DataRowState DataRowState = DataRowState.Unchanged;

        //string
        public string SetString(DataRow row, int index)
        {
            if (row.IsNull(index)) { return null; }
            return Converter.ToString(row[index]);
        }

        //smallint
        public Int16? SetInt16Null(DataRow row, int index)
        {
            if (row.IsNull(index))
            {
                return null;
            }
            return SetInt16(row, index);
        }

        public Int16 SetInt16(DataRow row, int index)
        {
            return Converter.ToInt16(row[index]);
        }

        //byte, tinyint, short (0 / 255)
        public Byte? SetByteNull(DataRow row, int index)
        {
            if (row.IsNull(index)) { return null; }
            return SetByte(row, index);
        }

        public Byte SetByte(DataRow row, int index)
        {
            return Converter.ToByte(row[index]);
        }

        //sbyte (-128 / 127)
        public SByte? SetSByteNull(DataRow row, int index)
        {
            if (row.IsNull(index)) { return null; }
            return SetSByte(row, index);

        }
        public SByte SetSByte(DataRow row, int index)
        {
            return Converter.ToSByte(row[index]);
        }

        public Row()
        {

        }

        public virtual void Init(DataRow row) 
        {
        }
    }
}

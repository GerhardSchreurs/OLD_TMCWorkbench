using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TMCWorkbench.Database.Attributes;

namespace TMCWorkbench.Database
{
    public class C
    {
        public C(MemberInfo member, bool isPrimaryKey, bool isAutoIncrement)
        {
            Member = member;
            IsPrimaryKey = isPrimaryKey;
            IsAutoIncrement = isAutoIncrement;
        }
           
        public MemberInfo Member { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsAutoIncrement { get; set; }
    }

    public abstract class Table<T> where T : Row, new()
    {
        public List<T> Rows = new List<T>();
        public List<C> Cols = new List<C>();
        public C ColPK;

        private string _tableName;

        public Table(string tableName)
        {
            _tableName = tableName;

            var members = typeof(T).GetMembers().Where(x => x.DeclaringType == typeof(T));

            foreach (var member in members)
            {
                var attrs = (Col[])member.GetCustomAttributes(typeof(Col), false);
                
                foreach (var attr in attrs)
                {
                    AddCol(member, attr.IsPrimaryKey, attr.IsAutoIncrement);
                }
            }
        }

        public T NewRow()
        {
            var row = new T();
            row.DataRowState = DataRowState.Detached;
            return row;
        }

        public void AddRow(T row)
        {
            row.DataRowState = DataRowState.Added;
            Rows.Add(row);
        }

        private void AddCol(MemberInfo member, bool isPrimaryKey, bool isAutoIncrement)
        {
            if (isPrimaryKey)
            {
                ColPK = new C(member, isPrimaryKey, isAutoIncrement);
            }
            else
            {
                Cols.Add(new C(member, isPrimaryKey, isAutoIncrement));
            }
        }

        public async Task GetDataAsync()
        {
            await Task.Run(() => GetData());
        }

        public void GetData()
        {
            Rows.Clear();

            using (var table = DB.Executor.GetDataTable($"SELECT * FROM {_tableName};"))
            {
                foreach (DataRow row in table.Rows)
                {
                    var dbrow = new T();
                    dbrow.Init(row);
                    Rows.Add(dbrow);
                }
            }
        }

        public IEnumerable<Row> GetRowsDeleted()
        {
            return Rows.Where(x => x.DataRowState == DataRowState.Deleted);
        }
        public IEnumerable<Row> GetRowsModified()
        {
            return Rows.Where(x => x.DataRowState == DataRowState.Modified);
        }
        public IEnumerable<Row> GetRowsAdded()
        {
            return Rows.Where(x => x.DataRowState == DataRowState.Added);
        }


        public void UpdateData()
        {
            if (Rows.Count == 0) { return; }

            var rowsDeleted = GetRowsDeleted();
            var rowsModified = GetRowsModified();
            var rowsAdded = GetRowsAdded();

            if ((rowsDeleted.Any() || rowsModified.Any() || rowsAdded.Any()) == false) return;

            if (rowsDeleted.Any())
            {
                if (ColPK == null) { throw new NotSupportedException("Cannot delete rows if table has no primary key"); }

                var query = $"DELETE FROM {_tableName} WHERE {ColPK.Member.Name} IN (@ids)";
            }

            
            
            //Get deleted rows
            //TODO



        }
    }
}

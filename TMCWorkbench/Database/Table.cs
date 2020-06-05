using Extensions;
using Force.DeepCloner;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TMCWorkbench.Database.Attributes;
using TMCWorkbench.Database.Extensions;

namespace TMCWorkbench.Database
{
    public class C
    {
        public C(MemberInfo member, bool isPrimaryKey, bool isAutoIncrement)
        {
            Member = member;
            Name = member.Name;
            IsPrimaryKey = isPrimaryKey;
            IsAutoIncrement = isAutoIncrement;
        }

        public string Name;
        public MemberInfo Member { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsAutoIncrement { get; set; }
    }

    public abstract class Table<T> where T : Row, new()
    {
        //private List<T> RowsOld = new List<T>();
        public List<T> Rows = new List<T>();
        public List<C> Cols = new List<C>();
        public C ColPK;

        private string _tableName;

        public Table(string tableName)
        {
            _tableName = tableName;

            //var members = typeof(T).GetMembers().Where(x => x.DeclaringType == typeof(T));

            //foreach (var member in members)
            //{
            //    var attrs = (Col[])member.GetCustomAttributes(typeof(Col), false);

            //    foreach (var attr in attrs)
            //    {
            //        AddCol(member, attr.IsPrimaryKey, attr.IsAutoIncrement);
            //    }
            //}

            var type = typeof(T);
            var properties = type.GetProperties().Where(x => x.DeclaringType == type);

            foreach (var property in properties)
            {
                var attrs = (Col[])property.GetCustomAttributes(typeof(Col), false);

                foreach (var attr in attrs)
                {
                    AddCol(property, attr.IsPrimaryKey, attr.IsAutoIncrement);
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
                    //RowsOld.Add(dbrow.DeepClone());
                }
            }
        }

        public IEnumerable<Row> GetRowsDeleted()
        {
            return Rows.Where(x => x.DataRowState == DataRowState.Deleted);
        }
        
        public IEnumerable<Row> GetRowsModified()
        {
            //Sadly, for now we have to set DataRowsState.Modified manually.
            //Maybe, I write my own dataset generator in the future
            //Once I have written some more code.

            //for (var i = 0; i<Rows.Count; i++)
            //{
            //    var row = Rows[i];
               
            //    if (row.DataRowState == DataRowState.Unchanged)
            //    {
            //        var rowOld = RowsOld[i];

            //        foreach (var col in Cols)
            //        {
            //            if (row.GetValue(col) != rowOld.GetValue(col))
            //            {
            //                //modified
            //                row.DataRowState = DataRowState.Modified;
            //                continue;
            //            }
            //        }
            //    }
            //}

            return Rows.Where(x => x.DataRowState == DataRowState.Modified);
        }
        public IEnumerable<Row> GetRowsAdded()
        {
            return Rows.Where(x => x.DataRowState == DataRowState.Added);
        }

        void ProcessRowsDeleted()
        {
            var rows = GetRowsDeleted();
            if (!rows.Any()) return;

            DB.Executor.QueryNew();
            DB.Executor.QuerySetSQL($"DELETE FROM {_tableName} WHERE {ColPK.Name} IN (@ids)");

            var ids = new List<object>();

            foreach (var row in rows)
            {
                ids.Add(row.GetValue(ColPK));
            }

            DB.Executor.QueryAddParamList("@delete_id", ids);
        }

        void ProcessRowsModified()
        {
            var rows = GetRowsModified();
            if (!rows.Any()) return;

            DB.Executor.QueryNew();

            foreach (var row in rows)
            {
                var sql = $"UPDATE {_tableName} SET (";

                for (var i = 0; i<Cols.Count; i++)
                {
                    DB.Executor.QueryAddParam($"@update_id{i}", row.GetValue(Cols[i]));
                    sql += $"{Cols[i].Name} = @update_id{i},";
                }

                sql = sql.StripLastChar(",");
                sql += $") WHERE {ColPK.Name} = @id";

                DB.Executor.QuerySetSQL(sql);
                DB.Executor.QueryAddParam("@id", row.GetValue(ColPK));
            }
        }

        void ProcessRowsAdded()
        {
            var rows = GetRowsAdded();
            if (!rows.Any()) return;

            DB.Executor.QueryNew();

            foreach (var row in rows)
            {
                var sql = $"INSERT INTO {_tableName}";
                var columns = "";
                var values = "";

                for (var i = 0; i<Cols.Count; i++)
                {
                    var col = Cols[i];

                    columns += col.Name + ",";
                    values += $"@insert_id{i},";

                    DB.Executor.QueryAddParam($"@insert_id{i}", row.GetValue(col));
                }

                columns = columns.StripLastChar(",");
                values = values.StripLastChar(",");

                DB.Executor.QuerySetSQL($"{sql} ({columns}) VALUES ({values})");
            }
        }

        public void UpdateData()
        {
            if (Rows.Count == 0) return;
            if (ColPK == null) throw new NotSupportedException("Cannot UpdateData() without a primary key");

            ProcessRowsDeleted();
            ProcessRowsModified();
            ProcessRowsAdded();

            DB.Executor.QueryProcessNonQuery();
        }

        public void UpdateDataAndReflect(bool retrieveIdValues)
        {
        }

        public void UpdateDataAndRefresh()
        {

        }
    }
}

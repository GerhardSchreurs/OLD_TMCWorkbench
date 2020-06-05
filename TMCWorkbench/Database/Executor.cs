using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMCWorkbench.Database
{
    public class Executor : IDisposable
    {
        public Executor(string connectionstring)
        {
            _regTableNameFormSql = new Regex("select.*?from\\s([a-zA-Z.]*)", RegexOptions.IgnoreCase);
            _transactionActive = false;
            _transactionFinished = false;
            _isScalarAutoId = true;
            _isParametersAutoClear = true;
            _parameters = new Dictionary<string, object>();

            SetConnectionString(connectionstring);
        }

        private MySqlConnection _connection;
        private MySqlTransaction _transaction;
        private MySqlDataAdapter _dataAdapter;
        private Exception _transactionException;
        private DataSet _dataset;
        private List<DataSetQuery> _datasetQueryCollection;
        private Dictionary<string, object> _parameters;

        private bool _transactionActive;
        private bool _transactionFinished;
        private bool _isScalarAutoId;
        private bool _isParametersAutoClear;

        private Regex _regTableNameFormSql;

        //The new Shit




        private void  InitDataAdapter(string sql)
        {
            if (_dataAdapter == null)
            {
                _dataAdapter = new MySqlDataAdapter(sql, _connection);
            }
            else
            {
                _dataAdapter.SelectCommand.CommandText = sql;
            }
        }

        private void ConnectionClose()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                if (_connection.State == ConnectionState.Executing)
                {
                    throw new Exception("Cannot set connection, connection is executing");
                }

                _connection.Close();
            }
        }

        private void ConnectionOpen()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void SetConnectionString(string connectionstring)
        {
            ConnectionClose();
            _connection = new MySqlConnection(connectionstring);
        }

        private void DataAdapterClose()
        {
            if (_dataAdapter != null)
            {
                _dataAdapter.Dispose();
                _dataAdapter = null;
            }
        }

        public bool IsScalarAutoID
        {
            get => _isScalarAutoId;
            set => _isScalarAutoId = value;

        }

        public bool IsParametersAutoClear
        {
            get => _isParametersAutoClear;
            set => _isParametersAutoClear = value;
        }

        public void TransactionStart()
        {
            ConnectionOpen();
            _transaction = _connection.BeginTransaction();
            _transactionActive = true;
            _transactionFinished = false;
        }

        public void TransactionEnd()
        {
            if (_transactionActive == true & _transactionFinished == false)
            {
                _transaction.Commit();
                _transactionActive = false;
                _transactionFinished = false;
            }
            else
            {
                //An error occured during the transaction. Transaction has been rolled back
                throw _transactionException;
            }
        }

        public void TransactionRollback(Exception ex = null)
        {
            _transaction.Rollback();
            _transactionException = ex;
            _transactionFinished = true;
            _connection.Close();
        }

        public void AddParameter(string name, object value)
        {
            _parameters.Add(name, value);
        }

        private void ParametersClearOnAuto()
        {
            if (_isParametersAutoClear)
            {
                if (_dataAdapter != null)
                {
                    _dataAdapter.SelectCommand.Parameters.Clear();
                }
                _parameters.Clear();
            }
        }

        public void ParametersClear()
        {
            _parameters.Clear();

            if (_dataAdapter != null)
            {
                _dataAdapter.SelectCommand.Parameters.Clear();
            }
        }

        private string GetTableNameFromSQL(string strSQL)
        {
            var returnValue = string.Empty;
            var matches = _regTableNameFormSql.Matches(strSQL);

            if (matches.Count == 1)
            {
                returnValue = matches[0].Groups[1].ToString();
            }

            return returnValue;
        }

        private void UpdateCommandWithParameters(MySqlCommand command)
        {
            if (_parameters.Count > 0)
            {
                for (var i = 0; i <= _parameters.Count - 1; i++)
                {
                    command.Parameters.AddWithValue(_parameters.ElementAt(i).Key, _parameters.ElementAt(i).Value);
                }
            }
        }

        private void UpdateCommandWithParameters(MySqlCommand command, SqlQuery query)
        {
            foreach (var param in query.Parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }
        }

        public DataTable GetDataTable(string sql, string tableName = "")
        {
            var dataTable = new DataTable();

            InitDataAdapter(sql);

            //Check if this is a stored procedure type command
            //colMatches = Regex.Matches(sql, "([a-zA-Z0-9]*?)\s\=\s(\@.*?)\){0,}\({0,}\s")

            UpdateCommandWithParameters(_dataAdapter.SelectCommand);

            _dataAdapter.Fill(dataTable);

            if (!string.IsNullOrEmpty(tableName))
            {
                dataTable.TableName = tableName;
            }
            else
            {
                dataTable.TableName = GetTableNameFromSQL(sql);
            }

            ParametersClearOnAuto();
            return dataTable;
        }

        public DataTable GetDateTableFromProcedure(string name, string tableName = "")
        {
            var datatable = new DataTable();

            using (var cmd = new MySqlCommand(name, _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                UpdateCommandWithParameters(cmd);

                if (_transactionActive)
                {
                    cmd.Transaction = _transaction;

                    try
                    {
                        datatable.Load(cmd.ExecuteReader());
                    }
                    catch (Exception ex)
                    {
                        TransactionRollback(ex);
                    }
                }
                else
                {
                    cmd.Connection.Open();
                    datatable.Load(cmd.ExecuteReader());
                    cmd.Connection.Close();
                }
            }

            if (!string.IsNullOrEmpty(tableName))
            {
                datatable.TableName = tableName;
            }
            else
            {
                datatable.TableName = name;
            }

            ParametersClearOnAuto();
            return datatable;
        }

        public object ExecuteScalar(string sql)
        {
            if (_transactionActive == true & _transactionFinished == true)
            {
                //An error occurred during this transaction...
                return -1;
            }

            if (_isScalarAutoId)
            {
                sql += "; SELECT SCOPE_IDENTITY() AS ID;";
            }

            object objReturn = null;

            using (var cmd = new MySqlCommand(sql, _connection))
            {
                UpdateCommandWithParameters(cmd);

                if (_transactionActive)
                {
                    cmd.Transaction = _transaction;

                    try
                    {
                        objReturn = cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        TransactionRollback(ex);
                    }
                }
                else
                {
                    cmd.Connection.Open();
                    objReturn = cmd.ExecuteScalar();
                    cmd.Connection.Close();
                }
            }

            ParametersClearOnAuto();
            return objReturn;
        }

        public void ExecuteNonQuery(string sql)
        {
            if (_transactionActive == true & _transactionFinished == true)
            {
                //An error occurred during this transaction...
                return;
            }

            using (var cmd = new MySqlCommand(sql, _connection))
            {
                UpdateCommandWithParameters(cmd);

                if (_transactionActive)
                {
                    cmd.Transaction = _transaction;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        TransactionRollback(ex);
                    }
                }
                else
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }

            ParametersClearOnAuto();
        }

        //************************************************//

        internal List<SqlQuery> SqlQueries;

        public void QueryNew()
        {
            if (SqlQueries == null) SqlQueries = new List<SqlQuery>();
            SqlQueries.Add(new SqlQuery(""));
        }

        public void QuerySetSQL(string sql)
        {
            SqlQueries.Last().SQL = sql;
        }

        public void QueryAddParam(string name, object value)
        {
            SqlQueries.Last().AddParam(name, value);
        }

        public void QueryAddParamList(string name, List<object> list)
        {
            Contract.Requires(list != null);

            for (var i = 0; i<list.Count; i++)
            {
                SqlQueries.Last().AddParam($"name{i}", list[i]);
            }
        }

        public int QueryProcessNonQuery()
        {
            return 0;
        }
        
        public DataTable QueryProcessReader()
        {
            return null;
        }

        public Tuple<int, int> QueryProcessGetIds(string tableName, string columnName)
        {
            if (_transactionActive == true & _transactionFinished == true)
            {
                //An error occurred during this transaction...
                return new Tuple<int, int>(-1,-1);
            }

            foreach (var query in SqlQueries)
            {
                using (var cmd = new MySqlCommand(query.SQL, _connection))
                {
                    UpdateCommandWithParameters(cmd);

                    if (_transactionActive)
                    {
                        cmd.Transaction = _transaction;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            TransactionRollback(ex);
                        }
                    }
                    else
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }

                ParametersClearOnAuto();
            }

            return new Tuple<int, int>(-1,-1);


            //using (var cmd = new MySqlCommand(sql, _connection))
            //{
            //    UpdateCommandWithParameters(cmd);

            //    if (_transactionActive)
            //    {
            //        cmd.Transaction = _transaction;
            //        try
            //        {
            //            cmd.ExecuteNonQuery();
            //        }
            //        catch (Exception ex)
            //        {
            //            TransactionRollback(ex);
            //        }
            //    }
            //    else
            //    {
            //        cmd.Connection.Open();
            //        cmd.ExecuteNonQuery();
            //        cmd.Connection.Close();
            //    }
            //}

            //ParametersClearOnAuto();
        }




        public void DataSetCreate(string name)
        {
            _dataset = new DataSet(name);
            _datasetQueryCollection = new List<DataSetQuery>();
        }

        public DataSet DataSet
        {
            get =>_dataset;
            set => _dataset = value;
        }

        public void DataSetQueryAdd(string sql, string tableName = "")
        {
            var datasetQuery = new DataSetQuery();
            datasetQuery.SQL = sql;
            datasetQuery.TableName = tableName;
            _datasetQueryCollection.Add(datasetQuery);
        }

        public void DatasetQueryAddParameter(string name, string value)
        {
            var datasetQuery = _datasetQueryCollection[_datasetQueryCollection.Count];
            datasetQuery.AddParameter(name, value);
        }

        /// <summary>
        /// Add table to dataset. If purpose is to save data using datasetsave, also provide sql string
        /// </summary>
        /// <remarks></remarks>
        public void DataSetTableAdd(DataTable table, string sql = "", string tableName = "")
        {
            var datasetQuery = new DataSetQuery();
            datasetQuery.SQL = sql;
            datasetQuery.Table = table;
            datasetQuery.TableName = tableName;

            _datasetQueryCollection.Add(datasetQuery);
        }

        public void DataSetFill()
        {
            DataSetQuery datasetQuery = null;

            for (var I = 0; I <= _datasetQueryCollection.Count - 1; I++)
            {
                datasetQuery = _datasetQueryCollection[I];

                if (datasetQuery.Parameters != null)
                {
                    for (var J = 0; J <= datasetQuery.Parameters.Count - 1; J++)
                    {
                        AddParameter(datasetQuery.Parameters.GetKey(J), datasetQuery.Parameters.Get(J));
                    }
                }

                if (datasetQuery.Table != null)
                {
                    if (!string.IsNullOrEmpty(datasetQuery.TableName))
                    {
                        datasetQuery.Table.TableName = datasetQuery.TableName;
                    }

                    _dataset.Tables.Add(datasetQuery.Table);
                }
                else
                {
                    _dataset.Tables.Add(GetDataTable(datasetQuery.SQL, datasetQuery.TableName));
                }
            }
        }

        public void DataSetSave()
        {
            DataSetQuery datasetQuery = null;

            string strTableName = string.Empty;
            string strSqlCurrent = string.Empty;
            //Stores CURRENT sql string

            using (var connection = new MySqlConnection(_connection.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        for (var I = 0; I <= _datasetQueryCollection.Count - 1; I++)
                        {
                            datasetQuery = _datasetQueryCollection[I];
                            strSqlCurrent = datasetQuery.SQL;
                            strTableName = datasetQuery.TableName;

                            if (string.IsNullOrEmpty(strTableName))
                            {
                                strTableName = GetTableNameFromSQL(strSqlCurrent);
                            }

                            using (var dataAdapter = new MySqlDataAdapter(strSqlCurrent, connection))
                            {
                                dataAdapter.SelectCommand.Transaction = transaction;

                                if (datasetQuery.Parameters != null)
                                {
                                    foreach (var param in datasetQuery.Parameters)
                                    {
                                        dataAdapter.SelectCommand.Parameters.Add(param);
                                    }
                                }

                                using (var commandBuilder = new MySqlCommandBuilder(dataAdapter))
                                {
                                    dataAdapter.Update(_dataset.Tables[strTableName]);
                                }
                            }

                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Debug.WriteLine(ex.ToString());
                    }

                    connection.Close();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
                if (_dataset != null)
                {
                    _dataset.Dispose();
                    _dataset = null;
                }
                if (_dataAdapter != null)
                {
                    _dataAdapter.Dispose();
                    _dataAdapter = null;
                }

                ConnectionClose();
            }
        }
    }

    internal class SqlQuery
    {
        public string SQL;
        public Dictionary<string, object> Parameters;

        public SqlQuery(string sql)
        {
            SQL = sql;
        }

        public void AddParam(string name, object value)
        {
            if (Parameters == null) { Parameters = new Dictionary<string, object>(); }
            Parameters.Add(name, value);
        }
    }


    internal class DataSetQuery
    {
        public string SQL { get; set; }
        public NameValueCollection Parameters { get; }
        private string _tableName;

        //Used when datatable is passed from DataSetTableAdd
        private DataTable _table;

        public DataSetQuery()
        {
            _tableName = "";
        }


        /// <summary>
        /// Used when datatable is passed from DataSetTableAdd. If purpose is to save, please also pass SQL
        /// Sets TableName property as well.
        /// </summary>
        /// <remarks></remarks>
        public DataTable Table
        {
            get { return _table; }
            set
            {
                //I don't know if this works, yet...

                if (value.DataSet != null)
                {
                    //This table already belongs to another dataset.
                    //Therefore, we need to copy it.
                    _table = value.Copy();
                }
                else
                {
                    _table = value;
                }

                TableName = _table.TableName;
            }
        }

        public string TableName
        {
            get { return _tableName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _tableName = value;
                }
            }
        }

        public void AddParameter(string name, string Value)
        {
            Parameters.Add(name, Value);
        }
    }
}

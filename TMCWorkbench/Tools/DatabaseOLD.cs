using VB = Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;

namespace TMCWorkbench.Tools
{
    public class DatabaseOLD
    {
        private MySqlConnection _connection;
        private MySqlDataAdapter _dataAdapter;
        //Private _parameters As NameValueCollection
        private Dictionary<string, object> _parameters;
        private bool _connectionChanged;
        private DataSet _dataSet;
        private List<DataSetQueryOLD> _DataSetQueryOLDCollection;
        private MySqlTransaction _transaction;
        private bool _transactionActive;
        private bool _transactionFinished;
        private Exception _transactionException;

        private bool _scalarautoid;

        public bool parametersAutoClear;

        public string ConnectionString
        {
            set
            {
                _connection = new MySqlConnection(value);
                _connectionChanged = true;
            }
        }

        public MySqlDataAdapter DataAdapter
        {
            //not in use yet...

            get
            {
                if (_dataAdapter == null)
                {
                    _dataAdapter = new MySqlDataAdapter();
                }

                return _dataAdapter;
            }
        }

        public DatabaseOLD()
        {
            _connectionChanged = false;
            _transactionActive = false;
            _transactionFinished = false;
            _scalarautoid = true;
            parametersAutoClear = true;
            _parameters = new Dictionary<string, object>();
        }

        public void ConnectionClose()
        {
            _connection.Close();
        }

        public void Dispose()
        {
            TransactionEnd();
            //Should do more here...
        }

        public bool ScalarAutoID
        {
            set { _scalarautoid = value; }
        }

        public void TransactionStart()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            _transaction = _connection.BeginTransaction();
            _transactionActive = true;
            _transactionFinished = false;
        }

        public void TransactionEnd()
        {
            if (_transactionActive == true & _transactionFinished == false)
            {
                _transaction.Commit();
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }

                _transactionActive = false;
                _transactionFinished = false;
            }
            else
            {
                //An error occured during the transaction. Transaction has been rolled back
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }

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

        private void ParametersClear()
        {
            if (parametersAutoClear)
            {
                if (_dataAdapter != null)
                {
                    _dataAdapter.SelectCommand.Parameters.Clear();
                }
                _parameters.Clear();
            }
        }

        public void ParameterClear()
        {
            _parameters.Clear();
            if (_dataAdapter != null)
            {
                _dataAdapter.SelectCommand.Parameters.Clear();
                //Q: Should we also do this with ParametersClear?
            }
        }

        private string GetTableNameFromSQL(string strSQL)
        {
            string strReturn = "";
            MatchCollection colMatches = default(MatchCollection);

            colMatches = Regex.Matches(strSQL, "select.*?from\\s([a-zA-Z.]*)", RegexOptions.IgnoreCase);

            if (colMatches.Count == 1)
            {
                strReturn = colMatches[0].Groups[1].ToString();
            }

            return strReturn;
        }

        /// <summary>
        /// Returns a Datatable based on the sql query and forgets. If parameters are set, they are being used
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DataTable GetDataTable(string sql, string tableName = "")
        {
            DataTable tblReturn = new DataTable();

            if ((_dataAdapter == null) || (_connectionChanged == true))
            {
                _dataAdapter = new MySqlDataAdapter(sql, _connection);
                _connectionChanged = false;
            }
            else
            {
                _dataAdapter.SelectCommand.CommandText = sql;
            }

            //Check if this is a stored procedure type command
            //colMatches = Regex.Matches(sql, "([a-zA-Z0-9]*?)\s\=\s(\@.*?)\){0,}\({0,}\s")

            if (_parameters.Count > 0)
            {
                for (var I = 0; I <= _parameters.Count - 1; I++)
                {
                    _dataAdapter.SelectCommand.Parameters.AddWithValue(_parameters.ElementAt(I).Key, _parameters.ElementAt(I).Value);
                    //_dataAdapter.SelectCommand.Parameters.AddWithValue(_parameters.GetKey(I), _parameters.Get(I))
                }
            }

            _dataAdapter.Fill(tblReturn);

            if (!string.IsNullOrEmpty(tableName))
            {
                tblReturn.TableName = tableName;
            }
            else
            {
                tblReturn.TableName = GetTableNameFromSQL(sql);
            }

            ParametersClear();
            return tblReturn;
        }

        public DataTable GetDateTableFromProcedure(string name, string tableName = "")
        {
            DataTable tblReturn = new DataTable();
            MySqlCommand cmd = new MySqlCommand(name, _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            if (_parameters.Count > 0)
            {
                for (var I = 0; I <= _parameters.Count - 1; I++)
                {
                    cmd.Parameters.AddWithValue(_parameters.ElementAt(I).Key, _parameters.ElementAt(I).Value);
                    //cmd.Parameters.AddWithValue(_parameters.GetKey(I), _parameters.Get(I))
                }
            }

            if (_transactionActive)
            {
                cmd.Transaction = _transaction;
                try
                {
                    tblReturn.Load(cmd.ExecuteReader());
                }
                catch (Exception ex)
                {
                    TransactionRollback(ex);
                }
            }
            else
            {
                cmd.Connection.Open();
                tblReturn.Load(cmd.ExecuteReader());
                cmd.Connection.Close();
            }

            if (!string.IsNullOrEmpty(tableName))
            {
                tblReturn.TableName = tableName;
            }
            else
            {
                tblReturn.TableName = name;
            }

            ParametersClear();
            return tblReturn;
        }

        public object ExecuteScalar(string sql)
        {
            object functionReturnValue = null;
            if (_transactionActive == true & _transactionFinished == true)
            {
                //An error occurred during this transaction...
                return -1;
                return functionReturnValue;
            }

            if (_scalarautoid)
            {
                sql += "; SELECT SCOPE_IDENTITY() AS ID;";
            }

            object objReturn = null;
            MySqlCommand cmd = new MySqlCommand(sql, _connection);

            if (_parameters.Count > 0)
            {
                for (var i = 0; i <= _parameters.Count - 1; i++)
                {
                    cmd.Parameters.AddWithValue(_parameters.ElementAt(i).Key, _parameters.ElementAt(i).Value);
                    //cmd.Parameters.AddWithValue(_parameters.GetKey(I), _parameters.Get(I))
                }
            }

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

            ParametersClear();
            return objReturn;
            return functionReturnValue;
        }

        public void ExecuteNonQuery(string sql)
        {
            if (_transactionActive == true & _transactionFinished == true)
            {
                //An error occurred during this transaction...
                return;
            }

            MySqlCommand cmd = new MySqlCommand(sql, _connection);

            if (_parameters.Count > 0)
            {
                for (var I = 0; I <= _parameters.Count - 1; I++)
                {
                    cmd.Parameters.AddWithValue(_parameters.ElementAt(I).Key, _parameters.ElementAt(I).Value);
                    //cmd.Parameters.AddWithValue(_parameters.GetKey(I), _parameters.Get(I))
                }
            }

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

            ParametersClear();
        }

        //public void DataSetGenerateRelations()
        //{
        //    DataTable tblRelation = null;
        //    DataRelation relData = null;
        //    string strQuery = null;
        //    DataRow[] rowsResult = null;
        //    DataRow rowResult = null;
        //    string tblPrimaryName = null;
        //    string tblForeignName = null;
        //    DataColumn colPrimary = null;
        //    DataColumn colForeign = null;

        //    if (System.Web.HttpContext.Current.Application["_databaseRelation"] == null)
        //    {
        //        System.Web.HttpContext.Current.Application["_databaseRelation"] = GetDataTable("select tblFK.constraint_name As ConstraintName, substring((tblAll.constraint_schema + '.' + tblAll.table_name), 1, 100) As PrimaryTableScheme, tblAll.table_name as PrimaryTable, tblAll.column_name as PrimaryTableColumn, substring((tblFK.constraint_schema + '.' + tblFK.table_name), 1, 100) As ForeignTableScheme, tblFK.table_name as ForeignTable, tblFK.column_name as ForeignTableColumn from information_schema.constraint_column_usage tblAll inner join information_schema.referential_constraints tblAllFK on tblAllFK.unique_constraint_name = tblAll.constraint_name inner join information_schema.constraint_column_usage tblFK on tblAllFK.constraint_name=tblFK.constraint_name");
        //    }

        //    tblRelation = (DataTable)System.Web.HttpContext.Current.Application["_databaseRelation"];

        //    foreach (DataTable tbl in _dataSet.Tables)
        //    {
        //        tblForeignName = tbl.TableName;
        //        strQuery = "(ForeignTableScheme = '" + tblForeignName + "')";

        //        foreach (DataColumn col in tbl.Columns)
        //        {
        //            //Check If there is a match for the datatable and column in tblRelation
        //            rowsResult = tblRelation.Select(strQuery + " AND (ForeignTableColumn = '" + col.ColumnName + "')");

        //            if (rowsResult.Length == 1)
        //            {
        //                rowResult = rowsResult[0];
        //                tblPrimaryName = Convert.ToString(rowResult["PrimaryTableScheme"]);
        //                //Now check if the related table is also in the dataset...

        //                if (_dataSet.Tables[tblPrimaryName] != null)
        //                {
        //                    //Yes, at this point I almost have an orgasm :)
        //                    //Now we need to create that relation...

        //                    colPrimary = _dataSet.Tables[tblPrimaryName].Columns[Convert.ToString(rowResult["PrimaryTableColumn"])];
        //                    colForeign = _dataSet.Tables[tblForeignName].Columns[Convert.ToString(rowResult["ForeignTableColumn"])];

        //                    relData = new DataRelation(Convert.ToString(rowResult["ConstraintName"]), colPrimary, colForeign, true);
        //                    _dataSet.Relations.Add(relData);
        //                }
        //            }
        //        }
        //    }
        //}


        //This stuff is single shot. Cannot create multiple datasets!
        public void DataSetCreate(string name)
        {
            _dataSet = new DataSet(name);
            _DataSetQueryOLDCollection = new List<DataSetQueryOLD>();
        }

        public DataSet DataSet
        {
            get { return _dataSet; }
            set { _dataSet = value; }
        }


        public void DataSetQueryOLDAdd(string sql, string tableName = "")
        {
            DataSetQueryOLD objDataSetQueryOLD = new DataSetQueryOLD();
            objDataSetQueryOLD.SQL = sql;
            objDataSetQueryOLD.TableName = tableName;
            _DataSetQueryOLDCollection.Add(objDataSetQueryOLD);
        }

        public void DataSetQueryOLDAddParameter(string name, string value)
        {
            DataSetQueryOLD objDataSetQueryOLD = _DataSetQueryOLDCollection[_DataSetQueryOLDCollection.Count];
            objDataSetQueryOLD.AddParameter(name, value);
        }

        /// <summary>
        /// Add table to dataset. If purpose is to save data using datasetsave, also provide sql string
        /// </summary>
        /// <remarks></remarks>
        public void DataSetTableAdd(DataTable table, string sql = "", string tableName = "")
        {
            DataSetQueryOLD objDataSetQueryOLD = new DataSetQueryOLD();
            objDataSetQueryOLD.SQL = sql;
            objDataSetQueryOLD.Table = table;
            objDataSetQueryOLD.TableName = tableName;

            _DataSetQueryOLDCollection.Add(objDataSetQueryOLD);
        }

        public void DataSetFill()
        {
            DataSetQueryOLD objDataSetQueryOLD = null;

            for (var I = 0; I <= _DataSetQueryOLDCollection.Count - 1; I++)
            {
                objDataSetQueryOLD = _DataSetQueryOLDCollection[I];

                if (objDataSetQueryOLD.Parameters != null)
                {
                    for (var J = 0; J <= objDataSetQueryOLD.Parameters.Count - 1; J++)
                    {
                        AddParameter(objDataSetQueryOLD.Parameters.GetKey(J), objDataSetQueryOLD.Parameters.Get(J));
                    }
                }

                if (objDataSetQueryOLD.Table != null)
                {
                    if (!string.IsNullOrEmpty(objDataSetQueryOLD.TableName))
                    {
                        objDataSetQueryOLD.Table.TableName = objDataSetQueryOLD.TableName;
                    }
                    _dataSet.Tables.Add(objDataSetQueryOLD.Table);
                }
                else
                {
                    _dataSet.Tables.Add(GetDataTable(objDataSetQueryOLD.SQL, objDataSetQueryOLD.TableName));
                }
            }
        }

        public void DataSetSave()
        {
            DataSetQueryOLD objDataSetQueryOLD = null;
            MySqlConnection conSQL = new MySqlConnection(_connection.ConnectionString);
            MySqlTransaction trsSQL = null;
            string strTableName = string.Empty;
            string strSqlCurrent = string.Empty;
            //Stores CURRENT sql string

            conSQL.Open();
            trsSQL = conSQL.BeginTransaction();

            try
            {
                for (var I = 0; I <= _DataSetQueryOLDCollection.Count - 1; I++)
                {
                    objDataSetQueryOLD = _DataSetQueryOLDCollection[I];
                    strSqlCurrent = objDataSetQueryOLD.SQL;
                    strTableName = objDataSetQueryOLD.TableName;

                    if (string.IsNullOrEmpty(strTableName))
                    {
                        strTableName = GetTableNameFromSQL(strSqlCurrent);
                    }

                    MySqlDataAdapter adpData = new MySqlDataAdapter(strSqlCurrent, conSQL);
                    adpData.SelectCommand.Transaction = trsSQL;

                    if (objDataSetQueryOLD.Parameters != null)
                    {
                        foreach (MySqlParameter param in objDataSetQueryOLD.Parameters)
                        {
                            adpData.SelectCommand.Parameters.Add(param);
                        }
                    }

                    MySqlCommandBuilder bldData = new MySqlCommandBuilder(adpData);
                    adpData.Update(_dataSet.Tables[strTableName]);
                }

                trsSQL.Commit();
            }
            catch (Exception ex)
            {
                trsSQL.Rollback();
                Debug.WriteLine(ex.ToString() + "<br>");
            }

            trsSQL.Dispose();
            conSQL.Close();
        }


        ///// <summary>
        ///// Make sure that every query in dataset provides the Primary Key!!!
        ///// </summary>
        ///// <remarks></remarks>
        //public void DataSetSaveOLD()
        //{
        //    List<SqlParameter> sqlParams = new List<SqlParameter>();
        //    //Stores NEW parameters
        //    List<string> strTableNames = new List<string>();

        //    string strSql = string.Empty;
        //    //Stores NEW sql string
        //    string strSqlCurrent = string.Empty;
        //    //Stores CURRENT sql string
        //    string strTableName = string.Empty;
        //    string strKeyName = null;
        //    string strKeyNameReplacement = null;
        //    string strKeyValue = null;
        //    DataSetQueryOLD objDataSetQueryOLD = null;
        //    Regex regParameter = new Regex("\\@([a-zA-Z0-9])*");
        //    //Unused for the time being

        //    //Since we are going to build one huge SQL String, and each SQL string can have parameters attached,
        //    //We are going to replace the parameters to guarantee uniqueness (well, somewhat)

        //    for (var I = 0; I <= _DataSetQueryOLDCollection.Count - 1; I++)
        //    {
        //        objDataSetQueryOLD = _DataSetQueryOLDCollection[I];
        //        strSqlCurrent = objDataSetQueryOLD.SQL;
        //        strTableName = objDataSetQueryOLD.TableName;

        //        if (string.IsNullOrEmpty(strTableName))
        //        {
        //            strTableName = GetTableNameFromSQL(strSqlCurrent);
        //        }

        //        if (objDataSetQueryOLD.Parameters != null)
        //        {
        //            for (int J = 0; J <= objDataSetQueryOLD.Parameters.Count; J++)
        //            {
        //                strKeyName = objDataSetQueryOLD.Parameters.GetKey(J);
        //                strKeyValue = objDataSetQueryOLD.Parameters.Get(J);
        //                strKeyNameReplacement = "@" + strTableName + "_" + VB.Strings.Mid(strKeyName, 2);

        //                strSqlCurrent = VB.Strings.Replace(strSqlCurrent, strKeyName, strKeyNameReplacement);

        //                //Add the new parameters
        //                sqlParams.Add(new SqlParameter(strKeyNameReplacement, strKeyValue));
        //            }
        //        }

        //        //Add the current sql query
        //        strSql += strSqlCurrent + ";";

        //        //Add the tablename
        //        strTableNames.Add(strTableName);
        //    }

        //    //That was all the hard work.
        //    //Pass new sql string to new SqlDataAdapter
        //    SqlDataAdapter adpData = new SqlDataAdapter(strSql, _connection);

        //    //Set all the params
        //    foreach (SqlParameter sqlParam in sqlParams)
        //    {
        //        adpData.SelectCommand.Parameters.Add(sqlParam);
        //    }

        //    //Create a builder object for our SqlDataAdapter
        //    SqlCommandBuilder bldData = new SqlCommandBuilder(adpData);

        //    //Do the tablemappings (and hope that they are still in order?)
        //    string strTableCount = "";
        //    foreach (string strTableName_loopVariable in strTableNames)
        //    {
        //        strTableName = strTableName_loopVariable;
        //        adpData.TableMappings.Add("Table" + strTableCount, strTableName);

        //        if (string.IsNullOrEmpty(strTableCount))
        //        {
        //            strTableCount = "1";
        //        }
        //        else
        //        {
        //            strTableCount = Convert.ToString(Convert.ToInt32(strTableCount) + 1);
        //        }
        //    }

        //    //w00t. Now save, and expect some kind of crash...
        //    try
        //    {
        //        adpData.Update(_dataSet);
        //    }
        //    catch (Exception ex)
        //    {
        //        HttpContext.Current.Response.Write(strSql + "<br><br>");
        //        HttpContext.Current.Response.Write(ex.ToString() + "<br>");
        //    }
        //}
    }

    internal class DataSetQueryOLD
    {
        private string _sql;
        private string _tableName;
        private NameValueCollection _parameters;
        //Used when datatable is passed from DataSetTableAdd
        private DataTable _table;

        public DataSetQueryOLD()
        {
            _tableName = "";
        }

        public string SQL
        {
            get { return _sql; }
            set { _sql = value; }
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

        public NameValueCollection Parameters
        {
            get { return _parameters; }
        }

        public void AddParameter(string name, string Value)
        {
            _parameters.Add(name, Value);
        }
    }
}

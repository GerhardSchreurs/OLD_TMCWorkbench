using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCDatabase.Extensions;
using TMCDatabase.Utility;

namespace TMCWorkbench.Utility
{
    public class SearchQueryExecutor
    {
        public SearchQueryExecutor()
        {
            _parameters = new List<MySqlParameter>();
        }

        public int Limit = 50;
        public int PageNumber = 0;
        private List<MySqlParameter> _parameters;
        private string _queryRegularStart = "SELECT * FROM view_tracks";
        private string _queryRegularEnd = "ORDER by Track_id DESC LIMIT {LIMIT}";
        private string _querySearchStart = "SELECT * FROM view_tracks WHERE Track_id IN(SELECT Track_id FROM (SELECT Track_id FROM tracks WHERE";
        private string _querySearchEnd = "ORDER by Track_id DESC LIMIT {LIMIT}) as t1);";


        public const string COL_TRACKTITLE = "TrackTitle";
        public const string COL_FILENAME = "FileName";
        public const string COL_METADATA = "YoutubeText";
        public const string COL_FORMAT_ID = "FK_fileextension_id";

        public const string PARAM_TRACKTITLE = "@param_TrackTitle";
        public const string PARAM_FILENAME = "@param_FileName";
        public const string PARAM_METADATA = "@param_MetaData";
        public const string PARAM_FORMAT_ID = "@param_FileExtensionId";

        public string Where_TrackTitle = "";
        public string Where_FileName = "";
        public string Where_MetaData = "";
        public string Where_Format_id = "";

        bool _hasParams = false;

        private void AddLikeParam(string name, string value)
        {
            _parameters.Add(new MySqlParameter(name, "%" + value + "%"));
            _hasParams = true;
        }

        private void AddParam(string name, int value)
        {
            _parameters.Add(new MySqlParameter(name, value));
            _hasParams = true;
        }

        public void SearchTrackTitle(string text)
        {
            if (text.IsNullOrEmpty()) return;
            Where_TrackTitle = $"{COL_TRACKTITLE} LIKE {PARAM_TRACKTITLE} AND ";
            AddLikeParam(PARAM_TRACKTITLE, text);
        }

        public void SearchFileName(string text)
        {
            if (text.IsNullOrEmpty()) return;
            Where_FileName = $"{COL_FILENAME} LIKE {PARAM_FILENAME} AND ";
            AddLikeParam(PARAM_FILENAME, text);
        }
        
        public void SearchMetaData(string text)
        {
            if (text.IsNullOrEmpty()) return;
            Where_MetaData = $"{COL_METADATA} LIKE {PARAM_METADATA} AND ";
            AddLikeParam(PARAM_METADATA, text);
        }

        public void SearchFormat(int id)
        {
            if (id == 0) return;
            Where_Format_id = $"{COL_FORMAT_ID} = {PARAM_FORMAT_ID} AND ";
            AddParam(PARAM_FORMAT_ID, id);
        }


        string RemoveLastPieceOfString(string s, string remove)
        {
            if (s.EndsWith(remove))
                s = s.Substring(0, s.Length - remove.Length);

            return s;
        }

        public DataTable ExecuteAndRetrieve()
        {
            string query = "";
            var limitStart = PageNumber * Limit;
            var limitEnd = limitStart + Limit;

            var limit = $"{limitStart},{limitEnd}";
            _queryRegularEnd = _queryRegularEnd.Replace("{LIMIT}", limit);
            _querySearchEnd = _querySearchEnd.Replace("{LIMIT}", limit);

            if (_hasParams == false)
            {
                query = $"{_queryRegularStart} {_queryRegularEnd}";
            }
            else
            {
                query = $"{Where_Format_id}{Where_TrackTitle}{Where_FileName}{Where_MetaData}";
                query = RemoveLastPieceOfString(query, " AND ");
                query = $"{_querySearchStart} {query} {_querySearchEnd}";
            }

            var tbl = DB.DBManager.Instance.C.DataTable(query, _parameters);
            return tbl;
        }
    }
}

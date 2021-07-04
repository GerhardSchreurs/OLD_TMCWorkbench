using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        private string _querySearchStart = $"SELECT * FROM view_tracks WHERE Track_id IN(SELECT Track_id FROM \n(\nSELECT Track_id FROM tracks WHERE\n";
        private string _querySearchEnd = "ORDER by Track_id DESC LIMIT {LIMIT}\n)\n as t1);";

        public const string TBL_C_TRACK_TAG = "c_track_tag";

        public const string COL_TRACKTITLE = "TrackTitle";
        public const string COL_FILENAME = "FileName";
        public const string COL_METADATA = "YoutubeText";
        public const string COL_FORMAT_ID = "FK_fileextension_id";
        public const string COL_STYLE_ID = "FK_style_id";
        public const string COL_COMPOSER_ID = "FK_composer_id";
        public const string COL_COMPOSER_NAME = "ComposerName";
        public const string COL_SCENEGROUP_ID = "FK_scenegroup_id";
        public const string COL_SCENEGROUP_NAME = "ScenegroupName";
        public const string COL_TAG_ID = "FK_tag_id";

        public const string PARAM_TRACKTITLE = "@param_TrackTitle";
        public const string PARAM_FILENAME = "@param_FileName";
        public const string PARAM_METADATA = "@param_MetaData";
        public const string PARAM_FORMAT_ID = "@param_FileExtensionId";
        public const string PARAM_STYLE_IDS = "@param_StyleIDs";
        public const string PARAM_COMPOSER_ID = "@param_ComposerID";
        public const string PARAM_COMPOSER_NAME = "@param_ComposerName";
        public const string PARAM_SCENEGROUP_ID = "@param_ScenegroupID";
        public const string PARAM_SCENEGROUP_NAME = "@param_ScenegroupName";
        public const string PARAM_TAGS_IDS = "@param_TagIDs";

        public string Where_TrackTitle = "";
        public string Where_FileName = "";
        public string Where_MetaData = "";
        public string Where_Format_id = "";
        public string Where_Styles_ids = "";
        public string Where_Composer_id = "";
        public string Where_Composer_name = "";
        public string Where_Scenegroup_id = "";
        public string Where_Scenegroup_name = "";
        public string Where_Tags_ids = "";

        public long ExecutionTimeMS;

        bool _hasParams = false;

        private void AddParamLike(string name, string value)
        {
            _parameters.Add(new MySqlParameter(name, "%" + value + "%"));
            _hasParams = true;
        }

        private void AddParam(string name, object value)
        {
            _parameters.Add(new MySqlParameter(name, value));
            _hasParams = true;
        }

        private void SearchLike(ref string variable, string text, string column, string param)
        {
            if (text.IsNullOrEmpty()) return;
            variable = $"{column} LIKE {param} AND ";
            AddParamLike(param, text);
        }

        private void SearchID(ref string variable, int id, string column, string param)
        {
            if (id == 0) return;
            variable = $"{column} = {param} AND ";
            AddParam(param, id);
        }

        private void SearchIN(ref string variable, int[] ids, string column)
        {
            if (ids == null || ids.Length == 0 || ids.Length > 99) return;
            variable = $"{column} IN ({string.Join(",", ids)}) AND ";
            _hasParams = true;
        }

        private void SearchCrossIN(ref string variable, int[] ids, string table, string column)
        {
            if (ids == null || ids.Length == 0 || ids.Length > 99) return;
            variable = $"Track_id IN (\nSELECT FK_Track_id FROM {table} WHERE {column} IN ({string.Join(",", ids)})\n) AND ";
            _hasParams = true;
        }

        public void SearchTrackTitle(string text) => SearchLike(ref Where_TrackTitle, text, COL_TRACKTITLE, PARAM_TRACKTITLE);
        public void SearchFileName(string text) => SearchLike(ref Where_FileName, text, COL_FILENAME, PARAM_FILENAME);
        public void SearchMetaData(string text) => SearchLike(ref Where_MetaData, text, COL_METADATA, PARAM_METADATA);
        public void SearchFormat(int id) => SearchID(ref Where_Format_id, id, COL_FORMAT_ID, PARAM_FORMAT_ID);
        public void SearchStyles(int[] ids) => SearchIN(ref Where_Styles_ids, ids, COL_STYLE_ID);
        public void SearchComposerById(int id) => SearchID(ref Where_Composer_id, id, COL_COMPOSER_ID, PARAM_COMPOSER_ID);
        public void SearchComposerByName(string text) => SearchLike(ref Where_Composer_name, text, COL_COMPOSER_NAME, PARAM_COMPOSER_NAME);
        public void SearchScenegroupById(int id) => SearchID(ref Where_Scenegroup_id, id, COL_SCENEGROUP_ID, PARAM_SCENEGROUP_ID);
        public void SearchScenegroupByName(string text) => SearchLike(ref Where_Scenegroup_name, text, COL_SCENEGROUP_NAME, PARAM_SCENEGROUP_NAME);
        public void SearchTags(int[] ids) => SearchCrossIN(ref Where_Tags_ids, ids, TBL_C_TRACK_TAG, COL_TAG_ID);

        public DataTable ExecuteAndRetrieve()
        {
            var stopwatch = new Stopwatch();
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
                query = $"{Where_Scenegroup_id}{Where_Composer_id}{Where_Format_id}{Where_Styles_ids}{Where_Tags_ids}{Where_TrackTitle}{Where_FileName}{Where_Scenegroup_name}{Where_Composer_name}{Where_MetaData}";
                query = RemoveLastPieceOfString(query, " AND ");
                query = $"{_querySearchStart} {query} {_querySearchEnd}";
            }

            stopwatch.Start();
            var tbl = DB.DBManager.Instance.C.DataTable(query, _parameters);
            stopwatch.Stop();

            ExecutionTimeMS = stopwatch.ElapsedMilliseconds;

            return tbl;
        }

        string RemoveLastPieceOfString(string s, string remove)
        {
            if (s.EndsWith(remove))
                s = s.Substring(0, s.Length - remove.Length);

            return s;
        }
    }
}

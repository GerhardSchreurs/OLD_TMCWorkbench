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

        private List<MySqlParameter> _parameters;
        public int Limit = 50;
        public int PageNumber = 0;

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
        public const string COL_TRACKER_ID = "FK_tracker_id";
        public const string COL_DATE_TRACK_CREATED = "Date_track_created";
        public const string COL_DATE_TRACK_STORED = "Date_created";
        public const string COL_SCORE = "Score";
        public const string COL_BPM = "Bpm";

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
        public const string PARAM_TRACKER_IDS = "@param_TrackerIDs";
        public const string PARAM_DATE_FROM_1 = "@param_DateFrom1"; //not in use yet
        public const string PARAM_DATE_FROM_2 = "@param_DateFrom2"; //not in use yet
        public const string PARAM_SCORE = "@param_Score";
        public const string PARAM_BPM = "@param_BPM";

        public string Q_TrackTitle = "";
        public string Q_FileName = "";
        public string Q_MetaData = "";
        public string Q_Format_id = "";
        public string Q_Styles_ids = "";
        public string Q_Composer_id = "";
        public string Q_Composer_name = "";
        public string Q_Scenegroup_id = "";
        public string Q_Scenegroup_name = "";
        public string Q_Tags_ids = "";
        public string Q_Tracker_ids = "";
        public string Q_Date_track_created = "";
        public string Q_Date_track_stored = "";
        public string Q_Score = "";
        public string Q_BPM = "";

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

        public void SearchDates(ref string where, DateTime? dateFrom, DateTime? dateTill, string column)
        {
            if (dateFrom == null && dateTill == null) return;

            _hasParams = true; //TODO: A lie, params not working atm, find out later

            if (dateFrom.HasValue && dateTill == null)
                where = $"{column} >= {GetStr_To_Date(dateFrom.Value)} AND ";
            if (dateTill.HasValue && dateFrom == null)
                where = $"{column} <= {GetStr_To_Date(dateFrom.Value)} AND ";
            if (dateFrom.HasValue && dateTill.HasValue)
                where = $"({column} BETWEEN {GetStr_To_Date(dateFrom.Value)} AND {GetStr_To_Date(dateTill.Value)}) AND ";
        }

        private void SearchWithModifier(ref string where, double? score, string modifier, string column, string param)
        {
            if (score == null || modifier.IsNullOrEmpty()) return;
            modifier = GetModifier(modifier);

            AddParam(param, score.Value);
            where = $"{column} {modifier} {param} AND ";
        }

        public void SearchTrackTitle(string text) => SearchLike(ref Q_TrackTitle, text, COL_TRACKTITLE, PARAM_TRACKTITLE);
        public void SearchFileName(string text) => SearchLike(ref Q_FileName, text, COL_FILENAME, PARAM_FILENAME);
        public void SearchMetaData(string text) => SearchLike(ref Q_MetaData, text, COL_METADATA, PARAM_METADATA);
        public void SearchFormat(int id) => SearchID(ref Q_Format_id, id, COL_FORMAT_ID, PARAM_FORMAT_ID);
        public void SearchStyles(int[] ids) => SearchIN(ref Q_Styles_ids, ids, COL_STYLE_ID);
        public void SearchComposerById(int id) => SearchID(ref Q_Composer_id, id, COL_COMPOSER_ID, PARAM_COMPOSER_ID);
        public void SearchComposerByName(string text) => SearchLike(ref Q_Composer_name, text, COL_COMPOSER_NAME, PARAM_COMPOSER_NAME);
        public void SearchScenegroupById(int id) => SearchID(ref Q_Scenegroup_id, id, COL_SCENEGROUP_ID, PARAM_SCENEGROUP_ID);
        public void SearchScenegroupByName(string text) => SearchLike(ref Q_Scenegroup_name, text, COL_SCENEGROUP_NAME, PARAM_SCENEGROUP_NAME);
        public void SearchTags(int[] ids) => SearchCrossIN(ref Q_Tags_ids, ids, TBL_C_TRACK_TAG, COL_TAG_ID);
        public void SearchTrackers(int[] ids) => SearchIN(ref Q_Tracker_ids, ids, COL_TRACKER_ID);
        public void SearchDateTrackCreated(DateTime? from, DateTime? till) => SearchDates(ref Q_Date_track_created, from, till, COL_DATE_TRACK_CREATED);
        public void SearchDateDatabaseStored(DateTime? from, DateTime? till) => SearchDates(ref Q_Date_track_stored, from, till, COL_DATE_TRACK_STORED);
        public void SearchRating(double? score, string modifier) => SearchWithModifier(ref Q_Score, score, modifier, COL_SCORE, PARAM_SCORE);
        public void SearchBPM(double? bpm, string modifier) => SearchWithModifier(ref Q_BPM, bpm, modifier, COL_BPM, PARAM_BPM);

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
                query = $"{Q_Scenegroup_id}{Q_Composer_id}{Q_Format_id}{Q_Tracker_ids}{Q_Score}{Q_BPM}{Q_Styles_ids}{Q_Tags_ids}{Q_TrackTitle}{Q_FileName}{Q_Scenegroup_name}{Q_Composer_name}{Q_MetaData}{Q_Date_track_stored}{Q_Date_track_created}";
                query = RemoveLastPieceOfString(query, " AND ");
                query = $"{_querySearchStart} {query} {_querySearchEnd}";
            }

            stopwatch.Start();
            var tbl = DB.DBManager.Instance.C.DataTable(query, _parameters);
            stopwatch.Stop();

            ExecutionTimeMS = stopwatch.ElapsedMilliseconds;

            return tbl;
        }

        private string GetModifier(string modifier)
        {
            if (modifier == "<" || modifier == "<=")
                modifier = "<=";
            else if (modifier == ">" || modifier == ">=")
                modifier = ">=";
            else
                modifier = "=";

            return modifier;
        }

        private string GetStr_To_Date(DateTime d)
        {
            return $"STR_TO_DATE('{d.Year},{d.Month},{d.Day}', '%Y,%m,%d')";
        }

        private string RemoveLastPieceOfString(string s, string remove)
        {
            if (s.EndsWith(remove))
                s = s.Substring(0, s.Length - remove.Length);

            return s;
        }
    }
}
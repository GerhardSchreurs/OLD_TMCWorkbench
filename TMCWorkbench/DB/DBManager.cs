using ModLibrary.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCDatabase;
using TMCDatabase.Model;
using TMCDatabase.Utility;

namespace TMCWorkbench.DB
{
    public sealed class DBManager : IDisposable
    {
        #region Singleton
        private static DBManager instance = null;
        private static readonly object padlock = new object();

        DBManager() {}

        public static DBManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DBManager();
                        instance.Init();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public DatabaseContext C;
        public MySqlConnection CON;

        public List<Style> Styles;
        public List<TrackStyle> TrackStyles;

        public Track Track;


        private void Init()
        {
            CON = new MySqlConnection(Configurator.ConnectionString);
            CON.Open();
            C = new DatabaseContext(CON,false);
        }

        public void LoadStyles(bool refresh = false)
        {
            if (refresh || refresh == false && TrackStyles == null)
            {
                C.Styles.Load();
                Styles = C.Styles.ToList();
            }

        }

        public void LoadTrackstyles()
        {
            LoadStyles();

            if (TrackStyles == null)
            {
                TrackStyles = new List<TrackStyle>();
            }

            foreach (var style in Styles.Where(x => x.ParentStyle == null))
            {
                AddStyle(null, style);
            }
        }

        public bool LoadTrackInfo(Guid guid)
        {
            Track = C.Tracks.SingleOrDefault(x => x.Md5 == guid);

            return Track != null;
        }

        private void AddStyle(TrackStyle parentStyle, Style style)
        {
            var trackStyle = new TrackStyle(style.Name, style.Weight);
            trackStyle.IsAlt = style.IsAlt;
            trackStyle.ParentStyle = parentStyle;

            //foreach (var substyle in Styles.Where(x => x.IsAlt && x.Parent_style_id == style.Style_id))
            //{
            //    var subTrackStyle = new TrackStyle(substyle.Name, substyle.Weight);
            //    subTrackStyle.IsAlt = substyle.IsAlt;
            //    subTrackStyle.ParentStyle = trackStyle;

            //    trackStyle.Add(subTrackStyle);
            //}

            foreach (var child in Styles.Where(x => x.Parent_style_id == style.Style_id))
            {
                AddStyle(trackStyle, child);
            }

            TrackStyles.Add(trackStyle);
        }

        public bool IsTrackInDB(Guid guid)
        {
            return C.Tracks.Any(x => x.Md5 == guid);
        }

        public void Add(Style style)
        {
            C.Styles.Add(style);
        }

        public void Delete(Style style)
        {
            C.Styles.Remove(style);
        }

        public void Save()
        {
            var modifiedOrAddedEntities = C.ChangeTracker.Entries()
                 .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added)
                 .Select(x => x.Entity).ToList();

            C.SaveChanges();

  

            Console.WriteLine(modifiedOrAddedEntities);
        }

        public void Dispose()
        {
            try
            {
                C.Dispose();
                CON.Close();
                CON.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

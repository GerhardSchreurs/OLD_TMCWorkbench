using ModLibrary.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCDatabase;
using TMCDatabase.DBModel;
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
        public List<Tracker> Trackers;
        public List<TrackStyle> TrackStyles;
        public List<Scenegroup> SceneGroups;
        public List<Composer> Composers;
        public List<C_Scenegroup_Composer> GroupsComposers;

        public Track Track;

        private void Init()
        {
            CON = new MySqlConnection(Configurator.ConnectionString);
            CON.Open();
            C = new DatabaseContext(CON,false);
            C.Database.Log = Console.WriteLine;
        }

        public void LoadTrackers(bool refresh = false)
        {
            if (refresh || refresh == false && Trackers == null)
            {
                C.Trackers.Load();
                Trackers = C.Trackers.ToList();
            }
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
                AddTrackStyle(null, style);
            }
        }

        private void AddTrackStyle(TrackStyle parentStyle, Style style)
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
                AddTrackStyle(trackStyle, child);
            }

            TrackStyles.Add(trackStyle);
        }

        public void LoadSceneGroups(bool refresh = false)
        {
            if (refresh || refresh == false && SceneGroups == null)
            {
                C.Scenegroups.Load();
                SceneGroups = C.Scenegroups.ToList();
            }
        }

        public void LoadComposers(bool refresh = false)
        {
            if (refresh || refresh == false && Composers == null)
            {
                C.Composers.Load();
                Composers = C.Composers.ToList();
            }
        }

        public void LoadGroupsComposers(bool refresh = false)
        {
            if (refresh || refresh == false && GroupsComposers == null)
            {
                C.C_Scenegroup_Composers.Load();
                GroupsComposers = C.C_Scenegroup_Composers.ToList();
            }
        }

        public bool LoadTrackInfo(Guid guid)
        {
            Track = C.Tracks.SingleOrDefault(x => x.Md5 == guid);

            return Track != null;
        }



        

        public bool IsTrackInDB(Guid guid)
        {
            return C.Tracks.Any(x => x.Md5 == guid);
        }

        public void Add(Style style)
        {
            C.Styles.Add(style);
        }

        public void AddOrUpdate(Track track)
        {
            if (IsTrackInDB(track.Md5))
            {
                //Do nothing
            }
            else
            {
                C.Tracks.Add(track);
            }
        }

        public void AddComposerToGroup(int sceneGroupId, int composerId, bool isFounder = false)
        {
            var group = new C_Scenegroup_Composer();
            group.FK_scenegroup_id = sceneGroupId;
            group.FK_composer_id = composerId;
            group.IsFounder = isFounder;

            C.C_Scenegroup_Composers.Add(group);
        }

        public void Add(Scenegroup scenegroup, bool save = true, bool refresh = true)
        {
            C.Scenegroups.Add(scenegroup);

            if (save)
            {
                C.SaveChanges();
            }
            if (refresh)
            {
                LoadSceneGroups(true);
            }
        }

        public void Add(Composer composer, bool save = true, bool refresh = true)
        {
            C.Composers.Add(composer);

            if (save)
            {
                C.SaveChanges();
            }
            if (refresh)
            {
                LoadComposers(true);
            }
        }

        public void RemoveComposerFromGroup(Scenegroup sceneGroup, List<Composer> composers)
        {
            if (composers == null) return;

            var collection = new List<C_Scenegroup_Composer>();

            foreach(var composer in composers)
            {
                foreach (var x in GroupsComposers.Where(g => g.FK_scenegroup_id == sceneGroup.Scenegroup_id))
                {
                    if (x.FK_composer_id == composer.Composer_id)
                    {
                        collection.Add(x);
                    }
                }
            }

            C.C_Scenegroup_Composers.RemoveRange(collection);
        }

        public void RemoveComposerFromGroup(Composer composer, List<Scenegroup> scenegroups)
        {
            if (scenegroups == null) return;

            var collection = new List<C_Scenegroup_Composer>();

            foreach (var scenegroup in scenegroups)
            {
                foreach (var x in GroupsComposers.Where(g => g.FK_composer_id == composer.Composer_id))
                {
                    if (x.FK_scenegroup_id == scenegroup.Scenegroup_id)
                    {
                        collection.Add(x);
                    }
                }
            }

            C.C_Scenegroup_Composers.RemoveRange(collection);
        }

        public void Remove(Composer composer)
        {
            C.Composers.Remove(composer);
        }

        public void Remove(Scenegroup scenegroup)
        {
            C.Scenegroups.Remove(scenegroup);
        }

        public void Delete(Style style)
        {
            C.Styles.Remove(style);
        }

        public void Replace(Scenegroup scenegroup)
        {
            C.Scenegroups.AddOrUpdate(scenegroup);
        }

        public void Replace(Composer composer)
        {
            C.Composers.AddOrUpdate(composer);
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

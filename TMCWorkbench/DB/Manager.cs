using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCDatabase;
using TMCDatabase.Model;
using TMCDatabase.Utility;

namespace TMCWorkbench.DB
{
    public sealed class Manager : IDisposable
    {
        #region Singleton
        private static Manager instance = null;
        private static readonly object padlock = new object();

        Manager() {}

        public static Manager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Manager();
                        instance.Init();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public DatabaseContext C;
        public MySqlConnection CON;

        private void Init()
        {
            CON = new MySqlConnection(Configurator.ConnectionString);
            CON.Open();
            C = new DatabaseContext(CON,false);
        }

        public void GetStyles(bool refresh = false)
        {
            C.Styles.Load();
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
            C.SaveChanges();
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

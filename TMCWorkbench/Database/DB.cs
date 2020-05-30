using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCWorkbench.Model;

namespace TMCWorkbench.Database
{
    public class DB : IDisposable
    {
        #region Singleton
        private DB() { }
        private static DB _instance = null;
        public static DB Instance()
        {
            if (_instance == null)
            {
                _instance = new DB();
            }

            return _instance;
        }
        #endregion

        public static Executor Executor = new Executor(Properties.Private.Default.ConnectionString);

        public TableStyles TableStyles = new TableStyles();

        public async Task GetDataTables()
        {
            await TableStyles.GetDataAsync();
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Executor.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

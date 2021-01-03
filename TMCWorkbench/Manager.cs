using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench.DB;

namespace TMCWorkbench
{
    public sealed class Manager
    {
        #region Singleton
        private static Manager _instance = null;
        private static readonly object _padlock = new object();
        private static Jot.Tracker _stateTracker = new Jot.Tracker();

        Manager() { }

        public static Manager Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Manager();
                        _instance.Init();
                    }
                    return _instance;
                }
            }
        }
        #endregion

        //Todo: dispose
        private MD5 _md5 = MD5.Create();
        private string LastMd5Path = string.Empty;
        public Guid LastMd5Guid = Guid.Empty;
        public bool LastMdSuccess = false;

        public static Jot.Tracker StateTracker
        {
            get
            {
                return _stateTracker;
            }
        }

        private void Init()
        {
            _stateTracker.Configure<_UCForm>()
                .Id(f => f.Name, SystemInformation.VirtualScreen.Size) // <-- include the screen resolution in the id
                .Properties(f => new { f.Top, f.Width, f.Height, f.Left, f.WindowState })
                .PersistOn(nameof(Form.Move), nameof(Form.Resize), nameof(Form.FormClosing))
                .WhenPersistingProperty((f, p) => p.Cancel = (f.WindowState != FormWindowState.Normal && (p.Property == nameof(Form.Height) || p.Property == nameof(Form.Width) || p.Property == nameof(Form.Top) || p.Property == nameof(Form.Left)))) // do not track form size and location when minimized/maximized
                .StopTrackingOn(nameof(Form.FormClosing)); // <-- a form should not be persisted after it is closed since properties will be empty
        }

        public bool IsTrackInDB(FileInfo fileInfo)
        {
            return IsTrackInDB(fileInfo.FullName);
        }

        public bool IsTrackInDB(string path)
        {
            if (path != LastMd5Path)
            {
                LastMd5Path = path;
                LastMd5Guid = GetFileGuid(path);
                LastMdSuccess = DBManager.Instance.IsTrackInDB(LastMd5Guid);
            }

            return LastMdSuccess;
        }


        public Guid GetFileGuid(string path)
        {
            Guid id;

            using (var stream = File.OpenRead(path))
            {
                var hash = _md5.ComputeHash(stream);
                id = new Guid(hash);
                Console.WriteLine(BitConverter.ToString(hash));
            }

            return id;
        }

        public int GetFileExtensionID(string fullName)
        {
            var extension = Path.GetExtension(fullName);

            if (extension.IsNullOrEmpty()) return 0;
            extension = extension.ToUpper();

            if (extension == ".IT")
                return 1;
            if (extension == ".XM")
                return 2;
            if (extension == ".S3M")
                return 3;
            if (extension == ".MOD")
                return 4;

            return 0;
        }
    }
}

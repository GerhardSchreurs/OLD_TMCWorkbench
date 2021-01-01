using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TMCWorkbench.DB;

namespace TMCWorkbench
{
    public sealed class Manager
    {
        #region Singleton
        private static Manager instance = null;
        private static readonly object padlock = new object();

        Manager() { }

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

        //Todo: dispose
        private MD5 _md5 = MD5.Create();
        private string LastMd5Path = string.Empty;
        public Guid LastMd5Guid = Guid.Empty;
        public bool LastMdSuccess = false;

        private void Init()
        {

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

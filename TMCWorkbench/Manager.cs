using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        private void Init()
        {

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


    }
}

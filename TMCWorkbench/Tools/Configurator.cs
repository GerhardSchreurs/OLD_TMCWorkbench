using System;
using System.Configuration;

namespace TMCWorkbench.Tools
{
    public static class Configurator
    {
        private static string _basePath = String.Empty;
        private static string _connectionString = String.Empty;

        public static string BasePath
        {
            get
            {
                if (_basePath == String.Empty)
                {
                    var basePath = Environment.CurrentDirectory;
                    var projectName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
                    basePath = basePath.Substring(0, basePath.LastIndexOf(projectName));
                    _basePath = basePath + projectName;
                }

                return _basePath;
            }
        }

        public static string ConnectionString
        {
            get
            {
                if (_connectionString == String.Empty)
                {
                    var path = $"{BasePath}\\Private.config";

                    try
                    {
                        var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
                        var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                        _connectionString = config.AppSettings.Settings["ConnectionString"].Value;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Please add an App.Config file to this project and referencing projects (TMCDatabase and TMCDatabaseTest), rename it to Private.Config and add your connectionstring. Private.config is in .GITIGNORE\n\n" + ex.Message);
                    }
                }

                return _connectionString;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCWorkbench.Constants;
using TMCWorkbench.Enums;

namespace TMCWorkbench.Helpers
{
    public static class GeneralHelper
    {
        public static string GetStringExtensionFromFileInfo(FileInfo info)
        {
            var ext = Path.GetExtension(info.FullName);

            if (ext.IsNotNullOrEmpty() && ext.Length > 1 && ext.Length <= 4)
            {
                return ext.Substring(1).ToUpper();
            }

            return string.Empty;
        }

        public static Extension GetExtensionFromString(string extension)
        {
            return (Extension)Enum.Parse(typeof(Extension), extension);
        }

        public static bool IsSupportedFile(string extension)
        {
            return Enum.IsDefined(typeof(Extension), extension);
        }

        public static bool IsSupportedFile(Extension extension)
        {
            return Enum.IsDefined(typeof(Extension), extension);
        }

        public static int GetSupportedFileIcon(string extension)
        {
            return (int)((Extension)Enum.Parse(typeof(Extension), extension));
        }

        public static string GetExtensionNameFromInt(int extension)
        {
            var ext = (Extension)extension;

            if (ext == Extension.IT)
                return TrackerInfo.IT;
            if (ext == Extension.XM)
                return TrackerInfo.XM;
            if (ext == Extension.S3M)
                return TrackerInfo.S3M;
            if (ext == Extension.MOD)
                return TrackerInfo.MOD;

            return "?";
        }

        public static Color GetColorForExtension(Extension extension)
        {
            if (extension == Extension.IT)
                return AppColors.ColorIT;
            else if (extension == Extension.XM)
                return AppColors.ColorXM;
            else if (extension == Extension.S3M)
                return AppColors.ColorS3M;
            else if (extension == Extension.MOD)
                return AppColors.ColorMOD;
            else
                return Color.Gray;
        }

        public static Color GetColorForExtension(int extension)
        {
            return GetColorForExtension((Extension)extension);
        }
    }
}

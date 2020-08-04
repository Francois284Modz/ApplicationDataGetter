using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationDataGetter
{
    internal static class Strings
    {
        private static string LogoPattern = @"<div class=""xSyT2c""><img src=""(.*?)""";
        private static string VersionPattern = @"Current Version<\/div><span class=""htlgb""><div class=""IQ1z0d""><span class=""htlgb"">(.*?)<\/span><\/div>";
        private static string NamePattern = @"<title id=""main-title"">(.*)<\/title>";
        private static string UpdatePattern = @"Updated<\/div><span class=""htlgb""><div class=""IQ1z0d""><span class=""htlgb"">(.*?)<\/span>";
        private static string SizePattern = @"<div class=""BgcNfc"">Size<\/div><span class=""htlgb""><div class=""IQ1z0d""><span class=""htlgb"">(.*?)<\/span><\/div><\/span><\/div>";
        /// <summary>
        /// Return APK Logo Url
        /// </summary>
        /// <param name="downloadedString"></param>
        /// <returns></returns>
        public static string GetLogo(string str)
        {
            RegexOptions options = RegexOptions.Multiline ;
            string value = null;
            foreach (Match m in Regex.Matches(str, Strings.LogoPattern, options))
            {

                value = m.Groups[1].Value;
            }
            return value;
        }
        /// <summary>
        /// Return APK Name
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetAPKName(string str)
        {
            RegexOptions options = RegexOptions.Multiline ;
            string value1 = null;
            foreach (Match m in Regex.Matches(str, Strings.NamePattern, options))
            {
             var strresult = m.Groups[1].Value.Replace("- Apps on Google Play", "");
                value1 = strresult;
            }
            return value1;
        }
        /// <summary>
        /// Return APK Version
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Version GetAPKVersion(string str)
        {
            RegexOptions options = RegexOptions.Multiline ;
            string value1 = null;
            foreach (Match m in Regex.Matches(str, VersionPattern, options))
            {
                 value1 = m.Groups[1].Value;
            }
            if (Version.TryParse(value1, out Version result))
            {
                return result;
            }
            else
            {
                throw new Exception("Failed to parse Value");
            }
        }

        /// <summary>
        /// Return APK Update Version
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public  static DateTime GetLastUpdate(string str)
        {
            RegexOptions options = RegexOptions.Multiline;
            string value1 = null;
            foreach (Match m in Regex.Matches(str, UpdatePattern, options))
            {
                value1 = m.Groups[1].Value;
            }
            if (DateTime.TryParse(value1, out DateTime result))
            {
                return result;
            }
            else
            {
                throw new Exception("Failed to parse Value");
            }
        }
        /// <summary>
        /// Return APK Size
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetAPKSize(string str)
        {
            RegexOptions options = RegexOptions.Multiline;
            string value1 = null;
            foreach (Match m in Regex.Matches(str, Strings.SizePattern, options))
            {
                 value1 = m.Groups[1].Value;
               
            }
            return value1;
        }
    }
}

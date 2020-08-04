using System;
using System.Net;
using System.Text.RegularExpressions;

namespace ApplicationDataGetter
{
    public class ApplicationData
    {
        /// <summary>
        /// Returns an ApplicationData for the packageid from google play
        /// </summary>
        /// <param name="packageid"></param>
        public ApplicationData(string packageid)
        {
            WebClient client = new WebClient();
            string downloadedString = client.DownloadString("https://play.google.com/store/apps/details?id=" + packageid);

            /*  RegexOptions options = RegexOptions.Multiline;

              foreach (Match m in Regex.Matches(downloadedString, Strings.LogoPattern, options))
              {
                  this.IconURL = m.Groups[1].Value;
              }
              */
            this.IconURL = Strings.GetLogo(downloadedString);
            this.Name = Strings.GetAPKName(downloadedString);
            this.Version = Strings.GetAPKVersion(downloadedString);
            this.Updated = Strings.GetLastUpdate(downloadedString);
            this.PackageID = packageid;
            this.Size = Strings.GetAPKSize(downloadedString);
        }

       

        public string PackageID { get; internal set; }
        public string Name { get; internal set; }
        public string IconURL { get; internal set; }
        // public Version Version { get; internal set; }
        public Version Version { get; internal set; }
        public DateTime Updated { get; internal set; }
        public string Size { get; internal set; }
    }
}

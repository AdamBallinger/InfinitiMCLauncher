using System;
using System.Net;

namespace InfinitiMCLauncher2.Utils
{
    class Downloader
    {

        public static void DownloadFile(Uri fileUrl, string downloadDir)
        {
            WebClient client = null;
            try
            {
                Logger.WriteLine("Downloading file: " + fileUrl + " to " + downloadDir);
                client = new WebClient();
                client.DownloadFile(fileUrl, downloadDir);
                Logger.WriteLine("File downloaded successfully.");
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            finally
            {
                if(client != null)
                {
                    client.Dispose();
                }
            }
        }

        public static void DownloadAndExtract(Uri fileUrl, string downloadDir, string extractDir)
        {
            DownloadFile(fileUrl, downloadDir);
        }

        public static string DownloadString(Uri url)
        {
            WebClient client = null;
            string response = "";
            try
            {
                Logger.WriteLine("Downloding string from: " + url);
                client = new WebClient();
                response = client.DownloadString(url);
                Logger.WriteLine("String downloaded successfully.");
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            finally
            {
                if (client != null)
                {
                    client.Dispose();
                }
            }
            return response.Trim();
        }
    }
}

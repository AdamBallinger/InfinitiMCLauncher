using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

using InfinitiMCLauncher2.Utils;

namespace InfinitiMCLauncher2.Launcher
{
    class MinecraftLogin
    {

        private MinecraftSession session = null;

        public MinecraftLogin()
        {
            session = new MinecraftSession();
        }

        /// <summary>
        /// Creates a legacy minecraft session for Minecraft versions 1.6 and before. Will not work for 1.7 up.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Legacy minecraft session.</returns>
        public void CreateLegacyLoginSession(string email, string password)
        {
            Logger.WriteLine("Creating legacy minecraft session.");
            string[] sessionData = null; 

            try
            {
                sessionData = GET(string.Format("https://login.minecraft.net?user={0}&password={1}&version=13", email, password)).Split(':');
                if (sessionData[0].ToUpper().Equals("BAD LOGIN"))
                {
                    Logger.WriteLine("Bad login from minecraft login servers.");
                    session.Valid = false;
                }
                else if(sessionData[2] != null)
                {
                    session.Valid = true;
                    session.MinecraftUsername = sessionData[2];
                    session.MinecraftPassword = password;
                    session.MinecraftSessionToken = sessionData[3];
                }
                else
                {
                    Logger.WriteLine("No response. Session invalid.");
                    session.Valid = false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public MinecraftSession Session
        {
            get { return session; }
        }

        /// <summary>
        /// Performs a HTTP GET request to the given URL.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Returns the response sent from the server.</returns>
        private string GET(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = null;
            StreamReader reader = null;
            string responseString = null;
            try
            {
                response = request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                responseString = reader.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                Logger.WriteException(ex);
                MessageBox.Show(ex.Message, "Invalid web response", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(reader != null)
                    reader.Close();
            }
            return responseString;
        }

        /// <summary>
        /// Performs an HTTP PUT request to the specified url.
        /// (UNIMPLEMENTED)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <returns>Server response.</returns>
        private static string PUT(string url, string file)
        {
            return null;
        }
    }
}

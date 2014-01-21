using System;
using System.Xml;
using System.Diagnostics;

namespace InfinitiMCLauncher
{
    class Configuration
    {

        /// <summary>
        /// Reads a value from the launchers configuration file.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>The value of the given element</returns>
        public static string Parse(string element)
        {
            XmlReader xmlReader = XmlReader.Create(Directories.LauncherRoot + @"\config.xml");
            string result = "";
            try
            {
                Log.WriteLine("Parsing xml element: " + element);
                xmlReader.ReadToFollowing(element);
                result = xmlReader.ReadElementContentAsString();
                Log.WriteLine("Parsed string: " + result);
            }
            catch (Exception ex)
            {
                Log.WriteException(ex);
            }
            finally
            {
                xmlReader.Close();
            }
            return result;
        }

        /// <summary>
        /// Sets a new value to the given element in the launcher configuration file.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="newValue"></param>
        public static void Set(string element, string newValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Directories.LauncherRoot + @"\config.xml");

            XmlNode node = null;

            try
            {
                node = xmlDoc.SelectSingleNode("Launcher/" + element);
                node.InnerText = newValue;
                Log.WriteLine(node.Name + " value set to: " + node.InnerText);
                xmlDoc.Save(Directories.LauncherRoot + @"\config.xml");
            }
            catch (Exception ex)
            {
                Log.WriteException(ex);
            }
        }

    }
}

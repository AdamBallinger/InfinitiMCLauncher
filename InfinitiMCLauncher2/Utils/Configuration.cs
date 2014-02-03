using System;
using System.IO;
using System.Xml;

namespace InfinitiMCLauncher2.Utils
{
    class Configuration
    {
        /// <summary>
        /// Checks if the config file for the launcher exists.
        /// </summary>
        public static void Check()
        {
            if(!File.Exists(Directories.LauncherRoot + @"\config.xml"))
            {
                Create();
            }
            else
            {
                Logger.WriteLine("Launcher configuration detected.");
                //autobewbs.
            }
        }

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
                Logger.WriteLine("Parsing xml element: " + element);
                xmlReader.ReadToFollowing(element);
                result = xmlReader.ReadElementContentAsString();
                Logger.WriteLine("Parsed string: " + result);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            finally
            {
                xmlReader.Close();
            }
            return result;
        }

        /// <summary>
        /// Sets a new value to the given element in the launcher configuration file.
        /// E.G. Set("MinRam", "1024") will change the element MinRam value to 1024.
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
                Logger.WriteLine(node.Name + " value set to: " + node.InnerText);
                xmlDoc.Save(Directories.LauncherRoot + @"\config.xml");
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// Creates the default configuration file with default settings.
        /// </summary>
        private static void Create()
        {
            Logger.WriteLine("Creating default configuration file.");
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            XmlWriter xmlWriter = XmlWriter.Create(Directories.LauncherRoot + @"\config.xml", xmlSettings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteComment("Launcher configuration file.");

            xmlWriter.WriteStartElement("Launcher");
            xmlWriter.WriteComment("The end of the directory must not end with a \\");
            xmlWriter.WriteElementString("MinecraftRoot", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft-infiniti");
            xmlWriter.WriteElementString("ShowConsole", "true");
            xmlWriter.WriteElementString("RememberLogin", "false");

            xmlWriter.WriteComment("Java Settings:");
            xmlWriter.WriteElementString("MinRam", "512");
            xmlWriter.WriteElementString("MaxRam", "2048");
            xmlWriter.WriteElementString("JavaArgs", "-XX:MaxPermSize=256M");

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Flush();
            xmlWriter.Close();
        }
    }
}

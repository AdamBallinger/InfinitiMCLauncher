using System;
using System.IO;

using Newtonsoft.Json;

namespace InfinitiMCLauncher
{
    class LibraryIdentifier
    {

        public struct Lib
        {
            public struct Rules
            {
                public struct OS
                {
                    public string name { get; set; }
                    public string version { get; set; }
                }
                public string action { get; set; }
                public OS os { get; set; }
            }
            public struct Natives
            {
                public string linux { get; set; }
                public string windows { get; set; }
                public string osx { get; set; }
            }
            public struct Extract
            {
                public string[] exclude { get; set; }
            }

            public string url { get; set; }
            public string name { get; set; }
            public Rules[] rules { get; set; }
            public Natives natives { get; set; }
            public Extract extract { get; set; }
            public string serverreq { get; set; }
        }

        public string id { get; set; }
        public string time { get; set; }
        public string releaseTime { get; set; }
        public string type { get; set; }
        public string minecraftArguments { get; set; }
        public Lib[] libraries { get; set; }
        public string mainClass { get; set; }
        public int minimumLauncherVersion { get; set; }

        public static LibraryIdentifier Identify(string targetFile)
        {
            if (File.Exists(targetFile))
            {
                LibraryIdentifier libIdentifier = null;
                try
                {
                    StreamReader reader = new StreamReader(targetFile);
                    libIdentifier = JsonConvert.DeserializeObject<LibraryIdentifier>(reader.ReadToEnd());
                    return libIdentifier;
                }
                catch (Exception ex)
                {
                    Log.WriteException(ex);
                }
            }
            return null;
        }

    }
}

using System;
using System.IO;
using System.Diagnostics;

namespace InfinitiMCLauncher2.Utils
{
    class Logger
    {
        
        public static void WriteLine(string log)
        {
            Debug.WriteLine("[DEBUG] >> " + log);
            FileStream fileStream = null;
            StreamWriter writer = null;

            try
            {
                fileStream = new FileStream(Directories.LauncherRoot + @"\launcher-log.log", FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(fileStream);

                writer.WriteLine("[{0}][Logger] -> {1}", DateTime.Now, log);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if(writer != null)
                {
                    writer.Close();
                }

                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        public static void WriteException(Exception ex)
        {
            WriteLine("----------- Fatal Exception -----------");
            WriteLine("Please notify crunchy about the problem, and send this log file.");
            WriteLine("Scrambling the debug rabbits...");
            WriteLine("Exception Message: " + ex.Message);
            WriteLine("Exception stack: " + ex.StackTrace);
            WriteLine("---------------------------------------");
        }

    }
}

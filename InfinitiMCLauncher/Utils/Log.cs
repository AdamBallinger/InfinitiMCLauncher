using System;
using System.IO;
using System.Diagnostics;

namespace InfinitiMCLauncher
{
    class Log
    {

        public static void WriteException(Exception ex)
        {
            WriteLine("=============== FATAL ERROR OMG SCRAMBLE THE DEBUG RABBITS =========================");
            WriteLine("Something went wrong! Tell crunchy!!");
            WriteLine("Exception message: (Send crunchy this too!!)");
            WriteLine(ex.Message);
            WriteLine("Exception source:");
            WriteLine(ex.Source);
            WriteLine("Exception stack:");
            WriteLine(ex.StackTrace);
            WriteLine("====================================================================================");
        }

        public static void WriteLine(string logInfo)
        {
            FileStream fileStream = null;
            StreamWriter writer = null;
            Debug.WriteLine(logInfo);

            try
            {
                fileStream = new FileStream(Directories.LauncherRoot + @"\launcher-log.log", FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(fileStream);
                writer.WriteLine("[{0}] -> " + logInfo, DateTime.Now);
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if(writer != null)
                {
                    writer.Close();
                }
                
                if(fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

    }
}

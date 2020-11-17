using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{
    public class Logger
    {
        private const string FileName = "Log.txt";
        

        public bool WriteLogLine(string logLine)
        {
            // find path for Log file to be recorded in.
            bool success = false;
            string path = Environment.CurrentDirectory;
            string fileName = "Log.txt";
            string inputFullPath = Path.Combine(path, fileName);
            //string revisedFileName = "log-revised.txt";



            try
            {
                using (StreamWriter sw = new StreamWriter(inputFullPath, true))
                {
                    sw.WriteLine(logLine);
                }

            }
            catch (Exception e) { }
            return success;

        }
        //public bool ReadLog()
        //{
        //    string directory = Environment.CurrentDirectory;
        //    string fileName = "Log.txt";
        //    string fullPath = Path.Combine(directory, fileName);

        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(fullPath))
        //            while (!sr.EndOfStream)
        //            {
        //                string line = sr.ReadLine();
        //                Console.WriteLine(line);
        //            }
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}
    }
}

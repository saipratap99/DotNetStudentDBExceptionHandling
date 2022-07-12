using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentDB
{
    public class FileOperations
    {
        public void AppendToFile(string path, string data)
        {
            FileStream f1 = null;
            StreamWriter s1 = null;
            try
            {
                f1 = new FileStream(path, FileMode.Append);
                s1 = new StreamWriter(f1);
                s1.WriteLine(data);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (s1 != null)
                    s1.Close();
                
                if (f1 != null)
                    f1.Close();
            }
        }

        public void ReadFromFile(string path)
        {
            FileStream f1 = null;
            StreamReader s1 = null;
            try
            {
                f1 = new FileStream(path, FileMode.Open);
                s1 = new StreamReader(f1);
                string line = null;

                while ((line = s1.ReadLine()) != null)
                    Console.WriteLine(line);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (s1 != null)
                    s1.Close();

                if (f1 != null)
                    f1.Close();
            }

        }



    }
}

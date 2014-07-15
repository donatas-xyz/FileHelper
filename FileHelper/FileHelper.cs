using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHelper
{
    public class FileHelper_For_Annotation
    {
        public string path; // Accessible publicly for Unit Testing

        public void SetFile(string path)
        {
            if (!File.Exists(path))
            {
                // Error solving solutions can be added here, depending on requirements
                throw new FileNotFoundException();
            }
            else
            {
                this.path = path;
            }
        }

        public string GetChar(int line, int position)
        {
            try 
            {
                StreamReader reader = new StreamReader(path);

                string t = null;

                for (var i = 0; i < line + 1; i++)
                {
                    t = reader.ReadLineAsync().Result;
                }

                reader.Close(); // Close the StreamReader

                string character = Convert.ToString(t[position]);

                return character;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void SetChar(int line, int position, string character)
        {
            try
            {
                var lines = File.ReadAllLines(path);

                char[] cs = lines[line].ToCharArray();

                cs[position] = character[0];

                lines[line] = string.Join("", cs.Select(c => c).ToList());

                File.WriteAllLines(path, lines);
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }

            //return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHelper
{
    class FileHelper // FileHelper class should be made public to be accessible to external classes.
    {                 
        string path; // For this helper class I think it would be easier to pass a path as parameter of method. 

        public void SetFile(string path) // Method to define the path to file. Verification for missing file or wrong path is missing.
        {                                // The method could take care of how paths are extracted or defined. 
            this.path = path;
        }

        public string GetChar(int line, int position) // Gets specified character by location from file defined in path. 
        {
            StreamReader reader = new StreamReader(path); // StreamReader is faster than File.ReadAllLines and can handle larger files, so no changes here. 
                                                          // StreamReader is not closed here, so SetChar won't be able to write into the file until it's closed. 
            string t = null;

            for (var i = 0; i < line + 1; i++) // Reads the file till the end and saves the result to string
            {
                t = reader.ReadLineAsync().Result;
            }

            return Convert.ToString(t[position]); // Since string is an array of characters, to display particular one we only need to choose the right position in the string.

            // Again, no care has been taken of guaranteed NullReferenceExceptions, which are caused by IndexOutOfRangeExceptions inside the loop.
        }

        public string SetChar(int line, int position, string character) // Replaces a character in particular location with the one defined in external class.
        {                                                               // I would still implement functionality that allows to amend multiple characters in any location of the file.
            try
            {
                var lines = File.ReadAllLines(path); // Similar to StreamReader. Actually uses StreamReader. 

                char[] cs = lines[line].ToCharArray(); // Retrieves selected line and saves it into array of characters. 
                cs[position] = character[0]; // Replaces character in defined location with one defined by external class.  

                lines[line] = string.Join("", cs.Select(c => c).ToList()); // Uses LINQ to replace selected line with amended one. 

                File.WriteAllLines(path, lines); // Writes changes to a file. 

                return null; // This method doesn't need to return anything
            }
            catch (Exception) // Expects any exception. Filtering it to range of expected exceptions would increase the performance. I'm likely micro-optimizing here...
            {
                throw new Exception("Cannot write lines"); // This new instance of Ecxeption would delete the information about inital Exception, so error details would actually be missed.  
            }
        }
    }
}

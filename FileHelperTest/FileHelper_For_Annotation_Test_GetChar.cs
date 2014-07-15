using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileHelper;
using System.Threading.Tasks;
using System.IO;

namespace FileHelperTest
{
    [TestClass]
    public class FileHelper_For_Annotation_Test_GetChar
    {
        FileHelper_For_Annotation file = new FileHelper_For_Annotation();

        [TestMethod]
        public void GetCharTest_HappyPath()
        {
            string pathSet = @"../../../FileHelper/TestFileTEMP.txt";
            string charSet = "X";
            int line = 4;
            int position = 2;

            using (StreamWriter sw = File.CreateText(pathSet))
            {
                sw.WriteLine("aaaaaaaaaa");
                sw.WriteLine("bbbbbbb");
                sw.WriteLine("ccccccccccc");
                sw.WriteLine("dd");
                sw.WriteLine("ee"+charSet+"e");
            }

            file.SetFile(@"../../../FileHelper/TestFileTEMP.txt");
            string charRetrieved = file.GetChar(line, position);

            Assert.AreEqual(charSet, charRetrieved);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetCharTest_LinesExceeded()
        {
            string pathSet = @"../../../FileHelper/TestFileTEMP.txt";
            int line = 5;
            int position = 2;

            using (StreamWriter sw = File.CreateText(pathSet))
            {
                sw.WriteLine("aaaaaaaaaa");
                sw.WriteLine("bbbbbbb");
                sw.WriteLine("ccccccccccc");
                sw.WriteLine("dd");
                sw.WriteLine("eeee");
            }

            file.SetFile(@"../../../FileHelper/TestFileTEMP.txt");
            file.GetChar(line, position);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetCharTest_PositionsExceeded()
        {
            string pathSet = @"../../../FileHelper/TestFileTEMP.txt";
            int line = 4;
            int position = 25;

            using (StreamWriter sw = File.CreateText(pathSet))
            {
                sw.WriteLine("aaaaaaaaaa");
                sw.WriteLine("bbbbbbb");
                sw.WriteLine("ccccccccccc");
                sw.WriteLine("dd");
                sw.WriteLine("eeee");
            }

            file.SetFile(@"../../../FileHelper/TestFileTEMP.txt");
            file.GetChar(line, position);
        }
    }
}

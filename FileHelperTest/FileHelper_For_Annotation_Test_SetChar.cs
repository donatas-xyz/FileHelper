using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileHelper;
using System.IO;

namespace FileHelperTest
{
    [TestClass]
    public class FileHelper_For_Annotation_Test_SetChar
    {
        FileHelper_For_Annotation file = new FileHelper_For_Annotation();
        RandomStringGenerator randomString = new RandomStringGenerator();

        [TestMethod]
        public void SetCharTest_HappyPath()
        {
            string pathSet = @"../../../FileHelper/TestFileTEMP.txt";
            int line = 4;
            int position = 2;

            using (StreamWriter sw = File.CreateText(pathSet))
            {
                sw.WriteLine("aaaaaaaaaa");
                sw.WriteLine("bbbbbbb");
                sw.WriteLine("ccccccccccc");
                sw.WriteLine("dd");
                sw.WriteLine("eeee");
            }

            string charSet = randomString.RandomString()[0].ToString();

            file.SetFile(@"../../../FileHelper/TestFileTEMP.txt");
            file.SetChar(line, position, charSet);

            string charRetrieved = file.GetChar(line, position);

            Assert.AreEqual(charSet, charRetrieved);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetCharTest_LinesOrCharactersExceeded()
        {
            string pathSet = @"../../../FileHelper/TestFileTEMP.txt";
            int line = 5;
            int position = 25;

            using (StreamWriter sw = File.CreateText(pathSet))
            {
                sw.WriteLine("aaaaaaaaaa");
                sw.WriteLine("bbbbbbb");
                sw.WriteLine("ccccccccccc");
                sw.WriteLine("dd");
                sw.WriteLine("eeee");
            }

            string charSet = randomString.RandomString()[0].ToString();

            file.SetFile(@"../../../FileHelper/TestFileTEMP.txt");
            file.SetChar(line, position, charSet);

            string charRetrieved = file.GetChar(line, position);

            Assert.AreEqual(charSet, charRetrieved);
        }
    }
}

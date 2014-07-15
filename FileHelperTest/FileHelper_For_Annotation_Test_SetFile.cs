using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileHelper;
using System.Threading.Tasks;
using System.IO;

namespace FileHelperTest
{
    [TestClass]
    public class FileHelper_For_Annotation_Test_SetFile
    {
        FileHelper_For_Annotation file = new FileHelper_For_Annotation();

        [TestMethod]
        public void SetFileTest_FileExists() 
        {
            string pathSet = @"../../../FileHelper/TestFile.txt";
            file.SetFile(pathSet);

            StreamReader reader = new StreamReader(file.path);
            string pathRetrieved = file.path;

            Assert.AreEqual(pathSet, pathRetrieved);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void SetFileTest_FileDoesNOTExist()
        {
            string pathSet = @"../../../FileHelper/FakeFile.txt";
            file.SetFile(pathSet);
        }
    }
}

using NUnit.Framework;
using System;
using System.IO;

namespace Tests_6
{
    internal class FileCreatorTests
    {
        [SetUp]
        public void CreateDirectory()
        {
            Directory.CreateDirectory(MyExercise_6.FileCreator.k_Directory);
        }

        [Test]
        public void CreateEmptyFile()
        {
            var objUnderTest = new MyExercise_6.FileCreator();

            var testFileName = "empty.txt";

            objUnderTest.CreateEmptyFile(testFileName);

            bool foundFile = false;
            var files = Directory.GetFiles(MyExercise_6.FileCreator.k_Directory);
            foreach (var file in files)
            {
                if (file.Equals(Path.Combine(MyExercise_6.FileCreator.k_Directory, testFileName)))
                {
                    foundFile = true;
                    break;
                }
            }

            Assert.That(foundFile, "Empty File found");

        }

        [Test]
        public void CreateFile()
        {
            var objUnderTest = new MyExercise_6.FileCreator();

            var testFileName = "notempty.txt";
            var testFileContent = "File Content";

            objUnderTest.CreateFile(testFileName, testFileContent);

            var files = Directory.GetFiles(MyExercise_6.FileCreator.k_Directory);
            Assert.That(files.Length, Is.EqualTo(1), "Expected one file");
            var expectedFilePath = Path.Combine(MyExercise_6.FileCreator.k_Directory, testFileName);
            Assert.That(files[0], Is.EqualTo(expectedFilePath));
            var content = File.ReadAllText(expectedFilePath);
            Assert.That(content, Is.EqualTo(testFileContent));
        }

        [TearDown]
        public void DeleteDirectory()
        {
            Directory.Delete(MyExercise_6.FileCreator.k_Directory, true);
        }
    }
}
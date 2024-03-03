
namespace UnitTest.Infrastructure.TestUtils;

public static partial class Constants
{
    public static class FileReaderService
    {
        public const string FilePath1 = "../../../../../Test/UnitTest.Infrastructure/TestFiles/TestFile1.txt";

        public const string FilePath1_CorrectFileContents = "Humpty Dumpty sat on a wall.\r\nHumpty Dumpty had a great fall.\r\nAll the king's horses and all the king's men\r\nCouldn't put Humpty together again.";

        public const string EmptyFile = "../../../../../Test/UnitTest.Infrastructure/TestFiles/EmptyFile.txt";

        public const string EmptyFile_CorrectFileContents = "";

        public const string InvalidFilePath = "../File.txt";
    }
}

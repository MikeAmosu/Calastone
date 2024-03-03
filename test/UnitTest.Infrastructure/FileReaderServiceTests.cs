using ContentFilterApp.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTest.Infrastructure.TestUtils;

namespace UnitTest.Infrastructure
{
    public class FileReaderServiceTests
    {
        
        readonly Mock<ILogger<FileReaderService>> _logger;
        public FileReaderServiceTests() 
        {
            _logger = new Mock<ILogger<FileReaderService>>();
        }
        
        private FileReaderService CreateFileReader()
        {
            return new FileReaderService(_logger.Object);
        }

        [Fact]
        public void FileReaderService_WhenFileIsAccessible_ReturnContentsOfFile()
        {
            //Arrange
            var service = CreateFileReader();

            //Act
            var result = service.ReadFile(Constants.FileReaderService.FilePath1);

            //Assert
            Assert.Equal(Constants.FileReaderService.FilePath1_CorrectFileContents, result);
        }

        [Fact]
        public void FileReaderService_PathIsIncorrect_ThrowFileNotFoundException()
        {
            //Arrange
            var service = CreateFileReader();

            //Act
            var ex = Assert.Throws<FileNotFoundException>(() => service.ReadFile(Constants.FileReaderService.InvalidFilePath));

            //Assert
            Assert.IsType<FileNotFoundException>(ex);
            Assert.Equal($"Unable to find File path {Constants.FileReaderService.InvalidFilePath}", ex.Message);
        }

        [Fact]
        public void FileReaderService_FileIsEmpty_ThrowExceptionSightingContentsEmpty()
        {
            //Arrange
            var service = CreateFileReader();

            //Act
            var ex = Assert.Throws<Exception>(() => service.ReadFile(Constants.FileReaderService.EmptyFile));

            //Assert
            Assert.IsType<Exception>(ex);
            Assert.Equal($"The file is empty. File Path: {Constants.FileReaderService.EmptyFile}.", ex.Message);
        }
    }
}
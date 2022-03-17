using Kata.Core.Contracts;
using Moq;
using NUnit.Framework;

namespace Kata.Core.Tests
{
    public class CopierTests
    {
        [Test]
        public void ReadsCharFromSource()
        {
            // Arrange
            Mock<ISource> _sourceMock = new();
            var copier = new Copier(_sourceMock.Object);

            // Act
            copier.Copy();

            // Assert
            _sourceMock.Verify(x => x.ReadChar(), Times.Once);
        }
    }
}

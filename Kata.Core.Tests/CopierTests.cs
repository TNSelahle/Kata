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
            Mock<IDestination> _destinationMock = new();
            var copier = new Copier(_sourceMock.Object, _destinationMock.Object);

            // Act
            copier.Copy();

            // Assert
            _sourceMock.Verify(x => x.ReadChar(), Times.Once);
        }

        [Test]
        public void WritesCharToDestinationAfterReadingFromSource()
        {
            // Arrange
            Mock<ISource> _sourceMock = new(MockBehavior.Strict);
            Mock<IDestination> _destinationMock = new(MockBehavior.Strict);
            var copier = new Copier(_sourceMock.Object, _destinationMock.Object);

            MockSequence sequence = new();
            _sourceMock.InSequence(sequence).Setup(x => x.ReadChar()).Returns('a');
            _destinationMock.InSequence(sequence).Setup(x => x.WriteChar(It.IsAny<char>()));

            // Act
            copier.Copy();

            // Assert
            _sourceMock.Verify(x => x.ReadChar(), Times.Once);
            _destinationMock.Verify(x => x.WriteChar(It.IsAny<char>()), Times.Once);
        }
    }
}

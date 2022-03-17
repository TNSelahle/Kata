using Kata.Core.Contracts;
using Moq;
using NUnit.Framework;

namespace Kata.Core.Tests
{
    public class CopierTests
    {
        private Mock<ISource> _sourceMock;
        private Mock<IDestination> _destinationMock;
        private Copier _copier;

        [SetUp]
        public void Setup()
        {
            _sourceMock = new(MockBehavior.Strict);
            _destinationMock = new();
            _copier = new Copier(_sourceMock.Object, _destinationMock.Object);
        }

        [Test]
        public void ReadsCharFromSource()
        {
            // Arrange
            _sourceMock.Setup(x => x.ReadChar()).Returns('\n');
            _destinationMock.Setup(x => x.WriteChar(It.IsAny<char>()));

            // Act
            _copier.Copy();

            // Assert
            _sourceMock.Verify(x => x.ReadChar(), Times.Once);
        }

        [Test]
        public void WritesCharToDestinationAfterReadingFromSource()
        {
            // Arrange
            _sourceMock.SetupSequence(x => x.ReadChar())
                .Returns('a')
                .Returns('\n');
            _destinationMock.Setup(x => x.WriteChar(It.IsAny<char>()));

            // Act
            _copier.Copy();

            // Assert
            _sourceMock.Verify(x => x.ReadChar(), Times.Exactly(2));
            _destinationMock.Verify(x => x.WriteChar(It.IsAny<char>()), Times.Once);
        }

        [Test]
        public void ReadsFromSourceUntilNewlineIsEncountered()
        {
            // Arrange
            int n = 5;
            _sourceMock.SetupSequence(x => x.ReadChar())
                .Returns('l')
                .Returns('e')
                .Returns('e')
                .Returns('t')
                .Returns('\n')
                .Returns('c')
                .Returns('o')
                .Returns('d')
                .Returns('e');
            _destinationMock.Setup(x => x.WriteChar(It.IsAny<char>()));

            // Act
            _copier.Copy();

            // Assert
            _sourceMock.Verify(x => x.ReadChar(), Times.Exactly(n));
            _destinationMock.Verify(x => x.WriteChar('t'), Times.Once);
            _destinationMock.Verify(x => x.WriteChar('e'), Times.Exactly(2));
            _destinationMock.Verify(x => x.WriteChar('d'), Times.Never);
        }

        [Test]
        public void ReadsMultipleCharactersThenWritesToDestination()
        {

            // Arrange
            int n = 6;
            _sourceMock.Setup(x => x.ReadChars(n)).Returns(new char[] { 'a', 'b', 'c', 'd', '\n', 'z' });
            _destinationMock.Setup(x => x.WriteChars(It.IsAny<char[]>()));

            // Act
            _copier.CopyMultiple(n);

            // Assert
            _sourceMock.Verify(x => x.ReadChars(n), Times.Once);
            _destinationMock.Verify(x => x.WriteChars(It.IsAny<char[]>()), Times.Once);
            _sourceMock.VerifyNoOtherCalls();
        }
    }
}

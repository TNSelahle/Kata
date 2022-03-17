﻿using Kata.Core.Contracts;
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
            _destinationMock = new(MockBehavior.Strict);
            _copier = new Copier(_sourceMock.Object, _destinationMock.Object);
        }

        [Test]
        public void ReadsCharFromSource()
        {
            // Arrange
            _sourceMock.Setup(x => x.ReadChar()).Returns('a');
            _destinationMock.Setup(x => x.WriteChar(It.IsAny<char>()));

            // Act
            _copier.Copy();

            // Assert
            _sourceMock.Verify(x => x.ReadChar(), Times.Once);
        }

        [Test]
        public void WritesCharToDestinationAfterReadingFromSource()
        {
            MockSequence sequence = new();
            _sourceMock.InSequence(sequence).Setup(x => x.ReadChar()).Returns('a');
            _destinationMock.InSequence(sequence).Setup(x => x.WriteChar(It.IsAny<char>()));

            // Act
            _copier.Copy();

            // Assert
            _sourceMock.Verify(x => x.ReadChar(), Times.Once);
            _destinationMock.Verify(x => x.WriteChar(It.IsAny<char>()), Times.Once);
        }
    }
}

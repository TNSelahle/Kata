using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adventure.Logic.Commands;
using Adventure.Logic.Abstractions;
using Rhino.Mocks;

namespace AdventureTest
{
    [TestClass]
    public class DanceCommandTests
    {
        private IConsoleFacade console;
        private DanceCommand target;

        [TestInitialize]
        public void Setup()
        {
            console = MockRepository.GenerateMock<IConsoleFacade>();
            target = new DanceCommand(null);
        }

        [TestMethod]
        public void Should_Handle_Uppercases()
        {
            // Arrange

            // Act
            var result = target.IsValid("DANCE");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_Handle_Uppercases()
        {
            // Arrange

            // Act
            var result = target.IsValid("        DANCE");

            // Assert
            Assert.IsTrue(result);
        }
    }
}

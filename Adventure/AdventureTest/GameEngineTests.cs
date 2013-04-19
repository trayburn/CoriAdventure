using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adventure;
using Rhino.Mocks;
using Adventure.Logic.Abstractions;
using Adventure.Logic;

namespace AdventureTest
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void Should_Display_Prompt()
        {
            // Arrange
            var mockConsole = MockRepository.GenerateMock<IConsoleFacade>();
            mockConsole.Stub(e => e.ReadLine()).Return("exit");
            var mockCommand = MockRepository.GenerateMock<ICommand>();
            mockCommand.Stub(e => e.IsValid(Arg<string>.Is.Anything)).Return(false);
            var engine = new GameEngine(mockConsole, mockCommand);

            // Act
            engine.Run();

            // Assert
            mockConsole.AssertWasCalled(e => e.Write(">> "));
            // find a way to check that the prompt was displayed.
        }
    }
}

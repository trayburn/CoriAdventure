using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adventure;
using Rhino.Mocks;

namespace AdventureTest
{
    [TestClass]
    public class GameEngineTest
    {
        [TestMethod]
        public void Should_Display_Prompt()
        {
            // Arrange
            var mockConsole = MockRepository.GenerateMock<IConsoleFacade>();
            mockConsole.Stub(e => e.ReadLine()).Return("exit");
            var engine = new GameEngine(mockConsole);

            // Act
            engine.Run();

            // Assert
            mockConsole.AssertWasCalled(e => e.Write(" > "));
            // find a way to check that the prompt was displayed.
        }
    }
}

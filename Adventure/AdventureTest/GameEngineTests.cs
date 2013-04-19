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

        [TestMethod]
        public void Should_Handle_Multiple_Commands()
        {
            // Arrange
            var mockConsole = MockRepository.GenerateMock<IConsoleFacade>();
            mockConsole.Stub(e => e.ReadLine()).Return("do a little dance");
            mockConsole.Stub(e => e.ReadLine()).Return("make a little love");
            mockConsole.Stub(e => e.ReadLine()).Return("get down tonight").Repeat.Times(2);
            mockConsole.Stub(e => e.ReadLine()).Return("exit");
            var cmd1 = MockRepository.GenerateMock<ICommand>();
            var cmd2 = MockRepository.GenerateMock<ICommand>();
            var engine = new GameEngine(mockConsole, new[] { cmd1, cmd2 });

            // Act
            engine.Run();

            // Assert
            cmd1.AssertWasCalled(e => e.IsValid(Arg<string>.Is.Anything), mo => mo.Repeat.Times(5));
            cmd2.AssertWasCalled(e => e.IsValid(Arg<string>.Is.Anything), mo => mo.Repeat.Times(5));
        }
    }
}

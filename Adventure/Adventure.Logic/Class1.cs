using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Logic
{

    public interface IConsoleFacade
    {
        void Write(string value);
        void WriteLine(string value);
        string ReadLine();
    }
    public interface ICommand
    {
        bool IsValid(string input);
        void Execute(string input);
    }

    public class GameEngine
    {
        private IConsoleFacade console;
        private ICommand command;

        public GameEngine(IConsoleFacade console, ICommand command)
        {
            this.console = console;
            this.command = command;
        }

        public void Run()
        {
            while (true)
            {
                console.Write(">> ");
                var input = console.ReadLine();
                if (input == "exit") break;
                if (command.IsValid(input)) command.Execute(input);
                else console.WriteLine(input);
            }
        }
    }
}

using Adventure.Logic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Logic
{
    public class GameEngine
    {
        private readonly IConsoleFacade console;
        private readonly ICommand command;

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

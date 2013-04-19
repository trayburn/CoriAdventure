using Adventure.Logic;
using Adventure.Logic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Logic.Commands
{
    public class DanceCommand : ICommand
    {
        private IConsoleFacade console;

        public DanceCommand(IConsoleFacade console)
        {
            this.console = console;
        }

        public bool IsValid(string input)
        {
            return input == "dance";
        }

        public void Execute(string input)
        {
            console.WriteLine("You dance around like a fool");
        }
    }
}

using Adventure.Logic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Register(
                Component.For<IConsoleFacade>().ImplementedBy<ConsoleFacade>(),
                Component.For<ICommand>().ImplementedBy<DanceCommand>(),
                Component.For<GameEngine>()
                );



            var engine = container.Resolve<GameEngine>();
            engine.Run();
        }
    }


    public class ConsoleFacade : IConsoleFacade
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }




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

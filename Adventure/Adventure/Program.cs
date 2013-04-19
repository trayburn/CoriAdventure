using Adventure.Logic;
using Adventure.Logic.Abstractions;
using Adventure.Logic.Commands;
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
}

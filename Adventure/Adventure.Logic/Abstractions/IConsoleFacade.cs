using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Logic.Abstractions
{
    public interface IConsoleFacade
    {
        void Write(string value);
        void WriteLine(string value);
        string ReadLine();
    }
}

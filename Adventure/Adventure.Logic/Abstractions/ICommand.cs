using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Logic.Abstractions
{
    public interface ICommand
    {
        bool IsValid(string input);
        void Execute(string input);
    }
}

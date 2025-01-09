using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.CommandsInterface;

namespace Lab2.Commands
{
    public class SetColorCommand : ICommandsWithArgs
    {
        public void Execute(Turtle turtle, string arg)
        {
            turtle.SetColor(arg);

        }
    }
}

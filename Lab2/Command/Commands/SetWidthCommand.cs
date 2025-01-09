using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.CommandsInterface;
using Lab1.TurtleObject;

namespace Lab1.Commands
{
    public class SetWidthCommand : ICommandsWithArgs
    {
        public void Execute(Turtle turtle, string arg)
        {
            turtle.SetWidth(double.Parse(arg));

        }
        
    }
}

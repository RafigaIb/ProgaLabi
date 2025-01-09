using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3;
using Lab3.CommandsInterface;

namespace Lab3.Commands
{
    public class AngleCommand : ICommandsWithArgs
    {
        public void Execute(Turtle turtle, string str)
        {

            turtle.SetAngle(int.Parse(str));

        }
        
    }
}

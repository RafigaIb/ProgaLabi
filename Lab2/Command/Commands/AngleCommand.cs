using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.CommandsInterface;
using Lab2;

namespace Lab2.Commands
{
    public class AngleCommand : ICommandsWithArgs
    {
        public void Execute(Turtle turtle, string str)
        {

            turtle.SetAngle(int.Parse(str));

        }
        
    }
}

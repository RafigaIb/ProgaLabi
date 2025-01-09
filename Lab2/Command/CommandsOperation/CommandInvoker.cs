
using Lab2.CommandsInterface;

namespace Lab2.CommandsOperation
{
    public class CommandInvoker
    {

        private Turtle turtle;

        public CommandInvoker(Turtle turtle)
        {
            this.turtle = turtle;
        }

        public void Invoke(ICommandsWithoutArgs comm)
        {
            comm.Execute(turtle);
        }

        public void Invoke(ICommandsWithArgs comm, string arg)
        {
            comm.Execute(turtle, arg);
        }
    }
}
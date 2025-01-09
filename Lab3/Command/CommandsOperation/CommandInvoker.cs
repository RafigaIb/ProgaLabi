using Lab3.CommandsInterface;

namespace Lab3.CommandsOperation
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
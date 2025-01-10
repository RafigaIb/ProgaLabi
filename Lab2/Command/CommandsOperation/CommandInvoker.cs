using Lab2.CommandsInterface;

namespace Lab2.CommandsOperation
{
    // Класс для вызова команд
    public class CommandInvoker
    {
        private Turtle turtle; // Объект черепашки, для которой будут выполняться команды

        // Конструктор принимает объект черепашки
        public CommandInvoker(Turtle turtle)
        {
            this.turtle = turtle;
        }

        // Метод для выполнения команд без аргументов
        public void Invoke(ICommandsWithoutArgs comm)
        {
            comm.Execute(turtle); // Выполняем команду, передав черепашку
        }

        // Метод для выполнения команд с аргументами
        public void Invoke(ICommandsWithArgs comm, string arg)
        {
            comm.Execute(turtle, arg); // Выполняем команду с аргументом
        }
    }
}
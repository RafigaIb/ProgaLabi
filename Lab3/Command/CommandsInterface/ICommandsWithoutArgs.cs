using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.CommandsInterface
{
    // Интерфейс для команд, которые не принимают аргументов
    public interface ICommandsWithoutArgs : ICommands
    {
        // Метод для выполнения команды без аргументов
        public void Execute(Turtle turtle);
    }
}

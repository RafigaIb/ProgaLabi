using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.CommandsInterface
{
    // Интерфейс для команд, которые принимают аргументы
    public interface ICommandsWithArgs : ICommands
    {
        // Метод для выполнения команды с аргументом
        // Аргумент может быть строкой (например, число или цвет), по умолчанию null
        void Execute(Turtle turtle, string arg = null);
    
    }
}

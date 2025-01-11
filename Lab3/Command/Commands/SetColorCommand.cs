using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.CommandsInterface;

namespace Lab3.Commands
{
    // Команда для установки цвета черепашки
    public class SetColorCommand : ICommandsWithArgs
    {
        // Метод Execute изменяет цвет черепашки на указанный в аргументе
        public void Execute(Turtle turtle, string arg)
        {
            // Устанавливаем цвет черепашки в значение, переданное в аргументе команды
            turtle.SetColor(arg);

        }
    }
}

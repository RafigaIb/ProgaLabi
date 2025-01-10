using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.CommandsInterface;

namespace Lab2.Commands
{
    // Команда для установки ширины пера черепашки
    public class SetWidthCommand : ICommandsWithArgs
    {
        // Метод Execute изменяет ширину пера черепашки на указанную в аргументе
        public void Execute(Turtle turtle, string arg)
        {
            // Устанавливаем ширину пера черепашки, преобразуя аргумент в тип double
            turtle.SetWidth(double.Parse(arg));
        }
    }
}
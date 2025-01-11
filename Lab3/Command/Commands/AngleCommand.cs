using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3;
using Lab3.CommandsInterface;

namespace Lab3.Commands
{
    // Команда для изменения угла наклона черепашки
    public class AngleCommand : ICommandsWithArgs
    {
        // Метод Execute изменяет угол наклона черепашки, используя переданный параметр
        public void Execute(Turtle turtle, string str)
        {
            // Преобразует строковое значение аргумента в целое число и устанавливает угол наклона
            turtle.SetAngle(int.Parse(str));

        }
        
    }
}

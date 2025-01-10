using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.CommandsInterface;

namespace Lab2.Commands
{
    // Команда для перемещения черепашки на заданное расстояние
    public class MoveCommand : ICommandsWithArgs
    {
        // Метод Execute перемещает черепашку в соответствии с переданным аргументом
        // str — это строковое представление расстояния для перемещения
        public void Execute(Turtle turtle, string str)
        {
            // Преобразуем строку в число (расстояние)
            double distance = double.Parse(str);

            // Вычисляем новые координаты для X и Y, используя угол черепашки
            turtle.SetCoordx(distance * Math.Sin(turtle.GetAngle() * (Math.PI / 180)));

            turtle.SetCoordY(distance * Math.Cos(turtle.GetAngle() * (Math.PI / 180)));
        }
    }
}
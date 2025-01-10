using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.CommandsInterface;

namespace Lab2.Commands
{
    // Команда для поднятия пера черепашки
    public class PenUpCommand : ICommandsWithoutArgs
    {
        // Метод Execute изменяет состояние пера на "поднято"
        public void Execute(Turtle turtle)
        {
            // Устанавливаем состояние пера на "поднято", что означает, что черепашка не будет рисовать.
            turtle.SetPenCondition(false);
        }
    }
}
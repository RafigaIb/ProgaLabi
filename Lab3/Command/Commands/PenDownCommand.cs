using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.CommandsInterface;

namespace Lab3.Commands
{
    // Команда для опускания пера черепашки
    public class PenDownCommand : ICommandsWithoutArgs
    {
        // Метод Execute изменяет состояние пера на "опущено"
        public void Execute(Turtle turtle)
        {
            // Устанавливаем состояние пера на "опущено"
            turtle.SetPenCondition(true);

        }
    }
}

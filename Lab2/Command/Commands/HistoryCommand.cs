using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.CommandsInterface;
using Lab2.DataBase;

namespace Lab2.Commands
{
    // Команда для отображения истории команд из базы данных
    public class HistoryCommand : ICommandsWithoutArgs
    {
        // Чтение данных из базы данных с помощью DataBaseReader
        private DataBaseReader dbReader;

        // Конструктор, инициализирует объект DataBaseReader для получения команд из базы
        public HistoryCommand(DataBaseReader reader)
        {
            dbReader = reader;
        }

        // Метод Execute выводит все команды из истории
        public void Execute(Turtle turtle)
        {
            // Получаем все команды из базы данных и выводим их в консоль
            Console.WriteLine(dbReader.GetCommands());
        }
    }
}
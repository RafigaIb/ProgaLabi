using Lab3.CommandsInterface;
using Lab3.DataBase;
using System;
using System.Threading.Tasks;

namespace Lab3.Commands
{
    // Команда для отображения истории команд из базы данных
    public class HistoryCommand : ICommandsWithoutArgs
    {
        // Чтение данных из базы данных с помощью DataBaseReader
        private IDataBaseReader dbReader;
        // Конструктор, инициализирует объект DataBaseReader для получения команд из базы
        public HistoryCommand(IDataBaseReader reader)
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
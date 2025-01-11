using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Storage;
using Lab3.CommandsInterface;
using Lab3.DataBase;

namespace Lab3.Commands
{
    // Команда для отображения всех фигур, нарисованных черепашкой
    public class ListFiguresCommand : ICommandsWithoutArgs
    {
        // Чтение данных из базы данных с помощью DataBaseReader
        private IDataBaseReader dbReader;
        
        // Конструктор, инициализирует объект DataBaseReader для получения фигур из базы данных
        public ListFiguresCommand(IDataBaseReader reader)
        {
            dbReader = reader;
        }
        
        // Метод Execute выводит все фигуры, которые были нарисованы
        public void Execute(Turtle turtle)
        {
            // Получаем все фигуры из базы данных и выводим их в консоль
            Console.WriteLine(dbReader.GetFigures());
        }
    }
}
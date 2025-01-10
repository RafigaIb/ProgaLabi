using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.CommandsInterface;
using Lab2.DataBase;
using Lab2.Storage;

namespace Lab2.Commands
{
    // Команда для отображения всех фигур, нарисованных черепашкой
    public class ListFiguresCommand : ICommandsWithoutArgs
    {
        // Чтение данных из базы данных с помощью DataBaseReader
        private DataBaseReader dbReader;

        // Конструктор, инициализирует объект DataBaseReader для получения фигур из базы данных
        public ListFiguresCommand(DataBaseReader reader)
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
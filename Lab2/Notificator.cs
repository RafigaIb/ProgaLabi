using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.DataBase;  // Использование класса для работы с базой данных
using Lab2.Storage;  // Использование классов для работы с хранилищем данных

namespace Lab2.ScreenNotificator
{
    public class Notificator
    {
        // Чтение из базы данных
        private DataBaseReader dbReader;
        // Статус черепашки (состояние)
        private TurtleStatus? turtleStatus;

        // Конструктор, инициализирующий объект для чтения из базы данных
        public Notificator(DataBaseReader reader)
        {
            dbReader = reader;  // Присваиваем переданный объект для чтения данных
        }

        // Метод отправки уведомлений в зависимости от команды
        public async Task SendNotification(string command)
        {
            // Если команда - история
            if (command == "history")
            {
                // Получаем все команды из базы данных
                var commands = await dbReader.GetCommands();
                // Выводим каждую команду
                foreach (var comm in commands)
                {
                    Console.WriteLine("· " + comm.CommandText);
                }
            }
            // Если команда - список фигур
            else if (command == "listfigures")
            {
                // Получаем все фигуры из базы данных
                var figures = await dbReader.GetFigures();
                // Если список фигур пуст
                if (figures.Count == 0)
                {
                    Console.WriteLine("empty...");  // Выводим "пусто"
                }
                // Выводим каждую фигуру
                foreach (var figure in figures)
                {
                    Console.WriteLine("· " + figure.FigureType + " " + figure.Parameters);
                }
            }
            // Если это не команды "history" или "listfigures"
            else
            {
                // Получаем текущий статус черепашки
                var turtleStatus = await dbReader.GetTurtleStatus();
                // Если статус черепашки не равен null
                if (turtleStatus != null)
                {
                    // Выводим информацию о состоянии черепашки
                    Console.WriteLine("состояние: " +
                                      "pos: (" + Math.Round(turtleStatus.Xcoors, 2) +
                                      "; " + Math.Round(turtleStatus.Ycoors, 2) + ")" +  // Координаты
                                      ", pen: " + turtleStatus.PenCondition +  // Состояние пера
                                      ", angle: " + turtleStatus.Angle +  // Угол
                                      ", color: " + turtleStatus.Color +  // Цвет
                                      ", width: " + turtleStatus.Width);  // Ширина линии
                }
            }
        }
    }
}

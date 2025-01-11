using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Storage;
using Lab3.DataBase;
using Lab3.Models;

namespace Lab3.ScreenNotificator
{
    // Класс для отправки уведомлений и получения данных о состоянии черепахи, фигурах и истории команд
    public class Notificator
    {
        private IDataBaseReader dbReader; // Интерфейс для чтения данных из базы данных
        private TurtleStatus? turtleStatus; // Переменная для хранения текущего состояния черепахи

        // Конструктор, который принимает объект для чтения данных из базы
        public Notificator(IDataBaseReader reader)
        {
            dbReader = reader;
        }

        // Метод для отправки уведомления в консоль в зависимости от команды
        public async Task SendNotification(string command)
        {
            // Обработка команды "history", выводит историю команд
            if (command == "history")
            {
                var commands = await dbReader.GetCommands(); // Получаем все команды из базы
                foreach (var comm in commands)
                {
                    Console.WriteLine("· " + comm.CommandText); // Выводим каждую команду
                }
            }
            // Обработка команды "listfigures", выводит список фигур
            else if (command == "listfigures")
            {
                var figures = await dbReader.GetFigures(); // Получаем все фигуры из базы
                if (figures.Count == 0)
                {
                    Console.WriteLine("empty..."); // Если фигур нет, выводим "empty..."
                }
                foreach (var figure in figures)
                {
                    Console.WriteLine("· " + figure.FigureType + " " + figure.Parameters); // Выводим тип фигуры и параметры
                }
            }
            // Обработка других команд, выводит текущее состояние черепахи
            else
            {
                var turtleStatus = await dbReader.GetTurtleStatus(); // Получаем статус черепахи из базы
                if (turtleStatus != null)
                {
                    Console.WriteLine("состояние: " +
                                      "pos: (" + Math.Round(turtleStatus.Xcoors, 2) + // Позиция X
                                      "; " + Math.Round(turtleStatus.Ycoors, 2) + ")" + // Позиция Y
                                      ", pen: " + turtleStatus.PenCondition + // Состояние пера
                                      ", angle: " + turtleStatus.Angle + // Угол поворота
                                      ", color: " + turtleStatus.Color + // Цвет пера
                                      ", width: " + turtleStatus.Width); // Ширина пера
                }
            }
        }

        // Метод для получения данных по команде в виде списка строк
        public async Task<List<string>> GetNotification(string command)
        {
            List<string> result = new List<string>(); // Список для хранения результатов
            // Обработка команды "history", возвращает список всех команд
            if (command == "history")
            {
                var commands = await dbReader.GetCommands(); // Получаем историю команд из базы
                foreach (var comm in commands)
                {
                    result.Add(comm.CommandText); // Добавляем текст каждой команды в результат
                }
            }
            // Обработка команды "listfigures", возвращает список фигур
            else if (command == "listfigures")
            {
                var figures = await dbReader.GetFigures(); // Получаем все фигуры из базы
                if (figures.Count == 0)
                {
                    return null; // Если фигур нет, возвращаем null
                }
                foreach (var figure in figures)
                {
                    result.Add(figure.FigureType + " " + figure.Parameters); // Добавляем тип и параметры фигуры в результат
                }
            }
            // Обработка других команд, возвращает текущее состояние черепахи
            else
            {
                var turtleStatus = await dbReader.GetTurtleStatus(); // Получаем статус черепахи
                if (turtleStatus != null)
                {
                    result.Add(Math.Round(turtleStatus.Xcoors, 2).ToString()); // Добавляем координату X
                    result.Add(Math.Round(turtleStatus.Ycoors, 2).ToString()); // Добавляем координату Y
                    result.Add(turtleStatus.PenCondition); // Добавляем состояние пера
                    result.Add(turtleStatus.Angle.ToString()); // Добавляем угол поворота
                    result.Add(turtleStatus.Color); // Добавляем цвет пера
                    result.Add(turtleStatus.Width.ToString()); // Добавляем ширину пера
                }
            }

            return result; // Возвращаем список данных
        }
    }
}

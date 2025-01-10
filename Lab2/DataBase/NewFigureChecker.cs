using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.DataBase;
using Microsoft.EntityFrameworkCore;
namespace Lab2.Storage
{
    // Класс для проверки, образована ли новая фигура при движении черепашки.
    // Если фигура завершена, ее координаты сохраняются в базу данных.
    public class NewFigureChecker
    {
        private Turtle turtle;  // Объект черепашки, который используется для получения текущего состояния
        private double lastX;   // Хранение предыдущей координаты X черепашки
        private double lastY;   // Хранение предыдущей координаты Y черепашки
        private string figure;  // Тип фигуры, если она завершена
        private IDataBaseWriter dbWriter;  // Интерфейс для записи данных в базу данных
        private IDataBaseReader dbReader;  // Интерфейс для чтения данных из базы данных
        private string param;  // Параметры фигуры
        private int rowCount;  // Количество записей в таблице координат
        private TurtleStatus firstRow;  // Первая запись в таблице TurtleStatus
        private TurtleStatus lastRow;   // Последняя запись в таблице TurtleStatus

        // Конструктор класса, принимающий объекты для черепашки и для записи/чтения данных из базы данных
        public NewFigureChecker(Turtle turtle, IDataBaseWriter writer, IDataBaseReader reader)
        {
            this.turtle = turtle;
            lastX = 0;  // Инициализация координат
            lastY = 0;
            dbWriter = writer;
            dbReader = reader;
        }

        // Метод для проверки, образована ли новая фигура
        public async Task Check()
        {
            // Получаем текущий статус черепашки из базы данных
            var turtleStatus = await dbReader.GetTurtleStatus();
            if (turtleStatus?.PenCondition == "penDown") // Если перо опущено
            {
                // Проверяем текущие координаты черепашки
                var latestStatus = await dbReader.GetTurtleStatus();
                if (latestStatus != null && 
                    (lastX != latestStatus.Xcoors || lastY != latestStatus.Ycoors))
                {
                    // Сохраняем новые координаты черепашки
                    await dbWriter.SaveTurtleCoords(turtle); 
                    
                    // Читаем последние координаты из базы данных
                    var lastCoords = await dbReader.GetTurtleCoords();
                    if (lastCoords != null)
                    {
                        lastX = lastCoords.xCoord;
                        lastY = lastCoords.yCoord;
                    }

                    // Получаем количество записей в таблице координат
                    using (var context = new TurtleContext())
                    {
                        rowCount = await context.TurtleCoords.CountAsync();
                    }
                    
                    // Получаем первую и последнюю записи в таблице TurtleStatus
                    using (var context = new TurtleContext())
                    {
                        firstRow = await context.TurtleStatus.OrderBy(t => t.Id).FirstOrDefaultAsync();
                        lastRow = await context.TurtleStatus.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
                    }
                    
                    // Определяем, завершена ли фигура (если количество точек > 2 и начальная координата совпадает с последней)
                    if (rowCount > 2 && 
                        firstRow != null && lastRow != null &&
                        (firstRow.Xcoors == lastRow.Xcoors && firstRow.Ycoors == lastRow.Ycoors))
                    {
                        // Определяем тип фигуры по количеству точек
                        switch (rowCount - 1)
                        {
                            case 3:
                                figure = "треугольник";
                                break;
                            case 4:
                                figure = "квадрат";
                                break;
                            case 5:
                                figure = "пятиугольник";
                                break;
                            case 6:
                                figure = "шестиугольник";
                                break;
                            case 7:
                                figure = "семиугольник";
                                break;
                        }

                        // Выводим сообщение об образованной фигуре
                        Console.Write("Образована новая фигура: " + figure);
                        Console.WriteLine();

                        // Получаем строку с координатами для сохранения
                        param = await CoordArrayToString();
                        if (dbWriter != null)
                        {
                            // Сохраняем фигуру в базу данных
                            await dbWriter.SaveFigure(figure, param);
                        }

                        // Очищаем таблицу координат
                        await ClearTurtleCoords();
                    }
                }
            }
            else
            {
                // Если перо не опущено, очищаем таблицу координат
                await ClearTurtleCoords();
            }
        }
        
        // Метод для преобразования всех координат черепашки в строку
        private async Task<string> CoordArrayToString()
        {
            using (var context = new TurtleContext())
            {
                // Получаем все координаты из таблицы TurtleCoords
                var allRows = await context.TurtleCoords.ToListAsync();
                var result = new StringBuilder();

                // Формируем строку с координатами
                foreach (var row in allRows)
                {
                    result.Append($"({row.xCoord}; {row.yCoord})");
                }

                // Возвращаем строку с координатами
                return result.ToString();
            }
        }

        // Метод для очистки таблицы координат
        private async Task ClearTurtleCoords() 
        {
            using (var context = new TurtleContext())
            {
                // Удаляем все записи в таблице TurtleCoords
                context.TurtleCoords.RemoveRange(context.TurtleCoords);
                // Сохраняем изменения в базе данных
                await context.SaveChangesAsync();
            }
        }
    }
}

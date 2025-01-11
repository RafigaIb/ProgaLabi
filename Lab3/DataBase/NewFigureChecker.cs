using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.DataBase;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Storage
{
    // Класс для проверки, образована ли новая фигура черепахой
    public class NewFigureChecker
    {
        private Turtle turtle; // Объект черепахи
        private double lastX; // Последняя координата X
        private double lastY; // Последняя координата Y
        private string figure; // Тип фигуры, которая будет образована
        private IDataBaseWriter dbWriter; // Для записи данных в базу данных
        private IDataBaseReader dbReader; // Для чтения данных из базы данных
        private string param; // Параметры фигуры в виде строки
        private int rowCount; // Количество записей в таблице координат черепахи
        private TurtleStatus firstRow; // Первая запись в таблице TurtleStatus
        private TurtleStatus lastRow; // Последняя запись в таблице TurtleStatus

        // Конструктор, который принимает черепаху, объект для записи и объект для чтения данных из базы
        public NewFigureChecker(Turtle turtle, IDataBaseWriter writer, IDataBaseReader reader)
        {
            this.turtle = turtle;
            lastX = 0;
            lastY = 0;
            dbWriter = writer;
            dbReader = reader;
        }

        // Метод для проверки, образована ли новая фигура
        public async Task Check()
        {
            // Чтение текущего статуса черепахи
            var turtleStatus = await dbReader.GetTurtleStatus();

            // Если перо черепахи опущено (penDown), продолжаем проверку
            if (turtleStatus?.PenCondition == "penDown")
            {
                // Чтение последнего статуса черепахи
                var latestStatus = await dbReader.GetTurtleStatus();
                
                // Если координаты изменились, сохраняем новые координаты
                if (latestStatus != null && 
                    (lastX != latestStatus.Xcoors || lastY != latestStatus.Ycoors))
                {
                    await dbWriter.SaveTurtleCoords(turtle);
                    
                    // Обновление последних координат
                    var lastCoords = await dbReader.GetTurtleCoords();
                    if (lastCoords != null)
                    {
                        lastX = lastCoords.xCoord;
                        lastY = lastCoords.yCoord;
                    }

                    // Подсчёт количества записей в таблице координат
                    using (var context = new TurtleContext())
                    {
                        rowCount = await context.TurtleCoords.CountAsync();
                    }
                    
                    // Чтение первой и последней записи из таблицы статусов черепахи
                    using (var context = new TurtleContext())
                    {
                        firstRow = await context.TurtleStatus.OrderBy(t => t.Id).FirstOrDefaultAsync();
                        lastRow = await context.TurtleStatus.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
                    }

                    // Проверка, образована ли фигура (если количество точек > 2 и первые и последние координаты совпадают)
                    if (rowCount > 2 && 
                        firstRow != null && lastRow != null &&
                        (firstRow.Xcoors == lastRow.Xcoors && firstRow.Ycoors == lastRow.Ycoors))
                    {
                        // Определение типа фигуры по количеству точек
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

                        // Вывод сообщения о том, что фигура образована
                        Console.Write("Образована новая фигура: " + figure);
                        Console.WriteLine();

                        // Получаем строковое представление координат
                        param = await CoordArrayToString();

                        // Сохраняем информацию о фигуре в базу данных
                        if (dbWriter != null)
                        {
                            await dbWriter.SaveFigure(figure, param);
                        }
                        
                        // Очищаем таблицу координат после сохранения фигуры
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

        // Метод для преобразования координат в строковое представление
        private async Task<string> CoordArrayToString()
        {
            using (var context = new TurtleContext())
            {
                // Получаем все записи координат черепахи
                var allRows = await context.TurtleCoords.ToListAsync();
                var result = new StringBuilder();

                // Строим строку с координатами
                foreach (var row in allRows)
                {
                    result.Append($"({row.xCoord}; {row.yCoord})");
                }
                
                return result.ToString(); // Возвращаем строку с координатами
            }
        }

        // Метод для очистки таблицы координат
        private async Task ClearTurtleCoords()
        {
            using (var context = new TurtleContext())
            {
                // Удаляем все записи из таблицы координат
                context.TurtleCoords.RemoveRange(context.TurtleCoords);
                await context.SaveChangesAsync(); // Сохраняем изменения в базе данных
            }
        }
    }
}

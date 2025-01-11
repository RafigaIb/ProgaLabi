using Lab3.Models;
using Lab3.Storage;

namespace Lab3.DataBase;

// Класс для записи данных в базу данных
public class DataBaseWriter: IDataBaseWriter
{
    // Метод для сохранения текущего состояния черепахи в таблицу "TurtleStatus"
    public async Task SaveTurtleStatus(Turtle turtle)
    {
        using (var context = new TurtleContext()) // Создаем новый контекст для работы с БД
        {
            var turtleStatus = new TurtleStatus
            {
                Xcoors = turtle.GetCoordX(),       // Координата X
                Ycoors = turtle.GetCoordY(),       // Координата Y
                Angle = turtle.GetAngle(),         // Угол поворота
                Color = turtle.GetColor(),         // Цвет пера
                PenCondition = turtle.GetPenCondition(), // Состояние пера (поднято/опущено)
                Width = turtle.GetWidth()          // Ширина линии
            };
            
            context.TurtleStatus.Add(turtleStatus); // Добавляем запись в таблицу TurtleStatus
            await context.SaveChangesAsync();       // Сохраняем изменения в базе данных
        }
    }

    // Метод для сохранения координат черепахи в таблицу "TurtleCoords"
    public async Task SaveTurtleCoords(Turtle turtle)
    {
        using (var context = new TurtleContext())
        {
            var turtleCoords = new TurtleCoords
            {
                xCoord = turtle.GetCoordX(),       // Координата X
                yCoord = turtle.GetCoordY()        // Координата Y
            };
            
            context.TurtleCoords.Add(turtleCoords); // Добавляем запись в таблицу TurtleCoords
            await context.SaveChangesAsync();       // Сохраняем изменения
        }
    }
    
    // Метод для сохранения команды в таблицу "CommandHistory"
    public async Task SaveCommand(string commandText)
    {
        using (var context = new TurtleContext())  
        {
            var command = new CommandHistory
            {
                CommandText = commandText, // Сохраняем текст команды
            };

            context.CommandHistory.Add(command);    // Добавляем запись в таблицу CommandHistory
            await context.SaveChangesAsync();       // Сохраняем изменения в базе данных
        }
    }
    
    // Метод для сохранения информации о фигуре в таблицу "Figure"
    public async Task SaveFigure(string figureType, string parameters)
    {
        using (var context = new TurtleContext())
        {
            var figure = new Figure
            {
                FigureType = figureType,   // Тип фигуры (например, "треугольник")
                Parameters = parameters,   // Параметры фигуры (например, координаты)
            };

            context.Figure.Add(figure);   // Добавляем запись в таблицу Figure
            await context.SaveChangesAsync(); // Сохраняем изменения в базе данных
        }
    }
}

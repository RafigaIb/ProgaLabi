using Lab2.Storage;

namespace Lab2.DataBase
{
    // Класс для сохранения данных в базу данных
    public class DataBaseWriter : IDataBaseWriter
    {
        // Метод для сохранения статуса черепашки в таблицу "TurtleStatus"
        public async Task SaveTurtleStatus(Turtle turtle)
        {
            using (var context = new TurtleContext())
            {
                // Создание объекта TurtleStatus на основе данных черепашки
                var turtleStatus = new TurtleStatus
                {
                    Xcoors = turtle.GetCoordX(),
                    Ycoors = turtle.GetCoordY(),
                    Angle = turtle.GetAngle(),
                    Color = turtle.GetColor(),
                    PenCondition = turtle.GetPenCondition(),
                    Width = turtle.GetWidth()
                };
                
                // Добавление нового статуса черепашки в таблицу TurtleStatus
                context.TurtleStatus.Add(turtleStatus);
                await context.SaveChangesAsync();  // Сохранение изменений в базе данных
            }
        }

        // Метод для сохранения координат черепашки в таблицу "TurtleCoords"
        public async Task SaveTurtleCoords(Turtle turtle)
        {
            using (var context = new TurtleContext())
            {
                // Создание объекта TurtleCoords для хранения координат черепашки
                var turtleCoords = new TurtleCoords
                {
                    xCoord = turtle.GetCoordX(),
                    yCoord = turtle.GetCoordY()
                };
                
                // Добавление координат в таблицу TurtleCoords
                context.TurtleCoords.Add(turtleCoords);
                await context.SaveChangesAsync();  // Сохранение изменений в базе данных
            }
        }
        
        // Метод для сохранения команды в таблицу "CommandList"
        public async Task SaveCommand(string commandText)
        {
            using (var context = new TurtleContext())
            {
                // Создание объекта CommandHistory для хранения текста команды
                var command = new CommandHistory
                {
                    CommandText = commandText,
                };

                // Добавление команды в таблицу CommandHistory
                context.CommandHistory.Add(command);
                await context.SaveChangesAsync();  // Сохранение изменений в базе данных
            }
        }
        
        // Метод для сохранения фигуры в таблицу "Figure"
        public async Task SaveFigure(string figureType, string parameters)
        {
            using (var context = new TurtleContext())
            {
                // Создание объекта Figure для хранения данных о фигуре
                var figure = new Figure
                {
                    FigureType = figureType,
                    Parameters = parameters,
                };

                // Добавление фигуры в таблицу Figure
                context.Figure.Add(figure);
                await context.SaveChangesAsync();  // Сохранение изменений в базе данных
            }
        }
    }
}

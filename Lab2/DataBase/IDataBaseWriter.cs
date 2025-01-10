namespace Lab2.DataBase
{
    // Интерфейс для записи данных в базу данных
    public interface IDataBaseWriter
    {
        // Метод для сохранения команды в таблице CommandHistory
        public Task SaveCommand(string commandText);

        // Метод для сохранения информации о нарисованной фигуре в таблице Figure
        public Task SaveFigure(string figureType, string parameters);

        // Метод для сохранения координат черепашки в таблице TurtleCoords
        public Task SaveTurtleCoords(Turtle turtle);
    }
}
namespace Lab3.DataBase;

public interface IDataBaseWriter
{
    // Метод для сохранения команды в таблицу CommandHistory
    public Task SaveCommand(string commandText);
    
    // Метод для сохранения фигуры в таблицу Figure
    public Task SaveFigure(string figureType, string parameters);
    
    // Метод для сохранения координат черепахи в таблицу TurtleCoords
    public Task SaveTurtleCoords(Turtle turtle);
    
    // Метод для сохранения статуса черепахи в таблицу TurtleStatus
    public Task SaveTurtleStatus(Turtle turtle);
}
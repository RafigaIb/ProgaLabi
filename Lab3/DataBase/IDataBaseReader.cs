using Lab3.DataBase;
using Lab3.Models;

// Интерфейс для чтения данных из базы данных
public interface IDataBaseReader
{
    // Метод для получения последнего состояния черепахи из таблицы TurtleStatus
    public Task<TurtleStatus?> GetTurtleStatus();
    
    // Метод для получения последних координат черепахи из таблицы TurtleCoords
    public Task<TurtleCoords?> GetTurtleCoords();
    
    // Метод для получения списка всех команд из таблицы CommandHistory
    public Task<List<CommandHistory>> GetCommands();
    
    // Метод для получения списка всех фигур из таблицы Figure
    public Task<List<Figure>> GetFigures();
}
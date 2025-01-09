


using Lab3.DataBase;
using Lab3.Models;

public interface IDataBaseReader
{
    public Task<TurtleStatus?> GetTurtleStatus();
    
    public Task<TurtleCoords?> GetTurtleCoords();
    
    public Task<List<CommandHistory>> GetCommands();
    
    public Task<List<Figure>> GetFigures();
}


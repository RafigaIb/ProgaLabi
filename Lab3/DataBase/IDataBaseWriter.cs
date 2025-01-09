
namespace Lab3.DataBase;

public interface IDataBaseWriter
{
    public Task SaveCommand(string commandText);
    
    public Task SaveFigure(string figureType, string parameters);
    public Task SaveTurtleCoords(Turtle turtle);
    
    public Task SaveTurtleStatus(Turtle turtle);

}
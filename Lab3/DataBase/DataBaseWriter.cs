using Lab3.Models;
using Lab3.Storage;

namespace Lab3.DataBase;

// Класс для записи данных в базу данных
public class DataBaseWriter : IDataBaseWriter
{
    private readonly TurtleContext _context;

    public DataBaseWriter(TurtleContext context)
    {
        _context = context;
    }

    public async Task SaveTurtleStatus(Turtle turtle)
    {
        var turtleStatus = new TurtleStatus
        {
            Xcoors = turtle.GetCoordX(),
            Ycoors = turtle.GetCoordY(),
            Angle = turtle.GetAngle(),
            Color = turtle.GetColor(),
            PenCondition = turtle.GetPenCondition(),
            Width = turtle.GetWidth()
        };

        _context.TurtleStatus.Add(turtleStatus);
        await _context.SaveChangesAsync();
    }

    public async Task SaveTurtleCoords(Turtle turtle)
    {
        var turtleCoords = new TurtleCoords
        {
            xCoord = turtle.GetCoordX(),
            yCoord = turtle.GetCoordY()
        };

        _context.TurtleCoords.Add(turtleCoords);
        await _context.SaveChangesAsync();
    }

    public async Task SaveCommand(string commandText)
    {
        var command = new CommandHistory
        {
            CommandText = commandText
        };

        _context.CommandHistory.Add(command);
        await _context.SaveChangesAsync();
    }

    public async Task SaveFigure(string figureType, string parameters)
    {
        var figure = new Figure
        {
            FigureType = figureType,
            Parameters = parameters
        };

        _context.Figure.Add(figure);
        await _context.SaveChangesAsync();
    }
}
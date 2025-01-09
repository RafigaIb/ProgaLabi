// DataBaseReader.cs
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.DataBase;

public class DataBaseReader : IDataBaseReader
{
    private readonly TurtleContext context;

    public DataBaseReader(TurtleContext context)
    {
        this.context = context;
    }

    public async Task<TurtleStatus?> GetTurtleStatus()
    {
        return await context.TurtleStatus.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
    }

    public async Task<TurtleCoords?> GetTurtleCoords()
    {
        return await context.TurtleCoords.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
    }

    public async Task<List<CommandHistory>> GetCommands()
    {
        return await context.CommandHistory.ToListAsync();
    }

    public async Task<List<Figure>> GetFigures()
    {
        return await context.Figure.ToListAsync();
    }
}
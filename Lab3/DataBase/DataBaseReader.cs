using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.DataBase;

// Класс для чтения данных из базы данных
public class DataBaseReader : IDataBaseReader
{
    private readonly TurtleContext _context;

    public DataBaseReader(TurtleContext context)
    {
        _context = context;
    }

    public async Task<TurtleStatus?> GetTurtleStatus()
    {
        return await _context.TurtleStatus.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
    }

    public async Task<TurtleCoords?> GetTurtleCoords()
    {
        return await _context.TurtleCoords.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
    }

    public async Task<List<CommandHistory>> GetCommands()
    {
        return await _context.CommandHistory.ToListAsync();
    }

    public async Task<List<Figure>> GetFigures()
    {
        return await _context.Figure.ToListAsync();
    }
}
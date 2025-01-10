
using Microsoft.EntityFrameworkCore;

namespace Lab2.DataBase;

// отвечает за извлечение данных из базы данных
public class DataBaseReader: IDataBaseReader
{
    public async Task<TurtleStatus?> GetTurtleStatus()
    {
        using (var context = new TurtleContext())
        {
            return await context.TurtleStatus.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
            // получает последний статус черепашки    
        }
    }

    public async Task<TurtleCoords?> GetTurtleCoords()
    {
        using (var context = new TurtleContext())
        {
            return await context.TurtleCoords.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
            // получает последние координаты черепашки
        }
    }
    public async Task<List<CommandHistory>> GetCommands()
    {
        using (var context = new TurtleContext())  // using гарантирует освобождение
        {
            return await context.CommandHistory.ToListAsync();
            // получает все команды из истории
        }
    }
    
    public async Task<List<Figure>> GetFigures()
    {
        using (var context = new TurtleContext())
        {
            return await context.Figure.ToListAsync();
            // получает все фигуры, которые были нарисованы
        }
    }
    
}
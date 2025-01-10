using Microsoft.EntityFrameworkCore;

namespace Lab2.DataBase
{
    // Отвечает за извлечение данных из базы данных
    public class DataBaseReader: IDataBaseReader
    {
        // Получает последний статус черепашки из базы данных
        public async Task<TurtleStatus?> GetTurtleStatus()
        {
            using (var context = new TurtleContext())
            {
                return await context.TurtleStatus.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
                // получает последний статус черепашки    
            }
        }

        // Получает последние координаты черепашки из базы данных
        public async Task<TurtleCoords?> GetTurtleCoords()
        {
            using (var context = new TurtleContext())
            {
                return await context.TurtleCoords.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
                // получает последние координаты черепашки
            }
        }

        // Получает все команды из истории команд
        public async Task<List<CommandHistory>> GetCommands()
        {
            using (var context = new TurtleContext())  // using гарантирует освобождение
            {
                return await context.CommandHistory.ToListAsync();
                // получает все команды из истории
            }
        }

        // Получает все фигуры, которые были нарисованы
        public async Task<List<Figure>> GetFigures()
        {
            using (var context = new TurtleContext())
            {
                return await context.Figure.ToListAsync();
                // получает все фигуры, которые были нарисованы
            }
        }
    }
}
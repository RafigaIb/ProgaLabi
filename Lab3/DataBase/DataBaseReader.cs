// DataBaseReader.cs
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.DataBase;

// Класс для чтения данных из базы данных
public class DataBaseReader : IDataBaseReader
{
    private readonly TurtleContext context; // Контекст базы данных, используется для взаимодействия с таблицами

    // Конструктор, инициализирующий контекст базы данных
    public DataBaseReader(TurtleContext context)
    {
        this.context = context;
    }

    // Получение последнего состояния черепахи из таблицы TurtleStatus
    public async Task<TurtleStatus?> GetTurtleStatus()
    {
        // Возвращает запись с наибольшим Id, что соответствует последнему состоянию
        return await context.TurtleStatus.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
    }

    // Получение последних координат черепахи из таблицы TurtleCoords
    public async Task<TurtleCoords?> GetTurtleCoords()
    {
        // Возвращает запись с наибольшим Id, что соответствует последним координатам
        return await context.TurtleCoords.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
    }

    // Получение всей истории команд из таблицы CommandHistory
    public async Task<List<CommandHistory>> GetCommands()
    {
        // Загружает все строки из таблицы CommandHistory
        return await context.CommandHistory.ToListAsync();
    }

    // Получение всех сохраненных фигур из таблицы Figure
    public async Task<List<Figure>> GetFigures()
    {
        // Загружает все строки из таблицы Figure
        return await context.Figure.ToListAsync();
    }
}
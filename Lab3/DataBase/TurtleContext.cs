using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.DataBase;

// Класс контекста базы данных, который используется для взаимодействия с базой данных через Entity Framework.
public class TurtleContext : DbContext
{
    // Таблицы, которые будут использоваться в базе данных.
    public DbSet<CommandList> CommandLists { get; set; } = null!; // Таблица для хранения списка команд
    public DbSet<TurtleStatus> TurtleStatus { get; set; } = null!; // Таблица для хранения статусов черепахи (позиция, угол, цвет, состояние пера)
    public DbSet<TurtleCoords> TurtleCoords { get; set; } = null!; // Таблица для хранения координат черепахи
    public DbSet<CommandHistory> CommandHistory { get; set; } = null!; // Таблица для хранения истории команд
    public DbSet<Figure> Figure { get; set; } = null!; // Таблица для хранения данных о фигурах, образованных черепахой

    // Конструктор, принимающий параметры конфигурации базы данных
    public TurtleContext(DbContextOptions<TurtleContext> options) : base(options) { }

    // Конструктор по умолчанию (используется в InitializeDatabase для инициализации базы)
    public TurtleContext() {}

    // Настройка подключения к базе данных SQLite.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Указание строки подключения к базе данных SQLite. Можно перенести строку подключения в файл конфигурации.
        optionsBuilder.UseSqlite("Data Source=my.db");
    }

    // Метод для инициализации базы данных, если она пуста
    public void InitializeDatabase()
    {
        // Используется для первоначальной настройки базы данных (например, добавление начальных данных)
        using (var context = new TurtleContext())
        {
            // Проверяем, есть ли записи в таблице TurtleStatus, если нет, добавляем начальные значения
            if (!context.TurtleStatus.Any())
            {
                var initialStatus = new TurtleStatus
                {
                    Xcoors = 0,           // Начальная координата X (черепаха начинает с позиции 0,0)
                    Ycoors = 0,           // Начальная координата Y
                    PenCondition = "down",// Начальное состояние пера (перо опущено)
                    Angle = 0,            // Начальный угол (0 градусов)
                    Color = "black",      // Начальный цвет пера
                    Width = 1             // Начальная ширина пера
                };

                context.TurtleStatus.Add(initialStatus); // Добавляем начальный статус в таблицу
            }

            // Проверяем, есть ли записи в таблице TurtleCoords, если нет, добавляем начальные координаты
            if (!context.TurtleCoords.Any())
            {
                var initialCoords = new TurtleCoords
                {
                    xCoord = 0,           // Начальная координата X
                    yCoord = 0            // Начальная координата Y
                };

                context.TurtleCoords.Add(initialCoords); // Добавляем начальные координаты в таблицу
            }

            // Сохраняем изменения в базе данных
            context.SaveChanges();
        }
    }
}

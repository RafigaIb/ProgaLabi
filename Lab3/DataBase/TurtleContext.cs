using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.DataBase;

/// <summary>
/// Контекст базы данных для взаимодействия с SQLite через Entity Framework.
/// </summary>
public class TurtleContext : DbContext
{
    // Таблицы, которые будут использоваться в базе данных.
    public DbSet<CommandList> CommandLists { get; set; } = null!; // Таблица для списка команд
    public DbSet<TurtleStatus> TurtleStatus { get; set; } = null!; // Таблица для статусов черепахи
    public DbSet<TurtleCoords> TurtleCoords { get; set; } = null!; // Таблица для координат черепахи
    public DbSet<CommandHistory> CommandHistory { get; set; } = null!; // Таблица для истории команд
    public DbSet<Figure> Figure { get; set; } = null!; // Таблица для данных о фигурах

    /// <summary>
    /// Конструктор с параметрами для конфигурации контекста.
    /// </summary>
    public TurtleContext(DbContextOptions<TurtleContext> options) : base(options) { }

    /// <summary>
    /// Конструктор по умолчанию для инициализации базы данных.
    /// </summary>
    public TurtleContext()
    {
        try
        {
            InitializeDatabase();
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// Настройка подключения к базе данных SQLite.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Используем SQLite с указанием строки подключения.
            optionsBuilder.UseSqlite("Data Source=my2.db");
        }
    }

    /// <summary>
    /// Настройка моделей через Fluent API.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Настройка таблицы CommandHistory.
        modelBuilder.Entity<CommandHistory>(entity =>
        {
            entity.HasKey(e => e.Id); // Первичный ключ
            entity.Property(e => e.CommandText)
                  .IsRequired()
                  .HasMaxLength(255); // Ограничение на длину текста команды
        });

        // Другие настройки можно добавить аналогично.
    }

    /// <summary>
    /// Метод для инициализации базы данных с начальными данными.
    /// </summary>
    public void InitializeDatabase()
    {
        // Инициализируем базу данных только если она пуста.
        if (Database.EnsureCreated())
        {
            using var context = new TurtleContext();

            // Добавляем начальный статус черепахи, если таблица пуста.
            if (!context.TurtleStatus.Any())
            {
                var initialStatus = new TurtleStatus
                {
                    Xcoors = 0,
                    Ycoors = 0,
                    PenCondition = "down",
                    Angle = 0,
                    Color = "black",
                    Width = 1
                };
                context.TurtleStatus.Add(initialStatus);
            }

            // Добавляем начальные координаты черепахи, если таблица пуста.
            if (!context.TurtleCoords.Any())
            {
                var initialCoords = new TurtleCoords
                {
                    xCoord = 0,
                    yCoord = 0
                };
                context.TurtleCoords.Add(initialCoords);
            }

            // Сохраняем изменения в базе данных.
            context.SaveChanges();
        }
    }
}

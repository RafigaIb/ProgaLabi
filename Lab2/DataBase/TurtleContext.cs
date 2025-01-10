namespace Lab2.DataBase;
using Microsoft.EntityFrameworkCore;  // Использование Entity Framework для работы с базой данных

// Класс, управляющий объектами, которые будут сохранены в базе данных (контекст базы данных).
public class TurtleContext: DbContext 
{
    // Представления таблиц в базе данных
    public DbSet<CommandList> CommandLists { get; set; } = null!;  // Таблица для списка команд
    public DbSet<TurtleStatus> TurtleStatus { get; set; } = null!;  // Таблица для хранения статуса черепашки
    public DbSet<TurtleCoords> TurtleCoords { get; set; } = null!;  // Таблица для хранения координат черепашки
    public DbSet<CommandHistory> CommandHistory { get; set; } = null!;  // Таблица для хранения истории команд
    public DbSet<Figure> Figure { get; set; } = null!;  // Таблица для хранения фигур, которые рисует черепашка
    
    // Конструктор для настройки подключения к базе данных
    public TurtleContext(DbContextOptions<TurtleContext> options) : base(options) { }

    // Пустой конструктор для использования по умолчанию
    public TurtleContext() {}

    // Настройка подключения к базе данных SQLite
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=mydb.db"); // Указываем строку подключения к базе данных SQLite
        // Строку подключения можно перенести в appsettings.json для удобства
    }

    // Метод инициализации базы данных
    public void InitializeDatabase()
    {
        // Используем контекст для работы с базой данных
        using (var context = new TurtleContext())
        {
            // Проверка, если таблица TurtleStatus пуста
            if (!context.TurtleStatus.Any())
            {
                var initialStatus = new TurtleStatus
                {
                    Xcoors = 0,           // начальная координата X
                    Ycoors = 0,           // начальная координата Y
                    PenCondition = "down",// начальное состояние пера
                    Angle = 0,            // начальный угол поворота
                    Color = "black",      // начальный цвет пера
                    Width = 1             // начальная ширина пера
                };

                context.TurtleStatus.Add(initialStatus);  // Добавляем начальный статус в таблицу
            }

            // Проверка, если таблица TurtleCoords пуста
            if (!context.TurtleCoords.Any())
            {
                var initialCoords = new TurtleCoords
                {
                    xCoord = 0,           // начальная координата X
                    yCoord = 0            // начальная координата Y
                };

                context.TurtleCoords.Add(initialCoords);  // Добавляем начальные координаты в таблицу
            }

            // Сохраняем изменения в базе данных
            context.SaveChanges();  // Сохраняем изменения в базе данных, чтобы инициализировать начальное состояние
        }
    }
}

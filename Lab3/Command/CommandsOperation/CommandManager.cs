// CommandManager.cs
using Lab3.Commands;
using Lab3.CommandsInterface;
using Lab3.DataBase;

namespace Lab3.CommandsOperation;

// Класс для управления командами
public class CommandManager
{
    private readonly IDataBaseReader dbReader; // Интерфейс для чтения данных из базы
    private readonly Dictionary<CommandType, ICommands> commandsDict = new(); // Словарь для хранения доступных команд

    public CommandManager(IDataBaseReader dbReader)
    {
        this.dbReader = dbReader; // Инициализация объекта для работы с базой данных
        FillDict(); // Заполнение словаря командами при создании экземпляра класса
    }

    // Добавление команд в словарь, где ключ — это тип команды, а значение — объект команды
    private void FillDict()
    {
        // Добавление команды "История" в словарь
        commandsDict.Add(CommandType.History, new HistoryCommand(dbReader));
        // Добавление команды "Список фигур"
        commandsDict.Add(CommandType.ListFigures, new ListFiguresCommand(dbReader));
        // Добавление команды "Перемещение"
        commandsDict.Add(CommandType.Move, new MoveCommand());
        // Добавление команды "Поднять перо"
        commandsDict.Add(CommandType.PenUp, new PenUpCommand());
        // Добавление команды "Установить угол"
        commandsDict.Add(CommandType.Angle, new AngleCommand());
        // Добавление команды "Опустить перо"
        commandsDict.Add(CommandType.PenDown, new PenDownCommand());
        // Добавление команды "Установить цвет"
        commandsDict.Add(CommandType.Color, new SetColorCommand());
        // Добавление команды "Установить ширину"
        commandsDict.Add(CommandType.Width, new SetWidthCommand());
    }

    // Определение и возвращение объекта команды на основе входной строки
    public ICommands DefineCommand(string command)
    {
        // Определение типа команды с помощью парсера
        var commandType = CommandParser.GetCommandType(command);
        // Поиск команды в словаре
        if (commandsDict.TryGetValue(commandType, out var commandInstance))
        {
            return commandInstance; // Возвращаем найденную команду
        }

        // Если команда не найдена, выбрасывается исключение
        throw new InvalidOperationException($"Команда '{command}' не реализована.");
    }
}

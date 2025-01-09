// CommandManager.cs
using Lab3.Commands;
using Lab3.CommandsInterface;
using Lab3.DataBase;

namespace Lab3.CommandsOperation;

public class CommandManager
{
    private readonly IDataBaseReader dbReader;
    private readonly Dictionary<CommandType, ICommands> commandsDict = new();

    public CommandManager(IDataBaseReader dbReader)
    {
        this.dbReader = dbReader;
        FillDict();
    }

    private void FillDict()
    {
        commandsDict.Add(CommandType.History, new HistoryCommand(dbReader));
        commandsDict.Add(CommandType.ListFigures, new ListFiguresCommand(dbReader));
        commandsDict.Add(CommandType.Move, new MoveCommand());
        commandsDict.Add(CommandType.PenUp, new PenUpCommand());
        commandsDict.Add(CommandType.Angle, new AngleCommand());
        commandsDict.Add(CommandType.PenDown, new PenDownCommand());
        commandsDict.Add(CommandType.Color, new SetColorCommand());
        commandsDict.Add(CommandType.Width, new SetWidthCommand());
    }

    public ICommands DefineCommand(string command)
    {
        var commandType = CommandParser.GetCommandType(command);
        if (commandsDict.TryGetValue(commandType, out var commandInstance))
        {
            return commandInstance;
        }

        throw new InvalidOperationException($"Команда '{command}' не реализована.");
    }
}
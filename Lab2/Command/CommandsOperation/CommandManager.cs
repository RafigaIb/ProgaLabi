using System;
using System.Collections.Generic;
using Lab1.Commands;
using Lab1.CommandsInterface;
using Lab1.Storage;

namespace Lab1.CommandsOperation
{
    public class CommandManager
    {
        private readonly StorageReader reader;
        private readonly StorageReader figuresReader;

        public CommandManager(StorageReader reader, StorageReader figuresReader)
        {
            this.reader = reader;
            this.figuresReader = figuresReader;
            FillDict();
        }


        private readonly Dictionary<CommandType, ICommands> commandsDict = new();

        private void FillDict()
        {
            commandsDict.Add(CommandType.History, new HistoryCommand(reader));
            commandsDict.Add(CommandType.ListFigures, new ListFiguresCommand(figuresReader));
            commandsDict.Add(CommandType.Move, new MoveCommand());
            commandsDict.Add(CommandType.PenUp, new PenUpCommand());
            commandsDict.Add(CommandType.Angle, new AngleCommand());
            commandsDict.Add(CommandType.PenDown, new PenDownCommand());
            commandsDict.Add(CommandType.Color, new SetColorCommand());
            commandsDict.Add(CommandType.Width, new SetWidthCommand());
        }

        

        public ICommands DefineCommand(string command)
        {
            CommandType commandType = CommandParser.GetCommandType(command);
            if (commandsDict.TryGetValue(commandType, out var commandInstance))
            {
                return commandInstance;
            }
            else
            {
                throw new InvalidOperationException($"Command '{command}' is not implemented.");
            }
        }
    }
}

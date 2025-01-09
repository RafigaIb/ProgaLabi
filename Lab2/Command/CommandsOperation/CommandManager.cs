using System;
using System.Collections.Generic;
using Lab2.Commands;
using Lab2.CommandsInterface;
using Lab2.DataBase;
using Lab2.Storage;

namespace Lab2.CommandsOperation
{
    public class CommandManager
    {
        private DataBaseReader dbReader;
        
        public CommandManager(DataBaseReader reader)
        {
            dbReader = reader;
            FillDict();
            

        }


        private readonly Dictionary<CommandType, ICommands> commandsDict = new();

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

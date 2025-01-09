using System;
using System.Collections.Generic;
using System.Data;
using Lab3.Storage;
using Lab3.Commands;
using Lab3.CommandsInterface;
using Lab3.DataBase;
using Lab3.Models;

namespace Lab3.CommandsOperation
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

using System;
using System.Collections.Generic;
using Lab2.Commands;
using Lab2.CommandsInterface;
using Lab2.DataBase;
using Lab2.Storage;

namespace Lab2.CommandsOperation
{
    // Класс для управления командами
    public class CommandManager
    {
        private DataBaseReader dbReader; // Объект для чтения данных из базы данных
        
        // Конструктор принимает объект для чтения данных из базы и инициализирует командный словарь
        public CommandManager(DataBaseReader reader)
        {
            dbReader = reader;
            FillDict(); // Заполнение словаря команд
        }

        // Словарь для хранения типов команд и соответствующих им объектов
        private readonly Dictionary<CommandType, ICommands> commandsDict = new();

        // Метод для заполнения словаря команд с привязкой к соответствующим объектам команд
        private void FillDict()
        {
            // Добавление команд в словарь, где ключ — это тип команды, а значение — объект команды
            commandsDict.Add(CommandType.History, new HistoryCommand(dbReader));
            commandsDict.Add(CommandType.ListFigures, new ListFiguresCommand(dbReader));
            commandsDict.Add(CommandType.Move, new MoveCommand());
            commandsDict.Add(CommandType.PenUp, new PenUpCommand());
            commandsDict.Add(CommandType.Angle, new AngleCommand());
            commandsDict.Add(CommandType.PenDown, new PenDownCommand());
            commandsDict.Add(CommandType.Color, new SetColorCommand());
            commandsDict.Add(CommandType.Width, new SetWidthCommand());
        }

        // Метод для определения и возврата соответствующей команды по строковому значению команды
        public ICommands DefineCommand(string command)
        {
            // Парсим команду в соответствующий тип с помощью CommandParser
            CommandType commandType = CommandParser.GetCommandType(command);
            
            // Если команда существует в словаре, возвращаем соответствующий объект команды
            if (commandsDict.TryGetValue(commandType, out var commandInstance))
            {
                return commandInstance;
            }
            else
            {
                // Если команда не найдена в словаре, выбрасываем исключение
                throw new InvalidOperationException($"Command '{command}' is not implemented.");
            }
        }
    }
}

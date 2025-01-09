using Lab3.CommandsInterface;
using Lab3.DataBase;
using System;
using System.Threading.Tasks;

namespace Lab3.Commands
{
    public class HistoryCommand : ICommandsWithoutArgs
    {
        private IDataBaseReader dbReader;
        public HistoryCommand(IDataBaseReader reader)
        {
            dbReader = reader;
        }

        public void Execute(Turtle turtle)
        {
            // Console.WriteLine(dbReader.GetCommands());
        }
    }
}
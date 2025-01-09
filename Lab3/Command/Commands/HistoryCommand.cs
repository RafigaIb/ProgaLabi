using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.CommandsInterface;
using Lab3.DataBase;

namespace Lab3.Commands
{
    public class HistoryCommand : ICommandsWithoutArgs
    {
        private DataBaseReader dbReader;
        public HistoryCommand(DataBaseReader reader)
        {
            dbReader = reader;
        }

        public void Execute(Turtle turtle)
        {
            // Console.WriteLine(dbReader.GetCommands());
        }
    }
}
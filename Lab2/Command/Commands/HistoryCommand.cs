using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.CommandsInterface;
using Lab2.DataBase;

namespace Lab2.Commands
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
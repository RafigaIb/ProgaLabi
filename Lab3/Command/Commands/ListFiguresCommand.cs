using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Storage;
using Lab3.CommandsInterface;
using Lab3.DataBase;

namespace Lab3.Commands
{
    public class ListFiguresCommand : ICommandsWithoutArgs
    {
        
        private DataBaseReader dbReader;
        public ListFiguresCommand(DataBaseReader reader)
        {
            dbReader = reader;
        }

        public void Execute(Turtle turtle)
        {
            // Console.WriteLine(dbReader.GetFigures());
        }
    }
}
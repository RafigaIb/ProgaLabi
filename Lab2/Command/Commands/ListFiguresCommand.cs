using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.CommandsInterface;
using Lab2.DataBase;
using Lab2.Storage;

namespace Lab2.Commands
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
            Console.WriteLine(dbReader.GetFigures());
        }
    }
}
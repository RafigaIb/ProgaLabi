using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.CommandsInterface;
using Lab1.Storage;
using Lab1.TurtleObject;

namespace Lab1.Commands
{
    public class HistoryCommand : ICommandsWithoutArgs
    {
        private StorageReader storageReader;

        public HistoryCommand(StorageReader reader)
        {
            storageReader = reader;
        }
        

        public async void Execute(Turtle turtle)
        {
            await storageReader.SetHistoryAsync();
        }


    }
}

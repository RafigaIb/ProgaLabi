using System.ComponentModel.DataAnnotations.Schema;
using Lab2.CommandsInterface;

namespace Lab2.DataBase
{
    // Класс для хранения истории команд
    public class CommandList
    {
        // Идентификатор записи в базе данных
        public int Id { get; set; }
        
        // Название команды (например, "move", "penup", и т.д.)
        public string? Name { get; set; }
        
        // Свойство для хранения команды, но оно не будет отображаться в базе данных
        [NotMapped]
        public ICommands Command { get; set; }
    }
}
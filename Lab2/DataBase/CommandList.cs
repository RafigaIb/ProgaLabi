using System.ComponentModel.DataAnnotations.Schema;
using Lab2.CommandsInterface;

namespace Lab2.DataBase;
// таблица для хранения истории команд
public class CommandList
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    [NotMapped]
    public ICommands Command { get; set; }
    
}
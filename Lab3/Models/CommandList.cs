using System.ComponentModel.DataAnnotations.Schema;
using Lab3.CommandsInterface;

namespace Lab3.Models;

public class CommandList
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    [NotMapped]
    public ICommands Command { get; set; }
    
}
namespace Lab1.CommandsOperation
{
    public enum CommandType
    {
        History,
        ListFigures,
        Move,
        PenUp,
        Angle,
        PenDown,
        Color,
        Width
    }

    public static class CommandParser
    {
        public static CommandType GetCommandType(string command)
        {
            return command.ToLower() switch
            {
                "history" => CommandType.History,
                "listfigures" => CommandType.ListFigures,
                "move" => CommandType.Move,
                "penup" => CommandType.PenUp,
                "angle" => CommandType.Angle,
                "pendown" => CommandType.PenDown,
                "color" => CommandType.Color,
                "width" => CommandType.Width,
                _ => throw new ArgumentException($"Invalid command: '{command}'", nameof(command))
            };
        }
    }
}
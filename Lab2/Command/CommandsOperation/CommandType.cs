namespace Lab2.CommandsOperation
{
    // Перечисление типов команд, которые доступны для выполнения
    public enum CommandType
    {
        History,      // Команда для вывода истории команд
        ListFigures,  // Команда для вывода списка фигур
        Move,         // Команда для движения черепашки
        PenUp,        // Команда для поднятия пера
        Angle,        // Команда для установки угла
        PenDown,      // Команда для опускания пера
        Color,        // Команда для установки цвета
        Width         // Команда для установки ширины линии
    }

    // Статический класс для парсинга строковых команд в тип CommandType
    public static class CommandParser
    {
        // Метод для преобразования строкового представления команды в соответствующий тип CommandType
        public static CommandType GetCommandType(string command)
        {
            // Преобразуем строку команды в нижний регистр и проверяем, какой тип команды соответствует этой строке
            return command.ToLower() switch
            {
                "history" => CommandType.History,              // История команд
                "listfigures" => CommandType.ListFigures,      // Список фигур
                "move" => CommandType.Move,                    // Движение
                "penup" => CommandType.PenUp,                  // Поднять перо
                "angle" => CommandType.Angle,                  // Установить угол
                "pendown" => CommandType.PenDown,              // Опустить перо
                "color" => CommandType.Color,                  // Установить цвет
                "width" => CommandType.Width,                  // Установить ширину линии
                _ => throw new ArgumentException($"Invalid command: '{command}'", nameof(command))  // Если команда не распознана, выбрасывается исключение
            };
        }
    }
}
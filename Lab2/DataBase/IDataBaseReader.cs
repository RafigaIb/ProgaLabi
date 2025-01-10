namespace Lab2.DataBase
{
    // Интерфейс для извлечения данных из базы данных
    public interface IDataBaseReader
    {
        // Метод для получения последнего статуса черепашки из таблицы TurtleStatus
        public Task<TurtleStatus?> GetTurtleStatus();

        // Метод для получения последних координат черепашки из таблицы TurtleCoords
        public Task<TurtleCoords?> GetTurtleCoords();

        // Метод для получения всех команд из истории команд из таблицы CommandHistory
        public Task<List<CommandHistory>> GetCommands();

        // Метод для получения всех нарисованных фигур из таблицы Figure
        public Task<List<Figure>> GetFigures();
    }
}
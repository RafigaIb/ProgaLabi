namespace Lab2.DataBase;

// Класс, представляющий таблицу в базе данных для хранения координат черепашки
public class TurtleCoords
{
    public int Id { get; set; }  // Уникальный идентификатор для записи координат (например, для идентификации каждой записи в базе данных)
    public double xCoord { get; set; }  // Координата X черепашки
    public double yCoord { get; set; }  // Координата Y черепашки
}
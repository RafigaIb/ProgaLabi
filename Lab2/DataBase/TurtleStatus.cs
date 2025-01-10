namespace Lab2.DataBase;

// Класс, представляющий таблицу в базе данных, которая хранит данные о текущем статусе черепашки.
public class TurtleStatus
{
    public int Id { get; set; }  // Уникальный идентификатор статуса черепашки (например, для записи в базе данных)
    public double Xcoors { get; set; }  // Координата X текущего положения черепашки
    public double Ycoors { get; set; }  // Координата Y текущего положения черепашки
    public double Angle { get; set; }  // Угол, под которым направлена черепашка
    public string PenCondition { get; set; }  // Состояние пера (например, поднято или опущено)
    public string Color { get; set; }  // Цвет линии, который использует черепашка
    public double Width { get; set; }  // Ширина линии, которая будет рисоваться черепашкой
}
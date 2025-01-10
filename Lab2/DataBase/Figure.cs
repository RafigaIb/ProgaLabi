namespace Lab2.DataBase
{
    // Класс, представляющий таблицу для хранения геометрических фигур.
    public class Figure
    {
        public int Id { get; set; }            // Уникальный идентификатор фигуры
        public string FigureType { get; set; }  // Тип фигуры (например, "треугольник", "квадрат", и т.д.)
        public string Parameters { get; set; }  // Параметры фигуры, представленные строкой (например, координаты точек)
    }
}
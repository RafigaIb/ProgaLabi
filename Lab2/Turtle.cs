using System;

namespace Lab2
{
    public class Turtle
    {
        // Приватные поля для хранения состояния черепашки
        private double coordX;   // Координата X черепашки
        private double coordY;   // Координата Y черепашки
        private bool penCondition;  // Состояние пера (опущено или поднято)
        private double angle;     // Угол направления черепашки
        private string color;     // Цвет пера
        private double width;     // Толщина линии пера

        // Конструктор для инициализации состояния черепашки с начальными значениями
        public Turtle()
        {
            coordX = 0;           // Начальная координата X
            coordY = 0;           // Начальная координата Y
            angle = 0;            // Начальный угол (смотрит вправо)
            penCondition = true;  // Перо изначально опущено
            color = "black";      // Цвет пера по умолчанию — черный
            width = 1;            // Толщина пера по умолчанию — 1
        }

        // Геттер для координаты X, округленной до 2 знаков после запятой
        public double GetCoordX()
        {
            return Math.Round(coordX, 2);
        }

        // Сеттер для координаты X, увеличивает на округленное значение
        public void SetCoordx(double value)
        {
            coordX += Math.Round(value, 2);
        }

        // Геттер для координаты Y, округленной до 2 знаков после запятой
        public double GetCoordY()
        {
            return Math.Round(coordY, 2);
        }

        // Сеттер для координаты Y, увеличивает на округленное значение
        public void SetCoordY(double value)
        {
            coordY += Math.Round(value, 2);
        }

        // Геттер для угла (направления) черепашки
        public double GetAngle()
        {
            return angle;
        }

        // Сеттер для угла, увеличивает угол на заданное значение и гарантирует, что угол будет в пределах от 0 до 360 градусов
        public void SetAngle(double value)
        {
            angle = (angle + value) % 360;  // Убедиться, что угол остается в пределах 0-359 градусов
        }

        // Геттер для состояния пера (опущено или поднято)
        public string GetPenCondition()
        {
            if (penCondition)
            {
                return "penDown";  // Если penCondition true, перо опущено
            }

            return "penUp";      // Если penCondition false, перо поднято
        }

        // Сеттер для состояния пера (опускает или поднимает перо)
        public void SetPenCondition(bool value)
        {
            penCondition = value;
        }

        // Сеттер для цвета пера
        public void SetColor(string value)
        {
            color = value;
        }

        // Геттер для цвета пера
        public string GetColor()
        {
            return color;
        }

        // Сеттер для толщины пера
        public void SetWidth(double value)
        {
            width = value;
        }

        // Геттер для толщины пера
        public double GetWidth()
        {
            return width;
        }
    }
}

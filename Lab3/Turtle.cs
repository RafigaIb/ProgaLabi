using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Commands;

namespace Lab3
{
    // Класс, представляющий черепаху и её состояние
    public class Turtle
    {
        private double coordX;       // Текущая координата X черепахи
        private double coordY;       // Текущая координата Y черепахи
        private bool penCondition;   // Состояние пера (включено или выключено)
        private double angle;        // Угол поворота черепахи
        private string color;        // Цвет пера черепахи
        private double width;        // Ширина пера

        // Конструктор по умолчанию, устанавливает начальные значения
        public Turtle()
        {
            coordX = 0;             // Начальная координата X
            coordY = 0;             // Начальная координата Y
            angle = 0;              // Начальный угол
            penCondition = true;    // Начальное состояние пера (включено)
            color = "black";        // Начальный цвет пера
            width = 1;              // Начальная ширина пера
        }

        // Геттер для координаты X
        public double GetCoordX()
        {
            return Math.Round(coordX, 2);  // Возвращает значение с округлением до двух знаков
        }

        // Сеттер для координаты X (прибавляет значение)
        public void SetCoordx(double value)
        {
            coordX += Math.Round(value, 2);  // Прибавляет значение к текущей координате X с округлением
        }

        // Геттер для координаты Y
        public double GetCoordY()
        {
            return Math.Round(coordY, 2);  // Возвращает значение с округлением до двух знаков
        }

        // Сеттер для координаты Y (прибавляет значение)
        public void SetCoordY(double value)
        {
            coordY += Math.Round(value, 2);  // Прибавляет значение к текущей координате Y с округлением
        }

        // Геттер для угла поворота
        public double GetAngle()
        {
            return angle;  // Возвращает текущий угол
        }

        // Сеттер для угла поворота
        public void SetAngle(double value)
        {
            angle = (angle + value) % 360;  // Устанавливает новый угол, гарантируя, что он будет в пределах 0-360 градусов
        }

        // Геттер для состояния пера (возвращает строку "penDown" или "penUp")
        public string GetPenCondition()
        {
            if (penCondition)
            {
                return "penDown";  // Если состояние пера включено, возвращает "penDown"
            }

            return "penUp";  // Если состояние пера выключено, возвращает "penUp"
        }

        // Сеттер для состояния пера (включено или выключено)
        public void SetPenCondition(bool value)
        {
            penCondition = value;  // Устанавливает состояние пера
        }

        // Сеттер для цвета пера
        public void SetColor(string value)
        {
            color = value;  // Устанавливает цвет пера
        }

        // Геттер для цвета пера
        public string GetColor()
        {
            return color;  // Возвращает текущий цвет пера
        }

        // Сеттер для ширины пера
        public void SetWidth(double value)
        {
            width = value;  // Устанавливает ширину пера
        }

        // Геттер для ширины пера
        public double GetWidth()
        {
            return width;  // Возвращает текущую ширину пера
        }
    }
}

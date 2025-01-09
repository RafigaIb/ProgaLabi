using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Commands;

namespace Lab1.TurtleObject
{
    /// <summary>
    /// Класс, представляющий объект Черепахи, который может перемещаться, рисовать и вращаться.
    /// </summary>
    public class Turtle
    {
        // Поля для хранения состояния черепахи
        private double coordX; // X-координата текущего положения черепахи
        private double coordY; // Y-координата текущего положения черепахи
        private bool penCondition; // Состояние пера: true - опущено, false - поднято
        private double angle; // Угол направления черепахи в градусах
        private string color; // Цвет пера
        private double width; // Толщина линии, рисуемой пером

        /// <summary>
        /// Инициализирует новый экземпляр класса Turtle с начальными значениями.
        /// </summary>
        public Turtle()
        {
            coordX = 0; // Начальная X-координата
            coordY = 0; // Начальная Y-координата
            angle = 0; // Начальное направление (вправо)
            penCondition = true; // Перо опущено по умолчанию
            color = "black"; // Цвет пера по умолчанию
            width = 1; // Толщина линии по умолчанию
        }

        /// <summary>
        /// Возвращает текущую X-координату черепахи.
        /// </summary>
        public double GetCoordX()
        {
            return coordX;
        }

        /// <summary>
        /// Обновляет X-координату текущего положения черепахи.
        /// </summary>
        /// <param name="value">Значение, на которое нужно изменить X-координату.</param>
        public void SetCoordx(double value)
        {
            coordX += value; // Изменяет X-координату на указанное значение
        }

        /// <summary>
        /// Возвращает текущую Y-координату черепахи.
        /// </summary>
        public double GetCoordY()
        {
            return coordY;
        }

        /// <summary>
        /// Обновляет Y-координату текущего положения черепахи.
        /// </summary>
        /// <param name="value">Значение, на которое нужно изменить Y-координату.</param>
        public void SetCoordY(double value)
        {
            coordY += value; // Изменяет Y-координату на указанное значение
        }

        /// <summary>
        /// Возвращает текущий угол направления черепахи в градусах.
        /// </summary>
        public double GetAngle()
        {
            return angle;
        }

        /// <summary>
        /// Устанавливает угол направления черепахи.
        /// </summary>
        /// <param name="value">Значение угла, которое нужно добавить к текущему углу (в градусах).</param>
        public void SetAngle(double value)
        {
            angle = (angle + value) % 360; // Обновляет угол и приводит его в диапазон [0, 360)
        }

        /// <summary>
        /// Возвращает текущее состояние пера ("penDown" или "penUp").
        /// </summary>
        public string GetPenCondition()
        {
            if (penCondition)
            {
                return "penDown"; // Перо опущено
            }

            return "penUp"; // Перо поднято
        }

        /// <summary>
        /// Устанавливает состояние пера.
        /// </summary>
        /// <param name="value">True, если перо должно быть опущено; False, если поднято.</param>
        public void SetPenCondition(bool value)
        {
            penCondition = value; // Устанавливает состояние пера
        }

        /// <summary>
        /// Устанавливает цвет пера.
        /// </summary>
        /// <param name="value">Новый цвет пера.</param>
        public void SetColor(string value)
        {
            color = value; // Задаёт новый цвет пера
        }

        /// <summary>
        /// Возвращает текущий цвет пера.
        /// </summary>
        public string GetColor()
        {
            return color;
        }

        /// <summary>
        /// Устанавливает толщину линии пера.
        /// </summary>
        /// <param name="value">Толщина линии.</param>
        public void SetWidth(double value)
        {
            width = value; // Устанавливает толщину линии
        }

        /// <summary>
        /// Возвращает текущую толщину линии пера.
        /// </summary>
        public double GetWidth()
        {
            return width;
        }
    }
}

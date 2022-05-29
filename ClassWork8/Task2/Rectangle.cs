using System;
using System.Drawing;

namespace ClassWork8
{
    class Rectangle : Point
    {
        public int length, width;
        public long Area => width * length;
        public override string status => $"Фигура: Прямоугольник; Длина:{length}; Ширина:{width}; Площадь:{Area} {base.status}";
        public Rectangle() : base()
        { length = width = 10; }

        public Rectangle(int length, int width, Color color, bool visible = true) : base(color, visible)
        {
            this.length = length;
            this.width = width;
        }

        public Rectangle(int x, int y, int length, int width, Color color, bool visible = true) : base(x, y, color, visible)
        {
            this.length = length;
            this.width = width;
        }
    }
}

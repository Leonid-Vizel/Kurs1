using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork8
{
    class Circle : Point
    {
        public int radius;
        public override string status => $"Фигура: Круг; Радиус: {radius}; Площадь: {Area}; {base.status}";
        public double Area => Math.PI * radius * radius;

        public Circle() : base()
        { radius = 10; }

        public Circle(int radius, Color color, bool visible = true) : base(color, visible)
        {this.radius = radius;}

        public Circle(int x, int y, int radius, Color color, bool visible = true) : base(x, y, color, visible)
        {this.radius = radius;}
    }
}

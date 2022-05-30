using System.Drawing;

namespace ClassWork9
{
    public abstract class Figure
    {
        public Color color;
        public bool visible;
        public virtual string status => $"Цвет: {color.Name}, Видимость: {visible}";

        #region Constructors
        public Figure()
        {
            color = Color.Black;
            visible = true;
        }

        public Figure(Color color, bool visible = true)
        {
            this.color = color;
            this.visible = visible;
        }
        #endregion
    }
}

using System.Drawing;

namespace ClassWork9
{
    class Point : Figure
    {
        protected int xPos;
        protected int yPos;
        public override string status => $"Положение в пространстве: [{xPos};{yPos}]; {base.status}";
        public Point() : base()
        {/*Nothing*/}

        public Point(Color color, bool visible = true) : base(color, visible)
        {/*Nothing*/}

        public Point(int x, int y, Color color, bool visible = true) : base(color,visible)
        {
            xPos = x;
            yPos = y;
        }

        #region Methods
        public void MoveHorisontal(int delta) => xPos += delta;
        public void MoveVertical(int delta) => yPos += delta;
        #endregion
    }
}

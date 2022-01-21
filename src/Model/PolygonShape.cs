using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw
{
    [Serializable]
    public abstract class PolygonShape : Shape
    {
        public PolygonShape() : base()
        {

        }
        public PolygonShape(RectangleF rect) : base(rect)
        {
        }

        public PolygonShape(PolygonShape polygon) : base(polygon)
        {
        }
        /// <summary>
        /// Име на елемента.
        /// </summary>
        public override string Name
        {
            get { return name; }
            set { name = "[P]" + value; }
        }
        public override bool Contains(PointF point)
        {
            PointF translatedPoint = TranslatePoint(point);
            bool result = false;
            int j = Points.Count() - 1;

            for (int i = 0; i < Points.Count(); i++)
            {
                if (!(Points[i].Y > translatedPoint.Y).Equals(Points[j].Y > translatedPoint.Y))
                {
                    //май това е проверка дали се пресичат 2-те прави
                    if ((translatedPoint.X - Points[i].X) < (Points[j].X - Points[i].X) * (translatedPoint.Y - Points[i].Y) / (Points[j].Y - Points[i].Y))
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
        }
    }
}


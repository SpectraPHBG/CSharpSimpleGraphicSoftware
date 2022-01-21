using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Draw
{
	[Serializable]
	public class TriangleShape : PolygonShape
    {
		public TriangleShape() : base()
		{

		}
		public TriangleShape(RectangleF rect) : base(rect)
		{

		}

		public TriangleShape(TriangleShape triangle) : base(triangle)
		{

		}

		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public override float Width
		{
			get { return Rectangle.Width; }
			set 
			{
				float ratio = Width / Height;
				if (value > 1 && value < 1500)
				{
					float scaleMargin = value / Width;
					float proportion;
					for (int i = 0; i < Points.Count; i++)
					{
						proportion = Points[i].X - Location.X;
						Points[i] = new PointF(Location.X + proportion * scaleMargin, Points[i].Y);
					}
					rectangle.Width = value;
				}
			}
		}

		/// <summary>
		/// Височина на елемента.
		/// </summary>
		public override float Height
		{
			get { return Rectangle.Height; }
			set 
			{
				if (value > 1 && value < 1500)
				{
					float scaleMargin = value / Height;
					float proportion;
					for (int i = 0; i < Points.Count; i++)
					{
						proportion = Points[i].Y - Location.Y;
						Points[i] = new PointF(Points[i].X, Location.Y + proportion * scaleMargin);
					}
					rectangle.Height = value;
				}
			}
		}

		public override PointF Location
		{
			get 
			{ 
				return Rectangle.Location; 
			}
			set 
			{
                for (int i = 0; i < Points.Count; i++)
                {
					Points[i] = new PointF(Points[i].X + (value.X - Location.X), Points[i].Y + (value.Y - Location.Y));
				}
				rectangle.Location = value; 
			}
		}
		/// <summary>
		/// Име на елемента.
		/// </summary>
		public override string Name
		{
			get { return name; }
			set
			{
				if (value.Contains("[T] "))
				{
					name = value;
				}
				else
				{
					name = "[T] " + value;
				}
			}
		}
		public override bool Contains(PointF point)
		{
			return base.Contains(point);
        }
		public override void DrawSelf(Graphics grfx)
		{
			int opacityValue = (int)(Opacity * 2.55F);
			base.DrawSelf(grfx);

			grfx.FillPolygon(new SolidBrush(Color.FromArgb(opacityValue, FillColor)), Points.ToArray());
			Pen pen = new Pen(Color.FromArgb(opacityValue, BorderColor), BorderThickness);
			pen.MiterLimit = BorderThickness / 2;
			pen.Alignment = PenAlignment.Inset;
			grfx.DrawPolygon(pen, Points.ToArray());
			if (IsSelected)
			{
				grfx.DrawRectangle(Pens.Red, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			}
			grfx.ResetTransform();
		}
	}
}

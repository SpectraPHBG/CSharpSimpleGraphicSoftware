using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw
{
	[Serializable]
	public class LineShape : Shape
    {
		public LineShape() : base()
		{

		}
		public LineShape(RectangleF rect) : base(rect)
		{
		}

		public LineShape(LineShape line) : base(line)
		{
		}
		/// <summary>
		/// Име на елемента.
		/// </summary>
		public override string Name
		{
			get { return name; }
			set
			{
				if (value.Contains("[L] "))
				{
					name = value;
				}
				else
				{
					name = "[L] " + value;
				}
			}
		}
		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public override float Width
		{
			get { return Rectangle.Width; }
			set
			{
                if (Points.Count == 2 && value>1 && value < 1500)
                {
                    if (Points[0].X <= Points[1].X)
                    {
						Points[1] = new PointF(Location.X + value, Points[1].Y);
					}
                    else
                    {
						Points[0] = new PointF(Location.X + value, Points[0].Y);
					}
					rectangle.Width = value;
                }
				else if (value == 0 && Height >1 && Height < 1500)
                {
					Points[0] = new PointF(Location.X, Points[0].Y);
					Points[1] = new PointF(Location.X, Points[1].Y);
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
				if (Points.Count == 2 && value>1 && value < 1500)
				{
                    if (Points[0].Y <= Points[1].Y)
                    {
						Points[1] = new PointF(Points[1].X, Location.Y + value);
					}
                    else
                    {
						Points[0] = new PointF(Points[0].X, Location.Y + value);
					}
					rectangle.Height = value;
				}
				else if (value == 0 && Width >1 && Width < 1500)
                {
					Points[0] = new PointF(Points[0].X, Location.Y);
					Points[1] = new PointF(Points[1].X, Location.Y);
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
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		/// 
		public override bool Contains(PointF point)
		{

			PointF rotatedPoint = TranslatePoint(point);
			float endX = Location.X + Width;
			float endY = Location.Y + Height;
			//AB = sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
			float AB = (float)Math.Sqrt(Math.Pow((Points[1].X - Points[0].X),2) + Math.Pow((Points[1].Y - Points[0].Y), 2));

			//AP = sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));
			float AP = (float)Math.Sqrt(Math.Pow((rotatedPoint.X - Points[0].X), 2) + Math.Pow((rotatedPoint.Y - Points[0].Y), 2));

			//PB = sqrt((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y);
			float PB = (float)Math.Sqrt(Math.Pow((Points[1].X - rotatedPoint.X), 2) + Math.Pow((Points[1].Y - rotatedPoint.Y), 2));
			if (Math.Abs(AB - (AP + PB))<=(0.02F+BorderThickness*0.01F))
				return true;
			else
				return false;
		}

		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			int opacityValue = (int)(Opacity * 2.55F);
			base.DrawSelf(grfx);

			grfx.DrawLine(new Pen(Color.FromArgb(opacityValue, BorderColor), BorderThickness), Points[0].X, Points[0].Y, Points[1].X, Points[1].Y);

			if (IsSelected)
			{
				if (Width == 0 || Height == 0)
				{
					grfx.DrawLine(new Pen(Color.FromArgb(opacityValue, Color.Red), BorderThickness), Points[0].X, Points[0].Y, Points[1].X, Points[1].Y);
				}
				else
				{
					grfx.DrawRectangle(Pens.Red, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
				}
			}
			grfx.ResetTransform();
		}
	}
}

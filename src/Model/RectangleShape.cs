using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	[Serializable]
	public class RectangleShape : Shape
	{
		#region Constructor
		public RectangleShape() : base()
        {

        }
		public RectangleShape(RectangleF rect) : base(rect)
		{
		}
		
		public RectangleShape(RectangleShape rectangle) : base(rectangle)
		{
		}

		#endregion

		/// <summary>
		/// Име на елемента.
		/// </summary>
		public override string Name
		{
			get { return name; }
			set 
			{ 
				if(value.Contains("[R] "))
                {
					name = value;
                }
                else
                {
					name = "[R] " + value;
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
				if (value > 1 && value<1500)
				{
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
					rectangle.Height = value;
				}
			}
		}
		/// <summary>
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		public override bool Contains(PointF point)
		{
			if (base.Contains(TranslatePoint(point)))
				// Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
				// В случая на правоъгълник - директно връщаме true
				return true;
			else
				// Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
				return false;
		}
		
		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			int opacityValue = (int)(Opacity * 2.55F);
			base.DrawSelf(grfx);
			grfx.FillRectangle(new SolidBrush(Color.FromArgb(opacityValue,FillColor)),Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			Pen pen = new Pen(Color.FromArgb(opacityValue, BorderColor), BorderThickness);
			pen.MiterLimit = BorderThickness / 2;
			pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
			grfx.DrawRectangle(pen, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            if (IsSelected)
            {
				grfx.DrawRectangle(Pens.Red, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			}
			grfx.ResetTransform();

		}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
	[Serializable]
	public class EllipseShape : Shape
    {
		public EllipseShape() : base()
        {

        }
		public EllipseShape(RectangleF rect) : base(rect)
		{
		}

		public EllipseShape(EllipseShape ellipse) : base(ellipse)
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
				if (value.Contains("[E] "))
				{
					name = value;
				}
				else
				{
					name = "[E] " + value;
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
				if (value > 1 && value < 1500)
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
		public override bool Contains(PointF point)
		{
			PointF translatedPoint = TranslatePoint(point);
			//координати на център - взимам горния ляв ъгъл на примитива и добавям половината дължина
			float centerX = this.Location.X + (this.Width / 2);
			float centerY = this.Location.Y + (this.Height / 2);
			// формула за примитива, повдигам на квадрат, тъй като разликата може да е отрицателна, проверявам дали разликата между координатите на центъра е по-голяма от радиуса на съответната ос на елипсата X или Y
			if (((Math.Pow((translatedPoint.X - centerX), 2) / Math.Pow((this.Width / 2), 2)) 
				+ 
				(Math.Pow((translatedPoint.Y - centerY), 2) / Math.Pow((this.Height / 2), 2))) <= 1)
				return true;
			else
				return false;
		}
		public override void DrawSelf(Graphics grfx)
		{
			int opacityValue = (int)(Opacity * 2.55F);
			base.DrawSelf(grfx);

			grfx.FillEllipse(new SolidBrush(Color.FromArgb(opacityValue, FillColor)), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			Pen pen = new Pen(Color.FromArgb(opacityValue, BorderColor), BorderThickness);
			pen.MiterLimit = BorderThickness / 2;
			pen.Alignment = PenAlignment.Inset;
			grfx.DrawEllipse(pen, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			if (IsSelected)
			{
				grfx.DrawRectangle(Pens.Red, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			}
			grfx.ResetTransform();
		}
	}
}

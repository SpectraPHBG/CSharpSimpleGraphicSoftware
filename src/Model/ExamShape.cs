using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	[Serializable]
	public class ExamShape : Shape
	{
		#region Constructor
		public ExamShape() : base()
		{

		}
		public ExamShape(RectangleF rect) : base(rect)
		{
		}

		public ExamShape(ExamShape rectangle) : base(rectangle)
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
				if (value.Contains("[EX] "))
				{
					name = value;
				}
				else
				{
					name = "[EX] " + value;
				}
			}
		}

		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			int opacityValue = (int)(Opacity * 2.55F);
			base.DrawSelf(grfx);
			grfx.FillRectangle(new SolidBrush(Color.FromArgb(opacityValue, FillColor)), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			Pen pen = new Pen(Color.FromArgb(opacityValue, BorderColor), BorderThickness);
			pen.MiterLimit = BorderThickness / 2;
			pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
			grfx.DrawRectangle(pen, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawLine(pen, Location.X, Location.Y, (Location.X+Width), (Location.Y+Height));
			grfx.DrawLine(pen, (Location.X + Width), Location.Y,Location.X, (Location.Y + Height));
			if (IsSelected)
			{
				grfx.DrawRectangle(Pens.Red, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			}
			grfx.ResetTransform();

		}
	}
}

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на дисплейната система.
	/// </summary>
	public class DisplayProcessor
	{
		#region Constructor
		
		public DisplayProcessor()
		{
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Списък с всички елементи формиращи изображението.
		/// </summary>
		private List<Shape> shapeList = new List<Shape>();		
		public List<Shape> ShapeList {
			get { return shapeList; }
			set { shapeList = value; }
		}

		#endregion

		#region Drawing

		public void DrawRectangle(List<PointF> points, Color fillColor, Color borderColor, float borderThickness, int opacity)
		{
			float width = Math.Abs(points[1].X - points[0].X);
			float height = Math.Abs(points[1].Y - points[0].Y);
			float x = Math.Min(points[0].X, points[1].X);
			float y = Math.Min(points[0].Y, points[1].Y);

			RectangleShape rect = new RectangleShape(new RectangleF(x, y, width, height));

			foreach (var point in points)
			{
				rect.Points.Add(point);
			}

			rect.FillColor = fillColor;
			rect.BorderColor = borderColor;
			rect.BorderThickness = borderThickness;
			rect.Opacity = opacity;

			ShapeList.Add(rect);
		}
		public void DrawExamShape(List<PointF> points, Color fillColor, Color borderColor, float borderThickness, int opacity)
		{
			float width = Math.Abs(points[1].X - points[0].X);
			float height = Math.Abs(points[1].Y - points[0].Y);
			float x = Math.Min(points[0].X, points[1].X);
			float y = Math.Min(points[0].Y, points[1].Y);

			ExamShape exShape = new ExamShape(new RectangleF(x, y, width, height));

			foreach (var point in points)
			{
				exShape.Points.Add(point);
			}

			exShape.FillColor = fillColor;
			exShape.BorderColor = borderColor;
			exShape.BorderThickness = borderThickness;
			exShape.Opacity = opacity;

			ShapeList.Add(exShape);
		}

		public void DrawEllipse(List<PointF> points, Color fillColor, Color borderColor, float borderThickness, int opacity)
		{
			float width = Math.Abs(points[1].X - points[0].X);
			float height = Math.Abs(points[1].Y - points[0].Y);
			float x = Math.Min(points[0].X, points[1].X);
			float y = Math.Min(points[0].Y, points[1].Y);

			EllipseShape ellipse = new EllipseShape(new RectangleF(x, y, width, height));

			foreach (var point in points)
			{
				ellipse.Points.Add(point);
			}

			ellipse.FillColor = fillColor;
			ellipse.BorderColor = borderColor;
			ellipse.BorderThickness = borderThickness;
			ellipse.Opacity = opacity;

			ShapeList.Add(ellipse);
		}

		public void DrawLine(List<PointF> points, Color borderColor, float borderThickness, int opacity)
		{
			float width = Math.Abs(points[1].X - points[0].X);
			float height = Math.Abs(points[1].Y - points[0].Y);
			float x = Math.Min(points[0].X, points[1].X);
			float y = Math.Min(points[0].Y, points[1].Y);
			LineShape line= new LineShape(new RectangleF(x, y, width, height));
            foreach (var point in points)
            {
				line.Points.Add(point);
            }
			line.BorderColor = borderColor;
			line.BorderThickness = borderThickness;
			line.Opacity = opacity;

			ShapeList.Add(line);
		}

		public void DrawTriangle(List<PointF> points, Color fillColor, Color borderColor, float borderThickness, int opacity)
		{
			float width =0;
			float height =0;
			float x1 = points[0].X;
			float y1 = points[0].Y;
			float x2 = points[1].X;
			float y2 = points[1].Y;
			foreach (var point in points)
			{
				x1 = Math.Min(x1, point.X);
				y1 = Math.Min(y1, point.Y);
				x2 = Math.Max(x2, point.X);
				y2 = Math.Max(y2, point.Y);
			}
			width = Math.Abs(x2 - x1);
			height =Math.Abs(y2 - y1);

			TriangleShape triangle = new TriangleShape(new RectangleF(x1, y1, width, height));

			foreach (var point in points)
			{
				triangle.Points.Add(point);
			}

			triangle.FillColor = fillColor;
			triangle.BorderColor = borderColor;
			triangle.BorderThickness = borderThickness;
			triangle.Opacity = opacity;

			ShapeList.Add(triangle);
		}

		/// <summary>
		/// Прерисува всички елементи в shapeList върху e.Graphics
		/// </summary>
		public void ReDraw(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Draw(e.Graphics);
		}
		
		/// <summary>
		/// Визуализация.
		/// Обхождане на всички елементи в списъка и извикване на визуализиращия им метод.
		/// </summary>
		/// <param name="grfx">Къде да се извърши визуализацията.</param>
		public virtual void Draw(Graphics grfx)
		{
			foreach (Shape item in ShapeList){
				item.DrawSelf(grfx);
			}
		}

		#endregion
	}
}

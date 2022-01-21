using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
	/// <summary>
	/// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
	/// </summary>
	[Serializable]
	public abstract class Shape:IDisposable
	{
		#region Constructors
		
		public Shape()
		{
			Points = new List<PointF>();
			Name = "Shape";
		}
		
		public Shape(RectangleF rect)
		{
			rectangle = rect;
			Points = new List<PointF>();
			Name = "Shape";
		}

		public Shape(Shape shape)
		{
			Points = new List<PointF>();
			foreach (var point in shape.Points)
			{
				this.Points.Add(new PointF(point.X, point.Y));
			}
			this.rectangle = new RectangleF(shape.Location.X, shape.Location.Y, shape.Rectangle.Width, shape.Rectangle.Height);
			this.Angle = shape.Angle;
			this.Location = new PointF(shape.Location.X,shape.Location.Y);
			this.Opacity = shape.Opacity;
			this.borderthickness = shape.borderthickness;
			this.FillColor = shape.FillColor;
			this.BorderColor = shape.BorderColor;
			this.Name = "Shape";
		}
		#endregion

		#region Properties
		/// <summary>
		/// Име на елемента.
		/// </summary>
		protected string name;
		public virtual string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// Обхващащ правоъгълник на елемента.
		/// </summary>
		protected RectangleF rectangle;		
		public virtual RectangleF Rectangle {
			get { return rectangle; }
			set { rectangle = value; }
		}
		
		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public virtual float Width {
			get { return Rectangle.Width; }
			set { rectangle.Width = value; }
		}
		
		/// <summary>
		/// Височина на елемента.
		/// </summary>
		public virtual float Height {
			get { return Rectangle.Height; }
			set { rectangle.Height = value; }
		}

		/// <summary>
		/// Ъгъл на ротация (Слагам го тук, защото завъртам примитива около центъра му, който трябва да се изчислява всеки път, иначе изображението не се движи заедно с мишката).
		/// </summary>
		public virtual float Angle { get; set; }

		/// <summary>
		/// Горен ляв ъгъл на елемента.
		/// </summary>
		public virtual PointF Location {
			get { return Rectangle.Location; }
			set { rectangle.Location = value; }
		}
		
		/// <summary>
		/// Цвят на елемента.
		/// </summary>
		private Color fillColor;		
		public virtual Color FillColor {
			get { return fillColor; }
			set { fillColor = value; }
		}

		/// <summary>
		/// Цвят на рамката.
		/// </summary>
		private Color borderColor;
		public virtual Color BorderColor
		{
			get { return borderColor; }
			set { borderColor = value; }
		}
		/// <summary>
		/// Проверка дали елемента е селектиран.
		/// </summary>
		public virtual bool IsSelected{ get; set; }

		/// <summary>
		/// Дебелина на рамката.
		/// </summary>
		private float borderthickness;
		public virtual float BorderThickness
		{
			get { return borderthickness; }
			set { borderthickness = value; }
		}

		/// <summary>
		/// Прозрачност на елемента.
		/// </summary>
		private int opacity;
		public virtual int Opacity
		{
			get { return opacity; }
			set { opacity = value; }
		}
		/// <summary>
		/// Матрица за манипулиране.
		/// </summary>
		[field:NonSerialized]
		private Matrix transformMatrix;
		public virtual Matrix TransformMatrix
		{
			get { return transformMatrix; }
			set { transformMatrix = value; }
		}
		#endregion

		public virtual List<PointF> Points { get; set; }

		/// <summary>
		/// Проверка дали точка point принадлежи на елемента.
		/// </summary>
		/// <param name="point">Точка</param>
		/// <returns>Връща true, ако точката принадлежи на елемента и
		/// false, ако не пренадлежи</returns>
		public virtual bool Contains(PointF point)
		{
			return Rectangle.Contains(point);
		}

		public virtual PointF TranslatePoint(PointF point)
        {
			PointF[] points = new PointF[1];
			points[0] = point;
			Matrix inverse;
			inverse = TransformMatrix;
			inverse.Invert();
			inverse.TransformPoints(points);
			return points[0];
		}

		/// <summary>
		/// Визуализира елемента.
		/// </summary>
		/// <param name="grfx">Къде да бъде визуализиран елемента.</param>
		public virtual void DrawSelf(Graphics grfx)
		{
			TransformMatrix = new Matrix();
			TransformMatrix.RotateAt(Angle,Location);
			grfx.Transform = transformMatrix;
		}

		public virtual void Dispose()
        {
			name = null;
			transformMatrix = null;
			Points.Clear();
        }
    }
}

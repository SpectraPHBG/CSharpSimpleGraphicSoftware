using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Draw
{
	[Serializable]
	public class GroupShape : Shape
    {
		#region Constructor

		public GroupShape():base()
		{
			Shapes = new List<Shape>();
			rectangle = new RectangleF(0, 0, 0, 0);
			TransformMatrix = new Matrix();
		}

		public GroupShape(RectangleF rect) : base(rect)
		{
			Shapes = new List<Shape>();
			TransformMatrix = new Matrix();
		}

		public GroupShape(GroupShape groupShape) : base(groupShape)
		{
			Shapes = new List<Shape>();
			TransformMatrix = new Matrix();
		}

		#endregion

		#region Properties
		/// <summary>
		/// Обхващащ правоъгълник на елемента.
		/// </summary>
		public override RectangleF Rectangle
		{
			get { return rectangle; }
			set { rectangle = value; }
		}

		/// <summary>
		/// Име на елемента.
		/// </summary>
		public override string Name
		{
			get { return name; }
			set
			{
				if (value.Contains("[G] "))
				{
					name = value;
				}
				else
				{
					name = "[G] " + value;
				}
			}
		}

		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public override float Width
		{
			get 
			{ 
				return Rectangle.Width; 
			}
			set 
			{ 
				foreach(var shape in Shapes)
                {
					shape.Width = value;
                }
				rectangle.Width = value; 
			}
		}

		/// <summary>
		/// Височина на елемента.
		/// </summary>
		public override float Height
		{
			get
			{
				return Rectangle.Height;
			}
			set
			{
				foreach (var shape in Shapes)
				{
					shape.Height = value;
				}
				rectangle.Height = value;
			}
		}

		/// <summary>
		/// Горен ляв ъгъл на елемента/ в групата локацията на всеки елемент е локацията на групата плюс разликата между горния ляв ъгъл на елемента и горния ляв ъгъл на групата.
		/// </summary>
		public override PointF Location
		{
			get
			{
				if (Shapes.Count > 0)
				{
					if (rectangle.Location != Shapes[0].Location)
					{
						rectangle.Location = Shapes[0].Location;
					}
				}
				return Rectangle.Location;
			}
			set
			{
				if (Shapes.Count > 0)
				{
                    if (Location != Shapes[0].Location)
                    {
						rectangle.Location = Shapes[0].Location;
					}
				}
				//при движението на групата запазваме същия offset между горния ляв ъгъл на всеки от елементите в групата и горния ляв ъгъл на самата група
				foreach (var shape in Shapes)
				{
					shape.Location = new PointF(shape.Location.X + (value.X - rectangle.Location.X), shape.Location.Y + (value.Y - rectangle.Location.Y));
				}
				if (Shapes.Count > 0)
				{
					rectangle.Location = Shapes[0].Location;
				}
				else
				{
					rectangle.Location = value;
				}
			}
		}

		/// <summary>
		/// Цвят на елемента.
		/// </summary>
		private Color fillColor;
		public override Color FillColor
		{
			get
			{
				return fillColor;
			}
			set
			{
				foreach (var shape in Shapes)
				{
					shape.FillColor = value;
				}
				fillColor = value;
			}
		}

		/// <summary>
		/// Цвят на рамката.
		/// </summary>
		private Color borderColor;
		public override Color BorderColor
		{
			get
			{
				return borderColor;
			}
			set
			{
				foreach (var shape in Shapes)
				{
					shape.BorderColor = value;
				}
				borderColor = value;
			}
		}

		/// <summary>
		/// Дебелина на рамката.
		/// </summary>
		private float borderthickness;
		public override float BorderThickness
		{
			get
			{
				return borderthickness;
			}
			set
			{
				foreach (var shape in Shapes)
				{
					shape.BorderThickness = value;
				}
				borderthickness = value;
			}
		}

		/// <summary>
		/// Прозрачност на елемента.
		/// </summary>
		private int opacity;
		public override int Opacity
		{
			get
			{
				return opacity;
			}
			set
			{
				foreach (var shape in Shapes)
				{
					shape.Opacity = value;
				}
				opacity = value;
			}
		}

		/// <summary>
		/// Ъгъл на ротация (Слагам го тук, защото завъртам примитива около центъра му, който трябва да се изчислява всеки път, иначе изображението не се движи заедно с мишката).
		/// </summary>
		private float angle;
		public override float Angle 
		{
			get
			{
				return angle;
			}

			set
			{
				//без тази проверка се транслират вече транслирани точки и при това с различен предишен градус понякога и фигурата от групата се размества
				if (angle != 0)
				{
					foreach (var shape in Shapes)
					{
                        using (Matrix invertTransform = new Matrix())
                        {
							invertTransform.RotateAt(Angle, Location);
							invertTransform.Invert();
							PointF[] points = { shape.Location };
							invertTransform.TransformPoints(points);
							shape.Location = points[0];
						}					
					}
				}
				//алтернативата на това в dialog processor да проверявам дали селектирания елемент е група и просто да му сетна ъгъла вместо да го добавям, защото иначе всеки път като завъртя групата тя ще се завърта с все по-голям ъгъл
				float toAddAngle = Math.Abs(angle - value);
				angle = value;
				foreach (var shape in Shapes)
				{
					shape.Angle += toAddAngle;
					if (shape.Angle > 360)
					{
						shape.Angle -= 360;
					}
					PointF[] points = { shape.Location };
                    using (Matrix transformMatrix = new Matrix())
                    {
						transformMatrix.RotateAt(Angle, Location);
						transformMatrix.TransformPoints(points);
						//if(Shapes[0].Location.X-points[0].X==)
						shape.Location = points[0];
					}
				}
			} 
		}

		/// <summary>
		/// Проверка дали елемента е селектиран.
		/// </summary>
		public override bool IsSelected 
		{
            get
            {
                if (Shapes.Count > 0)
                {
					return Shapes[0].IsSelected;
                }
                else
                {
					return false;
                }
            }
            set
            {
                foreach (var shape in Shapes)
                {
					shape.IsSelected = value;
                }
            }
		}
		public List<Shape> Shapes { get; set; } = new List<Shape>();
		#endregion

		/// <summary>
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		public override bool Contains(PointF point)
		{
			foreach(var shape in Shapes)
            {
				if (shape.Contains(point))
				{
					return true;
				}
            }
			return false;
		}

		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			foreach (var shape in Shapes)
            {
				shape.DrawSelf(grfx);
            }
		}

        public override void Dispose()
        {
            foreach (var shape in Shapes)
            {
				shape.Dispose();
            }
			Shapes.Clear();
        }
    }
}

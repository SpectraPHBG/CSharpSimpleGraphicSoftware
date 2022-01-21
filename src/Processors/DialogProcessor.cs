using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.ListBox;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		#region Constructor
		
		public DialogProcessor()
		{
			Selection = new List<Shape>();
			ClipboardShapes = new List<Shape>();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Избран елемент.
		/// </summary>
		public List<Shape> Selection { get; set; }
		
		/// <summary>
		/// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
		/// </summary>
		public bool IsDragging {get;set;}

		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		public PointF LastLocation { get; set; }

		private Queue<float> widths = new Queue<float>();
		private Queue<float> heights = new Queue<float>();
		private Queue<float> locationXs = new Queue<float>();
		private Queue<float> locationYs = new Queue<float>();

		/// <summary>
		/// Временно запазени елементи, за копиране и поставяне
		/// </summary>
		public List<Shape> ClipboardShapes { get; set; }

		#endregion

		/// <summary>
		/// Проверява дали дадена точка е в елемента.
		/// Обхожда в ред обратен на визуализацията с цел намиране на
		/// "най-горния" елемент т.е. този който виждаме под мишката.
		/// </summary>
		/// <param name="point">Указана точка</param>
		/// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
		public Shape ContainsPoint(PointF point, List<Shape> currentCollection)
		{
			for(int i = currentCollection.Count - 1; i >= 0; i--)
			{
				if (currentCollection[i].Contains(point))
				{
					return currentCollection[i];
				}
			}
			return null;
		}

		/// <summary>
		/// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		public void TranslateTo(PointF p)
		{
			foreach (var selection in Selection) {
				if (selection != null)
				{
					selection.Location = new PointF(selection.Location.X + p.X - LastLocation.X, selection.Location.Y + p.Y - LastLocation.Y);
				}
			}
			LastLocation = p;
		}

		/// <summary>
		/// Завъртане на изображението надясно
		/// </summary>
		public void Rotate(float angle)
		{
			foreach (var selection in Selection)
			{
				selection.Angle += angle;
				if (selection.Angle > 360)
				{
					selection.Angle -= 360;
				}
			}
		}
		/// <summary>
		/// Изрязване на примитиви
		/// </summary>
		public void Cut(List<Shape> currentCollection)
		{
			ClipboardShapes.Clear();
			foreach (var selection in Selection)
			{
                if (!ClipboardShapes.Contains(selection))
                {
					selection.IsSelected = false;
					ClipboardShapes.Add(selection);
                }
				if (currentCollection.Contains(selection))
                {
					currentCollection.Remove(selection);
                }
			}
			Selection.Clear();
		}
		/// <summary>
		/// Копиране на примитиви
		/// </summary>
		public void Copy()
		{
			ClipboardShapes.Clear();
			foreach (var selection in Selection)
			{
				if (!ClipboardShapes.Contains(selection))
				{
					selection.IsSelected = false;
					ClipboardShapes.Add(selection);
				}
			}
			Selection.Clear();
		}

		/// <summary>
		/// Премахване на всяка селектирана група от примитиви
		/// </summary>
		public void DisbandGroup(List<Shape> currentCollection)
		{
			foreach (var selection in Selection)
			{
				//ако променям как се изобразява селектиран елемент да променя реда отдолу
				selection.IsSelected=false;
				if (selection is GroupShape)
				{
					GroupShape group = selection as GroupShape;

					foreach (var shape in group.Shapes)
					{
						currentCollection.Add(shape);
					}

					currentCollection.Remove(selection);
				}
			}
			ClearSelection();
		}

		/// <summary>
		/// Селектиране на всички примитиви
		/// </summary>
		public void SelectAll()
		{
			foreach (var shape in ShapeList)
			{
				shape.IsSelected = true;
				if (!Selection.Contains(shape))
				{
					Selection.Add(shape);
				}
			}
		}

		/// <summary>
		/// Сливане на групи в една цяла група
		/// </summary>
		public void MergeSelectedGroups(List<Shape> currentCollection)
		{
			GroupShape group = new GroupShape();
			for (int i = 0; i < currentCollection.Count; i++)
			{
				if (!group.Shapes.Contains(currentCollection[i]) && Selection.Contains(currentCollection[i]))
				{
					if (group.Shapes.Count == 0)
					{
						group.Location = currentCollection[i].Location;
					}
					//ако променям как се изобразява селектиран елемент да променя реда отдолу
					currentCollection[i].IsSelected = false;
					if (currentCollection[i] is GroupShape)
					{
						group.Shapes.AddRange((currentCollection[i] as GroupShape).Shapes);
					}
					else
					{
						group.Shapes.Add(currentCollection[i]);
					}
				}
			}
			foreach (var selection in Selection)
			{
				currentCollection.Remove(selection);
			}
			Selection.Clear();
			if (currentCollection.Count > 0)
			{
				currentCollection.Add(group);
			}
		}

		/// <summary>
		/// Дублиране на селектираните примитиви
		/// </summary>
		//private GroupShape groupCopy = null;
		public void DublicateAllSelected(List<Shape> currentCollection,GroupShape group=null)
		{
			foreach (var shape in currentCollection)
			{
				if(shape is RectangleShape)
                {
					RectangleShape rect = new RectangleShape((shape as RectangleShape));
                    if (currentCollection != Selection && group != null)
                    {
						group.Shapes.Add(rect);
                    }
                    else
                    {
						ShapeList.Add(rect);
					}
				}
				if (shape is EllipseShape)
				{
					EllipseShape ellipse = new EllipseShape((shape as EllipseShape));
					if (currentCollection != Selection && group != null)
					{
						group.Shapes.Add(ellipse);
					}
					else
					{
						ShapeList.Add(ellipse);
					}
				}
				if (shape is LineShape)
				{
					LineShape line = new LineShape((shape as LineShape));
					if (currentCollection != Selection && group != null)
					{
						group.Shapes.Add(line);
					}
					else
					{
						ShapeList.Add(line);
					}
				}
				if (shape is TriangleShape)
				{
					TriangleShape triangle = new TriangleShape((shape as TriangleShape));
					if (currentCollection != Selection && group != null)
					{
						group.Shapes.Add(triangle);
					}
					else
					{
						ShapeList.Add(triangle);
					}
				}
				if (shape is GroupShape)
				{
					GroupShape groupCopy = new GroupShape((shape as GroupShape));
					DublicateAllSelected((shape as GroupShape).Shapes,groupCopy);
					if (currentCollection != Selection && group!=null)
					{
						group.Shapes.Add(groupCopy);
					}
					else
					{
						ShapeList.Add(groupCopy);
					}
				}
			}
		}

		/// <summary>
		/// Селектиране на всички примитиви
		/// </summary>
		public void DeleteSelected(List<Shape> collection)
		{
			foreach (var selection in Selection)
			{
				collection.Remove(selection);
			}
			Selection.Clear();
		}

		/// <summary>
		/// Създаване на селектирана група от примитиви
		/// </summary>
		public void CreateGroup(List<Shape> currentCollection)
		{
			if (Selection.Count > 0)
			{
				GroupShape group = new GroupShape();
                for (int i = 0; i < currentCollection.Count; i++)
                {
					if (!group.Shapes.Contains(currentCollection[i]) && Selection.Contains(currentCollection[i]))
					{
						if (group.Shapes.Count == 0)
						{
							group.Location = currentCollection[i].Location;
						}
						//ако променям как се изобразява селектиран елемент да променя реда отдолу
						currentCollection[i].IsSelected = false;
						group.Shapes.Add(currentCollection[i]);
					}
				}
				foreach (var selection in Selection)
				{
					currentCollection.Remove(selection);
				}
				Selection.Clear();
				if (!currentCollection.Contains(group))
				{
					currentCollection.Add(group);
				}
			}
		}

		/// <summary>
		/// Изпразване на селекцията от примитиви
		/// </summary>
		public void ClearSelection()
		{
			foreach (var selection in Selection)
			{
				selection.IsSelected=false;
			}
			Selection.Clear();

		}

		/// <summary>
		/// Нулиране на завъртането
		/// </summary>
		public void ResetRotate()
		{
			foreach (var selection in Selection)
			{
				selection.Angle += 360 - selection.Angle;
			}
		}

		/// <summary>
		/// Промяна на избраните индекси назад
		/// </summary>
		public void ShapeOrderUp(List<Shape> collection, SelectedIndexCollection indices)
		{
			foreach (int index in indices)
			{
				if (index > 0 && index < collection.Count)
				{
					Shape shapeToMove = collection[index];
					collection[index] = collection[index - 1];
					collection[index - 1] = shapeToMove;
				}
			}
		}
		/// <summary>
		/// Промяна на избраните индекси напред
		/// </summary>
		public void ShapeOrderDown(List<Shape> collection, SelectedIndexCollection indices)
		{
            for (int i = indices.Count-1; i >= 0; i--)
			{
				if (indices[i] >= 0 && indices[i] < collection.Count-1)
				{
					Shape shapeToMove = collection[indices[i]];
					collection[indices[i]] = collection[indices[i] + 1];
					collection[indices[i] + 1] = shapeToMove;
				}
			}
		}

		/// <summary>
		/// Промяна на визуализационните характеристики на елементите
		/// </summary>
		public void EditSelectedShapes(Color fillColor,Color borderColor,float borderThickness, int opacity,List<Shape> collection)
		{
			foreach (var selection in Selection)
			{
				selection.FillColor = fillColor;
				selection.BorderColor = borderColor;
				selection.BorderThickness = borderThickness;
				selection.Opacity = opacity;
			}
		}

		/// <summary>
		/// Променяне на размерите на селектираните фигури
		/// </summary>
		public void SetDimensions(float width,float height)
		{
            foreach (var selection in Selection)
            {
				if (width != -1)
					selection.Width = width;
				if (height != -1)
					selection.Height = height;
			}
		}
		/// <summary>
		/// Запазване на старите размери и позиции
		/// </summary>
		public void SaveOldDimensions(List<Shape> shapeCollection)
		{
            if (shapeCollection == Selection)
            {
				widths.Clear();
				heights.Clear();
				locationXs.Clear();
				locationYs.Clear();
            }
			foreach (var shape in shapeCollection)
			{
				if (shape is GroupShape)
				{
					//locationXs.Enqueue(shape.Location.X);
					//locationYs.Enqueue(shape.Location.Y);
					SaveOldDimensions((shape as GroupShape).Shapes);
				}
				else
				{
					widths.Enqueue(shape.Width);
					heights.Enqueue(shape.Height);
					locationXs.Enqueue(shape.Location.X);
					locationYs.Enqueue(shape.Location.Y);
				}
			}
		}
		/// <summary>
		/// Запазване на старите размери и позиции
		/// </summary>
		public void RestoreOldDimensions(List<Shape> shapeCollection)
		{
			foreach (var shape in shapeCollection)
			{
				if (shape is GroupShape)
				{
					RestoreOldDimensions((shape as GroupShape).Shapes);
					shape.Location = (shape as GroupShape).Shapes[0].Location;
				}
				else
				{
                    if (widths.Count > 0 && heights.Count > 0 && locationXs.Count > 0 && locationYs.Count > 0)
                    {
						shape.Width = widths.Dequeue();
						shape.Height = heights.Dequeue();
						shape.Location = new PointF(locationXs.Dequeue(), locationYs.Dequeue());
					}
				}
			}

		}
		/// <summary>
		/// Мащабиране на изображението
		/// </summary>
		private bool stopFlag = false;
		public void Scale(float scaleMargin,List<Shape> shapeCollection)
		{
			Shape anchor = shapeCollection[0];
			float proportionX = 0,proportionY=0;
            if (shapeCollection == Selection)
            {
				stopFlag = false;
				SaveOldDimensions(shapeCollection);
			}
			foreach (var selection in shapeCollection)
			{
				if (selection is GroupShape)
				{
					Scale(scaleMargin, (selection as GroupShape).Shapes);
				}
				else
				{
					if (!stopFlag)
					{
						float oldWidth = selection.Width, oldHeight = selection.Height;
						selection.Width = selection.Width * scaleMargin;
						selection.Height = selection.Height * scaleMargin;
						if ((selection.Width == oldWidth || selection.Height == oldHeight))
						{
							RestoreOldDimensions(Selection);
							stopFlag = true;
							break;
						}
					}
				}
			}
			if (!stopFlag)
			{
				for (int i = 0; i < shapeCollection.Count; i++)
				{
                    proportionX = shapeCollection[i].Location.X - anchor.Location.X;
                    proportionX *= scaleMargin;
                    proportionY = shapeCollection[i].Location.Y - anchor.Location.Y;
                    proportionY *= scaleMargin;
                    shapeCollection[i].Location = new PointF(anchor.Location.X + proportionX, anchor.Location.Y + proportionY);
                }
			}
		}
	}
}


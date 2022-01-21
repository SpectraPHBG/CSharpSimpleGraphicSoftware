using Draw.src.GUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
		private List<Shape> currentCollection;
		private int opacity =100;
		private List<PointF> Points = new List<PointF>();

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			FillColorByNameCMB.SelectedItem = "White";
			BorderColorByNameCMB.SelectedItem = "Black";
			OpacitySelectedCMB.SelectedIndex = 4;
			currentCollection = dialogProcessor.ShapeList;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}

		//Запълва прозореца със съществуващи примитиви с избраната от нас колекция
		void FillShapeDisplayer(List<Shape> collection)
        {
			ShapeDisplayerLB.Items.Clear();
			foreach (var shape in collection)
			{
				ShapeDisplayerLB.Items.Add(shape.Name);
			}
		}

		//задава подадените width и height към селектираните елементи в прозореца с примитиви
		public void SetDimensions(float width,float height)
		{
			dialogProcessor.SetDimensions(width, height);
			statusBar.Items[0].Text = "Последно действие: Промяна на размер на примитив/и.";
			viewPort.Invalidate();
		}
		public void SetOpacity(int value)
        {
			opacity = value;
			OpacitySelectorL.Text = $"Opacity: {value}%";
        }
		void SaveShape()
        {
			SaveModelSFD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			SaveModelSFD.RestoreDirectory = true;//отваря папката, в която сме били последно (ако съм разбрал правилно)
			if (SaveModelSFD.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.ClearSelection();
				viewPort.Invalidate();
				Stream saveFileStream;
				saveFileStream = SaveModelSFD.OpenFile();
				if (saveFileStream != null)
				{
					BinaryFormatter formatter = new BinaryFormatter();
					formatter.Serialize(saveFileStream, dialogProcessor.ShapeList);
					saveFileStream.Close();
				}
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveShape();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenModelSFD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			OpenModelSFD.RestoreDirectory = true;//отваря папката, в която сме били последно (ако съм разбрал правилно)
			if (OpenModelSFD.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.ClearSelection();
				dialogProcessor.ShapeList.Clear();
				Stream openFileStream;
				openFileStream = OpenModelSFD.OpenFile();
				if (openFileStream != null)
				{
					BinaryFormatter formatter = new BinaryFormatter();

					try
					{
						List<Shape> shapeList = formatter.Deserialize(openFileStream) as List<Shape>;
						dialogProcessor.ShapeList = shapeList;
					}
					catch (System.Runtime.Serialization.SerializationException)
					{
						statusBar.Items[0].Text = "Грешка! Файлът е повреден или е променян!";
					}
					openFileStream.Close();
				}
				currentCollection = dialogProcessor.ShapeList;
				FillShapeDisplayer(dialogProcessor.ShapeList);
				Points.Clear();
				OpacitySelectedCMB.Enabled = true;
				OpacitySelectedCMB.SelectedIndex = 4;
				FillColorBTN.Enabled = true;
				FillColorByNameCMB.Enabled = true;
				BorderColorBTN.Enabled = true;
				BorderColorByNameCMB.Enabled = true;
				BorderThickNUD.Enabled = true;
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            #region Изрисуване на примитиви
            if (drawRectangleSpeedButton.Checked || drawEllipseSpeedButton.Checked || drawLineSpeedButton.Checked || drawExamShapeSpeedButton.Checked)
            {
				if (Points.Count+1 == 2)
                {
					if (drawRectangleSpeedButton.Checked)
					{
						Points.Add(new PointF(e.Location.X, e.Location.Y));
						statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник.";
						dialogProcessor.DrawRectangle(Points, FillColorBTN.BackColor, BorderColorBTN.BackColor, (float)BorderThickNUD.Value, opacity);
						Points.Clear();
						FillShapeDisplayer(dialogProcessor.ShapeList);
						viewPort.Invalidate();
						return;
					}
					if (drawEllipseSpeedButton.Checked)
					{
						Points.Add(new PointF(e.Location.X, e.Location.Y));
						statusBar.Items[0].Text = "Последно действие: Рисуване на елипса.";
						dialogProcessor.DrawEllipse(Points, FillColorBTN.BackColor, BorderColorBTN.BackColor, (float)BorderThickNUD.Value, opacity);
						Points.Clear();
						FillShapeDisplayer(dialogProcessor.ShapeList);
						viewPort.Invalidate();
						return;
					}
					if (drawLineSpeedButton.Checked)
					{
						Points.Add(new PointF(e.Location.X, e.Location.Y));
						statusBar.Items[0].Text = "Последно действие: Рисуване на линия.";
						dialogProcessor.DrawLine(Points, BorderColorBTN.BackColor, (float)BorderThickNUD.Value, opacity);
						Points.Clear();
						FillShapeDisplayer(dialogProcessor.ShapeList);
						viewPort.Invalidate();
						return;
					}
					if (drawExamShapeSpeedButton.Checked)
					{
						Points.Add(new PointF(e.Location.X, e.Location.Y));
						statusBar.Items[0].Text = "Последно действие: Рисуване на примитив за изпит.";
						dialogProcessor.DrawExamShape(Points, FillColorBTN.BackColor, BorderColorBTN.BackColor, (float)BorderThickNUD.Value, opacity);
						Points.Clear();
						FillShapeDisplayer(dialogProcessor.ShapeList);
						viewPort.Invalidate();
						return;
					}
				}
                else
                {
					Points.Add(new PointF(e.Location.X, e.Location.Y));
				}
            }
			else if (drawTriangleSpeedButton.Checked)
            {
				if (Points.Count + 1 == 3)
				{
					Points.Add(new PointF(e.Location.X, e.Location.Y));
					statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник.";
					dialogProcessor.DrawTriangle(Points, FillColorBTN.BackColor, BorderColorBTN.BackColor, (float)BorderThickNUD.Value, opacity);
					Points.Clear();
					FillShapeDisplayer(dialogProcessor.ShapeList);
					viewPort.Invalidate();
					return;
				}
				else
				{
					Points.Add(new PointF(e.Location.X, e.Location.Y));
				}
			}
			else
			{
				Points.Clear();
			}
            #endregion


            #region Селекция на примитив
            if (pickUpSpeedButton.Checked)
			{
				Shape newShape = dialogProcessor.ContainsPoint(e.Location,currentCollection);
				if (newShape != null)
				{
					statusBar.Items[0].Text = "Последно действие: Селекция на примитив.";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
					DeleteShapeBTN.Enabled = true;
					EditShapeBTN.Enabled = true;
					if (ModifierKeys == Keys.Control)
					{
						if (!dialogProcessor.Selection.Contains(newShape))
						{
							newShape.IsSelected = true;
							dialogProcessor.Selection.Add(newShape);
                            if (dialogProcessor.ShapeList.IndexOf(newShape) >= 0 && currentCollection==dialogProcessor.ShapeList)
                            {
								ShapeDisplayerLB.SelectedIndices.Add(dialogProcessor.ShapeList.IndexOf(newShape));
							}
						}
					}
					else
					{
						foreach (var selection in dialogProcessor.Selection)
						{
							selection.IsSelected = false;
						}
						dialogProcessor.ClearSelection();
						newShape.IsSelected = true;
						dialogProcessor.Selection.Add(newShape);
						ShapeDisplayerLB.ClearSelected();
						if (dialogProcessor.ShapeList.IndexOf(newShape) >= 0 && currentCollection == dialogProcessor.ShapeList)
						{
							ShapeDisplayerLB.SelectedIndices.Add(dialogProcessor.ShapeList.IndexOf(newShape));
						}
					}
					viewPort.Invalidate();

				}
				else
				{
					foreach (var selection in dialogProcessor.Selection)
					{
						selection.IsSelected = false;
					}
					ShapeDisplayerLB.ClearSelected();
					dialogProcessor.Selection.Clear();
					DeleteShapeBTN.Enabled = false;
					EditShapeBTN.Enabled = false;
					viewPort.Invalidate();
				}
			}
			#endregion

		}

        /// <summary>
        /// Прихващане на преместването на мишката.
        /// Ако сме в режм на "влачене", то избрания елемент се транслира.
        /// </summary>
        void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging && pickUpSpeedButton.Checked==true )
			{
				if (dialogProcessor.Selection.Count > 0)
				{
					statusBar.Items[0].Text = "Последно действие: Влачене.";
					dialogProcessor.TranslateTo(e.Location);

				}
				viewPort.Invalidate();
			}

		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		private void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			Points.Clear();
			OpacitySelectedCMB.Enabled = true;
			FillColorBTN.Enabled = true;
			FillColorByNameCMB.Enabled = true;
			BorderColorBTN.Enabled = true;
			BorderColorByNameCMB.Enabled = true;
			BorderThickNUD.Enabled = true;
		}

		private void drawEllipseSpeedButton_Click(object sender, EventArgs e)
        {
			Points.Clear();
			OpacitySelectedCMB.Enabled = true;
			FillColorBTN.Enabled = true;
			FillColorByNameCMB.Enabled = true;
			BorderColorBTN.Enabled = true;
			BorderColorByNameCMB.Enabled = true;
			BorderThickNUD.Enabled = true;
		}

        private void drawLineSpeedButton_Click(object sender, EventArgs e)
        {
			Points.Clear();
			OpacitySelectedCMB.Enabled = true;
			FillColorBTN.Enabled = false;
			FillColorByNameCMB.Enabled = true;
			BorderColorBTN.Enabled = false;
			BorderColorByNameCMB.Enabled = false;
			BorderThickNUD.Enabled = true;
		}

        private void drawTriangleSpeedButton_Click(object sender, EventArgs e)
        {
			Points.Clear();
			OpacitySelectedCMB.Enabled = true;
			FillColorBTN.Enabled = true;
			FillColorByNameCMB.Enabled = true;
			BorderColorBTN.Enabled = true;
			BorderColorByNameCMB.Enabled = true;
			BorderThickNUD.Enabled = true;
		}
		private void drawExamShapeSpeedButton_Click(object sender, EventArgs e)
		{
			Points.Clear();
			OpacitySelectedCMB.Enabled = true;
			FillColorBTN.Enabled = true;
			FillColorByNameCMB.Enabled = true;
			BorderColorBTN.Enabled = true;
			BorderColorByNameCMB.Enabled = true;
			BorderThickNUD.Enabled = true;
		}

		private void drawRectangleSpeedButton_CheckedChanged(object sender, EventArgs e)
		{
			if (drawRectangleSpeedButton.Checked)
			{
				pickUpSpeedButton.Checked = false;
				drawEllipseSpeedButton.Checked = false;
				drawLineSpeedButton.Checked = false;
				drawTriangleSpeedButton.Checked = false;
				drawExamShapeSpeedButton.Checked = false;
			}
		}

		private void drawEllipseSpeedButton_CheckedChanged(object sender, EventArgs e)
		{
			if (drawEllipseSpeedButton.Checked)
			{
				pickUpSpeedButton.Checked = false;
				drawRectangleSpeedButton.Checked = false;
				drawLineSpeedButton.Checked = false;
				drawTriangleSpeedButton.Checked = false;
				drawExamShapeSpeedButton.Checked = false;
			}
		}

		private void drawLineSpeedButton_CheckedChanged(object sender, EventArgs e)
		{
			if (drawLineSpeedButton.Checked)
			{
				pickUpSpeedButton.Checked = false;
				drawEllipseSpeedButton.Checked = false;
				drawRectangleSpeedButton.Checked = false;
				drawTriangleSpeedButton.Checked = false;
			}
		}
		private void drawExamShapeSpeedButton_CheckedChanged(object sender, EventArgs e)
		{
			if (drawExamShapeSpeedButton.Checked)
			{
				pickUpSpeedButton.Checked = false;
				drawEllipseSpeedButton.Checked = false;
				drawRectangleSpeedButton.Checked = false;
				drawLineSpeedButton.Checked = false;
				drawTriangleSpeedButton.Checked = false;
			}
		}
		private void drawTriangleSpeedButton_CheckedChanged(object sender, EventArgs e)
		{
			if (drawTriangleSpeedButton.Checked)
			{
				pickUpSpeedButton.Checked = false;
				drawEllipseSpeedButton.Checked = false;
				drawRectangleSpeedButton.Checked = false;
				drawLineSpeedButton.Checked = false;
				drawExamShapeSpeedButton.Checked = false;
			}
		}

		private void EditShapeBTN_Click(object sender, EventArgs e)
		{
			int opacity = int.Parse(OpacitySelectedCMB.SelectedItem.ToString().Trim(new char[] { '%' }));
			dialogProcessor.EditSelectedShapes(FillColorColorDialog.Color, BorderColorColorDialog.Color, (float)BorderThickNUD.Value, opacity,currentCollection);
			dialogProcessor.ClearSelection();
			statusBar.Items[0].Text = "Последно действие: Промяна на изгледа на примитив/и.";
			viewPort.Invalidate();
		}

		private void DeleteShapeBTN_Click(object sender, EventArgs e)
        {

			if (dialogProcessor.Selection != null && dialogProcessor.Selection.Count>0)
			{
				statusBar.Items[0].Text = "Последно действие: Изтриване на примитив/и.";
				dialogProcessor.DeleteSelected(currentCollection);
				dialogProcessor.ClearSelection();
				FillShapeDisplayer(currentCollection);
			}
			//FillShapeDisplayer(dialogProcessor.ShapeList);
			viewPort.Invalidate();
		}

        private void FillColorBTN_Click(object sender, EventArgs e)
        {
			DialogResult fillColorResult=FillColorColorDialog.ShowDialog();
            if (fillColorResult == DialogResult.OK)
            {
				FillColorBTN.BackColor = FillColorColorDialog.Color;
            }
        }

		private void BorderColorBTN_Click(object sender, EventArgs e)
		{
			DialogResult borderColorResult = BorderColorColorDialog.ShowDialog();
			if (borderColorResult == DialogResult.OK)
			{
				BorderColorBTN.BackColor = BorderColorColorDialog.Color;
			}
		}

		private void Plus50BTN_Click(object sender, EventArgs e)
        {
			if (dialogProcessor.Selection != null && dialogProcessor.Selection.Count > 0)
			{
				dialogProcessor.Scale(1.5F, dialogProcessor.Selection);
				statusBar.Items[0].Text = "Последно действие: Промяна на размер на примитив/и.";
				viewPort.Invalidate();
			}
		}

        private void Plus25BTN_Click(object sender, EventArgs e)
        {
			if (dialogProcessor.Selection != null && dialogProcessor.Selection.Count > 0)
			{
				dialogProcessor.Scale(1.25F,dialogProcessor.Selection);
				statusBar.Items[0].Text = "Последно действие: Промяна на размер на примитив/и.";
				viewPort.Invalidate();
			}
		}

        private void Minus25BTN_Click(object sender, EventArgs e)
        {
			if (dialogProcessor.Selection != null && dialogProcessor.Selection.Count > 0)
			{
				//dialogProcessor.Scale(1/1.25F);
				dialogProcessor.Scale(0.75F, dialogProcessor.Selection);
				statusBar.Items[0].Text = "Последно действие: Промяна на размер на примитив/и.";
				viewPort.Invalidate();
			}
		}

        private void Minus50BTN_Click(object sender, EventArgs e)
        {
			if (dialogProcessor.Selection != null && dialogProcessor.Selection.Count > 0)
			{
				//dialogProcessor.Scale(1/1.5F);
				dialogProcessor.Scale(0.5F, dialogProcessor.Selection);
				statusBar.Items[0].Text = "Последно действие: Промяна на размер на примитив/и.";
				viewPort.Invalidate();
			}
		}

        private void groupSelectedBTN_Click(object sender, EventArgs e)
        {
			dialogProcessor.CreateGroup(currentCollection);
			statusBar.Items[0].Text = "Последно действие: Създаване на група от примитиви.";
			FillShapeDisplayer(currentCollection);
			viewPort.Invalidate();
		}

        private void RotateBTN_Click(object sender, EventArgs e)
        {
			float rotationAngle = 0;

			try
			{
				if (rotateAngle.Text.Length <= 8)
				{
					rotationAngle = float.Parse(rotateAngle.Text);
				}
				if (rotationAngle < 0)
				{
					rotationAngle = 360 + rotationAngle;
					statusBar.Items[0].Text = rotationAngle.ToString();

				}
				while (true)
				{
					if (rotationAngle > 360)
					{
						rotationAngle -= 360;
					}
					else
					{
						break;
					}
				}
				dialogProcessor.Rotate(rotationAngle);
				viewPort.Invalidate();
				statusBar.Items[0].Text = "Последно действие: Завъртане на примитив/и.";
			}
			catch (FormatException)
			{
				statusBar.Items[0].Text = "Грешка: Грешен формат на ъгъл на завъртане!";
			}


		}

        private void rotateResetBTN_Click(object sender, EventArgs e)
        {
			dialogProcessor.ResetRotate();
			viewPort.Invalidate();
		}

        private void deleteSelectedGroupBTN_Click(object sender, EventArgs e)
        {
			dialogProcessor.DisbandGroup(currentCollection);
			FillShapeDisplayer(currentCollection);
			statusBar.Items[0].Text = "Последно действие: Разгрупиране на елементи.";
			viewPort.Invalidate();
        }

        private void FillColorByNameCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
			FillColorBTN.BackColor = Color.FromName(FillColorByNameCMB.SelectedItem.ToString());
		}

        private void BorderColorByNameCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
			BorderColorBTN.BackColor = Color.FromName(BorderColorByNameCMB.SelectedItem.ToString());
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				dialogProcessor.SelectAll();
				currentCollection = dialogProcessor.ShapeList;
				FillShapeDisplayer(currentCollection);
				for (int i = 0; i < ShapeDisplayerLB.Items.Count; i++)
				{
					ShapeDisplayerLB.SetSelected(i, true);
				}
				OpacitySelectedCMB.Enabled = true;
				OpacitySelectedCMB.SelectedIndex = 4;
				FillColorBTN.Enabled = true;
				FillColorByNameCMB.Enabled = true;
				BorderColorBTN.Enabled = true;
				BorderColorByNameCMB.Enabled = true;
				BorderThickNUD.Enabled = true;
				EditShapeBTN.Enabled = true;
				DeleteShapeBTN.Enabled = true;
				viewPort.Invalidate();
			}
			if (e.KeyCode == Keys.Delete)
			{
				dialogProcessor.DeleteSelected(currentCollection);
				currentCollection = dialogProcessor.ShapeList;
				FillShapeDisplayer(currentCollection);
				viewPort.Invalidate();
			}
			if (e.Control && e.KeyCode == Keys.J)
			{
				dialogProcessor.DublicateAllSelected(dialogProcessor.Selection);
				currentCollection = dialogProcessor.ShapeList;
				FillShapeDisplayer(currentCollection);
				viewPort.Invalidate();
			}
			if (e.Control && e.KeyCode == Keys.S)
			{
				SaveShape();
			}
			if (e.Control && e.KeyCode == Keys.C)
			{
				dialogProcessor.Copy();
			}
			if (e.Control && e.KeyCode == Keys.X)
			{
				dialogProcessor.Cut(currentCollection);
				viewPort.Invalidate();
			}
			if (e.Control && e.KeyCode == Keys.V)
			{
				dialogProcessor.DublicateAllSelected(dialogProcessor.ClipboardShapes);
				currentCollection = dialogProcessor.ShapeList;
				FillShapeDisplayer(currentCollection);
				viewPort.Invalidate();
			}
		}

		private void pickUpSpeedButton_CheckedChanged(object sender, EventArgs e)
        {
			if (pickUpSpeedButton.Checked)
			{
				drawTriangleSpeedButton.Checked = false;
				drawEllipseSpeedButton.Checked = false;
				drawLineSpeedButton.Checked = false;
				drawRectangleSpeedButton.Checked = false;
				drawExamShapeSpeedButton.Checked = false;
			}
		}

		private void ShapeNameChangeBTN_Click(object sender, EventArgs e)
		{
			string newName = ShapeNameChangeTB.Text;
			if (newName.Length < 1500)
			{
				for (int i = 0; i < ShapeDisplayerLB.Items.Count; i++)
				{
					if (ShapeDisplayerLB.SelectedIndices.Contains(i))
					{
						if (!ShapeNameChangeTB.Text.Trim().Equals(""))
							currentCollection[i].Name = newName;
					}
				}
				FillShapeDisplayer(currentCollection);
			}
			ShapeNameChangeTB.Text = "";
			statusBar.Items[0].Text = "Последно действие: Промяна името на примитив/и.";
			viewPort.Invalidate();
		}

        private void resetShapeDisplayerBTN_Click(object sender, EventArgs e)
        {
			currentCollection = dialogProcessor.ShapeList;
			FillShapeDisplayer(currentCollection);
			dialogProcessor.ClearSelection();
			ShapeDisplayerLB.ClearSelected();
			viewPort.Invalidate();
        }

		private void ShapeDisplayerLB_Click(object sender, EventArgs e)
		{

			if (ModifierKeys == Keys.Control)
			{
				for (int i = 0; i < ShapeDisplayerLB.Items.Count; i++)
				{
					if (!dialogProcessor.Selection.Contains(currentCollection[i]) && ShapeDisplayerLB.SelectedIndices.Contains(i))
					{
						currentCollection[i].IsSelected = true;
						dialogProcessor.Selection.Add(currentCollection[i]);
					}
				}
				viewPort.Invalidate();
			}
            else
            {
                if (currentCollection == dialogProcessor.ShapeList)
                {
					dialogProcessor.ClearSelection();
					viewPort.Invalidate();
				}
            }
		}

		private void ShapeDisplayerLB_DoubleClick(object sender, EventArgs e)
        {
            if (ShapeDisplayerLB.SelectedItems.Count == 1)
            {
				if (currentCollection[ShapeDisplayerLB.SelectedIndex] is GroupShape)
				{
					dialogProcessor.ClearSelection();
					currentCollection = (currentCollection[ShapeDisplayerLB.SelectedIndex] as GroupShape).Shapes;
					FillShapeDisplayer(currentCollection);
				}
			}
		}

		private void ShapeDisplayerLB_MouseDown(object sender, MouseEventArgs e)
		{
			//ако мишката е не е кликнала върху съществуващ елемент да се изчисти селекцията
			int index = ShapeDisplayerLB.IndexFromPoint(e.Location);
			if (index <= -1)
			{
				ShapeDisplayerLB.SelectedItems.Clear();
				dialogProcessor.ClearSelection();
				viewPort.Invalidate();
				EditShapeBTN.Enabled = false;
				DeleteShapeBTN.Enabled = false;
			}
            else
            {
				EditShapeBTN.Enabled = true;
				DeleteShapeBTN.Enabled = true;
			}
		}

        private void ChangeShapeOrderUp_Click(object sender, EventArgs e)
        {
			dialogProcessor.ShapeOrderUp(currentCollection, ShapeDisplayerLB.SelectedIndices);
			FillShapeDisplayer(currentCollection);
			ShapeDisplayerLB.ClearSelected();
			statusBar.Items[0].Text = "Последно действие: Промяна подредбата на примитиви.";
			viewPort.Invalidate();
        }

        private void ChangeShapeOrderDown_Click(object sender, EventArgs e)
        {
			dialogProcessor.ShapeOrderDown(currentCollection, ShapeDisplayerLB.SelectedIndices);
			FillShapeDisplayer(currentCollection);
			ShapeDisplayerLB.ClearSelected();
			statusBar.Items[0].Text = "Последно действие: Промяна подредбата на примитиви.";
			viewPort.Invalidate();
		}

        private void MergeGroupsBTN_Click(object sender, EventArgs e)
        {
			dialogProcessor.MergeSelectedGroups(currentCollection);
			currentCollection = dialogProcessor.ShapeList;
			FillShapeDisplayer(currentCollection);
			statusBar.Items[0].Text = "Последно действие: Сливане на групи от примитиви и елементи.";
			viewPort.Invalidate();
        }

        private void OpacityFormOpenBTN_Click(object sender, EventArgs e)
        {
			OpacitySelector selector = new OpacitySelector();
			selector.MainFormWindow = this;
			selector.ShowDialog();
		}

        private void OpacitySelectedCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
			OpacitySelectorL.Text = $"Opacity: {OpacitySelectedCMB.SelectedItem}";
			opacity = int.Parse(OpacitySelectedCMB.SelectedItem.ToString().Trim().Replace("%",""));
		}

        private void ResizeSelectedBTN_Click(object sender, EventArgs e)
        {
			DimensionsSelector selector = new DimensionsSelector();
			selector.MainFormWindow = this;
			selector.ShowDialog();
		}

        private void Minus90DegreesBTN_Click(object sender, EventArgs e)
        {
			dialogProcessor.Rotate(270);
			viewPort.Invalidate();
			statusBar.Items[0].Text = "Последно действие: Завъртане на примитив/и.";
		}

        private void Minus45DegreesBTN_Click(object sender, EventArgs e)
        {
			dialogProcessor.Rotate(315);
			viewPort.Invalidate();
			statusBar.Items[0].Text = "Последно действие: Завъртане на примитив/и.";
		}

        private void Plus45DegreesBTN_Click(object sender, EventArgs e)
        {
			dialogProcessor.Rotate(45);
			viewPort.Invalidate();
			statusBar.Items[0].Text = "Последно действие: Завъртане на примитив/и.";
		}

        private void Plus90DegreesBTN_Click(object sender, EventArgs e)
        {
			dialogProcessor.Rotate(90);
			viewPort.Invalidate();
			statusBar.Items[0].Text = "Последно действие: Завъртане на примитив/и.";
		}

        private void viewPortColorBTN_Click(object sender, EventArgs e)
        {
			DialogResult borderColorResult = viewPortColorDialog.ShowDialog();
			if (borderColorResult == DialogResult.OK)
			{
				viewPort.BackColor = viewPortColorDialog.Color;
			}
		}

    }
}

namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.EditShapeBTN = new System.Windows.Forms.Button();
            this.DeleteShapeBTN = new System.Windows.Forms.Button();
            this.FillColorColorDialog = new System.Windows.Forms.ColorDialog();
            this.FillColorBTN = new System.Windows.Forms.Button();
            this.BorderThickNUD = new System.Windows.Forms.NumericUpDown();
            this.BorderThickL = new System.Windows.Forms.Label();
            this.BorderColorColorDialog = new System.Windows.Forms.ColorDialog();
            this.FillColorL = new System.Windows.Forms.Label();
            this.Minus50BTN = new System.Windows.Forms.Button();
            this.Minus25BTN = new System.Windows.Forms.Button();
            this.Plus25BTN = new System.Windows.Forms.Button();
            this.Plus50BTN = new System.Windows.Forms.Button();
            this.ScaleTransformL = new System.Windows.Forms.Label();
            this.RotateTrackL = new System.Windows.Forms.Label();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawEllipseSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawLineSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawTriangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpacitySelectorL = new System.Windows.Forms.ToolStripLabel();
            this.OpacitySelectedCMB = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupSelectedBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.OpacityFormOpenBTN = new System.Windows.Forms.ToolStripButton();
            this.deleteSelectedGroupBTN = new System.Windows.Forms.ToolStripButton();
            this.MergeGroupsBTN = new System.Windows.Forms.ToolStripButton();
            this.viewPortColorBTN = new System.Windows.Forms.ToolStripButton();
            this.rotateAngle = new System.Windows.Forms.TextBox();
            this.RotateBTN = new System.Windows.Forms.Button();
            this.rotateResetBTN = new System.Windows.Forms.Button();
            this.FillColorByNameCMB = new System.Windows.Forms.ComboBox();
            this.BorderColorByNameCMB = new System.Windows.Forms.ComboBox();
            this.BorderColorL = new System.Windows.Forms.Label();
            this.BorderColorBTN = new System.Windows.Forms.Button();
            this.ShapeDisplayerLB = new System.Windows.Forms.ListBox();
            this.shapedisplayerL = new System.Windows.Forms.Label();
            this.ShapeNameChangeTB = new System.Windows.Forms.TextBox();
            this.ShapeNameChangeBTN = new System.Windows.Forms.Button();
            this.resetShapeDisplayerBTN = new System.Windows.Forms.Button();
            this.ChangeShapeOrderUp = new System.Windows.Forms.Button();
            this.ChangeShapeOrderDown = new System.Windows.Forms.Button();
            this.SaveModelSFD = new System.Windows.Forms.SaveFileDialog();
            this.OpenModelSFD = new System.Windows.Forms.OpenFileDialog();
            this.ResizeSelectedBTN = new System.Windows.Forms.Button();
            this.Plus90DegreesBTN = new System.Windows.Forms.Button();
            this.Plus45DegreesBTN = new System.Windows.Forms.Button();
            this.Minus45DegreesBTN = new System.Windows.Forms.Button();
            this.Minus90DegreesBTN = new System.Windows.Forms.Button();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.viewPortColorDialog = new System.Windows.Forms.ColorDialog();
            this.drawExamShapeSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorderThickNUD)).BeginInit();
            this.speedMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1584, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 779);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1584, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // EditShapeBTN
            // 
            this.EditShapeBTN.Enabled = false;
            this.EditShapeBTN.Location = new System.Drawing.Point(1384, 718);
            this.EditShapeBTN.Name = "EditShapeBTN";
            this.EditShapeBTN.Size = new System.Drawing.Size(71, 45);
            this.EditShapeBTN.TabIndex = 5;
            this.EditShapeBTN.Text = "Edit";
            this.EditShapeBTN.UseVisualStyleBackColor = true;
            this.EditShapeBTN.Click += new System.EventHandler(this.EditShapeBTN_Click);
            // 
            // DeleteShapeBTN
            // 
            this.DeleteShapeBTN.Enabled = false;
            this.DeleteShapeBTN.Location = new System.Drawing.Point(1461, 718);
            this.DeleteShapeBTN.Name = "DeleteShapeBTN";
            this.DeleteShapeBTN.Size = new System.Drawing.Size(75, 45);
            this.DeleteShapeBTN.TabIndex = 6;
            this.DeleteShapeBTN.Text = "Delete";
            this.DeleteShapeBTN.UseVisualStyleBackColor = true;
            this.DeleteShapeBTN.Click += new System.EventHandler(this.DeleteShapeBTN_Click);
            // 
            // FillColorColorDialog
            // 
            this.FillColorColorDialog.Color = System.Drawing.Color.White;
            // 
            // FillColorBTN
            // 
            this.FillColorBTN.BackColor = System.Drawing.Color.White;
            this.FillColorBTN.Enabled = false;
            this.FillColorBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FillColorBTN.ForeColor = System.Drawing.Color.Black;
            this.FillColorBTN.Location = new System.Drawing.Point(1271, 666);
            this.FillColorBTN.Name = "FillColorBTN";
            this.FillColorBTN.Size = new System.Drawing.Size(152, 28);
            this.FillColorBTN.TabIndex = 16;
            this.FillColorBTN.UseVisualStyleBackColor = false;
            this.FillColorBTN.Click += new System.EventHandler(this.FillColorBTN_Click);
            // 
            // BorderThickNUD
            // 
            this.BorderThickNUD.DecimalPlaces = 2;
            this.BorderThickNUD.Enabled = false;
            this.BorderThickNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.BorderThickNUD.InterceptArrowKeys = false;
            this.BorderThickNUD.Location = new System.Drawing.Point(1417, 558);
            this.BorderThickNUD.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.BorderThickNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BorderThickNUD.Name = "BorderThickNUD";
            this.BorderThickNUD.Size = new System.Drawing.Size(119, 20);
            this.BorderThickNUD.TabIndex = 18;
            this.BorderThickNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BorderThickL
            // 
            this.BorderThickL.AutoSize = true;
            this.BorderThickL.Location = new System.Drawing.Point(1438, 542);
            this.BorderThickL.Name = "BorderThickL";
            this.BorderThickL.Size = new System.Drawing.Size(93, 13);
            this.BorderThickL.TabIndex = 19;
            this.BorderThickL.Text = "Border Thickness:";
            // 
            // FillColorL
            // 
            this.FillColorL.AutoSize = true;
            this.FillColorL.Location = new System.Drawing.Point(1389, 650);
            this.FillColorL.Name = "FillColorL";
            this.FillColorL.Size = new System.Drawing.Size(49, 13);
            this.FillColorL.TabIndex = 21;
            this.FillColorL.Text = "Fill Color:";
            // 
            // Minus50BTN
            // 
            this.Minus50BTN.Location = new System.Drawing.Point(1333, 505);
            this.Minus50BTN.Name = "Minus50BTN";
            this.Minus50BTN.Size = new System.Drawing.Size(46, 23);
            this.Minus50BTN.TabIndex = 22;
            this.Minus50BTN.Text = "-50%";
            this.Minus50BTN.UseVisualStyleBackColor = true;
            this.Minus50BTN.Click += new System.EventHandler(this.Minus50BTN_Click);
            // 
            // Minus25BTN
            // 
            this.Minus25BTN.Location = new System.Drawing.Point(1385, 505);
            this.Minus25BTN.Name = "Minus25BTN";
            this.Minus25BTN.Size = new System.Drawing.Size(46, 23);
            this.Minus25BTN.TabIndex = 23;
            this.Minus25BTN.Text = "-25%";
            this.Minus25BTN.UseVisualStyleBackColor = true;
            this.Minus25BTN.Click += new System.EventHandler(this.Minus25BTN_Click);
            // 
            // Plus25BTN
            // 
            this.Plus25BTN.Location = new System.Drawing.Point(1438, 505);
            this.Plus25BTN.Name = "Plus25BTN";
            this.Plus25BTN.Size = new System.Drawing.Size(46, 23);
            this.Plus25BTN.TabIndex = 24;
            this.Plus25BTN.Text = "+25%";
            this.Plus25BTN.UseVisualStyleBackColor = true;
            this.Plus25BTN.Click += new System.EventHandler(this.Plus25BTN_Click);
            // 
            // Plus50BTN
            // 
            this.Plus50BTN.Location = new System.Drawing.Point(1490, 505);
            this.Plus50BTN.Name = "Plus50BTN";
            this.Plus50BTN.Size = new System.Drawing.Size(46, 23);
            this.Plus50BTN.TabIndex = 25;
            this.Plus50BTN.Text = "+50%";
            this.Plus50BTN.UseVisualStyleBackColor = true;
            this.Plus50BTN.Click += new System.EventHandler(this.Plus50BTN_Click);
            // 
            // ScaleTransformL
            // 
            this.ScaleTransformL.AutoSize = true;
            this.ScaleTransformL.Location = new System.Drawing.Point(1438, 489);
            this.ScaleTransformL.Name = "ScaleTransformL";
            this.ScaleTransformL.Size = new System.Drawing.Size(87, 13);
            this.ScaleTransformL.TabIndex = 26;
            this.ScaleTransformL.Text = "Scale Transform:";
            // 
            // RotateTrackL
            // 
            this.RotateTrackL.AutoSize = true;
            this.RotateTrackL.Location = new System.Drawing.Point(1446, 406);
            this.RotateTrackL.Name = "RotateTrackL";
            this.RotateTrackL.Size = new System.Drawing.Size(42, 13);
            this.RotateTrackL.TabIndex = 28;
            this.RotateTrackL.Text = "Rotate:";
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.CheckOnClick = true;
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawRectangleSpeedButton.Text = "Draw Rectangle";
            this.drawRectangleSpeedButton.CheckedChanged += new System.EventHandler(this.drawRectangleSpeedButton_CheckedChanged);
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.pickUpSpeedButton.Text = "Shape Picker";
            this.pickUpSpeedButton.ToolTipText = "Shape Picker";
            this.pickUpSpeedButton.CheckedChanged += new System.EventHandler(this.pickUpSpeedButton_CheckedChanged);
            // 
            // drawEllipseSpeedButton
            // 
            this.drawEllipseSpeedButton.CheckOnClick = true;
            this.drawEllipseSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawEllipseSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawEllipseSpeedButton.Image")));
            this.drawEllipseSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawEllipseSpeedButton.Name = "drawEllipseSpeedButton";
            this.drawEllipseSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawEllipseSpeedButton.Text = "Draw Ellipse";
            this.drawEllipseSpeedButton.CheckedChanged += new System.EventHandler(this.drawEllipseSpeedButton_CheckedChanged);
            this.drawEllipseSpeedButton.Click += new System.EventHandler(this.drawEllipseSpeedButton_Click);
            // 
            // drawLineSpeedButton
            // 
            this.drawLineSpeedButton.CheckOnClick = true;
            this.drawLineSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawLineSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawLineSpeedButton.Image")));
            this.drawLineSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawLineSpeedButton.Name = "drawLineSpeedButton";
            this.drawLineSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawLineSpeedButton.Text = "Draw Line";
            this.drawLineSpeedButton.ToolTipText = "Draw Line";
            this.drawLineSpeedButton.CheckedChanged += new System.EventHandler(this.drawLineSpeedButton_CheckedChanged);
            this.drawLineSpeedButton.Click += new System.EventHandler(this.drawLineSpeedButton_Click);
            // 
            // drawTriangleSpeedButton
            // 
            this.drawTriangleSpeedButton.CheckOnClick = true;
            this.drawTriangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawTriangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawTriangleSpeedButton.Image")));
            this.drawTriangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawTriangleSpeedButton.Name = "drawTriangleSpeedButton";
            this.drawTriangleSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawTriangleSpeedButton.Text = "Draw Triangle";
            this.drawTriangleSpeedButton.ToolTipText = "Draw Triangle";
            this.drawTriangleSpeedButton.CheckedChanged += new System.EventHandler(this.drawTriangleSpeedButton_CheckedChanged);
            this.drawTriangleSpeedButton.Click += new System.EventHandler(this.drawTriangleSpeedButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // OpacitySelectorL
            // 
            this.OpacitySelectorL.Name = "OpacitySelectorL";
            this.OpacitySelectorL.Size = new System.Drawing.Size(51, 22);
            this.OpacitySelectorL.Text = "Opacity:";
            // 
            // OpacitySelectedCMB
            // 
            this.OpacitySelectedCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OpacitySelectedCMB.Enabled = false;
            this.OpacitySelectedCMB.Items.AddRange(new object[] {
            "0%",
            "25%",
            "50%",
            "75%",
            "100%"});
            this.OpacitySelectedCMB.MaxDropDownItems = 5;
            this.OpacitySelectedCMB.Name = "OpacitySelectedCMB";
            this.OpacitySelectedCMB.Size = new System.Drawing.Size(135, 25);
            this.OpacitySelectedCMB.SelectedIndexChanged += new System.EventHandler(this.OpacitySelectedCMB_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // groupSelectedBTN
            // 
            this.groupSelectedBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.groupSelectedBTN.Image = ((System.Drawing.Image)(resources.GetObject("groupSelectedBTN.Image")));
            this.groupSelectedBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.groupSelectedBTN.Name = "groupSelectedBTN";
            this.groupSelectedBTN.Size = new System.Drawing.Size(44, 22);
            this.groupSelectedBTN.Text = "Group";
            this.groupSelectedBTN.Click += new System.EventHandler(this.groupSelectedBTN_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // speedMenu
            // 
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawRectangleSpeedButton,
            this.pickUpSpeedButton,
            this.drawEllipseSpeedButton,
            this.drawLineSpeedButton,
            this.drawTriangleSpeedButton,
            this.drawExamShapeSpeedButton,
            this.toolStripSeparator1,
            this.OpacitySelectorL,
            this.toolStripSeparator4,
            this.OpacitySelectedCMB,
            this.OpacityFormOpenBTN,
            this.toolStripSeparator2,
            this.groupSelectedBTN,
            this.deleteSelectedGroupBTN,
            this.MergeGroupsBTN,
            this.toolStripSeparator3,
            this.viewPortColorBTN});
            this.speedMenu.Location = new System.Drawing.Point(0, 24);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(1584, 25);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // OpacityFormOpenBTN
            // 
            this.OpacityFormOpenBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpacityFormOpenBTN.Image = ((System.Drawing.Image)(resources.GetObject("OpacityFormOpenBTN.Image")));
            this.OpacityFormOpenBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpacityFormOpenBTN.Name = "OpacityFormOpenBTN";
            this.OpacityFormOpenBTN.Size = new System.Drawing.Size(23, 22);
            this.OpacityFormOpenBTN.Text = "Select Opacity Manually";
            this.OpacityFormOpenBTN.Click += new System.EventHandler(this.OpacityFormOpenBTN_Click);
            // 
            // deleteSelectedGroupBTN
            // 
            this.deleteSelectedGroupBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteSelectedGroupBTN.Image = ((System.Drawing.Image)(resources.GetObject("deleteSelectedGroupBTN.Image")));
            this.deleteSelectedGroupBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteSelectedGroupBTN.Name = "deleteSelectedGroupBTN";
            this.deleteSelectedGroupBTN.Size = new System.Drawing.Size(74, 22);
            this.deleteSelectedGroupBTN.Text = "Degroup All";
            this.deleteSelectedGroupBTN.Click += new System.EventHandler(this.deleteSelectedGroupBTN_Click);
            // 
            // MergeGroupsBTN
            // 
            this.MergeGroupsBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MergeGroupsBTN.Image = ((System.Drawing.Image)(resources.GetObject("MergeGroupsBTN.Image")));
            this.MergeGroupsBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MergeGroupsBTN.Name = "MergeGroupsBTN";
            this.MergeGroupsBTN.Size = new System.Drawing.Size(86, 22);
            this.MergeGroupsBTN.Text = "Merge Groups";
            this.MergeGroupsBTN.Click += new System.EventHandler(this.MergeGroupsBTN_Click);
            // 
            // viewPortColorBTN
            // 
            this.viewPortColorBTN.BackColor = System.Drawing.SystemColors.Window;
            this.viewPortColorBTN.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.viewPortColorBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewPortColorBTN.Name = "viewPortColorBTN";
            this.viewPortColorBTN.Size = new System.Drawing.Size(107, 22);
            this.viewPortColorBTN.Text = "Background Color";
            this.viewPortColorBTN.Click += new System.EventHandler(this.viewPortColorBTN_Click);
            // 
            // rotateAngle
            // 
            this.rotateAngle.Location = new System.Drawing.Point(1387, 426);
            this.rotateAngle.Name = "rotateAngle";
            this.rotateAngle.Size = new System.Drawing.Size(58, 20);
            this.rotateAngle.TabIndex = 29;
            // 
            // RotateBTN
            // 
            this.RotateBTN.Location = new System.Drawing.Point(1446, 424);
            this.RotateBTN.Name = "RotateBTN";
            this.RotateBTN.Size = new System.Drawing.Size(87, 23);
            this.RotateBTN.TabIndex = 30;
            this.RotateBTN.Text = "Rotate";
            this.RotateBTN.UseVisualStyleBackColor = true;
            this.RotateBTN.Click += new System.EventHandler(this.RotateBTN_Click);
            // 
            // rotateResetBTN
            // 
            this.rotateResetBTN.Location = new System.Drawing.Point(1439, 463);
            this.rotateResetBTN.Name = "rotateResetBTN";
            this.rotateResetBTN.Size = new System.Drawing.Size(94, 23);
            this.rotateResetBTN.TabIndex = 32;
            this.rotateResetBTN.Text = "Reset Rotation";
            this.rotateResetBTN.UseVisualStyleBackColor = true;
            this.rotateResetBTN.Click += new System.EventHandler(this.rotateResetBTN_Click);
            // 
            // FillColorByNameCMB
            // 
            this.FillColorByNameCMB.Enabled = false;
            this.FillColorByNameCMB.FormattingEnabled = true;
            this.FillColorByNameCMB.Items.AddRange(new object[] {
            "AliceBlue",
            "AntiqueWhite",
            "Aqua",
            "Aquamarine",
            "Azure",
            "Beige",
            "Black",
            "Blue",
            "Brown",
            "BurlyWood",
            "CadetBlue",
            "Cyan",
            "DarkBlue",
            "DarkGoldenrod",
            "DarkGreen",
            "DarkMagenta",
            "DarkRed",
            "DarkTurquoise",
            "DeepSkyBlue",
            "DimGray",
            "DodgerBlue",
            "FloralWhite",
            "ForestGreen",
            "Gainsboro",
            "GhostWhite",
            "Gold",
            "Gray",
            "Green",
            "HotPink",
            "IndianRed",
            "Indigo",
            "Lavender",
            "LawnGreen",
            "LemonChiffon",
            "LightBlue",
            "LightCoral",
            "LightPink",
            "LightSeaGreen",
            "Lime",
            "Magenta",
            "MediumSlateBlue",
            "MintCream",
            "Navy",
            "OldLace",
            "Olive",
            "OrangeRed",
            "Orange",
            "PaleGoldenrod",
            "PaleGreen",
            "PapayaWhip",
            "Peru",
            "Pink",
            "Plum",
            "Red",
            "RosyBrown",
            "RoyalBlue",
            "SaddleBrown",
            "Salmon",
            "Sienna",
            "Silver",
            "SkyBlue",
            "SlateBlue",
            "SlateGray",
            "SpringGreen",
            "SteelBlue",
            "Tomato",
            "Turquoise",
            "Violet",
            "White",
            "WhiteSmoke",
            "YellowGreen"});
            this.FillColorByNameCMB.Location = new System.Drawing.Point(1429, 669);
            this.FillColorByNameCMB.Name = "FillColorByNameCMB";
            this.FillColorByNameCMB.Size = new System.Drawing.Size(106, 21);
            this.FillColorByNameCMB.TabIndex = 33;
            this.FillColorByNameCMB.SelectedIndexChanged += new System.EventHandler(this.FillColorByNameCMB_SelectedIndexChanged);
            // 
            // BorderColorByNameCMB
            // 
            this.BorderColorByNameCMB.Enabled = false;
            this.BorderColorByNameCMB.FormattingEnabled = true;
            this.BorderColorByNameCMB.Items.AddRange(new object[] {
            "AliceBlue",
            "AntiqueWhite",
            "Aqua",
            "Aquamarine",
            "Azure",
            "Beige",
            "Black",
            "Blue",
            "Brown",
            "BurlyWood",
            "CadetBlue",
            "Cyan",
            "DarkBlue",
            "DarkGoldenrod",
            "DarkGreen",
            "DarkMagenta",
            "DarkRed",
            "DarkTurquoise",
            "DeepSkyBlue",
            "DimGray",
            "DodgerBlue",
            "FloralWhite",
            "ForestGreen",
            "Gainsboro",
            "GhostWhite",
            "Gold",
            "Gray",
            "Green",
            "HotPink",
            "IndianRed",
            "Indigo",
            "Lavender",
            "LawnGreen",
            "LemonChiffon",
            "LightBlue",
            "LightCoral",
            "LightPink",
            "LightSeaGreen",
            "Lime",
            "Magenta",
            "MediumSlateBlue",
            "MintCream",
            "Navy",
            "OldLace",
            "Olive",
            "OrangeRed",
            "Orange",
            "PaleGoldenrod",
            "PaleGreen",
            "PapayaWhip",
            "Peru",
            "Pink",
            "Plum",
            "Red",
            "RosyBrown",
            "RoyalBlue",
            "SaddleBrown",
            "Salmon",
            "Sienna",
            "Silver",
            "SkyBlue",
            "SlateBlue",
            "SlateGray",
            "SpringGreen",
            "SteelBlue",
            "Tomato",
            "Turquoise",
            "Violet",
            "White",
            "WhiteSmoke",
            "YellowGreen"});
            this.BorderColorByNameCMB.Location = new System.Drawing.Point(1429, 612);
            this.BorderColorByNameCMB.Name = "BorderColorByNameCMB";
            this.BorderColorByNameCMB.Size = new System.Drawing.Size(106, 21);
            this.BorderColorByNameCMB.TabIndex = 36;
            this.BorderColorByNameCMB.SelectedIndexChanged += new System.EventHandler(this.BorderColorByNameCMB_SelectedIndexChanged);
            // 
            // BorderColorL
            // 
            this.BorderColorL.AutoSize = true;
            this.BorderColorL.Location = new System.Drawing.Point(1381, 593);
            this.BorderColorL.Name = "BorderColorL";
            this.BorderColorL.Size = new System.Drawing.Size(68, 13);
            this.BorderColorL.TabIndex = 35;
            this.BorderColorL.Text = "Border Color:";
            // 
            // BorderColorBTN
            // 
            this.BorderColorBTN.BackColor = System.Drawing.Color.Black;
            this.BorderColorBTN.Enabled = false;
            this.BorderColorBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorderColorBTN.ForeColor = System.Drawing.Color.Black;
            this.BorderColorBTN.Location = new System.Drawing.Point(1271, 609);
            this.BorderColorBTN.Name = "BorderColorBTN";
            this.BorderColorBTN.Size = new System.Drawing.Size(152, 28);
            this.BorderColorBTN.TabIndex = 34;
            this.BorderColorBTN.UseVisualStyleBackColor = false;
            this.BorderColorBTN.Click += new System.EventHandler(this.BorderColorBTN_Click);
            // 
            // ShapeDisplayerLB
            // 
            this.ShapeDisplayerLB.FormattingEnabled = true;
            this.ShapeDisplayerLB.Location = new System.Drawing.Point(1269, 66);
            this.ShapeDisplayerLB.Name = "ShapeDisplayerLB";
            this.ShapeDisplayerLB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ShapeDisplayerLB.Size = new System.Drawing.Size(264, 225);
            this.ShapeDisplayerLB.TabIndex = 37;
            this.ShapeDisplayerLB.Click += new System.EventHandler(this.ShapeDisplayerLB_Click);
            this.ShapeDisplayerLB.DoubleClick += new System.EventHandler(this.ShapeDisplayerLB_DoubleClick);
            this.ShapeDisplayerLB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeDisplayerLB_MouseDown);
            // 
            // shapedisplayerL
            // 
            this.shapedisplayerL.AutoSize = true;
            this.shapedisplayerL.Location = new System.Drawing.Point(1277, 48);
            this.shapedisplayerL.Name = "shapedisplayerL";
            this.shapedisplayerL.Size = new System.Drawing.Size(46, 13);
            this.shapedisplayerL.TabIndex = 38;
            this.shapedisplayerL.Text = "Shapes:";
            // 
            // ShapeNameChangeTB
            // 
            this.ShapeNameChangeTB.Location = new System.Drawing.Point(1269, 338);
            this.ShapeNameChangeTB.Name = "ShapeNameChangeTB";
            this.ShapeNameChangeTB.Size = new System.Drawing.Size(264, 20);
            this.ShapeNameChangeTB.TabIndex = 39;
            // 
            // ShapeNameChangeBTN
            // 
            this.ShapeNameChangeBTN.Location = new System.Drawing.Point(1438, 364);
            this.ShapeNameChangeBTN.Name = "ShapeNameChangeBTN";
            this.ShapeNameChangeBTN.Size = new System.Drawing.Size(95, 27);
            this.ShapeNameChangeBTN.TabIndex = 40;
            this.ShapeNameChangeBTN.Text = "Change Name";
            this.ShapeNameChangeBTN.UseVisualStyleBackColor = true;
            this.ShapeNameChangeBTN.Click += new System.EventHandler(this.ShapeNameChangeBTN_Click);
            // 
            // resetShapeDisplayerBTN
            // 
            this.resetShapeDisplayerBTN.Location = new System.Drawing.Point(1459, 300);
            this.resetShapeDisplayerBTN.Name = "resetShapeDisplayerBTN";
            this.resetShapeDisplayerBTN.Size = new System.Drawing.Size(74, 27);
            this.resetShapeDisplayerBTN.TabIndex = 41;
            this.resetShapeDisplayerBTN.Text = "Reset";
            this.resetShapeDisplayerBTN.UseVisualStyleBackColor = true;
            this.resetShapeDisplayerBTN.Click += new System.EventHandler(this.resetShapeDisplayerBTN_Click);
            // 
            // ChangeShapeOrderUp
            // 
            this.ChangeShapeOrderUp.Location = new System.Drawing.Point(1392, 300);
            this.ChangeShapeOrderUp.Name = "ChangeShapeOrderUp";
            this.ChangeShapeOrderUp.Size = new System.Drawing.Size(29, 27);
            this.ChangeShapeOrderUp.TabIndex = 42;
            this.ChangeShapeOrderUp.Text = "↑";
            this.ChangeShapeOrderUp.UseVisualStyleBackColor = true;
            this.ChangeShapeOrderUp.Click += new System.EventHandler(this.ChangeShapeOrderUp_Click);
            // 
            // ChangeShapeOrderDown
            // 
            this.ChangeShapeOrderDown.Location = new System.Drawing.Point(1424, 300);
            this.ChangeShapeOrderDown.Name = "ChangeShapeOrderDown";
            this.ChangeShapeOrderDown.Size = new System.Drawing.Size(29, 27);
            this.ChangeShapeOrderDown.TabIndex = 43;
            this.ChangeShapeOrderDown.Text = "↓";
            this.ChangeShapeOrderDown.UseVisualStyleBackColor = true;
            this.ChangeShapeOrderDown.Click += new System.EventHandler(this.ChangeShapeOrderDown_Click);
            // 
            // OpenModelSFD
            // 
            this.OpenModelSFD.FileName = "openFileDialog1";
            // 
            // ResizeSelectedBTN
            // 
            this.ResizeSelectedBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ResizeSelectedBTN.BackgroundImage")));
            this.ResizeSelectedBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResizeSelectedBTN.Location = new System.Drawing.Point(1304, 505);
            this.ResizeSelectedBTN.Name = "ResizeSelectedBTN";
            this.ResizeSelectedBTN.Size = new System.Drawing.Size(23, 23);
            this.ResizeSelectedBTN.TabIndex = 44;
            this.ResizeSelectedBTN.UseVisualStyleBackColor = true;
            this.ResizeSelectedBTN.Click += new System.EventHandler(this.ResizeSelectedBTN_Click);
            // 
            // Plus90DegreesBTN
            // 
            this.Plus90DegreesBTN.Location = new System.Drawing.Point(1353, 425);
            this.Plus90DegreesBTN.Name = "Plus90DegreesBTN";
            this.Plus90DegreesBTN.Size = new System.Drawing.Size(34, 23);
            this.Plus90DegreesBTN.TabIndex = 45;
            this.Plus90DegreesBTN.Text = "90°";
            this.Plus90DegreesBTN.UseVisualStyleBackColor = true;
            this.Plus90DegreesBTN.Click += new System.EventHandler(this.Plus90DegreesBTN_Click);
            // 
            // Plus45DegreesBTN
            // 
            this.Plus45DegreesBTN.Location = new System.Drawing.Point(1320, 425);
            this.Plus45DegreesBTN.Name = "Plus45DegreesBTN";
            this.Plus45DegreesBTN.Size = new System.Drawing.Size(34, 23);
            this.Plus45DegreesBTN.TabIndex = 45;
            this.Plus45DegreesBTN.Text = "45°";
            this.Plus45DegreesBTN.UseVisualStyleBackColor = true;
            this.Plus45DegreesBTN.Click += new System.EventHandler(this.Plus45DegreesBTN_Click);
            // 
            // Minus45DegreesBTN
            // 
            this.Minus45DegreesBTN.Location = new System.Drawing.Point(1287, 425);
            this.Minus45DegreesBTN.Name = "Minus45DegreesBTN";
            this.Minus45DegreesBTN.Size = new System.Drawing.Size(34, 23);
            this.Minus45DegreesBTN.TabIndex = 45;
            this.Minus45DegreesBTN.Text = "-45°";
            this.Minus45DegreesBTN.UseVisualStyleBackColor = true;
            this.Minus45DegreesBTN.Click += new System.EventHandler(this.Minus45DegreesBTN_Click);
            // 
            // Minus90DegreesBTN
            // 
            this.Minus90DegreesBTN.Location = new System.Drawing.Point(1254, 425);
            this.Minus90DegreesBTN.Name = "Minus90DegreesBTN";
            this.Minus90DegreesBTN.Size = new System.Drawing.Size(34, 23);
            this.Minus90DegreesBTN.TabIndex = 45;
            this.Minus90DegreesBTN.Text = "-90°";
            this.Minus90DegreesBTN.UseVisualStyleBackColor = true;
            this.Minus90DegreesBTN.Click += new System.EventHandler(this.Minus90DegreesBTN_Click);
            // 
            // viewPort
            // 
            this.viewPort.BackColor = System.Drawing.SystemColors.Window;
            this.viewPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewPort.Location = new System.Drawing.Point(12, 52);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(1236, 711);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // drawExamShapeSpeedButton
            // 
            this.drawExamShapeSpeedButton.CheckOnClick = true;
            this.drawExamShapeSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.drawExamShapeSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawExamShapeSpeedButton.Image")));
            this.drawExamShapeSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawExamShapeSpeedButton.Name = "drawExamShapeSpeedButton";
            this.drawExamShapeSpeedButton.Size = new System.Drawing.Size(24, 22);
            this.drawExamShapeSpeedButton.Text = "EX";
            this.drawExamShapeSpeedButton.CheckedChanged += new System.EventHandler(this.drawExamShapeSpeedButton_CheckedChanged);
            this.drawExamShapeSpeedButton.Click += new System.EventHandler(this.drawExamShapeSpeedButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1584, 801);
            this.Controls.Add(this.Minus90DegreesBTN);
            this.Controls.Add(this.Minus45DegreesBTN);
            this.Controls.Add(this.Plus45DegreesBTN);
            this.Controls.Add(this.Plus90DegreesBTN);
            this.Controls.Add(this.ResizeSelectedBTN);
            this.Controls.Add(this.ChangeShapeOrderDown);
            this.Controls.Add(this.ChangeShapeOrderUp);
            this.Controls.Add(this.resetShapeDisplayerBTN);
            this.Controls.Add(this.ShapeNameChangeBTN);
            this.Controls.Add(this.ShapeNameChangeTB);
            this.Controls.Add(this.shapedisplayerL);
            this.Controls.Add(this.ShapeDisplayerLB);
            this.Controls.Add(this.BorderColorByNameCMB);
            this.Controls.Add(this.BorderColorL);
            this.Controls.Add(this.BorderColorBTN);
            this.Controls.Add(this.FillColorByNameCMB);
            this.Controls.Add(this.rotateResetBTN);
            this.Controls.Add(this.RotateBTN);
            this.Controls.Add(this.rotateAngle);
            this.Controls.Add(this.RotateTrackL);
            this.Controls.Add(this.ScaleTransformL);
            this.Controls.Add(this.Plus50BTN);
            this.Controls.Add(this.Plus25BTN);
            this.Controls.Add(this.Minus25BTN);
            this.Controls.Add(this.Minus50BTN);
            this.Controls.Add(this.FillColorL);
            this.Controls.Add(this.BorderThickL);
            this.Controls.Add(this.BorderThickNUD);
            this.Controls.Add(this.FillColorBTN);
            this.Controls.Add(this.DeleteShapeBTN);
            this.Controls.Add(this.EditShapeBTN);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Draw";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorderThickNUD)).EndInit();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.Button EditShapeBTN;
        private System.Windows.Forms.Button DeleteShapeBTN;
        private System.Windows.Forms.ColorDialog FillColorColorDialog;
        private System.Windows.Forms.Button FillColorBTN;
        private System.Windows.Forms.NumericUpDown BorderThickNUD;
        private System.Windows.Forms.Label BorderThickL;
        private System.Windows.Forms.ColorDialog BorderColorColorDialog;
        private System.Windows.Forms.Label FillColorL;
        private System.Windows.Forms.Button Minus50BTN;
        private System.Windows.Forms.Button Minus25BTN;
        private System.Windows.Forms.Button Plus25BTN;
        private System.Windows.Forms.Button Plus50BTN;
        private System.Windows.Forms.Label ScaleTransformL;
        private System.Windows.Forms.Label RotateTrackL;
        private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
        private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
        private System.Windows.Forms.ToolStripButton drawEllipseSpeedButton;
        private System.Windows.Forms.ToolStripButton drawLineSpeedButton;
        private System.Windows.Forms.ToolStripButton drawTriangleSpeedButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel OpacitySelectorL;
        private System.Windows.Forms.ToolStripComboBox OpacitySelectedCMB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton groupSelectedBTN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStrip speedMenu;
        private System.Windows.Forms.TextBox rotateAngle;
        private System.Windows.Forms.Button RotateBTN;
        private System.Windows.Forms.Button rotateResetBTN;
        private System.Windows.Forms.ToolStripButton deleteSelectedGroupBTN;
        private System.Windows.Forms.ComboBox FillColorByNameCMB;
        private System.Windows.Forms.ComboBox BorderColorByNameCMB;
        private System.Windows.Forms.Label BorderColorL;
        private System.Windows.Forms.Button BorderColorBTN;
        private System.Windows.Forms.ListBox ShapeDisplayerLB;
        private System.Windows.Forms.Label shapedisplayerL;
        private System.Windows.Forms.TextBox ShapeNameChangeTB;
        private System.Windows.Forms.Button ShapeNameChangeBTN;
        private System.Windows.Forms.Button resetShapeDisplayerBTN;
        private System.Windows.Forms.Button ChangeShapeOrderUp;
        private System.Windows.Forms.Button ChangeShapeOrderDown;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveModelSFD;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenModelSFD;
        private System.Windows.Forms.ToolStripButton MergeGroupsBTN;
        private System.Windows.Forms.ToolStripButton OpacityFormOpenBTN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Button ResizeSelectedBTN;
        private System.Windows.Forms.Button Plus90DegreesBTN;
        private System.Windows.Forms.Button Plus45DegreesBTN;
        private System.Windows.Forms.Button Minus45DegreesBTN;
        private System.Windows.Forms.Button Minus90DegreesBTN;
        private System.Windows.Forms.ToolStripButton viewPortColorBTN;
        private System.Windows.Forms.ColorDialog viewPortColorDialog;
        private System.Windows.Forms.ToolStripButton drawExamShapeSpeedButton;
    }
}

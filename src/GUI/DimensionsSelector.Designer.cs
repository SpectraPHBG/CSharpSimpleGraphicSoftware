namespace Draw
{
    partial class DimensionsSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OkBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.WidthL = new System.Windows.Forms.Label();
            this.HeightL = new System.Windows.Forms.Label();
            this.HeightTB = new System.Windows.Forms.TextBox();
            this.WidthTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OkBTN
            // 
            this.OkBTN.Location = new System.Drawing.Point(76, 99);
            this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
            this.OkBTN.TabIndex = 0;
            this.OkBTN.Text = "OK";
            this.OkBTN.UseVisualStyleBackColor = true;
            this.OkBTN.Click += new System.EventHandler(this.OkBTN_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.Location = new System.Drawing.Point(157, 99);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 1;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // WidthL
            // 
            this.WidthL.AutoSize = true;
            this.WidthL.Location = new System.Drawing.Point(85, 33);
            this.WidthL.Name = "WidthL";
            this.WidthL.Size = new System.Drawing.Size(38, 13);
            this.WidthL.TabIndex = 2;
            this.WidthL.Text = "Width:";
            // 
            // HeightL
            // 
            this.HeightL.AutoSize = true;
            this.HeightL.Location = new System.Drawing.Point(85, 58);
            this.HeightL.Name = "HeightL";
            this.HeightL.Size = new System.Drawing.Size(41, 13);
            this.HeightL.TabIndex = 3;
            this.HeightL.Text = "Height:";
            // 
            // HeightTB
            // 
            this.HeightTB.Location = new System.Drawing.Point(132, 55);
            this.HeightTB.Name = "HeightTB";
            this.HeightTB.Size = new System.Drawing.Size(100, 20);
            this.HeightTB.TabIndex = 4;
            // 
            // WidthTB
            // 
            this.WidthTB.Location = new System.Drawing.Point(132, 30);
            this.WidthTB.Name = "WidthTB";
            this.WidthTB.Size = new System.Drawing.Size(100, 20);
            this.WidthTB.TabIndex = 5;
            // 
            // DimensionsSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 150);
            this.Controls.Add(this.WidthTB);
            this.Controls.Add(this.HeightTB);
            this.Controls.Add(this.HeightL);
            this.Controls.Add(this.WidthL);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.OkBTN);
            this.Name = "DimensionsSelector";
            this.Text = "Select Width and Height";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Label WidthL;
        private System.Windows.Forms.Label HeightL;
        private System.Windows.Forms.TextBox HeightTB;
        private System.Windows.Forms.TextBox WidthTB;
    }
}
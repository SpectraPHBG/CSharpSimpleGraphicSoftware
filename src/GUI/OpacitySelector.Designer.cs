namespace Draw.src.GUI
{
    partial class OpacitySelector
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
            this.OpacitySelectorTB = new System.Windows.Forms.TrackBar();
            this.OpacityTextL = new System.Windows.Forms.Label();
            this.OpacityDisplayL = new System.Windows.Forms.Label();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.OkBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OpacitySelectorTB)).BeginInit();
            this.SuspendLayout();
            // 
            // OpacitySelectorTB
            // 
            this.OpacitySelectorTB.Location = new System.Drawing.Point(12, 36);
            this.OpacitySelectorTB.Maximum = 100;
            this.OpacitySelectorTB.Name = "OpacitySelectorTB";
            this.OpacitySelectorTB.Size = new System.Drawing.Size(375, 45);
            this.OpacitySelectorTB.TabIndex = 0;
            this.OpacitySelectorTB.Value = 100;
            this.OpacitySelectorTB.Scroll += new System.EventHandler(this.OpacitySelectorTB_Scroll);
            // 
            // OpacityTextL
            // 
            this.OpacityTextL.AutoSize = true;
            this.OpacityTextL.Location = new System.Drawing.Point(158, 20);
            this.OpacityTextL.Name = "OpacityTextL";
            this.OpacityTextL.Size = new System.Drawing.Size(46, 13);
            this.OpacityTextL.TabIndex = 1;
            this.OpacityTextL.Text = "Opacity:";
            // 
            // OpacityDisplayL
            // 
            this.OpacityDisplayL.AutoSize = true;
            this.OpacityDisplayL.Location = new System.Drawing.Point(200, 20);
            this.OpacityDisplayL.Name = "OpacityDisplayL";
            this.OpacityDisplayL.Size = new System.Drawing.Size(0, 13);
            this.OpacityDisplayL.TabIndex = 2;
            // 
            // CancelBTN
            // 
            this.CancelBTN.Location = new System.Drawing.Point(195, 87);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 102;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // OkBTN
            // 
            this.OkBTN.Location = new System.Drawing.Point(114, 87);
            this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
            this.OkBTN.TabIndex = 101;
            this.OkBTN.Text = "OK";
            this.OkBTN.UseVisualStyleBackColor = true;
            this.OkBTN.Click += new System.EventHandler(this.OkBTN_Click);
            // 
            // OpacitySelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 136);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.OkBTN);
            this.Controls.Add(this.OpacityDisplayL);
            this.Controls.Add(this.OpacityTextL);
            this.Controls.Add(this.OpacitySelectorTB);
            this.Name = "OpacitySelector";
            this.Text = "OpacitySelector";
            ((System.ComponentModel.ISupportInitialize)(this.OpacitySelectorTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar OpacitySelectorTB;
        private System.Windows.Forms.Label OpacityTextL;
        private System.Windows.Forms.Label OpacityDisplayL;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Button OkBTN;
    }
}
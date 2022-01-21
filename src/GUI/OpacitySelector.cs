using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Draw.src.GUI
{
    public partial class OpacitySelector : Form
    {
        public OpacitySelector()
        {
            InitializeComponent();
            OpacityDisplayL.Text = $"{OpacitySelectorTB.Value}%";
        }
        public MainForm MainFormWindow { get; set; }
        private void OkBTN_Click(object sender, EventArgs e)
        {
            MainFormWindow.SetOpacity(OpacitySelectorTB.Value);
            this.Hide();
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OpacitySelectorTB_Scroll(object sender, EventArgs e)
        {
            OpacityDisplayL.Text = $"{OpacitySelectorTB.Value}%";
        }
    }
}

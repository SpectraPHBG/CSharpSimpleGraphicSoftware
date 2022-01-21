using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Draw
{
    public partial class DimensionsSelector : Form
    {
        public DimensionsSelector()
        {
            InitializeComponent();
        }
        public MainForm MainFormWindow { get; set; }
        private void OkBTN_Click(object sender, EventArgs e)
        {
            float width=-1, height=-1;
            if (!WidthTB.Text.Equals("") && !Regex.IsMatch(WidthTB.Text, @"[a-zA-Z]"))
            {
                width = float.Parse(WidthTB.Text);
            }
            if (!HeightTB.Text.Equals("") && !Regex.IsMatch(HeightTB.Text, @"[a-zA-Z]"))
            {
                height = float.Parse(HeightTB.Text);
            }
            MainFormWindow.SetDimensions(width, height);
            this.Hide();
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

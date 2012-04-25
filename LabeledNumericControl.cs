using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GalaxySmash
{
    public partial class LabeledNumericControl : UserControl
    {
        public LabeledNumericControl()
        {
            InitializeComponent();
            numericValue.Minimum = decimal.MinValue;
            numericValue.Maximum = decimal.MaxValue;
        }

        public int DecimalPlaces
        {
            get { return numericValue.DecimalPlaces; }
            set { numericValue.DecimalPlaces = value; }
        }

        public string Title
        {
            get { return labelTitle.Text; }
            set { labelTitle.Text = value; }
        }

        public decimal Value
        {
            get { return numericValue.Value; }
            set { numericValue.Value = value; }
        }

        public decimal MinimumValue
        {
            get { return numericValue.Minimum; }
            set { numericValue.Minimum = value; }
        }

        public decimal MaximumValue
        {
            get { return numericValue.Maximum; }
            set { numericValue.Maximum = value; }
        }
    }
}

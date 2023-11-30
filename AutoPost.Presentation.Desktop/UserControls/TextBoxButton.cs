using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPost.Presentation.Desktop.UserControls
{
    public partial class TextBoxButton : UserControl
    {
        public string UCButtonText
        {
            get { return Button.Text; }
            set { Button.Text = value; }
        }
        public string UCTextBoxText
        {
            get { return TextBox.Text; }
            set { TextBox.Text = value; }
        }
        public string UCTextBoxPlaceHolder
        {
            get { return TextBox.PlaceholderText; }
            set { TextBox.PlaceholderText = value; }
        }
        public Action? UCButtonAction { get; set; } = null;
        //public event   UCButtonClick ;

        public TextBoxButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            //UCButtonClick(sender, e);
            if (UCButtonAction != null)
            {
                UCButtonAction();
            }
        }

    }
}

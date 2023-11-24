using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Windows.Forms;
namespace AutoPost.Presentation.Desktop.UserControls
{
    public class TagBox : TextBox
    {
        private List<string> Tags = new List<string>();

        public TagBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //this.Invalidate();
            this.Multiline = true;
            this.ScrollBars = ScrollBars.Vertical;
            this.AcceptsReturn = true;
            this.TextChanged += TagBox_TextChanged;
            this.KeyDown += TagBox_KeyDown;
            splitter();
            //this.Update();
        }
        private void splitter()
        {
            Tags = this.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(tag => tag.Trim())
                                    .ToList();
        }

        private void TagBox_TextChanged(object sender, EventArgs e)
        {
            splitter();
            this.Refresh();
        }

        private void TagBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int yPos = 5;
            foreach (string tag in Tags)
            {
                Image icon = Properties.Resources.Tag; 
                e.Graphics.DrawImage(icon, 5, yPos, 16, 16);

                SizeF tagSize = e.Graphics.MeasureString(tag, this.Font);
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 25, yPos, tagSize.Width, tagSize.Height);
                e.Graphics.DrawString(tag, this.Font, Brushes.Black, 25, yPos);

                yPos += (int)tagSize.Height + 5; 
            }
        }
    }
}
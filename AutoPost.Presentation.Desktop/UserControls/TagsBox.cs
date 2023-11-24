using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPost.Presentation.Desktop.UserControls
{
    public partial class TagsBox : UserControl
    {
        private FlowLayoutPanel flowLayoutPanel;
        private TextBox textBox;
        private List<string> tagList;

        public List<string> TagList
        {
            get { return tagList; }
            set
            {
                tagList = value;
                UpdateTags();
            }
        }

        public TagsBox()
        {
            InitializeComponent();
            tagList = new List<string>();
        }

        private void UpdateTags()
        {
            this.flowLayoutPanel.Controls.Clear();
            foreach (var tag in tagList)
            {
                // Crear y configurar el control del tag
                var tagLabel = new Label();
                tagLabel.Text = tag;
                tagLabel.BorderStyle = BorderStyle.FixedSingle;
                tagLabel.Padding = new Padding(3);
                tagLabel.Click += new EventHandler(TagLabel_Click);

                this.flowLayoutPanel.Controls.Add(tagLabel);
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                string inputText = textBox.Text.Trim();

                
                if (flowLayoutPanel.Controls.OfType<Label>().Any(label => label.BackColor == Color.LightBlue))
                {
                    var selectedLabel = flowLayoutPanel.Controls.OfType<Label>().FirstOrDefault(label => label.BackColor == Color.LightBlue);
                    if (selectedLabel != null)
                    {
                        int index = tagList.IndexOf(selectedLabel.Text);
                        tagList[index] = inputText;
                        selectedLabel.Text = inputText;
                    }
                }
                else 
                {
                    tagList.Add(inputText);
                    var newTagLabel = new Label
                    {
                        Text = inputText,
                        BorderStyle = BorderStyle.FixedSingle,
                        Padding = new Padding(3)
                    };
                    newTagLabel.Click += new EventHandler(TagLabel_Click);
                    flowLayoutPanel.Controls.Add(newTagLabel);
                }
                DeselectAllTags();
                textBox.Clear();
            }
        }

        private void DeselectAllTags()
        {
            foreach (Label tagLabel in flowLayoutPanel.Controls)
            {
                tagLabel.BackColor = Control.DefaultBackColor;
            }
        }
        private void TagLabel_Click(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                // Resaltar el tag seleccionado
                foreach (Label tagLabel in flowLayoutPanel.Controls)
                {
                    tagLabel.BackColor = tagLabel == label ? Color.LightBlue : Control.DefaultBackColor;
                }

                // Poner el texto del tag seleccionado en el TextBox para editar
                textBox.Text = label.Text;
                textBox.Focus(); // Poner el foco en el TextBox
            }
        }

    }
}

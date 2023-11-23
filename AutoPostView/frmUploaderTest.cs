using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;

namespace AutoPost.View
{
    public partial class frmUploaderTest : Form
    {
        private readonly IVideoUploader _videoUploader;

        public frmUploaderTest(IVideoUploader videoUploader)
        {
            InitializeComponent();

            _videoUploader = videoUploader;
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
             await SubirVideoAYoutube();
        }
        private async Task SubirVideoAYoutube()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                VideoMetadata metadata = new VideoMetadata
                {
                    Title = txtTitle.Text,
                    Description = txtDescription.Text,
                    Privacidad = VideoMetadata.EPrivacidad.PUBLIC // Opciones: "public", "private", "unlisted"
                };

                try
                {
                   if (await _videoUploader.UploadVideoAsync(filePath, metadata))
                    {
                        MessageBox.Show("Video subido con éxito.");
                    }
                    else
                    {
                        MessageBox.Show($"Error al subir el video.");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al subir el video: {ex.Message}");
                }
            }
        }
    }
}

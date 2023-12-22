using SharpAvi;
using SharpAvi.Output;
using NAudio.Wave;
using System.Drawing;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
namespace AutoPost.PostGenerator.Recorders
{
    public class VideoRecorder
    {
        private AviWriter aviWriter;
        private IAviVideoStream videoStream;
        private WaveInEvent audioSource;
        private MemoryStream audioStream;
        private Thread recordingThread;
        private bool isRecording = false;
        private int width;
        private int height;
        private int frameRate;

        public VideoRecorder(string outputPath, int width, int height, int frameRate = 10)
        {
            this.width = width;
            this.height = height;
            this.frameRate = frameRate;

            aviWriter = new AviWriter(outputPath)
            {
                FramesPerSecond = frameRate,
                EmitIndex1 = true
            };

            //videoStream = aviWriter.AddMpeg4VideoStream(width, height, frameRate);
            videoStream = aviWriter.AddVideoStream(width, height);
            // Configura el videoStream (codec, tamaño, etc.)

            audioSource = new WaveInEvent();
            // Configura el audioSource (formato, etc.)
            audioStream = new MemoryStream();
        }

        public void StartRecording()
        {
            isRecording = true;
            recordingThread = new Thread(RecordScreen)
            {
                IsBackground = true
            };
            recordingThread.Start();

            audioSource.StartRecording();
        }

        private void RecordScreen()
        {
            while (isRecording)
            {
                using (var bitmap = new Bitmap(width, height))
                {
                    using (var g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, new Size(width, height));
                    }

                    var bits = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    var length = bits.Stride * bits.Height;
                    byte[] bytes = new byte[length];
                    Marshal.Copy(bits.Scan0, bytes, 0, length);
                    bitmap.UnlockBits(bits);

                    videoStream.WriteFrame(true, bytes);
                    Thread.Sleep(1000 / frameRate);
                }
            }
        }

        public void StopRecording()
        {
            isRecording = false;
            recordingThread.Join();

            audioSource.StopRecording();
            audioSource.Dispose();

            // Aquí puedes agregar el código para combinar el audioStream con el videoStream
            aviWriter.Close();
        }

        // Métodos adicionales para capturar frames y audio...
    }
}
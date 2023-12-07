using FFmpeg.AutoGen;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.VideoGenerator
{
    public class Program
    {
        public static void Execute(string OutPath)
        {

            Screen scrn = new(new Vector2u(400,700),new SFML.Graphics.Color(218, 220, 220),"");
            scrn.Random();
            scrn.Run();

            //////if (!Directory.Exists(OutPath)) { throw new Exception($"Directory {nameof(OutPath)} doesn´t exist."); }
            //////const int windowWidth = 900;
            //////const int windowHeight = 1600;
            //////RenderWindow window = new RenderWindow(new VideoMode(windowWidth, windowHeight), "Pelotitas Rebote");
            //////window.SetFramerateLimit(60);
            
            //////List<Ball> balls = CreateBalls(10, windowWidth, windowHeight);
            //////Clock clock = new Clock();
            //////int frameCount = 0;

            //////while (window.IsOpen && clock.ElapsedTime.AsSeconds() < 120) // Durante 2 minutos
            //////{
            //////    window.DispatchEvents();

            //////    foreach (var ball in balls)
            //////    {
            //////        ball.Update();
            //////        CheckCollision(ball, windowWidth, windowHeight);
            //////    }

            //////    window.Clear();
            //////    foreach (var ball in balls)
            //////    {
            //////        window.Draw(ball.Shape);
            //////    }
            //////    window.Display();

            //////    // Captura y guarda cada frame como imagen
            //////    Texture texture = new Texture(windowWidth, windowHeight);
            //////    texture.Update(window);
            //////    Image screenshot = texture.CopyToImage();
            //////    screenshot.SaveToFile($"{OutPath}\\frame_{frameCount++}.png");

            //////}
            
        }

        //private static List<Ball> CreateBalls(int numberOfBalls, int windowWidth, int windowHeight)
        //{
        //    List<Ball> balls = new List<Ball>();
        //    Random random = new Random();

        //    for (int i = 0; i < numberOfBalls; i++)
        //    {
        //        float radius = random.Next(10, 30);
        //        float x = random.Next((int)radius, windowWidth - (int)radius);
        //        float y = random.Next((int)radius, windowHeight - (int)radius);
        //        SFML.Graphics.Color color =  new SFML.Graphics.Color()
        //        balls.Add(new Ball(x, y, radius));
        //    }

        //    return balls;
        //}

        //private static void CheckCollision(Ball ball, int windowWidth, int windowHeight)
        //{
        //    if (ball.Position.X - ball.Radius < 0 || ball.Position.X + ball.Radius > windowWidth)
        //    {
        //        ball.Velocity.X = -ball.Velocity.X;
        //    }
        //    if (ball.Position.Y - ball.Radius < 0 || ball.Position.Y + ball.Radius > windowHeight)
        //    {
        //        ball.Velocity.Y = -ball.Velocity.Y;
        //    }
        //}
    }
    //public class Ball
    //{
    //    public SFML.System.Vector2f Position;
    //    public SFML.System.Vector2f Velocity;
    //    public float Radius;
    //    public SFML.Graphics.CircleShape Shape;

    //    public Ball(float x, float y, float radius)
    //    {
    //        Position = new SFML.System.Vector2f(x, y);
    //        Velocity = new SFML.System.Vector2f(new Random().Next(-5, 5), new Random().Next(-5, 5));
    //        Radius = radius;

    //        Shape = new SFML.Graphics.CircleShape(Radius)
    //        {
    //            Position = Position,
    //            FillColor = SFML.Graphics.Color.Red
    //        };
    //    }

    //    public void Update()
    //    {
    //        Position += Velocity;
    //        Shape.Position = Position;
    //    }
    //}
    //public class FFmpegVideoCreator
    //{
    //    public static void CreateVideoFromImages(string[] imagePaths, string outputPath, int width, int height, int frameRate)
    //    {

    //    }
    //}
    //public unsafe class VideoGenerator
    //{
    //    public static void GenerateVideo(string[] imageFiles, string outputFileName, int width, int height, int frameRate)
    //    {
    //        ffmpeg.regu();

    //        AVCodec* codec = ffmpeg.avcodec_find_encoder(AVCodecID.AV_CODEC_ID_H264);
    //        if (codec == null) throw new Exception("Codec not found");

    //        AVCodecContext* context = ffmpeg.avcodec_alloc_context3(codec);
    //        if (context == null) throw new Exception("Could not allocate video codec context");

    //        context->bit_rate = 400000;
    //        context->width = width;
    //        context->height = height;
    //        context->time_base = new AVRational { num = 1, den = frameRate };
    //        context->framerate = new AVRational { num = frameRate, den = 1 };
    //        context->gop_size = 10;
    //        context->max_b_frames = 1;
    //        context->pix_fmt = AVPixelFormat.AV_PIX_FMT_YUV420P;

    //        if (ffmpeg.avcodec_open2(context, codec, null) < 0)
    //            throw new Exception("Could not open codec");

    //        AVFrame* frame = ffmpeg.av_frame_alloc();
    //        if (frame == null) throw new Exception("Could not allocate video frame");
    //        frame->format = (int)context->pix_fmt;
    //        frame->width = context->width;
    //        frame->height = context->height;

    //        if (ffmpeg.av_frame_get_buffer(frame, 32) < 0)
    //            throw new Exception("Could not allocate the video frame data");

    //        AVPacket pkt;
    //        int ret;

    //        foreach (var file in imageFiles)
    //        {
    //            ret = ffmpeg.av_frame_make_writable(frame);
    //            if (ret < 0) throw new Exception("Could not make frame writable");

    //            // Cargar imagen y convertirla a YUV
    //            using (Bitmap bitmap = new Bitmap(file))
    //            {
    //                BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    //                // Convertir datos de imagen a YUV y asignar a frame->data
    //                // ...
    //                bitmap.UnlockBits(data);
    //            }

    //            frame->pts++;

    //            ret = ffmpeg.avcodec_send_frame(context, frame);
    //            if (ret < 0) throw new Exception("Error sending a frame for encoding");

    //            while (ret >= 0)
    //            {
    //                ret = ffmpeg.avcodec_receive_packet(context, &pkt);
    //                if (ret == ffmpeg.AVERROR(ffmpeg.EAGAIN) || ret == ffmpeg.AVERROR_EOF)
    //                    break;
    //                else if (ret < 0)
    //                    throw new Exception("Error during encoding");

    //                // Escribir paquete en el archivo de salida
    //                // ...

    //                ffmpeg.av_packet_unref(&pkt);
    //            }
    //        }

    //        // Flush the encoder
    //        ffmpeg.avcodec_send_frame(context, null);

    //        while (ret >= 0)
    //        {
    //            ret = ffmpeg.avcodec_receive_packet(context, &pkt);
    //            if (ret == ffmpeg.AVERROR(ffmpeg.EAGAIN) || ret == ffmpeg.AVERROR_EOF)
    //                break;
    //            // Escribir paquete restante en el archivo de salida
    //            // ...

    //            ffmpeg.av_packet_unref(&pkt);
    //        }

    //        ffmpeg.avcodec_free_context(&context);
    //        ffmpeg.av_frame_free(&frame);
    //        // Cerrar y liberar recursos del archivo de salida
    //        // ...
    //    }
    //}
}

using AutoPost.Domain.Interfaces;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;

namespace AutoPost.Infraestructure.VideoManagement
{
    public class VideoCropper : IVideoCropper
    {
        public async Task CropVideo(string VideoPathInput, string VideoPathOutput)
        {
            var inputFile = new MediaFile { Filename = VideoPathInput };
            var outputFile = new MediaFile { Filename = VideoPathOutput };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                var originalSize = inputFile.Metadata.VideoData.FrameSize.Split('x');
                var originalWidth = int.Parse(originalSize[0]);
                var originalHeight = int.Parse(originalSize[1]);

                // Asumiendo que el vídeo original es 16:9 y quieres convertirlo a 9:16
                var newWidth = originalHeight * 9 / 16;

                var cropX = (originalWidth - newWidth) / 2;  // Centrar en el eje X

                var options = new ConversionOptions
                {
                    // Estas opciones deberían definir el tamaño de la salida, no necesariamente el recorte
                    CustomHeight = originalHeight,
                    CustomWidth = newWidth,
                    // No está claro si MediaToolkit soporta SourceCrop, esto dependerá de tu versión específica de MediaToolkit
                     SourceCrop = new CropRectangle { X = cropX, Y = 0, Width = newWidth, Height = originalHeight }
                };

                // Ejecuta la conversión de forma asíncrona
                await Task.Run(() => engine.Convert(inputFile, outputFile, options));
            }
        }

        //public async Task CropVideoAsync(string inputPath, string outputPath)
        //{
        //    var inputFile = new MediaFile { Filename = inputPath };
        //    var outputFile = new MediaFile { Filename = outputPath };

        //    using (var engine = new Engine())
        //    {
        //        engine.GetMetadata(inputFile);

        //        var originalWidth = inputFile.Metadata.VideoData.FrameSize;
        //        //var originalHeight = inputFile.Metadata.VideoData.FrameSize.Height;

        //        //// Asumiendo que el vídeo original es 16:9 y quieres convertirlo a 9:16
        //        //var newWidth = originalHeight * 9 / 16;
        //        //var cropX = (originalWidth - newWidth) / 2;  // Centrar en el eje X

        //        //var options = new ConversionOptions
        //        //{
        //        //    CustomHeight = originalHeight,
        //        //    CustomWidth = newWidth,
        //        //    SourceCrop = cropX
        //        //    // Establece las opciones de recorte como argumentos personalizados para FFmpeg
        //        //    //CustomArguments = $"-vf \"crop={newWidth}:{newHeight}:{cropX}:{cropY}\""
        //        //};
        //        await Task.Delay(100);
        //        // Ejecuta la conversión de forma asíncrona
        //        //await Task.Run(() => engine.Convert(inputFile, outputFile, options));
        //    }
        //}
    }
}

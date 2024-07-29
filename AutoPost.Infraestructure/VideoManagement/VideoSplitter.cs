using AutoPost.Domain.Interfaces;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AutoPost.Infrastructure.VideoManagement
{
    public class VideoSplitter : IVideoSplitter, IDisposable
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly CancellationToken cancellation;
        private readonly Engine engine;

        // Constructor para inicializar el CancellationToken y el Engine.
        public VideoSplitter()
        {
            cancellation = cancellationTokenSource.Token;
            engine = new Engine();
        }

        public void Dispose()
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            engine.Dispose();
        }

        public async Task SplitVideoByDuration(string videoPath, string outputPath, int splitDuration)
        {
            // Verificación de Parámetros
            if (!File.Exists(videoPath))
                throw new FileNotFoundException("El archivo de video no fue encontrado.", videoPath);

            if (splitDuration <= 0)
                throw new ArgumentException("La duración del segmento debe ser un número positivo.", nameof(splitDuration));

            // Inicialización de archivos de media
            var inputFile = new MediaFile { Filename = videoPath };
            var outputFile = new MediaFile();

            await Task.Run(() =>
            {
                try
                {
                    engine.GetMetadata(inputFile);
                    var segmentDuration = TimeSpan.FromSeconds(splitDuration);
                    var totalDuration = inputFile.Metadata.Duration;
                    var contadorVideos = 0;
                    TimeSpan? lastSegmentDuration = null;

                    for (var i = TimeSpan.Zero; i < totalDuration; i += segmentDuration)
                    {
                        if (cancellation.IsCancellationRequested) break;

                        if (totalDuration - i < segmentDuration * 2)
                        {
                            lastSegmentDuration = totalDuration - i;
                        }

                        var currentSegmentDuration = lastSegmentDuration ?? segmentDuration;
                        contadorVideos += 1;
                        outputFile.Filename = $"{Path.Combine(outputPath, Path.GetFileNameWithoutExtension(inputFile.Filename))}_{contadorVideos:D3}.mp4";
                        if (File.Exists(outputFile.Filename)) continue;
                        var options = new ConversionOptions
                        {
                            Seek = i,
                            MaxVideoDuration = currentSegmentDuration
                        };


                        engine.Convert(inputFile, outputFile, options);

                        if (lastSegmentDuration.HasValue) break;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de Excepciones: Log o rethrow si es necesario
                    throw new InvalidOperationException("Ocurrió un error al dividir el video.", ex);
                }
            }, cancellation);
        }
        public async Task SplitVideoByNumberSplits(string videoPath, string outputPath, int numberOfSplits)
        {
            // Verificación de Parámetros
            if (!File.Exists(videoPath))
                throw new FileNotFoundException("File not found.", videoPath);

            if (numberOfSplits < 1)
                throw new ArgumentException("Split number must be more than one.", nameof(numberOfSplits));

            // Inicialización de archivos de media
            var inputFile = new MediaFile { Filename = videoPath };
            var outputFile = new MediaFile();

            await Task.Run(() =>
            {
                try
                {
                    engine.GetMetadata(inputFile);
                    var totalDuration = inputFile.Metadata.Duration;

                    // Calcula la duración de cada segmento
                    var segmentDuration = TimeSpan.FromSeconds(totalDuration.TotalSeconds / numberOfSplits);

                    for (int contadorVideos = 1; contadorVideos <= numberOfSplits; contadorVideos++)
                    {
                        if (cancellation.IsCancellationRequested) break;
                        var startTime = TimeSpan.FromSeconds((contadorVideos - 1) * segmentDuration.TotalSeconds);
                        outputFile.Filename = $"{Path.Combine(outputPath, Path.GetFileNameWithoutExtension(inputFile.Filename))}_{contadorVideos:D3}.mp4";
                        if (File.Exists(outputFile.Filename)) continue;
                        var options = new ConversionOptions
                        {
                            Seek = startTime,
                            MaxVideoDuration = segmentDuration
                        };

   
                        engine.Convert(inputFile, outputFile, options);
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de Excepciones: Log o rethrow si es necesario
                    throw new InvalidOperationException("Ocurrió un error al dividir el video.", ex);
                }
            }, cancellation);
        }

        public void CancelOperation()
        {
            cancellationTokenSource.Cancel();
        }
    }
}

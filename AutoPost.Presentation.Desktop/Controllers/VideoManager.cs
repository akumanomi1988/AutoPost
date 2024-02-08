
using AutoPost.Application.Interfaces;
using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;
using System.Security.Policy;
using System.Text.RegularExpressions;


namespace AutoPost.Presentation.Desktop.Controllers
{
    internal class VideoManager
    {
        private readonly IVideoDownloadService _videoDownloaderService;
        private readonly IVideoManagementService _videoManagementService;

        internal async Task<string> DownloadVideoFromURL(string url,string OutputPath)
        {
            var t = await _videoDownloaderService.DownloadVideoAsync(url, OutputPath);
            return t.Path;
        }
        internal async Task SplitVideo(string videoPath, string outputPath, int numberOfSplits)
        {
            await _videoManagementService.SplitVideoByNumberSplits(videoPath, outputPath, numberOfSplits);  
        }
        internal async void Publish(Domain.Models.PostData postData, IPostPublisher publisher)
        {
            if (postData == null) return;
            if (publisher == null) return;

            if (File.Exists(postData.ContentPath))
            {
                //Its a File
                await publisher.UploadPostAsync(postData);
            }

            if (Directory.Exists(postData.ContentPath))
            {
                //Its a Directory
                var dir = new DirectoryInfo(postData.ContentPath);

                OrderFiles(dir.EnumerateFiles().Select( obj => obj.FullName).ToList()).ForEach(async file =>
                {
                    postData.Title = new FileInfo(file).Name;
                    postData.ContentPath = file;
                    await publisher.UploadPostAsync(postData);
                }) ; 
            }
        }
        //Order files with the 3 last characters of his name without extension
        private List<string> OrderFiles(List<string> filePaths)
        {
            var orderedFiles = filePaths
                .Select(filePath => new
                {
                    OriginalPath = filePath,
                    SortKey = Path.GetFileNameWithoutExtension(filePath).Length >= 3
                              ? Path.GetFileNameWithoutExtension(filePath).Substring(Path.GetFileNameWithoutExtension(filePath).Length - 3)
                              : Path.GetFileNameWithoutExtension(filePath)
                })
                .OrderBy(file => file.SortKey, StringComparer.Ordinal )
                .Select(file => file.OriginalPath)
                .ToList();

            return orderedFiles;
        }

        public VideoManager(IVideoDownloadService videoDownloaderService, IVideoManagementService videoSplitterService)
        {
            _videoDownloaderService = videoDownloaderService;
            _videoManagementService = videoSplitterService;
        }
        public async Task<string> CropVideosFromFolder(string FolderPath)
        {

            if (Directory.Exists(FolderPath))
            {
                var croppedFolder = $"{FolderPath}\\Cropped";
                Directory.CreateDirectory(croppedFolder);
                await Task.Run(() =>
                {
                    var dir = new DirectoryInfo(FolderPath);

                    OrderFiles(dir.EnumerateFiles().Select(obj => obj.FullName).ToList()).ForEach(async file =>
                    {
                        var OutputFilePath = Path.Combine(croppedFolder, new FileInfo(file).Name);
                        if(!File.Exists(OutputFilePath)) await _videoManagementService.CropVideo(file, OutputFilePath);
                    });
                });
                return croppedFolder;
            }
            return FolderPath;
        }
        public  string GetFileName(string fullFilePath)
        {
            //
            // Extrae el nombre del archivo sin la ruta ni la extensión
            var fileName = Path.GetFileNameWithoutExtension(fullFilePath);

            // Define el patrón de la expresión regular para el formato especificado (nombre + 3 dígitos)
            var regexPattern = @"^(?<name>.+)_(\d{3})$";

            // Crea el objeto Regex con el patrón definido
            var regex = new Regex(regexPattern);

            // Intenta hacer coincidir el nombre del archivo con el patrón
            var match = regex.Match(fileName);

            if (match.Success)
            {
                // Si el patrón coincide, devuelve el grupo 'name'
                return match.Groups["name"].Value;
            }
            else
            {
                // Si el patrón no coincide, devuelve el nombre del archivo sin la extensión
                return fileName;
            }
        }
    }
}


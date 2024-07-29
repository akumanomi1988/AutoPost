namespace AutoPost.AnimationCanvas.Utils
{
    internal static class Initializer
    {
        internal static void CreateDirectoryIfNotExist(string relativePath)
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), relativePath);

            if (!Directory.Exists(folderPath))
            {
                _ = Directory.CreateDirectory(folderPath);
            }
        }
    }
}

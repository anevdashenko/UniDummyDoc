using System.IO;

namespace Editor.Documentation.Services.FileHandler
{
    public class FileHandlerSample : IFileHandler
    {
        public void SavePath(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }
}
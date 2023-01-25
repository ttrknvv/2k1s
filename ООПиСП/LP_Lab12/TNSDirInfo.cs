using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab12
{
    static class TNSDirInfo
    {
        private static string _path = TNSLog.Path;
        private static string _pathToDirectory;
        public static string PathToDirectory
        {
            set 
            { 
                _pathToDirectory = value;
            }
        }
        public static void WriteCountFile()
        {
            if(_path == null || _pathToDirectory == null || !Directory.Exists(_pathToDirectory))
            {
               throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now}\n");
            File.AppendAllText(_path, $"Количество файлов в каталоге: {Directory.GetFiles(_pathToDirectory).Length} \n");
        }
        public static void WriteTimeCreation()
        {
            if (_path == null || _pathToDirectory == null || !Directory.Exists(_pathToDirectory))
            {
                throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now}\n");
            File.AppendAllText(_path, $"Время создания каталога: {Directory.GetCreationTime(_pathToDirectory)} \n");
        }
        public static void WriteCountPodDir()
        {
            if (_path == null || _pathToDirectory == null || !Directory.Exists(_pathToDirectory))
            {
                throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now}\n");
            File.AppendAllText(_path, $"Количество поддиректорий: {Directory.GetDirectories(_pathToDirectory).Length}\n");
        }
        public static void WriteParentDir()
        {
            if (_path == null || _pathToDirectory == null || !Directory.Exists(_pathToDirectory))
            {
                throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now}\n");
            File.AppendAllText(_path, $"Список родительских директорий: {Directory.GetParent(_pathToDirectory)}\n");
        }
    }
}

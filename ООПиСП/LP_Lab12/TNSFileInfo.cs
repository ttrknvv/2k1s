using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab12
{
    static class TNSFileInfo
    {
        private static string _path = TNSLog.Path;
        private static string _pathToFile;
        public static string PathToFile
        {
            set
            {
                _pathToFile = value;
            }
        }
        public static void WriteFullPath()
        {
            if (_path == null || _pathToFile == null || !File.Exists(_pathToFile))
            {
                throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now}\n");
            File.AppendAllText(_path, $"Полный путь к файлу: {(new FileInfo(_pathToFile)).DirectoryName} \n");
        }
        public static void WriteFulInf()
        {
            if(_path == null || _pathToFile == null || !File.Exists(_pathToFile))
            {
                throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now}\n");
            File.AppendAllText(_path, $"Размер: {(new FileInfo(_pathToFile)).Length / Math.Pow(10, 6)} МБ, " +
                $"Расширение: {(new FileInfo(_pathToFile)).Extension}, Имя: {(new FileInfo(_pathToFile)).Name} \n");
        }
        public static void WritrDopInf()
        {
            if (_path == null || _pathToFile == null || !File.Exists(_pathToFile))
            {
                throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now}\n");
            File.AppendAllText(_path, $"Дата создания: {(new FileInfo(_pathToFile)).CreationTime} " +
                $"Дата изменения: {(new FileInfo(_pathToFile)).LastWriteTime} \n");
        }
    }
}

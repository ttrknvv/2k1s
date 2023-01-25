using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab12
{
    static class TNSDiskInfo
    {
        private static string _path = TNSLog.Path;
        private static DriveInfo[] allDrives = DriveInfo.GetDrives();

        public static void FreeMemory() 
        {
            if (_path == null)
            {
                throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now}\n");
            foreach (var dr in allDrives)
            {
                File.AppendAllText(_path, $"Свободное место на диске {dr.Name} : {dr.TotalFreeSpace / Math.Pow(10, 9)} ГБ\n");
            }
        }
        public static void WriteFileSystem()
        {
            if (_path == null)
            {
                throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now}\n");
            foreach (var dr in allDrives)
            {
                File.AppendAllText(_path, $"Файловая система на диске {dr.Name} : {dr.DriveFormat}\n");
            }
        }
        public static void WriteGlobalInf()
        {
            if (_path == null)
            {
                throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now}\n");
            File.AppendAllText(_path, "\n\n");
            foreach (var dr in allDrives)
            {
                File.AppendAllText(_path, $"Имя диска {dr.Name}, объем : {dr.TotalSize / Math.Pow(10, 9)} ГБ\n");
                File.AppendAllText(_path, $"Доступный объем {dr.TotalFreeSpace / Math.Pow(10, 9)} ГБ, метка тома : {dr.RootDirectory}\n");
            }
        }
    }

}

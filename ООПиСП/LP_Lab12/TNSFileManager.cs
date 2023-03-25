using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab12
{
    public static class TNSFileManager
    {
        private static string _path = TNSLog.Path;
        private static string _nameDisk;
        public static string NameDisk
        {
            set { _nameDisk = value; }
        }
        public static void Z5a(string nameDisk)
        {
            DriveInfo drive = new DriveInfo(nameDisk);
            if(drive == null)
            {
                throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now} Выполнение задания Z5A\n");
            var listFiles = Directory.GetFiles(nameDisk);
            var listCat = Directory.GetDirectories(nameDisk);
            Directory.CreateDirectory(nameDisk + "\\TNSInspect");
            File.AppendAllText(nameDisk + "\\TNSInspect\\TNSdirinfo.txt", "Файлы: ");
            foreach(var a in listFiles)
            {
                File.AppendAllText(nameDisk + "\\TNSInspect\\TNSdirinfo.txt", a + " ");
            }
            File.AppendAllText(nameDisk + "\\TNSInspect\\TNSdirinfo.txt", "\nДиректории: ");
            foreach (var a in listCat)
            {
                File.AppendAllText(nameDisk + "\\TNSInspect\\TNSdirinfo.txt", a + " ");
            }
            File.Copy(nameDisk + "\\TNSInspect\\TNSdirinfo.txt", nameDisk + "\\TNSInspect\\TNSdirinfo2.txt");
            File.Delete(nameDisk + "\\TNSInspect\\TNSdirinfo.txt");
        }
        public static void Z6b(string directory)
        {
            if(!Directory.Exists(directory))
            {
                throw new Exception("No path to file.");
            }
            File.AppendAllText(_path, $"{DateTime.Now} Выполнение задания Z5b\n");
            int size = 0;
            Directory.CreateDirectory("D://TNSFiles");
            foreach(var file in Directory.GetFiles(directory))
            {
                if((new FileInfo(file)).Extension == ".pdf")
                {
                    string pth = $"D:\\TNSFiles\\copy{size++}.pdf";
                    (new FileInfo(file)).CopyTo(pth);
                }
            }
            (new DirectoryInfo("D:\\TNSFiles")).MoveTo("D:\\TNSInspect2"); //Move("D:\\TNSFiles", "D:\\TNSInspect");
        }
        public static void Z6c(string nameFolder)
        {
            File.AppendAllText(_path, $"{DateTime.Now} Выполнение задания Z5c\n");
            string oath = Path.GetDirectoryName(nameFolder);
            ZipFile.CreateFromDirectory(nameFolder, oath + "MyZip.zip");

            ZipFile.ExtractToDirectory(oath + "MyZip.zip", oath + "MyZipFolder");
        }
    }
}

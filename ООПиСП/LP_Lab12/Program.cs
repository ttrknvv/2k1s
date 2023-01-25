namespace LP_Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TNSLog.Path = "D:\\2k1s\\ООПиСП\\LP_Lab12\\TNSLog.txt";
                //////////////////////////////////////////////////////////////////////// 
                TNSDiskInfo.FreeMemory(); // работа с диском
                TNSDiskInfo.WriteFileSystem();
                TNSDiskInfo.WriteGlobalInf();
                ////////////////////////////////////////////////////////////////////////
                TNSFileInfo.PathToFile = "D:\\2k1s\\ООПиСП\\LP_Lab12\\12_Потоки_файловая система.pdf";
                TNSFileInfo.WriteFullPath(); // работа с файлом
                TNSFileInfo.WriteFulInf();
                TNSFileInfo.WritrDopInf();
                ////////////////////////////////////////////////////////////////////////
                TNSDirInfo.PathToDirectory = "D:\\2k1s\\ООПиСП\\LP_Lab12"; // работа с каталогом
                TNSDirInfo.WriteCountFile();
                TNSDirInfo.WriteTimeCreation();
                TNSDirInfo.WriteCountPodDir();
                TNSDirInfo.WriteParentDir();
                ////////////////////////////////////////////////////////////////////////
                TNSFileManager.Z5a("D:\\");
                TNSFileManager.Z6b("D:\\2k1s\\ООПиСП\\LP_Lab12");
                TNSFileManager.Z6c("D:\\TNSInspect2");
                ////////////////////////////////////////////////////////////////////////
                string FileData; 
                using (StreamReader file2 = new StreamReader("D:\\2k1s\\ООПиСП\\LP_Lab12\\TNSLog.txt"))
                {
                    int i = 0;
                    FileData = file2.ReadToEnd();
                    file2.Close();
                }
                string FileDay = "";
                string FileTime = "";
                string FileWord = "";
                string keyWord = "Свободное";
                foreach(var word in FileData.Split('\n'))
                {
                    if(word.Contains("15.12.2022"))
                    {
                        FileDay += word;
                    }
                }
                foreach (var word in FileData.Split('\n'))
                {
                    if (word.Contains("17:"))
                    {
                        FileTime += word;
                    }
                }
                foreach (var word in FileData.Split('\n'))
                {
                    if (word.Contains(keyWord))
                    {
                        FileWord += word;
                    }
                }
                Console.WriteLine($"По дню:\n {FileDay}");
                Console.WriteLine($"По промежутку:\n {FileTime}");
                Console.WriteLine($"По ключевому слову:\n {FileWord}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
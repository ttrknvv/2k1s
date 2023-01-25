using Newtonsoft.Json;

namespace SE_Lab07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType <Bed> a1 = new CollectionType<Bed>(3); // обобщенный
                a1.Add(new Bed { NameOfBed = "Masha", Count = 5 }); // добавление
                a1.Add(new Bed { NameOfBed = "Tanya", Count = 4 });
                a1.Add(new Bed { NameOfBed = "Nikita", Count = 55 });
                a1.Remove(2); // удаление
                a1.Add(new Bed { Count = 9, NameOfBed = "Tatata" });
                a1.Show(); // вывод

                CollectionType<Passwords > a2 = new CollectionType<Passwords>(3);
                a2.Add(new Passwords { Password = "123452" });
                a2.Add(new Passwords { Password = "546022" });
                a2.Add(new Passwords { Password = "123789" });
                a2.Show();

                List<int> b = new List<int>(); // обобщенный тип со стандартными типами
                b.Add(2); b.Add(3);
                List<char> b2 = new List<char>();
                b2.Add('c'); b2.Add('d');
                List<float> b3 = new List<float>();
                b3.Add((float)2.3); b3.Add((float)4.24);

                a1.WriteJson("D:\\2k1s\\ООПиСП\\LP_Lab07\\jsonCONVERT.json"); // работа с JSON
                CollectionType<Bed> a3 = new CollectionType<Bed>(3);
                a3.ReadJson("D:\\2k1s\\ООПиСП\\LP_Lab07\\jsonCONVERT.json");
                a2.Add(new Passwords());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Блок FINALLY");
            }
        }
    }
}
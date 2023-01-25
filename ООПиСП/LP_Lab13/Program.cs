
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LP_Lab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomSerializer serializer = new CustomSerializer();
            Hanger obj = new Hanger() { Count = 500, DateOfManufacture = 20192021, NameOfFabricator = "Belarus", NameOfHanger = "Alena", Price = 500 };
            string path = "D:\\2k1s\\ООПиСП\\LP_Lab13";
            // сериализация в двоичный файл
            serializer.BinarySerialize(obj, path + "\\binary.dat");
            // десериализация двоичного файла
            Hanger objBin = serializer.BinaryDeserialize(path + "\\binary.dat");
            // сериализация в SOAP
            serializer.SOAPSerialize(obj, path + "\\SOAP.dat");
            // десериализация SOAP
            //Hanger objSOAP = serializer.SOAPDeserialize(path + "\\SOAP.dat");
            // сериализация xml
            serializer.XMLSerialize(obj, path + "\\xml.xml");
            // десериализация xml
            Hanger objXML = serializer.XMLDeserialize(path + "\\xml.xml");
            // сериализация JSON
            serializer.JSONSerialize(obj, path + "\\JSON.json");
            // десериализация JSON
            Hanger objJSON = serializer.JSONDeserialize(path + "\\JSON.json");
            // сериализация коллекции
            Hanger obj2 = new Hanger() { Count = 200, DateOfManufacture = 20192022, NameOfFabricator = "Belarus2", NameOfHanger = "Alena2", Price = 550 };
            Hanger obj3 = new Hanger() { Count = 220, DateOfManufacture = 25192022, NameOfFabricator = "Belarus3", NameOfHanger = "Alena3", Price = 555 };
            List<Hanger> list = new List<Hanger>();
            list.Add(obj2);
            list.Add(obj3);
            list.Add(obj);
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<Hanger>));
            using (
                Stream fs = new FileStream("Collection.xml", FileMode.OpenOrCreate))
            {
                serializer2.Serialize(fs, list);
            }
            List<Hanger> list2 = new List<Hanger>();
            using (FileStream fs = new FileStream("Collection.xml", FileMode.OpenOrCreate))
            {
                list2 = (List<Hanger>)serializer2.Deserialize(fs);
            }
            // XPath
            XmlDocument document = new XmlDocument();
            document.Load("Collection.xml");
            XmlElement root = document.DocumentElement;
            Console.WriteLine("Все дочерние элементы:");
            XmlNodeList listn = root.SelectNodes("*");
            foreach(XmlNode a in listn)
            {
                Console.WriteLine(a.OuterXml);
            }
            Console.WriteLine("Все теги NameHanger");
            XmlNodeList lisnName = root.SelectNodes("//Hanger/NameOfHanger");
            foreach(XmlNode a in lisnName)
            {
                Console.WriteLine(a.InnerText);
            }
            // linq to xml
            XDocument Languages = new XDocument(new XElement("Languages", new XElement("Language", new XAttribute("name", "C#"), new XElement("company", "Microsoft"),
                new XElement("date", "1999")), new XElement("Language", new XAttribute("name", "C++"), new XElement("company", "Microsoft"), new XElement("date", "1990"))));
            Languages.Save("4Task.xml");
            Console.WriteLine("LINQ to XML:");
            foreach(XElement a in Languages.Element("Languages").Elements("Language"))
            {
                XAttribute nameAttribute = a.Attribute("name");
                XElement companyElement = a.Element("company");
                XElement priceElement = a.Element("date");

                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine($"Язык: {nameAttribute.Value}");
                    Console.WriteLine($"Компания: {companyElement.Value}");
                    Console.WriteLine($"Дата: {priceElement.Value}");
                }
                Console.WriteLine();
            }
            var lang = from a in Languages.Element("Languages").Elements("Language") where a.Element("date").Value == "1990" select a.Attribute("name").Value;
            Console.WriteLine(lang.First());

        }
    }
}

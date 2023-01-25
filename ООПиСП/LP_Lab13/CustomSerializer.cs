using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace LP_Lab13
{
    class CustomSerializer : ISerialize
    {
        public void BinarySerialize(object obj, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(Stream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
        public Hanger BinaryDeserialize(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Hanger obj;
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                obj = (Hanger)formatter.Deserialize(fs);
            }
            return obj;
        }
        public void SOAPSerialize(object obj, string path)
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            using(Stream fstream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormatter.Serialize(fstream, obj);
            }
        }
        public Hanger SOAPDeserialize(string path)
        {
            Hanger obj;
            SoapFormatter soapFormatter = new SoapFormatter();
            using (Stream fstream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                obj = (Hanger)soapFormatter.Deserialize(fstream);
            }
            return obj;
        }
        public void XMLSerialize(Hanger obj, string path)
        {
            XmlSerializer xSer = new XmlSerializer(typeof(Hanger));
            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xSer.Serialize(fs, obj);
            }
        }
        public Hanger XMLDeserialize(string path)
        {
            Hanger obj;
            XmlSerializer xSer = new XmlSerializer(typeof(Hanger));
            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                obj = xSer.Deserialize(fs) as Hanger;
            }
            return obj;
        }
        public void JSONSerialize(Hanger obj, string path)
        {
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(Hanger));
            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                jsonSer.WriteObject(fs, obj);
            }
        }
        public Hanger JSONDeserialize(string path)
        {
            Hanger obj;
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(Hanger));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                obj = (Hanger)jsonSer.ReadObject(fs);
            }
            return obj;
        }
    }
}

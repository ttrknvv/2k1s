using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LP_Lab04
{
    internal class ControlStorage
    {
        public int CostOfAllWardrobe(Storage a)
        {
            int sum = 0;
            
            for(int i = 0; i < a.CountOfElements; i++)
            {
                if(a.GetElementOnID(i) is Wardrobe)
                {
                    Wardrobe? b = a.GetElementOnID(i) as Wardrobe;
                    sum += b.Count * b.Price;
                }
            }
            return sum;
        }
        public int PriceOfFabricator(Storage a, string Country)
        {
            int count = 0;
            for (int i = 0; i < a.CountOfElements; i++)
            {
                if (a.GetElementOnID(i) is Furniture)
                {
                    Furniture? b = a.GetElementOnID(i) as Furniture;
                    if(b.NameOfFabricator == Country)
                    {
                        count += b.Price * ((ICount)b).Count;
                    }
                    
                }
            }
            return count;
        }
        public void ReadFileIntoStore(string wayFile, Storage a)
        {
            string []data = File.ReadAllLines(wayFile);
            a.CountOf = data.Length / 3;
            for(int i = 0; i < data.Length;)
            {
                switch(data[i++])
                {
                    case "Bed": Bed a1 = new Bed();
                                a1.NameOfBed = data[i++];
                                a1.NameOfFabricator = data[i++];
                                a.AddElement(a1);
                                break;

                    case "Curbstone": Curbstone a2 = new Curbstone();
                                      a2.NameOfCurbstone = data[i++];
                                      a2.NameOfFabricator = data[i++];
                                      a.AddElement(a2);
                                      break;
                                       
                    case "Hanger": Hanger a3 = new Hanger();
                                      a3.NameOfHanger = data[i++];
                                      a3.NameOfFabricator = data[i++];
                                      a.AddElement(a3);
                                      break;
                }
            }
        }
        public void ReadJsonIntoStore(string wayFile, Storage a)
        {
            string[] data = File.ReadAllLines(wayFile);
            a.CountOf = data.Length / 6;
            int iterator1 = 0;
            while (iterator1 < data.Length)
            {
                string str = String.Join("", data, iterator1, 6);
                string product = "";
                for(int i = 15; str[i] != '\''; i++)
                {
                    product += str[i];
                }
                switch(product)
                {
                    case "Bed" : Bed b1 = new Bed();
                                 b1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Bed>(str);
                                 a.AddElement(b1);
                                 break;
                    case "Sofa": Sofa b2 = new Sofa();
                                 b2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Sofa>(str);
                                 a.AddElement(b2);
                                 break;
                    case "Curbstone": Curbstone b3 = new Curbstone();
                                      b3 = Newtonsoft.Json.JsonConvert.DeserializeObject<Curbstone>(str);
                                      a.AddElement(b3);
                                      break;
                    case "Hanger": Hanger b4 = new Hanger();
                                   b4 = Newtonsoft.Json.JsonConvert.DeserializeObject<Hanger>(str);
                                   a.AddElement(b4);
                                   break;
                }
                iterator1 += 6;
            }           
            
        }
    }
}

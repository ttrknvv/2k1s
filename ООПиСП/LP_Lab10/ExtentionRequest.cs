using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab10
{
    public static class ExtentionRequest
    {
        public static int MeanFromMaxAndMin(this IEnumerable<int> data)
        {
            if(data.Count() == 0)
            {
                throw new Exception("No elements");
            }
            if(data.Count() == 1)
            {
                return data.First();
            }
            else
            {
                return (data.Max() + data.Min()) / 2;
            }
        } // среднее значение между max min
        public static IEnumerable<int> Sort(this IEnumerable<int> data, int point) // сортировка пузырьком
        {
            if(data.Count() == 0)
            {
                throw new Exception("No elements");
            }
            if(point < 1 || point > 3)
            {
                throw new Exception("Invalid point");
            }
            int[] result = data.ToArray();
            for(int i = 0; i < result.Length - 1; i++)
            {
                for(int j = i + 1; j < result.Length; j++)
                {
                    if(point == 1) // по возрастанию
                    {
                        if (result[i] > result[j])
                        {
                            int temp = result[j];
                            result[j] = result[i];
                            result[i] = temp;
                        }
                    }
                    if(point == 2) // по убыванию
                    {
                        if (result[i] < result[j])
                        {
                            int temp = result[j];
                            result[j] = result[i];
                            result[i] = temp;
                        }
                    }
                    
                }
            }
            return result;
        }
        public static IEnumerable<int> RandgeOrder(this IEnumerable<int> data)
        {
            int []result = data.ToArray();
            for (int i = 0; i < data.Count(); i++)
            {
                result[i] = i + 1;
            }
            return result;
        } // генерация от 1 до count
        public static List<int> CreateCollection(this IEnumerable<int> data, Predicate<int> func)
        {
            int[] coll = data.ToArray();
            List<int> result = new List<int>();
            for(int i = 0; i < coll.Count(); i++)
            {
                if (func(coll[i]))
                {
                    result.Add(coll[i]);
                }
            }
            return result;
        } // список по предикату
        public static bool ConditionIsTrue(this IEnumerable<int> data, Predicate<int> func)
        {
            int[] arr = data.ToArray();
            for(int i = 0; i < arr.Count(); i++)
            {
                if (!func(arr[i]))
                {
                    return false;
                }
            }
            return true;
        } // проверка словия для всех элементов
        public static List<int> JoinCondition(this IEnumerable<int> data, IEnumerable<int> data2, Predicate<int> func)
        {
            int[] arr1 = data.ToArray();
            int []arr2 = data2.ToArray();
            List<int> result = new List<int>();
            for(int i = 0; i < arr1.Count(); i++)
            {
                if (func(arr1[i]))
                {
                    result.Add(arr1[i]);
                }
            }
            for (int i = 0; i < arr2.Count(); i++)
            {
                if (func(arr2[i]))
                {
                    result.Add(arr2[i]);
                }
            }
            return result;
        }
        // формирование списка объединения с условием
    }
}

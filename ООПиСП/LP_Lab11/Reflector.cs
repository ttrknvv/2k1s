using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab11
{
    static class Reflector
    {
        private static string _pathToFile;
        private static string _nameOfClass;
        private static Type _typeClass;
        public static string PathToFile
        {
            set { _pathToFile = value; }
        }
        public static string NameOfClass
        {
            set 
            { 
                _nameOfClass = value;
                _typeClass = Type.GetType(_nameOfClass, true, true);
            }
        }
        public static void StartWriteInfo()
        {
            if(_nameOfClass == "")
            {
                throw new Exception("Not find class");
            }
            File.WriteAllText(_pathToFile, $"Здесь указана информация о классе: {_nameOfClass}\n");
        }
        public static void WriteNameOfAssembly()
        {
            if (_nameOfClass == "")
            {
                throw new Exception("Not find class");
            }
            File.AppendAllText(_pathToFile, $"a) Имя сборки: {_typeClass.Assembly.FullName}\n");
        }
        public static void WritePublicConstructor()
        {
            if (_nameOfClass == "")
            {
                throw new Exception("Not find class");
            }
            bool publicC = false;
            foreach (var type in _typeClass.GetConstructors())
            {
                if(type.IsPublic)
                {
                    publicC = true;
                }
            }
            File.AppendAllText(_pathToFile, $"b) Наличие публичных конструктуров: {publicC}\n");
        }
        public static IEnumerable<string> GetAllPublicMethods()
        {
            if (_nameOfClass == "")
            {
                throw new Exception("Not find class");
            }
            File.AppendAllText(_pathToFile, $"c) Все публичные методы: ");
            foreach (var type in _typeClass.GetMethods())
            {
                if (true)
                {
                    File.AppendAllText(_pathToFile, type.Name + " ");
                }
            }
            File.AppendAllText(_pathToFile, "\n");

            var publicM = _typeClass.GetMethods().Select(p => p.Name);
            return publicM;
        }
        public static IEnumerable<string> GetDataAndPropetry()
        {
            if (_nameOfClass == "")
            {
                throw new Exception("Not find class");
            }
            File.AppendAllText(_pathToFile, "d1) Все поля класса: ");
            foreach (var type in _typeClass.GetRuntimeFields())
            {
                File.AppendAllText(_pathToFile, type.Name + " ");
            }
            var fields = _typeClass.GetRuntimeFields().Select(f => f.Name);
            File.AppendAllText(_pathToFile, "\nd2) Все свойства класса: ");
            foreach (var type in _typeClass.GetRuntimeProperties())
            {
                File.AppendAllText(_pathToFile, type.Name + " ");
            }
            File.AppendAllText(_pathToFile, "\n");
            var properties = _typeClass.GetRuntimeProperties().Select(f => f.Name);
            return fields.Concat(properties);
        }
        public static IEnumerable<string> GetAllInterface()
        {
            File.AppendAllText(_pathToFile, "e) Все интерфейсы класса: ");
            foreach (var type in _typeClass.GetInterfaces())
            {
                File.AppendAllText(_pathToFile, type.Name + " ");
            }
            File.AppendAllText(_pathToFile, "\n");
            var allInter = _typeClass.GetInterfaces().Select(p => p.Name);
            return allInter;
        }
        public static void WriteAllMethodIncludeParam(string nameClass, Type type)
        {
            if(Type.GetType(nameClass) == null)
            {
                throw new Exception("Not find class");
            }
            Type classA = Type.GetType(nameClass);
            File.AppendAllText(_pathToFile, $"f) Имена методов класса {nameClass} с параметров типа {type.Name}: ");
            foreach(var methods in classA.GetRuntimeMethods())
            {
                foreach(var param in methods.GetParameters())
                {
                    if (param.ParameterType == type)
                    {
                        File.AppendAllText(_pathToFile, methods.Name);
                        break;
                    }
                }
            }
            
            File.AppendAllText(_pathToFile, "\n");
        }
        public static void Invoke(string nameClass, string nameMethods, object[] paramets)
        {
            if (Type.GetType(nameClass) == null)
            {
                throw new Exception("Not find class");
            }
            Type classA = Type.GetType(nameClass);
            if(classA.GetMethod(nameMethods) == null)
            {
                //throw
            }
            var methodA = classA.GetMethod(nameMethods);
            methodA.Invoke(new RandomClass(), new object[] { Convert.ToDouble(paramets[0]), 
                            Convert.ToDouble(paramets[1]), Convert.ToInt32(paramets[2])});
        }
        public static object Create<T>(T obj)
        {
            ConstructorInfo? cons = null;
            Type type = obj as Type;
            foreach(var n in type.GetConstructors())
            {
                if (n.IsPublic && n.GetParameters().Length == 0)
                {
                    cons = n;
                    break;
                }
            }
            if(cons == null)
            {
                return null;
            }
            return cons.Invoke(new object[] { });
        }
    }
}

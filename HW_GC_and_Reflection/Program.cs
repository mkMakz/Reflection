using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW_GC_and_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("С помощью рефлексии получить список методов класса Console и вывести на экран.");
            Console.WriteLine();

            Type console = typeof(Console);
            MethodInfo[] methods = console.GetMethods();

            foreach (MethodInfo m in methods)
            {
                Console.WriteLine("-->" + m.ReturnType.Name + " - " + m.Name);
                ParameterInfo[] p = m.GetParameters();
                for (int i = 0; i < p.Length; i++)
                {
                    Console.WriteLine(p[i].ParameterType.Name + " " + p[i].Name);
                }
            }
          
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine("2. Описать класс с несколькими свойствами. Создать экземпляр класса и инициализировать его свойства." +
                " С помощью рефлексии получить свойства и их значения из созданного экземпляра класса." +
                " Вывести полученные значения на экран");
            Console.WriteLine();

            User user = new User()
            {
                Id = 1,
                Login = "root",
                Password = "admin"
            };

            Type type = typeof(User);
            Console.WriteLine("Type -> " + type.Name);

            PropertyInfo[] props = type.GetProperties();
            Console.WriteLine("Properties --> " + props.Length);

            foreach (var prop in props)
                if (prop.GetIndexParameters().Length == 0)
                    Console.WriteLine("     {0} ({1}): {2}", prop.Name,
                                      prop.PropertyType.Name,
                                      prop.GetValue(user, null));
        }

        public class User
        {
            public long Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}

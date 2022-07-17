using System;
using System.Collections.Generic;


namespace DZ_2m_11l
{
    public class Program
    {
        static void Main(string[] args)
        {
            Head();
        }

        private static void Head()
        {
            //Создание объекта, вызов его методов и работа с ним
            var s = new Stack("a", "b", "c");
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            var deleted = s.Pop();
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
            s.Add("d");
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            s.Pop();
            s.Pop();
            s.Pop();
            Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
            //s.Pop(); //Раскомментировать для получения ошибки. Обработчик не стал делать.
            s = new Stack("a", "b", "c");
            s.Merge(new Stack("1", "2", "3"));
            Stack.Print(s);
            s = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            Stack.Print(s);
        }
        //Класс коллекция
        public class Stack
        {
            public List<string> stack = new List<string>();

            //Конструктор
            public Stack(params string[] inputs)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    stack.Add(inputs[i]);
                }
            }
            //Методы

            public static Stack Concat(params Stack[] inputs)
            {
                var a = new Stack();
                for (int i = 0; i < inputs.Length; i++)
                {
                    a.Merge(inputs[i]);
                }
                return a;
            }


            public void Add(string a)
            {
                stack.Add(a);
            }
            public string Pop()
            {

                if (stack.Count != 0)
                {
                    var a = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                    return a;
                }
                else
                {
                    throw new Exception("Список пуст!");
                }
            }

            public static void Print(Stack stack)
            {
                Console.WriteLine("////////////////////////////////");
                for (int i = 0; i < stack.Size; i++)
                {
                    Console.Write(stack.stack[i]);
                }
                Console.WriteLine();
                Console.WriteLine("////////////////////////////////");
            }



            //Свойства
            public int Size
            {
                get
                {
                    return stack.Count;
                }

            }

            public string Top
            {
                get
                {
                    if (stack.Count != 0)
                    {
                        return stack[stack.Count - 1];
                    }
                    else
                    {
                        return null;
                    }
                }
            }

        }
    }



    //Расширение класса.
    public static class StackEtensions
    {
        public static void Merge(this Program.Stack stack, Program.Stack a)
        {
            var j = a.Size;
            a.stack.Reverse(a.stack.Count, 0);
            for (int i = 0; i < j; i++)
            {
                stack.Add(a.Top);
                a.stack.RemoveAt(a.stack.Count - 1);
            }
        }
    }
}
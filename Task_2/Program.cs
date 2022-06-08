using System;
using System.Collections.Generic;

namespace Task_2
{
    internal class Program
    {
        //Создайте консольный мини-калькулятор, который будет подсчитывать сумму двух чисел.
        //Определите интерфейс для функции сложения числа и реализуйте его.
        //Реализуйте механизм внедрения зависимостей: добавьте в мини-калькулятор логгер, используя материал из скринкаста юнита 10.1.
        //Дополнительно: текст ошибки, выводимый в логгере, окрасьте в красный цвет, а текст события — в синий цвет.
        static ILogger Logger { get; set; }
        static void Main(string[] args)
        {
            Logger = new Logger();
            IArithmetic calc = new Calculator(Logger);
            calc.CollectNumbers();
            calc.Addition();
        }
    }

    public interface IArithmetic
    {
        public void Addition();
        public void Subtraction();
        public void CollectNumbers();

    }
    public class Calculator : IArithmetic, ILogger
    {
        ILogger Log { get; }
        private int[] numbers;
        public Calculator(ILogger logger)
        {
            Log = logger;
            numbers = new int[2];
        }

        public void CollectNumbers()
        {
            try
            {
                for(int i = 0; i < numbers.Length; i++)
                {
                    Log.Event(string.Concat("Введите число " , (i + 1), ": "));
                    numbers[i] = Convert.ToInt32(Console.ReadLine()); 
                }
            }
            catch(FormatException)
            {
                Log.Error("Ошибка ввода.");
            }
            finally
            {
                Console.WriteLine("============");
            }
        }
        void IArithmetic.Addition()
        {
            Log.Event(string.Concat("Сумма чисел = ", Convert.ToString(numbers[0] + numbers[1])));
        }

        void IArithmetic.Subtraction()
        {
            Log.Event(string.Concat("Разнича чисел = ", Convert.ToString(numbers[0] - numbers[1])));
        }

    }

    public interface ILogger 
    {
        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(message);
        }
        public void Error(string message)
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine(message); 
        }
    }
    public class Logger : ILogger
    { }
}

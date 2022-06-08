using System;

namespace Practices_10_5_1
{
    internal class Program
    {
        //Создайте консольный мини-калькулятор, который будет подсчитывать сумму двух чисел.
        //Определите интерфейс для функции сложения числа и реализуйте его.
        static void Main(string[] args)
        {
            try
            {
                int x, y, result;

                IArithmetic calc = new Calculator();

                Console.Write("Введите первое число: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите второе число: ");
                y = Convert.ToInt32(Console.ReadLine());

                result = calc.Addition(x, y);

                Console.WriteLine("Рузультат = {0}", result);
            }
            catch (Exception ex) when (ex is FormatException)
            {
                Console.WriteLine("Ошибка ввода");
                Console.WriteLine("Нажмите любую клавишу");
            }
            finally
            {
                Console.ReadKey();
            }
            
        }
    }

    public interface IArithmetic
    {
        public int Addition(int x, int y);
        public int Subtraction(int x, int y);

    }
    public class Calculator : IArithmetic
    {
        int IArithmetic.Addition(int x, int y)
        {
            return x + y ;
        }

        int IArithmetic.Subtraction(int x, int y)
        {
            return x - y;
        }
    }
}

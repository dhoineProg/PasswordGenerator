using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePassword
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в генератор паролей!");
            Console.WriteLine();
            int length = 0;
            bool validLength = false;
            while (!validLength) // Цикл для проверки на корректность введенных данных
            {
                try
                {
                    Console.Write("Выберите количество символов в пароле (1-10): ");
                    length = Int32.Parse(Console.ReadLine());
                    if (length >= 1 && length <= 10) validLength = true;
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите число от 1 до 10.");
                        Console.WriteLine();
                    }
                }
                catch (Exception e) // Исключение при вводе некорректного значения
                {
                    Console.WriteLine("Ошибка " + e.Message);
                    Console.WriteLine("Введите корректное значение.");
                }
            }

            string line = new string('_', 65);
            Console.WriteLine(line);
            Console.WriteLine();

            int count = 0;
            bool validCount = false;
            while (!validCount) // Цикл для проверки на корректность введенных данных
            {
                try
                {
                    Console.Write("Выберите количество паролей, которые нужно сгенерировать (1-5): ");
                    count = Int32.Parse(Console.ReadLine());
                    if (count >= 1 && count <= 5) validCount = true;
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите число от 1 до 5.");
                        Console.WriteLine();
                    }
                }
                catch (Exception e) // Исключение при вводе некорректного значения
                {
                    Console.WriteLine("Ошибка " + e.Message);
                    Console.WriteLine("Введите корректное значение.");
                }
            }
            Console.WriteLine(line);
            while (count > 0) // Вывод паролей
            {
                --count;
                char[] password = GeneratePassword(length, count);
                Console.WriteLine(password);
            }
            Console.ReadKey();           
        }


        public static char[] GeneratePassword(int length, int count) // Метод генерации паролей
        {
            Random rand = new Random(); // Создаем объект класса Random для генерации случайных чисел
            char[] password = new char[length]; // Создаем массив размера переменной length
            while (count >= 0)
            {
                --count;
                for (int i = 0; i < length; i++)
                {
                    int randNumb = rand.Next(1, 4);
                    if (randNumb == 1) password[i] = (char)rand.Next(65, 90); // Если число равно 1, то добавляем случайную букву в верхнем регистре
                    else if (randNumb == 2) password[i] = (char)rand.Next(48, 57); // Если число равно 2, то добавляем случайное число
                    else if (randNumb == 3) password[i] = (char)rand.Next(97, 122); // Если число равно 3, то добавляем случайную букву в нижнем регистре
                }
                
            }
            return password;
        }
    }
}

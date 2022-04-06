using System;
using System.IO;

namespace Exceptions
{
    public class Hero
    {
        public int Number;
    }

    public class Mage : Hero
    {
        public int Mana;
    }
    
    public class Exceptions
    {
        public int DivideByZeroException(int divisible, int divisor) // !#1. Обрабатываем деление на ноль, присваивая 0.
        {
            Console.WriteLine("#1. Деление на ноль.");
            Console.WriteLine("Делим одно число на другое.");
            int result;
            Console.WriteLine($"divisible = {divisible}, divisor = {divisor}, result - ?");
            try
            { 
                result = divisible / divisor;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"Исключение: {e.Message}");
                Console.WriteLine($"Метод: {e.TargetSite}");
                result = 0;
            }

            Console.WriteLine($"result = {result}");
            Console.WriteLine();
            return result;
        }

        public int OverflowException(int n) // !#2. Обрабатываем выход за границы Int32, присваивая в результат -1.
        {
            Console.WriteLine("#2. Выход за допустимые границы аргумента");
            Console.WriteLine("Считаем факториал числа.");
            var result = 1;
            Console.WriteLine($"n = {n}, n! - ?");
            try
            {

                for (var i = 2; i <= n; i++) 
                {
                    result = checked(result * i);
                    Console.WriteLine(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"Исключение: {e.Message}");
                Console.WriteLine($"Метод: {e.TargetSite}");
                result = -1;
            }

            Console.WriteLine($"result = {result}");
            Console.WriteLine();
            return result;
        }

        public int FormatException(string str) // !#3. Обрабатываем неудачную попытку сконвертить строку в число, присваивая в переменную значение -1.
        {
            Console.WriteLine("#3. Вызов метода, который преобразует строку в другой тип данных, а строка не соответствует требуемому шаблону.");
            var result = 0;
            try
            {
                
                result = Convert.ToInt32(str);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"Исключение: {e.Message}");
                Console.WriteLine($"Метод: {e.TargetSite}");
                result = -1;
            }

            Console.WriteLine($"result = {result}");
            Console.WriteLine();
            return result;
        }

        public int InvalidCastException() // !#4. Обрабатываем недопустимые преобразования типов, присваивая переменные полям объекта.
        {
            Console.WriteLine("#4. Попытка произвести недопустимые преобразования типов.");
            
            var hero = new Hero
            {
                Number = 4
            };
            var mage = new Mage
            {
                Number = 5,
                Mana = 6
            };
            Console.WriteLine($"hero: number = {hero.Number}.");
            Console.WriteLine($"mage: mage.Number = {mage.Number}, mage.Mana = {mage.Mana}.");
            
            try
            {
                mage = (Mage) hero;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.Message);
                Console.WriteLine($"Метод: {e.TargetSite}");
                mage.Number = 4;
                Console.WriteLine($"mage: mage.Number = {mage.Number}, mage.Mana = {mage.Mana}.");
            }
            Console.WriteLine();
            return 1; // Достаточно вызвать в Main и посмотреть на работу данного метода.
        }

        public int[] IndexOutOfRangeException(int[] array, int index) // !#5. Обрабатываем выход за границы массива, вызывая Resize и записывая значение.
        {
            Console.WriteLine("#5. Выход за границы массива.");
            Console.Write($"array[{index}]:");
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = i;
                Console.WriteLine($"{i} => {array[i]}");
            }
            Console.WriteLine($"array[{index}] = {index} => Exception?");
            try
            {
                array[index] = index;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"Исключение: {e.Message}");
                Console.WriteLine($"Метод: {e.TargetSite}");
                Array.Resize(ref array, index + 1);
                array[index] = index;
                Console.Write("Resize: ");
            }
            Console.WriteLine($"array[{index}] = {array[index]}");
            Console.WriteLine();
            return array;
        }

        public FileStream ArgumentException(string path) // !#6. Обрабатываем некорректное открытие файла, создавая новый.
        {
            Console.WriteLine("#6. Попытка открыть файл, который не существует.");
            FileStream text;
            try
            {
                text = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
                Console.WriteLine($"Метод: {e.TargetSite}");
                Console.WriteLine("Файл не существует. Создаем новый.");
                text = File.Create(Path.GetTempFileName());
                Console.WriteLine();
                return text;
            }
            Console.WriteLine("Файл открыт успешно.");
            Console.WriteLine();
            return text;
        }
        
        public bool NotSupportedException(FileStream text) // !#7. Обрабатываем исключение, вызываемое при попытке
                                            // записи в поток, который не поддерживает вызванную
                                            // функцию, выводя сообщение с просьбой изменить Access.
        {
            Console.WriteLine("#7. Пытаемся записать в файл (Access: read) что-то.");
            try
            {
                text.WriteByte(5);
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
                Console.WriteLine($"Метод: {e.TargetSite}");
                Console.WriteLine("В файл нельзя ничего записывать!.");
                Console.WriteLine();
                return false;
            }
            Console.WriteLine("Записали в файл: 5");
            Console.WriteLine();
            return true;
        }

        public bool ArrayTypeMismatchException(Object[] array, Object obj) // !#8. Обрабатываем исключение, которое выдается
                                                                           // при попытке сохранить в массиве элемент неподходящего
                                                                           // типа, выводя сообщение на консоль и возвращая false.
        {
            Console.WriteLine("#8. Пытаемся сохранить в массиве элемент неподходящего типа.");
            try
            {
                array[0] = obj;
            }
            catch(ArrayTypeMismatchException e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
                Console.WriteLine("Попытка сохранить в массиве элемент неподходящего типа.");
                Console.WriteLine();
                return false;
            }
            Console.WriteLine("Сохранили элемент в массиве.");
            Console.WriteLine();
            return true;
        }

        public Hero NullReferenceException(Hero hero) // !#9. Обрабатываем попытку обратиться к объекту, равному null, производя инициализацию.
        {
            Console.WriteLine("#9. Пытаемся присвоить полю Number объекта hero значение, равное 5.");
            try
            {
                hero.Number = 5;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
                Console.WriteLine($"Метод: {e.TargetSite}");
                hero = new Hero
                {
                    Number = 5
                };
            }
            Console.WriteLine($"hero.Number = {hero.Number}");
            Console.WriteLine();
            return hero;
        }
    }
    
}

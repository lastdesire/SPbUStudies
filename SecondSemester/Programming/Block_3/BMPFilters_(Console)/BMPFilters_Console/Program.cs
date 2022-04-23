using System;
using System.Drawing;
using System.IO;
using BMPFilters;

namespace BMPFilters_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа применяет фильтры к картинке, путь к которой вы укажите, а также устанавливает заданную прозрачность.");

            bool flag = true;
            FileStream fileInput = null;
            FileStream fileOutput = null;
            string chosenFilter = "";
            // Организовываем корректный ввод от пользователя с помощью цикла и флага, который сигнализирует о том, что ввод не является корректным. 
            while (flag)
            {
                flag = false;

                // Выбор нужного фильтра.
                Console.WriteLine("Чтобы выбрать фильтр, введите его название в консоль:");
                Console.WriteLine("Без фильтра -- standard");
                Console.WriteLine("Перевод в оттенки серого -- gray");
                Console.WriteLine("Усредняющий фильтр 3x3 -- median");
                Console.WriteLine("Усредняющий фильтр Гаусса 3x3 -- gauss");
                Console.WriteLine("Фильтр Собеля по X -- sobelx");
                Console.WriteLine("Фильтр Собеля по Y -- sobely");
                chosenFilter = Console.ReadLine();
                if (!chosenFilter.Equals("standard") && !chosenFilter.Equals("gray") && !chosenFilter.Equals("median") && !chosenFilter.Equals("gauss") && !chosenFilter.Equals("sobelx") &&
                    !chosenFilter.Equals("sobely"))
                {
                    Console.WriteLine("Введенного вами фильтра не существует, повторите ввод с самого начала:");
                    flag = true;
                    continue;
                }

                // Открытие файла по введенному пути.
                Console.WriteLine("Введите путь к файлу:");
                var inputPath = Console.ReadLine();
                try
                {
                    fileInput = new FileStream(inputPath, FileMode.Open, FileAccess.ReadWrite);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Файл не был найден, повторите ввод с самого начала:");
                    Console.WriteLine("Формат ввода следующий: <path>\\<name>.<type>");
                    flag = true;
                    continue;
                }

                // Сохранение файла по введенному пути.
                Console.WriteLine("Введите путь куда разместить результат работы программы:");
                Console.WriteLine("Формат ввода следующий: <path>\\<name>.<type>");

                var outputPath = Console.ReadLine();
                try
                {
                    fileOutput = new FileStream(outputPath, FileMode.Create, FileAccess.ReadWrite);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Невозможно создать файл по указанному пути, повторите ввод с самого начала:");
                    fileInput.Close();
                    flag = true;
                    continue;
                }
            }
            Console.WriteLine("Ввод прошел успешно. Начинаем применять фильтры...");

            // Применяем выбранный фильтр.
            var bitmap = new Bitmap(fileInput);
            if (chosenFilter.Equals("standard"))
            {
            }
            else if (chosenFilter.Equals("gray"))
            {
                GrayFilter.ApplyFilter(bitmap);
            }
            else if (chosenFilter.Equals("median"))
            {
                MedianFilter.ApplyFilter(bitmap);
            }
            else if (chosenFilter.Equals("gauss"))
            {
                GaussFilter.ApplyFilter(bitmap);
            }
            else if (chosenFilter.Equals("sobelx"))
            {
                SobelFilter.ApplyFilter(bitmap, SobelFilterType.SobelX);
            }
            else if (chosenFilter.Equals("sobely"))
            {
                SobelFilter.ApplyFilter(bitmap, SobelFilterType.SobelY);
            }

            // Записываем результат и закрываем файлы.
            fileInput.Close();
            bitmap.Save(fileOutput, System.Drawing.Imaging.ImageFormat.Bmp);
            fileOutput.Close();
        }


    }
}
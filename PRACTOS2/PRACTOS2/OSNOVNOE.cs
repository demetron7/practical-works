using System;
using System.IO;

namespace PRACTOS2
{
    internal class OSNOVNOE
    {
        /// <summary>
        /// Генерация двумерного массива случайными числами.
        /// </summary>
        public static void InitMas2D(out int[,] mas, int rows, int cols, int max)
        {
            Random random = new Random();
            mas = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    mas[i, j] = random.Next(max);
                }
            }
        }

        /// <summary>
        /// Сохранение двумерного массива в файл.
        /// Первая строка — "rows cols", далее — строки чисел через пробел.
        /// </summary>
        public static void SaveMas(int[,] mas, string fileName)
        {
            int rows = mas.GetLength(0);
            int cols = mas.GetLength(1);

            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.WriteLine(rows + " " + cols);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        file.Write(mas[i, j]);
                        if (j < cols - 1) file.Write(" ");
                    }
                    file.WriteLine();
                }
            }
        }

        /// <summary>
        /// Чтение двумерного массива из файла.
        /// </summary>
        public static int[,] OpenMas(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            string[] sizes = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);

            int[,] mas = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] nums = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cols; j++)
                {
                    mas[i, j] = int.Parse(nums[j]);
                }
            }

            return mas;
        }

        /// <summary>
        /// Сумма всех элементов двумерного массива.
        /// </summary>
        public static long Sum(int[,] mas)
        {
            long sum = 0;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    sum += mas[i, j];
                }
            }
            return sum;
        }
    }
}
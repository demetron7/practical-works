using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTOS1
{
    public class Calculation
    {
        /// <summary>
        /// Нахождение произведения всех элементов массива
        /// </summary>
        /// <param name="mas">Входной массив</param>
        /// <returns>Произведение элементов массива</returns>
        public static int ProductMas(int[] mas)
        {
            int product = 1; // Начальное значение произведения
            for (int i = 0; i < mas.Length; i++)
                product = product * mas[i];
            return product;
        }
    }
}

namespace PRACTOS2
{
    internal class calculator
    {
        /// <summary>
        /// Произведение всех элементов двумерного массива.
        /// </summary>
        public static long ProductMas(int[,] mas)
        {
            long product = 1;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    product *= mas[i, j];
                }
            }
            return product;
        }
    }
}
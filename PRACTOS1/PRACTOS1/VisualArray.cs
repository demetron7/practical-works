using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTOS1
{
    public static class VisualArray
    {
        /// <summary>
        /// Преобразование одномерного массива в DataTable
        /// </summary>
        public static DataTable ToDataTable(int[] mas)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Индекс", typeof(int));
            table.Columns.Add("Значение", typeof(int));

            for (int i = 0; i < mas.Length; i++)
                table.Rows.Add(i, mas[i]);

            return table;
        }
    }
}

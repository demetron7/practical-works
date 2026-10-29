using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///ПОМОГАЕТ ПЕРЕВЕСТИ ДАТА ТЭЙБЛ В ДАТА ГРИТ
namespace PRACTOS2
{
    internal class visualPOMOGI
    {
        public static DataTable ToDataTable(int[] mas)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Значение", typeof(int));
            for (int i = 0; i < mas.Length; i++)
            {
                table.Rows.Add(mas[i]);
            }
            return table;
        }
    }
}

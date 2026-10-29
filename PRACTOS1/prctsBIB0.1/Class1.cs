
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace prctsBIB0._1
{
    public class Massiv
    {
       

        public static void InitMas(out int[] mas, int elementik, int randMax) 
        {

            Random rnd = new Random();
            mas = new int[elementik];
            for (int i = 0; i < elementik; i++)
                mas[i] = rnd.Next(-randMax, randMax); 

        }

        public static void PrintMas(int[] mas)
        {
            foreach (int item in mas)
            {
                Console.WriteLine(item);

            }

        }

        public static void SaveMas(int[] mas, string save)
        {
            if(save != null)
            {
                MessageBox.Show("ÑÍÀ×ÀËÎ ÂÂÅÄÈÒÅ ÌÀÑÑÈÂ");
            }

            
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(save))
            {
                file.WriteLine(mas.Length);
                for (int i = 0;i < mas.Length;i++)              
                file.WriteLine(mas[i]);
            }
        }
        //çàãðóçêà ìàññèâà èç ôàéëà 
        public static int[] OpenMas(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            int len = Convert.ToInt32(lines[0]);
            int[] mas = new int[len];
            for (int i = 0; i < len; i++)
                mas[i] = Convert.ToInt32(lines[i + 1]);
            return mas;
        }
        public static void ClearMas(int[] mas)
        {
            Array.Fill(mas, 0);
        }
    }

}

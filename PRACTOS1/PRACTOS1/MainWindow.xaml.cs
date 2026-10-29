using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using prctsBIB0._1;

namespace PRACTOS1
{
  
    public partial class MainWindow : Window
    {
        private int[] mas;
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void zapolnit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int elementik = Convert.ToInt32(txtELEMET.Text);
                int Max = Convert.ToInt32(txtRANDMAX.Text);
                if (elementik <= 0)
                {
                    MessageBox.Show("Кол-во элементов должно быть больше 0!");
                }
                Massiv.InitMas(out mas, elementik, Max);
                DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                txtREZULT.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ашибка");
            }
        }

        private void Rachitai_Click(object sender, RoutedEventArgs e)
        {
        if (mas == null)
            {
                MessageBox.Show("сначала заполни массив");
                return;
            }
            int product = Calculation.ProductMas(mas);
            txtREZULT.Text = product.ToString();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (mas == null)
            {
                MessageBox.Show("массив пуст ");
            }

            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            save.Title = "Сохранение массива";

            if (save.ShowDialog() == true)
            {
                Massiv.SaveMas(mas, save.FileName);
                MessageBox.Show("Массив сохранён!");
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            open.Title = "Открытие массива";

            if (open.ShowDialog() == true)
            {
                mas = Massiv.OpenMas(open.FileName);
                DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                txtREZULT.Clear();
            }
        }

        private void Clear_Open(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                Massiv.ClearMas(mas);
                DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                txtREZULT.Clear();
            }
        }

        private void EXIT_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void info_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show
                (
                "практическая 1 \n" +
                "ЛАРИН ДМИТРИЙ ИСП-34",
                "О программе",
                MessageBoxButton.OK,
                MessageBoxImage.Information);



        }
    }
}

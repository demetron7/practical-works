using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PRACTOS2
{
    public partial class MainWindow : Window
    {
        private int[,] mas;  // Двумерный массив

        public MainWindow()
        {
            InitializeComponent();
        }

        private void zapolnit_click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1. Пытаемся превратить текст в числа
                if (!int.TryParse(txtELEMENT.Text, out int rows))
                {
                    MessageBox.Show("Введите корректное число строк!");
                    return;
                }

                if (!int.TryParse(txtDIAPAZONE.Text, out int cols))
                {
                    MessageBox.Show("Введите корректное число столбцов!");
                    return;
                }

                // 2. Проверяем диапазон (от 1 до 100)
                if (rows < 1 || rows > 100)
                {
                    MessageBox.Show("Количество элементов должно быть от 1 до 100!");
                    return;
                }

                if (cols < 1 || cols > 100)
                {
                    MessageBox.Show("Диапозон должен быть от 1 до 100!");
                    return;
                }

                // 3. Всё в порядке — генерируем массив
                OSNOVNOE.InitMas2D(out mas, rows, cols, 100);

                // 4. Отображаем в DataGrid
                DataGrid.ItemsSource = mas.ToDataTable().DefaultView;
                DataGrid.IsReadOnly = false;

                txtREZULTAT.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода данных: " + ex.Message);
            }
        }

        private void raschitat_click(object sender, RoutedEventArgs e)
        {
            if (mas == null || mas.Length == 0)
            {
                MessageBox.Show("Сначала заполните массив!");
                return;
            }

            long product = calculator.ProductMas(mas);
            txtREZULTAT.Text = product.ToString();
        }

        private void clear_click(object sender, RoutedEventArgs e)
        {
            mas = null;
            DataGrid.ItemsSource = null;
            txtREZULTAT.Text = "";
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
                try
                {
                    mas = OSNOVNOE.OpenMas(open.FileName);
                    DataGrid.ItemsSource = mas.ToDataTable().DefaultView;
                    DataGrid.IsReadOnly = true; // запрещаем редактировать открытый файл
                    txtREZULTAT.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка чтения файла: " + ex.Message);
                }
            }
        }

        private void save_click(object sender, RoutedEventArgs e)
        {
            if (mas == null || mas.Length == 0)
            {
                MessageBox.Show("Массив пуст, сохранять нечего!");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                try
                {
                    OSNOVNOE.SaveMas(mas, save.FileName);
                    MessageBox.Show("Файл успешно сохранён!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка сохранения файла: " + ex.Message);
                }
            }
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void info_clic(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ларин Дмитрий Витальевич исп-34");
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                int indexColumn = e.Column.DisplayIndex;
                int indexRow = e.Row.GetIndex();

                var textBox = e.EditingElement as TextBox;
                if (textBox != null)
                {
                    string inputText = textBox.Text;

                    if (int.TryParse(inputText, out int result))
                    {
                        // Запись в двумерный массив с проверкой границ
                        if (mas != null
                            && indexRow >= 0 && indexRow < mas.GetLength(0)
                            && indexColumn >= 0 && indexColumn < mas.GetLength(1))
                        {
                            mas[indexRow, indexColumn] = result;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите целое число!");
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using LibMas;
using Lib_10;

namespace Практическая_работа3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        int[,] matr;//описываем матрицу как глобальный элемент
        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Определяем номер столбца
            int columnIndex = e.Column.DisplayIndex;
            //Определяем номер строки
            int rowIndex = e.Row.GetIndex();
            //Заносим полученное значение в матрицу
            matr[rowIndex, columnIndex] = Convert.ToInt32(((TextBox)e.EditingElement).Text);

        }
        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Создать_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(RowCount.Text, out int row) == true && Int32.TryParse(ColumnCount.Text, out int count) == true)
            {
                Class2.CreateArray(out matr, count, row);//используем функцию для создания матрицы
                dataGrid.ItemsSource = VisualArray1.ToDataTable(matr).DefaultView;//выводим матрицу на форму
            }
            else MessageBox.Show("Введены некорректные значения", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Заполнить_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(RowCount.Text, out int row) == true && Int32.TryParse(ColumnCount.Text, out int count) == true && Int32.TryParse(diapazon.Text, out int randMax) == true)
            {
                Class2.InitArray(out matr, count, row, randMax);//используем функцию
                dataGrid.ItemsSource = VisualArray1.ToDataTable(matr).DefaultView;////выводим матрицу на форму
            }
            else MessageBox.Show("Введены некорректные значения", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void Решение_Click(object sender, RoutedEventArgs e)
        {
            Class1.Raschet(matr, out int num,out int minproiz);//используем функцию
            nom.Text = Convert.ToString(num);
            rez.Text = Convert.ToString(minproiz);//выводим минимальное произведение
        }

        private void Очистить_Click(object sender, RoutedEventArgs e)
        {
            Class2.CleanArray(ref matr);//используем функцию для очистки матрицы
            dataGrid.ItemsSource = VisualArray1.ToDataTable(matr).DefaultView;////выводим матрицу на форму
        }
        private void Сброс_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;//очищаем таблицу
            matr = null;//очищаем массив
            rez.Clear();//очищаем результаты вычислений
            diapazon.Clear();//очищаем диапозон случайных чисел
            ColumnCount.Clear();//очищаем количество ячеек
            RowCount.Clear();//очищаем количество ячеек
        }

        private void Сохранить_Click(object sender, RoutedEventArgs e)
        {
            Class2.SaveArray(matr);//используем функцию для сохранения матрицы
        }

        private void Открыть_Click(object sender, RoutedEventArgs e)
        {
            Class2.OpenArray(out int[,] matr);
            dataGrid.ItemsSource = VisualArray1.ToDataTable(matr).DefaultView;////выводим матрицу на форму
        }

        private void Опрограмме_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа№3\n Выполнила:Мельцаева Дарья ИСП-31\n Дана матрица размера M × N. Найти номер ее столбца с наименьшим произведением элементов и вывести данный номер, а также значение наименьшего произведения.");
        }
    }
}

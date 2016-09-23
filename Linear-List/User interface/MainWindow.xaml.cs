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
using Linear_List;

namespace User_interface
{
    public partial class MainWindow : Window
    {
        #region Поля
        /// <summary>
        /// Публичная переменная для дальнейшего использования в качестве переменной типа LinearList
        /// </summary>
        public Object MyList;
        #endregion

        #region Методы

        /// <summary>
        /// Инициализирует компоненты и переводит пользовательский интерфейс в режим выбора типа линейного списка
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InterfaceOff();
        }

        /// <summary>
        /// Переводит пользовательский интерфейс в режим выбора типа линейного списка
        /// </summary>
        public void InterfaceOff()
        {
            stpInput.IsEnabled = false;
            wrpActionButtons.IsEnabled = false;
            btnResult.IsEnabled = false;
            rbInt.IsChecked = false;
            rbDouble.IsChecked = false;
            groupBox.IsEnabled = true;
            tbResult.Text = "Для начала работы выберите тип списка (int/double)";
            groupBox.Background = Brushes.LightGreen;
        }

        /// <summary>
        /// Переводит пользовательский интерфейс в режим работы с линейным списком
        /// </summary>
        public void InterfaceOn()
        {
            stpInput.IsEnabled = true;
            wrpActionButtons.IsEnabled = true;
            btnResult.IsEnabled = true;
            groupBox.IsEnabled = false;
            groupBox.Background = Brushes.LightPink;
            tbResult.Text = "Для изменения типа списка нажмите \"очистить\"";
        }

        #endregion

        #region Обработчики событий

        /// <summary>
        /// Очищает линейный список, текстовые блоки и переводит пользовательский интерфейс в режим выбора типа линейного списка
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbInput.Text = "";
            tbResult.Text = "";
            InterfaceOff();
            MyList = null;
        }

        /// <summary>
        /// Определяет тип линейного списка
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            InterfaceOn();
            RadioButton rb = (RadioButton)sender;
            if (rb.Tag.ToString() == "int") MyList = new LinearList<int>();
            else MyList = new LinearList<double>();
        }

        /// <summary>
        /// Добавляет вперед новый элемент линейного списка со значением, указанным в поле ввода 
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnAddFront_Click(object sender, RoutedEventArgs e)
        {
            if (rbInt.IsChecked == true)
            {
                int Value;
                if ((!tbInput.Text.Contains(" ")) && (Int32.TryParse(tbInput.Text, out Value)))
                {
                    ((LinearList<int>)MyList).AddFront(Value);
                    tbInput.Text = "";
                }
                else
                {
                    tbInput.Text = "Введено неверное значение";
                }
            }
            else
            {
                double Value;
                if ((!tbInput.Text.Contains(" ")) && (Double.TryParse(tbInput.Text, out Value)))
                {
                    ((LinearList<double>)MyList).AddFront(Value);
                    tbInput.Text = "";
                }
                else
                {
                    tbInput.Text = "Введено неверное значение";
                }
            }
        }

        /// <summary>
        /// Выводит линейный список в поле вывода результата
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            if (rbInt.IsChecked == true) tbResult.Text = ((LinearList<int>)MyList).Print();
            else tbResult.Text = ((LinearList<double>)MyList).Print();
        }

        /// <summary>
        /// Очищает поле вывода результата
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnClearResult_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "";
        }

        /// <summary>
        /// Добавляет назад новый элемент линейного списка со значением, указанным в поле ввода 
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnAddBack_Click(object sender, RoutedEventArgs e)
        {
            if (rbInt.IsChecked == true)
            {
                int Value;
                if ((!tbInput.Text.Contains(" ")) && (Int32.TryParse(tbInput.Text, out Value)))
                {
                    ((LinearList<int>)MyList).AddBack(Value);
                    tbInput.Text = "";
                }
                else
                {
                    tbInput.Text = "Введено неверное значение";
                }
            }
            else
            {
                double Value;
                if ((!tbInput.Text.Contains(" ")) && (Double.TryParse(tbInput.Text, out Value)))
                {
                    ((LinearList<double>)MyList).AddBack(Value);
                    tbInput.Text = "";
                }
                else
                {
                    tbInput.Text = "Введено неверное значение";
                }
            }
        }

        /// <summary>
        /// Удаляет с указанной, в поле ввода, позиции элемент из линейного списка
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int Value;
            if ((rbInt.IsChecked == true) && (Int32.TryParse(tbInput.Text, out Value)) && (!tbInput.Text.Contains(" ")))
            {
                try
                {
                    ((LinearList<int>)MyList).Delete(Value);
                    tbInput.Text = "";
                }
                catch (Exception ex)
                {
                    tbInput.Text = ex.Message;
                }
            }
            else if ((Int32.TryParse(tbInput.Text, out Value)) && (!tbInput.Text.Contains(" ")))
            {
                try
                {
                    ((LinearList<double>)MyList).Delete(Value);
                    tbInput.Text = "";
                }
                catch (Exception ex)
                {
                    tbInput.Text = ex.Message;
                }
            }
            else
            {
                tbInput.Text = "Введено неверное значение";
            }
        }

        /// <summary>
        /// Осуществляет поиск элемента в линейном списке по значению, указанному в поле ввода
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (rbInt.IsChecked == true)
            {
                int Value;
                if ((!tbInput.Text.Contains(" ")) && (Int32.TryParse(tbInput.Text, out Value)))
                {
                    tbResult.Text = ((LinearList<int>)MyList).SearchValueToString(Value);
                    tbInput.Text = "";
                }
                else
                {
                    tbInput.Text = "Введено неверное значение";
                }
            }
            else
            {
                double Value;
                if ((!tbInput.Text.Contains(" ")) && (Double.TryParse(tbInput.Text, out Value)))
                {
                    tbResult.Text = ((LinearList<double>)MyList).SearchValueToString(Value);
                    tbInput.Text = "";
                }
                else
                {
                    tbInput.Text = "Введено неверное значение";
                }
            }
        }
        #endregion
        
    }
}



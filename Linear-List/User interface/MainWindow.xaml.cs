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
            rbInt.IsChecked = false;
            btnResult.IsEnabled = false;
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
            groupBox.IsEnabled = false;
            btnResult.IsEnabled = true;
            groupBox.Background = Brushes.LightPink;
            tbResult.Text = "Для изменения типа списка нажмите \"Очистить список\"";
        }

        /// <summary>
        /// Выводит линейный список в поле "Результат"
        /// </summary>
        public void Print()
        {
            if (rbInt.IsChecked == true) tbResult.Text = ((LinearList<int>)MyList).Print();
            else tbResult.Text = ((LinearList<double>)MyList).Print();
        }

        /// <summary>
        /// Скрывает панель для ввода данных метода добавления на определенную позицию
        /// </summary>
        public void HideAddPanel()
        {
            tbAddInput.Text = "";
            tbAddPosition.Text = "";
            stpInput.Visibility = Visibility.Visible;
            stpAddInput.Visibility = Visibility.Hidden;
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
                if (tbInput.Text == "") tbResult.Text = "Вы не ввели значение в поле ввода";
                else
                {
                    int Value;
                    if ((!tbInput.Text.Contains(" ")) && (Int32.TryParse(tbInput.Text, out Value)))
                    {
                        ((LinearList<int>)MyList).AddFront(Value);
                        tbInput.Text = "";
                        Print();
                    }
                    else
                    {
                        tbResult.Text = "Введено неверное значение";
                        tbInput.Text = "";
                    }
                }
            }
            else
            {
                if (tbInput.Text == "") tbResult.Text = "Вы не ввели значение в поле ввода";
                else
                {
                    double Value;
                    if ((!tbInput.Text.Contains(" ")) && (Double.TryParse(tbInput.Text, out Value)))
                    {
                        ((LinearList<double>)MyList).AddFront(Value);
                        tbInput.Text = "";
                        Print();
                    }
                    else
                    {
                        tbResult.Text = "Введено неверное значение";
                        tbInput.Text = "";
                    }
                }
            }
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
                if (tbInput.Text == "") tbResult.Text = "Вы не ввели значение в поле ввода";
                else
                {
                    int Value;
                    if ((!tbInput.Text.Contains(" ")) && (Int32.TryParse(tbInput.Text, out Value)))
                    {
                        ((LinearList<int>)MyList).AddBack(Value);
                        tbInput.Text = "";
                        Print();
                    }
                    else
                    {
                        tbResult.Text = "Введено неверное значение";
                        tbInput.Text = "";
                    }
                }
            }
            else
            {
                if (tbInput.Text == "") tbResult.Text = "Вы не ввели значение в поле ввода";
                else
                {
                    double Value;
                    if ((!tbInput.Text.Contains(" ")) && (Double.TryParse(tbInput.Text, out Value)))
                    {
                        ((LinearList<double>)MyList).AddBack(Value);
                        tbInput.Text = "";
                        Print();
                    }
                    else
                    {
                        tbResult.Text = "Введено неверное значение";
                        tbInput.Text = "";
                    }
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
            if (tbInput.Text == "") tbResult.Text = "Вы не ввели значение в поле ввода";
            else
            {
                int Value;
                if ((rbInt.IsChecked == true) && (Int32.TryParse(tbInput.Text, out Value)) && (!tbInput.Text.Contains(" ")))
                {
                    try
                    {
                        ((LinearList<int>)MyList).Delete(Value);
                        tbInput.Text = "";
                        Print();
                    }
                    catch (Exception ex)
                    {
                        tbResult.Text = ex.Message;
                        tbInput.Text = "";
                    }
                }
                else if ((Int32.TryParse(tbInput.Text, out Value)) && (!tbInput.Text.Contains(" ")))
                {
                    try
                    {
                        ((LinearList<double>)MyList).Delete(Value);
                        tbInput.Text = "";
                        Print();
                    }
                    catch (Exception ex)
                    {
                        tbResult.Text = ex.Message;
                        tbInput.Text = "";
                    }
                }
                else
                {
                    tbResult.Text = "Введено неверное значение";
                    tbInput.Text = "";
                }
            }
        }

        /// <summary>
        /// Осуществляет поиск элемента в линейном списке по значению, указанному в поле ввода
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (tbInput.Text == "") tbResult.Text = "Вы не ввели значение в поле ввода";
            else
            {
                if (rbInt.IsChecked == true)
                {
                    int Value;
                    if (tbInput.Text == "") tbResult.Text = "Вы не ввели значение в поле ввода";
                    else
                    {
                        if ((!tbInput.Text.Contains(" ")) && (Int32.TryParse(tbInput.Text, out Value)))
                        {
                            Print();
                            tbInput.Text = "";
                            MessageBox.Show(((LinearList<int>)MyList).SearchValueToString(Value));
                        }
                        else
                        {
                            tbResult.Text = "Введено неверное значение";
                            tbInput.Text = "";
                        }
                    }
                }
                else
                {
                    double Value;
                    if (tbInput.Text == "") tbResult.Text = "Вы не ввели значение в поле ввода";
                    else
                    {
                        if ((!tbInput.Text.Contains(" ")) && (Double.TryParse(tbInput.Text, out Value)))
                        {
                            Print();
                            tbInput.Text = "";
                            MessageBox.Show(((LinearList<double>)MyList).SearchValueToString(Value));
                        }
                        else
                        {
                            tbResult.Text = "Введено неверное значение";
                            tbInput.Text = "";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Очищает поле ввода
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnClearInput_Click(object sender, RoutedEventArgs e)
        {
            tbInput.Text = "";
        }

        /// <summary>
        /// Выводит линейный список в поле "Результат" (вызывает метод "Print")
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }

        /// <summary>
        /// Открывает панель для ввода данных метода добавить на определенную позицию
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            stpInput.Visibility = Visibility.Hidden;
            stpAddInput.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Добавляет элемент с указанным значением на указанную позицию
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnAddOk_Click(object sender, RoutedEventArgs e)
        {
            if (rbInt.IsChecked == true)
            {
                if ((tbAddInput.Text == "") || (tbAddPosition.Text == "")) tbResult.Text = "Вы не ввели необходимые данные";
                else
                {
                    int Value;
                    int position;
                    if ((!tbAddInput.Text.Contains(" ")) && (Int32.TryParse(tbAddInput.Text, out Value)) && (Int32.TryParse(tbAddPosition.Text, out position)))
                    {
                        try
                        {
                            ((LinearList<int>)MyList).Add(Value, position);
                            tbAddInput.Text = "";
                            tbAddPosition.Text = "";
                            Print();
                        }
                        catch (Exception ex)
                        {
                            tbResult.Text = ex.Message;
                            tbAddInput.Text = "";
                            tbAddPosition.Text = "";
                        }
                    }
                    else
                    {
                        tbResult.Text = "Введены неверные данные";
                        tbAddInput.Text = "";
                        tbAddPosition.Text = "";
                    }
                }
            }
            else
            {
                if ((tbAddInput.Text == "") || (tbAddPosition.Text == "")) tbResult.Text = "Вы не ввели необходимые данные";
                else
                {
                    double Value;
                    int position;
                    if ((!tbAddInput.Text.Contains(" ")) && (Double.TryParse(tbAddInput.Text, out Value)) && (Int32.TryParse(tbAddPosition.Text, out position)))
                    {
                        try
                        {
                            ((LinearList<double>)MyList).Add(Value, position);
                            tbAddInput.Text = "";
                            tbAddPosition.Text = "";
                            Print();
                        }
                        catch (Exception ex)
                        {
                            tbResult.Text = ex.Message;
                            tbAddInput.Text = "";
                            tbAddPosition.Text = "";
                        }
                    }
                    else
                    {
                        tbResult.Text = "Введены неверные данные";
                        tbAddInput.Text = "";
                        tbAddPosition.Text = "";
                    }
                }
            }
        }

        /// <summary>
        /// Скрывает панель для ввода данных метода добавить на определенную позицию
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительная информация</param>
        private void btnAddCancel_Click(object sender, RoutedEventArgs e)
        {
            HideAddPanel();
        }
        #endregion
    }
}



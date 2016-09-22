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
        public Object MyList;
        public MainWindow()
        {
            InitializeComponent();
            InterfaceOff();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbInput.Text = "";
            tbResult.Text = "";
            InterfaceOff();
            MyList = null;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            InterfaceOn();
            RadioButton rb = (RadioButton)sender;
            if (rb.Tag.ToString() == "int") MyList = new LinearList<int>();
            else MyList = new LinearList<double>();
        }

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

        public void InterfaceOn()
        {
            stpInput.IsEnabled = true;
            wrpActionButtons.IsEnabled = true;
            btnResult.IsEnabled = true;
            groupBox.IsEnabled = false;
            groupBox.Background = Brushes.LightPink;
            tbResult.Text = "Для изменения типа списка нажмите \"очистить\"";
        }
    }

}

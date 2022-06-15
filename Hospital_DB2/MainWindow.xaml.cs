using Hospital_DB2.UIComponents.Tabs;
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

namespace Hospital_DB2
{

    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ITab currentTab { get; set; } = new CreateTab();
        public MainWindow()
        {
            InitializeComponent();
            tabDiv.Children.Add(currentTab);
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            tabDiv.Children.Remove(currentTab);
            currentTab = new CreateTab();
            tabDiv.Children.Add(currentTab);
        }

        private void Read_Button_Click(object sender, RoutedEventArgs e)
        {
            tabDiv.Children.Remove(currentTab);
            currentTab = new ReadTab();
            tabDiv.Children.Add(currentTab);
        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {
            tabDiv.Children.Remove(currentTab);

        }

    }
}

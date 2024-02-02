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

namespace Proyecto2TrimestreInterfaces
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            String user = txtUser.Text;

            if (txtUser.Text.Length == 0 || txtUser.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe introducir un usuario correcto");
            }
            else if (!txtUser.Text.Equals(" ") && txtPass.Password.ToString().Equals("root"))
            {
                ventana2 v2 = new ventana2(user);
                v2.Show();
                this.Close();
            }
        }
    }
}

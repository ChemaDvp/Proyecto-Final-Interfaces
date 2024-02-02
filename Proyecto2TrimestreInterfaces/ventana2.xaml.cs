﻿using System;
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
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace Proyecto2TrimestreInterfaces
{
    
    public partial class ventana2 : Window
    {
        String user;
        public ventana2(String user)
        {
            InitializeComponent();
            this.user = user;
            frame.Navigate(new InicioPage(user));
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);

        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        private void btnManimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new PorductsPage());
        }
        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new InicioPage(user));
        }

        private void Consulta_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new ConsultaPage());
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new exitPage(user));
        }
    }
}

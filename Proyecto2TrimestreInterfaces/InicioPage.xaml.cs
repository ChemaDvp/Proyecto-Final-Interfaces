using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// <summary>
    /// Lógica de interacción para InicioPage.xaml
    /// </summary>
    public partial class InicioPage : Page
    {
        String user;
        public InicioPage(string user)
        {
            InitializeComponent();
            this.user = user;
            txtBienvenido.Text = "Bienvenido, " + user;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (e.Uri is Uri uri)
            {
                // Abre la URL en el navegador web predeterminado
                Process.Start(new ProcessStartInfo
                {
                    FileName = uri.AbsoluteUri,
                    UseShellExecute = true
                });

                // Indica que el evento fue manejado para evitar la navegación predeterminada
                e.Handled = true;
            }
        }

    }
}

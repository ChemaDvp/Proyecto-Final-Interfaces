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
using System.Windows.Shapes;

namespace Proyecto2TrimestreInterfaces
{

    public partial class Delete : Window
    {

        public event EventHandler ProductoEliminado;
        public Delete()
        {
            InitializeComponent();
            LlenarDataGridPorDefecto();
            
        }

        private void EliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Obtener el producto seleccionado del DataGrid
                Products productoSeleccionado = (Products)dgProductos.SelectedItem;

                if (productoSeleccionado != null)
                {
                    // Eliminar el producto de la base de datos
                    database.DeleteProduct(productoSeleccionado.ProductID);

                    // Dispara el evento para notificar a la ventana principal que se ha eliminado un producto
                    ProductoEliminado?.Invoke(this, EventArgs.Empty);

                    // Cerrar la ventana de Delete
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un producto para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar producto: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void LlenarDataGridPorDefecto()
        {
            try
            {
                // Obtener los productos desde la base de datos
                List<Products> productos = database.ObtenerProductos();

                // Asignar la lista de productos al ItemSource del DataGrid
                dgProductos.ItemsSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el DataGrid: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

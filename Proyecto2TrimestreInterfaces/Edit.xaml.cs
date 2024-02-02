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
    /// <summary>
    /// Lógica de interacción para Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private Products productoSeleccionado;
        public event EventHandler ProductoEditado;

        public Edit()
        {
            InitializeComponent();
            LlenarDataGridPorDefecto();
        }

        private void LlenarDataGridPorDefecto()
        {
            try
            {
                // Obtener los productos desde la base de datos
                List<Products> productos = database.ObtenerProductos();

                // Asignar la lista de productos al ItemSource del DataGrid
                dgDetallesProducto.ItemsSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el DataGrid: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgDetallesProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtener el producto seleccionado
            productoSeleccionado = (Products)dgDetallesProducto.SelectedItem;

            // Llenar los controles de edición con los detalles del producto seleccionado
            CargarDetallesProducto();
        }
        private void CargarDetallesProducto()
        {
            if (productoSeleccionado != null)
            {
                // Mostrar detalles del producto en el DataGrid
                dgDetallesProducto.ItemsSource = new List<Products> { productoSeleccionado };

                // Mostrar valores actuales en los controles de edición
                txtNuevoNombre.Text = productoSeleccionado.ProductName;
                txtNuevoPrecio.Text = productoSeleccionado.UnitPrice.ToString();
                txtNuevoStock.Text = productoSeleccionado.UnitsInStock.ToString();
            }
            else
            {
                // Limpiar los controles de edición si no hay producto seleccionado
                dgDetallesProducto.ItemsSource = null;
                txtNuevoNombre.Text = string.Empty;
                txtNuevoPrecio.Text = string.Empty;
                txtNuevoStock.Text = string.Empty;
            }
        }



        private void AñadirCambios_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Verificar si hay un producto seleccionado
                if (productoSeleccionado != null)
                {
                    // Actualizar los campos del producto con los nuevos valores
                    productoSeleccionado.ProductName = txtNuevoNombre.Text;
                    productoSeleccionado.UnitPrice = Convert.ToDecimal(txtNuevoPrecio.Text);
                    productoSeleccionado.UnitsInStock = Convert.ToInt16(txtNuevoStock.Text);

                    // Guardar los cambios en la base de datos
                    database.UpdateProduct(productoSeleccionado);

                    // Dispara el evento para notificar a la ventana principal que se ha editado un producto
                    ProductoEditado?.Invoke(this, EventArgs.Empty);

                    // Cerrar la ventana de Edit
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un producto para editar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al añadir cambios: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


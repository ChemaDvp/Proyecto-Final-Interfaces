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
    /// Lógica de interacción para Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public event EventHandler ProductoAgregado;

        public Add()
        {
            InitializeComponent();
            List<string> categorias = database.ObtenerCategorias();
            List<string> proveedores = database.ObtenerProveedores();
            cmbProveedor.ItemsSource = proveedores;
            cmbCategoria.ItemsSource = categorias;
        }

        private void AgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Obtener los valores de los controles
                string productName = txtNombre.Text;
                int supplierID = database.ObtenerIdProveedorPorNombre(cmbProveedor.SelectedItem.ToString());
                int categoryID = database.ObtenerIdCategoria(cmbCategoria.SelectedItem.ToString());
                string quantityPerUnit = txtCantidadPorUnidad.Text;
                decimal unitPrice = Convert.ToDecimal(txtPrecioUnitario.Text);
                short unitsInStock = Convert.ToInt16(txtUnidadesEnStock.Text);
                short unitsOnOrder = Convert.ToInt16(txtUnidadesEnPedido.Text);
                short reorderLevel = Convert.ToInt16(txtNivelReposicion.Text);
                bool discontinued = chkDescontinuado.IsChecked ?? false;

                // Llama al método para agregar el producto a la base de datos
                database.AddProduct(
                    productName,
                    supplierID,
                    categoryID,
                    quantityPerUnit,
                    unitPrice,
                    unitsInStock,
                    unitsOnOrder,
                    reorderLevel,
                    discontinued
                );

                // Activa el evento para notificar que se ha agregado un producto
                ProductoAgregado?.Invoke(this, EventArgs.Empty);

                // Cerrar la ventana actual
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar producto: {ex.Message}\nStackTrace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





    }
}

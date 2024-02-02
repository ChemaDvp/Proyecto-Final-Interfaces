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
    /// <summary>
    /// Lógica de interacción para PorductsPage.xaml
    /// </summary>
    public partial class PorductsPage : Page
    {
        public PorductsPage()
        {
            InitializeComponent();
            agregarElementos();
            LlenarDataGridPorDefecto();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete deleteProductWindow = new Delete();

            deleteProductWindow.ProductoEliminado += deleteProductWindow_ProductoEliminado;

            deleteProductWindow.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            Edit editProductWindow = new Edit();

            editProductWindow.ProductoEditado += EditWindow_ProductoEditado;

            editProductWindow.ShowDialog();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           
            Add addProductWindow = new Add();

            // Suscríbete al evento ProductoAgregado
            addProductWindow.ProductoAgregado += AddProductWindow_ProductoAgregado;


            addProductWindow.ShowDialog();

            // Actualizar la lista de productos después de cerrar la ventana
            LlenarDataGridPorDefecto();
        }

        private void AddProductWindow_ProductoAgregado(object sender, EventArgs e)
        {
            // Actualizar la lista de productos después de agregar un producto
            LlenarDataGridPorDefecto();
        }
        private void EditWindow_ProductoEditado(object sender, EventArgs e)
        {
            // Actualizar la lista de productos después de agregar un producto
            LlenarDataGridPorDefecto();
        }
        private void deleteProductWindow_ProductoEliminado(object sender, EventArgs e)
        {
            // Actualizar la lista de productos después de agregar un producto
            LlenarDataGridPorDefecto();
        }

        private void agregarElementos()
        {
            List<String> categoriasBD = database.ObtenerCategorias();
            foreach (string elemento in categoriasBD)
            {
                btnSelect.Items.Add(elemento);
            }
        }

        private void LlenarDataGridPorDefecto()
        {
            try
            {
                // Obtener los productos desde la base de datos
                List<Products> productos = database.ObtenerProductos();

                // Asignar la lista de productos al ItemSource del DataGrid
                tabla.ItemsSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el DataGrid: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Obtener la categoría seleccionada
                string categoriaSeleccionada = btnSelect.SelectedItem as string;

                // Verificar si la categoría no es nula
                if (categoriaSeleccionada != null)
                {
                    // Obtener los productos de la categoría seleccionada desde la base de datos
                    List<Products> productosPorCategoria = database.ObtenerProductosPorCategoria(categoriaSeleccionada);

                    // Asignar la lista de productos al ItemSource del DataGrid
                    tabla.ItemsSource = productosPorCategoria;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos por categoría: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}

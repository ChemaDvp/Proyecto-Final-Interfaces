using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto2TrimestreInterfaces
{
    public partial class ConsultaPage : Page
    {
        public ConsultaPage()
        {
            InitializeComponent();
            cmbConsulta.SelectionChanged += CmbConsulta_SelectionChanged;
        }

        private void CmbConsulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Manejar el evento de cambio de selección y realizar la consulta correspondiente
            string selectedConsulta = (cmbConsulta.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (!string.IsNullOrEmpty(selectedConsulta))
            {
                // Llamar al método que ejecuta la consulta y llenar la tabla
                LlenarDataGridPorConsulta(selectedConsulta);
            }
        }

        private void LlenarDataGridPorConsulta(string consulta)
        {
            try
            {
                List<Products> productos = null;

                // Realizar la consulta correspondiente
                switch (consulta)
                {
                    case "Mostrar los 5 productos más vendidos.":
                        productos = database.ObtenerProductosMasVendidos();
                        break;
                    case "Mostrar los productos que no tienen stock.":
                        productos = database.ObtenerProductosSinStock();
                        break;
                    case "Mostrar los 5 productos más caros.":
                        productos = database.ObtenerProductosMasCaros();
                        break;
                        // Puedes agregar más casos según las consultas que necesites
                }

                // Asignar la lista de productos al ItemSource del DataGrid
                tabla.ItemsSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el DataGrid: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

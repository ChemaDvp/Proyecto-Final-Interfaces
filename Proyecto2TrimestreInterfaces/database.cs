using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Proyecto2TrimestreInterfaces
{
    class database
    {
        // Definimos la cadena de conexión
        private static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=root;database=northwind";

        public static List<string> ObtenerCategorias()
        {
            List<string> listaCategorias = new List<string>();

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();
                    string consulta = "SELECT CategoryName FROM categories;";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaCategorias.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (puedes imprimir un mensaje o registrarla)
                Console.WriteLine("Error al obtener categorías: " + ex.Message);
            }

            return listaCategorias;
        }

        
        public static List<Products> ObtenerProductos()
        {
            List<Products> listaProductos = new List<Products>();

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM products;"; // Reemplaza con el nombre real de tu tabla

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products producto = new Products
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                SupplierID = reader.GetInt32(2),
                                CategoryID = reader.GetInt32(3),
                                QuantityPerUnit = reader.GetString(4),
                                UnitPrice = reader.GetDecimal(5),
                                UnitsInStock = reader.GetInt16(6),
                                UnitsOnOrder = reader.GetInt16(7),
                                ReorderLevel = reader.GetInt16(8),
                                Discontinued = reader.GetBoolean(9)
                            };

                            listaProductos.Add(producto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (puedes imprimir un mensaje o registrarla)
                Console.WriteLine("Error al obtener productos: " + ex.Message);
            }

            return listaProductos;
        }


        public static List<Products> ObtenerProductosPorCategoria(string categoria)
        {
            List<Products> listaProductos = new List<Products>();

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    // Modifica la consulta para obtener productos por la categoría seleccionada
                    string consulta = $"SELECT * FROM products WHERE CategoryID IN (SELECT CategoryID FROM categories WHERE CategoryName = '{categoria}');";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products producto = new Products
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                SupplierID = reader.GetInt32(2),
                                CategoryID = reader.GetInt32(3),
                                QuantityPerUnit = reader.GetString(4),
                                UnitPrice = reader.GetDecimal(5),
                                UnitsInStock = reader.GetInt16(6),
                                UnitsOnOrder = reader.GetInt16(7),
                                ReorderLevel = reader.GetInt16(8),
                                Discontinued = reader.GetBoolean(9)
                            };

                            listaProductos.Add(producto);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al obtener productos por categoría: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general al obtener productos por categoría: " + ex.Message);
            }

            return listaProductos;
        }

        public static List<Products> ObtenerProductosMasVendidos()
        {
            List<Products> listaProductos = new List<Products>();

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    // Modifica la consulta para obtener los productos más vendidos
                    string consulta = @"
                SELECT p.*
                FROM Products p
                JOIN OrderDetails od ON p.ProductID = od.ProductID
                JOIN Orders o ON od.OrderID = o.OrderID
                GROUP BY p.ProductID
                ORDER BY SUM(od.Quantity) DESC
                LIMIT 5;";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products producto = new Products
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                SupplierID = reader.GetInt32(2),
                                CategoryID = reader.GetInt32(3),
                                QuantityPerUnit = reader.GetString(4),
                                UnitPrice = reader.GetDecimal(5),
                                UnitsInStock = reader.GetInt16(6),
                                UnitsOnOrder = reader.GetInt16(7),
                                ReorderLevel = reader.GetInt16(8),
                                Discontinued = reader.GetBoolean(9)
                            };

                            listaProductos.Add(producto);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al obtener productos más vendidos: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general al obtener productos más vendidos: " + ex.Message);
            }

            return listaProductos;
        }

        public static List<Products> ObtenerProductosSinStock()
        {
            List<Products> listaProductos = new List<Products>();

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    // Modifica la consulta para obtener los productos sin stock
                    string consulta = "SELECT * FROM products WHERE UnitsInStock = 0;";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products producto = new Products
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                SupplierID = reader.GetInt32(2),
                                CategoryID = reader.GetInt32(3),
                                QuantityPerUnit = reader.GetString(4),
                                UnitPrice = reader.GetDecimal(5),
                                UnitsInStock = reader.GetInt16(6),
                                UnitsOnOrder = reader.GetInt16(7),
                                ReorderLevel = reader.GetInt16(8),
                                Discontinued = reader.GetBoolean(9)
                            };

                            listaProductos.Add(producto);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al obtener productos sin stock: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general al obtener productos sin stock: " + ex.Message);
            }

            return listaProductos;
        }

        public static List<Products> ObtenerProductosMasCaros()
        {
            List<Products> listaProductos = new List<Products>();

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    // Modifica la consulta para obtener los productos más caros
                    string consulta = "SELECT * FROM products ORDER BY UnitPrice DESC LIMIT 5;";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products producto = new Products
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                SupplierID = reader.GetInt32(2),
                                CategoryID = reader.GetInt32(3),
                                QuantityPerUnit = reader.GetString(4),
                                UnitPrice = reader.GetDecimal(5),
                                UnitsInStock = reader.GetInt16(6),
                                UnitsOnOrder = reader.GetInt16(7),
                                ReorderLevel = reader.GetInt16(8),
                                Discontinued = reader.GetBoolean(9)
                            };

                            listaProductos.Add(producto);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al obtener productos más caros: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general al obtener productos más caros: " + ex.Message);
            }

            return listaProductos;
        }


        public static void AddProduct(
    string productName,
    int supplierID,
    int categoryID,
    string quantityPerUnit,
    decimal unitPrice,
    short unitsInStock,
    short unitsOnOrder,
    short reorderLevel,
    bool discontinued)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    string consulta = "INSERT INTO products (ProductName, SupplierID, CategoryID, QuantityPerUnit, " +
                                      "UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                                      "VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, " +
                                      "@UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued);";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ProductName", productName);
                        comando.Parameters.AddWithValue("@SupplierID", supplierID);
                        comando.Parameters.AddWithValue("@CategoryID", categoryID);
                        comando.Parameters.AddWithValue("@QuantityPerUnit", quantityPerUnit);
                        comando.Parameters.AddWithValue("@UnitPrice", unitPrice);
                        comando.Parameters.AddWithValue("@UnitsInStock", unitsInStock);
                        comando.Parameters.AddWithValue("@UnitsOnOrder", unitsOnOrder);
                        comando.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
                        comando.Parameters.AddWithValue("@Discontinued", discontinued);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al agregar producto: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general al agregar producto: " + ex.Message);
            }
        }


        public static int ObtenerIdCategoria(string nombreCategoria)
        {
            int idCategoria = -1; // Valor predeterminado en caso de no encontrar la categoría

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();
                    string consulta = $"SELECT CategoryID FROM categories WHERE CategoryName = '{nombreCategoria}';";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        object result = comando.ExecuteScalar();

                        if (result != null)
                        {
                            idCategoria = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al obtener ID de categoría: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general al obtener ID de categoría: " + ex.Message);
            }

            return idCategoria;
        }


        public static List<string> ObtenerProveedores()
        {
            List<string> proveedores = new List<string>();

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    string consulta = "SELECT CompanyName FROM suppliers;";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                proveedores.Add(reader["CompanyName"].ToString());
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al obtener proveedores: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general al obtener proveedores: " + ex.Message);
            }

            return proveedores;
        }
        public static int ObtenerIdProveedorPorNombre(string nombreProveedor)
        {
            int idProveedor = -1; // Valor predeterminado en caso de no encontrar el proveedor

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();
                    string consulta = $"SELECT SupplierID FROM suppliers WHERE CompanyName = '{nombreProveedor}';";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        object result = comando.ExecuteScalar();

                        if (result != null)
                        {
                            idProveedor = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al obtener ID de proveedor: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general al obtener ID de proveedor: " + ex.Message);
            }

            return idProveedor;
        }

        public static void DeleteProduct(int productID)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    string consulta = "DELETE FROM products WHERE ProductID = @ProductID;";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ProductID", productID);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al eliminar producto: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general al eliminar producto: " + ex.Message);
            }
        }

        public static void UpdateProduct(Products updatedProduct)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    string consulta = "UPDATE products " +
                                      "SET ProductName = @ProductName, " +
                                      "SupplierID = @SupplierID, " +
                                      "CategoryID = @CategoryID, " +
                                      "QuantityPerUnit = @QuantityPerUnit, " +
                                      "UnitPrice = @UnitPrice, " +
                                      "UnitsInStock = @UnitsInStock, " +
                                      "UnitsOnOrder = @UnitsOnOrder, " +
                                      "ReorderLevel = @ReorderLevel, " +
                                      "Discontinued = @Discontinued " +
                                      "WHERE ProductID = @ProductID;";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ProductID", updatedProduct.ProductID);
                        comando.Parameters.AddWithValue("@ProductName", updatedProduct.ProductName);
                        comando.Parameters.AddWithValue("@SupplierID", updatedProduct.SupplierID);
                        comando.Parameters.AddWithValue("@CategoryID", updatedProduct.CategoryID);
                        comando.Parameters.AddWithValue("@QuantityPerUnit", updatedProduct.QuantityPerUnit);
                        comando.Parameters.AddWithValue("@UnitPrice", updatedProduct.UnitPrice);
                        comando.Parameters.AddWithValue("@UnitsInStock", updatedProduct.UnitsInStock);
                        comando.Parameters.AddWithValue("@UnitsOnOrder", updatedProduct.UnitsOnOrder);
                        comando.Parameters.AddWithValue("@ReorderLevel", updatedProduct.ReorderLevel);
                        comando.Parameters.AddWithValue("@Discontinued", updatedProduct.Discontinued);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al actualizar producto: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general al actualizar producto: " + ex.Message);
            }
        }






    }

}

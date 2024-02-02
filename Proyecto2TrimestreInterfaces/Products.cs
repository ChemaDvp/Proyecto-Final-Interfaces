using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2TrimestreInterfaces
{
    internal class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        // Puedes agregar otras propiedades según la estructura de tu tabla

        // Constructor por defecto
        public Products()
        {

        }

        // Constructor con parámetros para facilitar la creación de instancias
        public Products(int productID, string productName, int? supplierID, int? categoryID,
                        string quantityPerUnit, decimal? unitPrice, short? unitsInStock,
                        short? unitsOnOrder, short? reorderLevel, bool discontinued)
        {
            ProductID = productID;
            ProductName = productName;
            SupplierID = supplierID;
            CategoryID = categoryID;
            QuantityPerUnit = quantityPerUnit;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
            UnitsOnOrder = unitsOnOrder;
            ReorderLevel = reorderLevel;
            Discontinued = discontinued;
        }

    }
}

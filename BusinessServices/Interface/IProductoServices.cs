using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessServices.Interface
{
    public interface IProductoServices
    {
        Productos GetProductById(int productId);
        IEnumerable<Productos> GetAllProducts();
        int CreateProduct(Productos productEntity);
        bool UpdateProduct(int productId, Productos productEntity);
        bool DeleteProduct(int productId);
    }
}

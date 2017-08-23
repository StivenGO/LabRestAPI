using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices.Services;
using BusinessServices.Interface;

namespace LabApp.WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        #region Miembros Privados
        readonly IProductoServices productoServices;
        #endregion

        public ProductoController()
        {
            productoServices = new ProductoServices();
        }

        // GET: api/Producto
        public HttpResponseMessage Get()
        {
            var productos = productoServices.GetAllProducts();
            if (productos != null)
            {
                if (productos.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, productos, Configuration.Formatters.JsonFormatter);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, productos);
        }

        // GET: api/Producto/5
        public HttpResponseMessage Get(int id)
        {
            var producto = productoServices.GetProductById(id);

            if (producto != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, producto);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontró el producto con id " + id.ToString());
        }

        // POST: api/Producto
        public int Post([FromBody]Productos producto)
        {
            return productoServices.CreateProduct(producto);
        }

        // PUT: api/Producto/5
        public bool Put(int id, [FromBody]Productos producto)
        {
            if (id > 0)
            {
                return productoServices.UpdateProduct(id, producto);
            }

            return false;
        }

        // DELETE: api/Producto/5
        public bool Delete(int id)
        {
            if (id > 0)
            {
                return productoServices.DeleteProduct(id);
            }

            return false;
        }
    }
}

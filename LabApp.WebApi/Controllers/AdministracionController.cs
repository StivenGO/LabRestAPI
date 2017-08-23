using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices.Services;
using BusinessServices.Interface;
using System.Web.Http.Cors;

namespace LabApp.WebApi.Controllers
{
    [RoutePrefix("Administracion")]
    public class AdministracionController : ApiController
    {
        #region Miembros Privados
        readonly IEmpleadosServices empleadosServices;
        readonly IClientesServices clientesServices;
        readonly IProveedoresServices proveedoresServices;
        #endregion

        public AdministracionController()
        {
            empleadosServices = new Empleadoservices();
            clientesServices = new ClientesServices();
            proveedoresServices = new ProveedoresServices();
        }

        #region Empleados API
        // GET: api/empleado
        [Route("Empleado/Get")]
        public HttpResponseMessage GetEmpleados()
        {
            var empleados = empleadosServices.GetAllEmpleados();
            if (empleados != null)
            {
                if (empleados.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, empleados, Configuration.Formatters.JsonFormatter);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, empleados);
        }

        // GET: api/empleado/5
        [Route("Empleado/Get/{id:int}")]
        public HttpResponseMessage GetEmpleadosById(int id)
        {
            var empleado = empleadosServices.GetEmpleadoById(id);

            if (empleado != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, empleado);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontró el empleado con id " + id.ToString());
        }

        // POST: api/empleado
        [Route("Empleado/Post")]
        public int CreateEmpleado([FromBody]Empleados empleado)
        {
            empleado.FechaInicioVigencia = DateTime.Now;
            return empleadosServices.CreateEmpleado(empleado);
        }

        // PUT: api/empleado/5
        [Route("Empleado/Put/{id:int}")]
        public bool UpdateEmpleado(int id, [FromBody]Empleados empleado)
        {
            if (id > 0)
            {
                return empleadosServices.UpdateEmpleado(id, empleado);
            }

            return false;
        }

        // DELETE: api/empleado/5
        [Route("Empleado/Delete/{id:int}")]
        public bool DeleteEmpleado(int id)
        {
            if (id > 0)
            {
                return empleadosServices.DeleteEmpleado(id);
            }

            return false;
        } 
        #endregion

        #region Clientes API
        // GET: api/empleado
        [Route("Cliente/Get")]
        public HttpResponseMessage GetClientes()
        {
            var clientes = clientesServices.GetAllClientes();
            if (clientes != null)
            {
                if (clientes.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, clientes, Configuration.Formatters.JsonFormatter);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, clientes);
        }

        [Route("TiposClientes/Get")]
        public HttpResponseMessage GetTiposClientes()
        {
            var tiposClientes = clientesServices.GetTiposClientes();
            if (tiposClientes != null)
            {
                if (tiposClientes.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, tiposClientes, Configuration.Formatters.JsonFormatter);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, tiposClientes);
        }

        // GET: api/empleado/5
        [Route("Cliente/Get/{id:int}")]
        public HttpResponseMessage GetClientesById(int id)
        {
            var cliente = clientesServices.GetClienteById(id);

            if (cliente != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, cliente);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontró el cliente con id " + id.ToString());
        }

        // POST: api/empleado
        [Route("Cliente/Post")]
        public int CreateCliente([FromBody]Clientes cliente)
        {
            cliente.FechaInicioVigencia = DateTime.Now;
            return clientesServices.CreateCliente(cliente);
        }

        // PUT: api/empleado/5
        [Route("Cliente/Put/{id:int}")]
        public bool UpdateCliente(int id, [FromBody]Clientes cliente)
        {
            if (id > 0)
            {
                return clientesServices.UpdateCliente(id, cliente);
            }

            return false;
        }

        // DELETE: api/empleado/5
        [Route("Cliente/Delete/{id:int}")]
        public bool DeleteCliente(int id)
        {
            if (id > 0)
            {
                return clientesServices.DeleteCliente(id);
            }

            return false;
        }
        #endregion

        #region Proveedores API
        // GET: api/empleado
        [Route("Proveedor/Get")]
        public HttpResponseMessage GetProveedores()
        {
            var proveedores = proveedoresServices.GetAllProveedores();
            if (proveedores != null)
            {
                if (proveedores.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, proveedores, Configuration.Formatters.JsonFormatter);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, proveedores);
        }

        // GET: api/empleado/5
        [Route("Proveedor/Get/{id:int}")]
        public HttpResponseMessage GetProveedoresById(int id)
        {
            var proveedor = proveedoresServices.GetProveedorById(id);

            if (proveedor != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, proveedor);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontró el proveedor con id " + id.ToString());
        }

        // POST: api/empleado
        [Route("Proveedor/Post")]
        public int CreateProveedor([FromBody]Proveedores proveedor)
        {
            proveedor.FechaInicioVigencia = DateTime.Now;
            return proveedoresServices.CreateProveedor(proveedor);
        }

        // PUT: api/empleado/5
        [Route("Proveedor/Put/{id:int}")]
        public bool UpdateProveedor(int id, [FromBody]Proveedores proveedor)
        {
            if (id > 0)
            {
                return proveedoresServices.UpdateProveedor(id, proveedor);
            }

            return false;
        }

        // DELETE: api/empleado/5
        [Route("Proveedor/Delete/{id:int}")]
        public bool DeleteProveedor(int id)
        {
            if (id > 0)
            {
                return proveedoresServices.DeleteProveedor(id);
            }

            return false;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessServices.Interface
{
    public interface IProveedoresServices
    {
        Proveedores GetProveedorById(int ProveedorId);
        IEnumerable<Proveedores> GetAllProveedores();
        int CreateProveedor(Proveedores ProveedorEntity);
        bool UpdateProveedor(int proveedorId, Proveedores proveedorEntity);
        bool DeleteProveedor(int proveedorId);
    }
}

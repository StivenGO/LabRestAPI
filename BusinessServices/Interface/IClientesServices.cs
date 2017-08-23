using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessServices.Interface
{
    public interface IClientesServices
    {
        Clientes GetClienteById(int clienteId);
        IEnumerable<Clientes> GetAllClientes();
        int CreateCliente(Clientes clienteEntity);
        bool UpdateCliente(int clienteId, Clientes clienteEntity);
        bool DeleteCliente(int clienteId);
        IEnumerable<TiposClientes> GetTiposClientes();
    }
}

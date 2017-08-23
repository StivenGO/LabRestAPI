using BusinessServices.Interface;
using System.Transactions;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices.Services
{
    public class ClientesServices : IClientesServices
    {
        readonly UnitOfWork _unitOfWork;

        public ClientesServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.Clientes GetClienteById(int clienteId)
        {
            return _unitOfWork.ClientesRepository.GetById(clienteId);
        }

        public IEnumerable<BusinessEntities.Clientes> GetAllClientes()
        {
            return _unitOfWork.ClientesRepository.GetAll().Where(c => !c.FechaFinVigencia.HasValue);
        }

        public int CreateCliente(BusinessEntities.Clientes clienteEntity)
        {
            using (var scope = new TransactionScope())
            {
                _unitOfWork.ClientesRepository.Insert(clienteEntity);
                _unitOfWork.Save();
                scope.Complete();

                return clienteEntity.IdCliente;
            }
        }

        public bool UpdateCliente(int ClienteId, BusinessEntities.Clientes clienteEntity)
        {
            var success = false;

            if (clienteEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    //var Cliente = _unitOfWork.ClientesRepository.GetById(ClienteId);
                    //if (Cliente != null)
                    //{
                    _unitOfWork.ClientesRepository.Update(clienteEntity);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                    //}
                }
            }

            return success;
        }

        public bool DeleteCliente(int clienteId)
        {
            var success = false;
            if (clienteId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var cliente = _unitOfWork.ClientesRepository.GetById(clienteId);
                    cliente.FechaFinVigencia = DateTime.Now;

                    if (cliente != null)
                    {
                        _unitOfWork.ClientesRepository.Update(cliente);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public IEnumerable<BusinessEntities.TiposClientes> GetTiposClientes()
        {
            return _unitOfWork.TipoClienteRepository.GetAll();
        }
    }
}

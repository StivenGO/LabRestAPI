using BusinessServices.Interface;
using System.Transactions;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices.Services
{
    public class ProveedoresServices : IProveedoresServices
    {
        readonly UnitOfWork _unitOfWork;

        public ProveedoresServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.Proveedores GetProveedorById(int proveedorId)
        {
            return _unitOfWork.ProveedorRepository.GetById(proveedorId);
        }

        public IEnumerable<BusinessEntities.Proveedores> GetAllProveedores()
        {
            return _unitOfWork.ProveedorRepository.GetAll().Where(c => !c.FechaFinVigencia.HasValue);
        }

        public int CreateProveedor(BusinessEntities.Proveedores proveedorEntity)
        {
            using (var scope = new TransactionScope())
            {
                _unitOfWork.ProveedorRepository.Insert(proveedorEntity);
                _unitOfWork.Save();
                scope.Complete();

                return proveedorEntity.IdProveedor;
            }
        }

        public bool UpdateProveedor(int proveedorId, BusinessEntities.Proveedores proveedorEntity)
        {
            var success = false;

            if (proveedorEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    //var proveedor = _unitOfWork.ProveedoresRepository.GetById(proveedorId);
                    //if (proveedor != null)
                    //{
                    _unitOfWork.ProveedorRepository.Update(proveedorEntity);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                    //}
                }
            }

            return success;
        }

        public bool DeleteProveedor(int proveedorId)
        {
            var success = false;
            if (proveedorId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var proveedor = _unitOfWork.ProveedorRepository.GetById(proveedorId);
                    proveedor.FechaFinVigencia = DateTime.Now;

                    if (proveedor != null)
                    {
                        _unitOfWork.ProveedorRepository.Update(proveedor);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }



    }
}

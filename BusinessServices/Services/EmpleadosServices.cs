using BusinessServices.Interface;
using System.Transactions;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices.Services
{
    public class Empleadoservices : IEmpleadosServices
    {
        readonly UnitOfWork _unitOfWork;

        public Empleadoservices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.Empleados GetEmpleadoById(int empleadoId)
        {
            return _unitOfWork.EmpleadosRepository.GetById(empleadoId);
        }

        public IEnumerable<BusinessEntities.Empleados> GetAllEmpleados()
        {
            return _unitOfWork.EmpleadosRepository.GetAll().Where(e => !e.FechaFinVigencia.HasValue);
        }

        public int CreateEmpleado(BusinessEntities.Empleados empleadoEntity)
        {
            using (var scope = new TransactionScope())
            {
                _unitOfWork.EmpleadosRepository.Insert(empleadoEntity);
                _unitOfWork.Save();
                scope.Complete();

                return empleadoEntity.IdEmpleado;
            }
        }

        public bool UpdateEmpleado(int empleadoId, BusinessEntities.Empleados empleadoEntity)
        {
            var success = false;

            if (empleadoEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    //var empleado = _unitOfWork.EmpleadosRepository.GetById(empleadoId);
                    //if (empleado != null)
                    //{
                    _unitOfWork.EmpleadosRepository.Update(empleadoEntity);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                    //}
                }
            }

            return success;
        }

        public bool DeleteEmpleado(int empleadoId)
        {
            var success = false;
            if (empleadoId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var empleado = _unitOfWork.EmpleadosRepository.GetById(empleadoId);
                    empleado.FechaFinVigencia = DateTime.Now;

                    if (empleado != null)
                    {
                        _unitOfWork.EmpleadosRepository.Update(empleado);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessServices.Interface
{
    public interface IEmpleadosServices
    {
        Empleados GetEmpleadoById(int productId);
        IEnumerable<Empleados> GetAllEmpleados();
        int CreateEmpleado(Empleados empleadoEntity);
        bool UpdateEmpleado(int empleadoId, Empleados empleadoEntity);
        bool DeleteEmpleado(int empleadoId);
    }
}

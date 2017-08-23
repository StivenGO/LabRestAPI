using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Validation;
using BusinessEntities;
using DataModel.GenericRepository;
using System.Diagnostics;

namespace DataModel.UnitOfWork
{
    /// <summary>
    /// Clase de trabajo encargada de las transacciones en base de datos
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Miembros Privados
        bool disposed = false;
        LABASPRODENTConnection _context = null;
        GenericRepository<Productos> _productoRepository;
        GenericRepository<Empleados> _empleadosRepository;
        GenericRepository<Clientes> _clientesRepository;
        GenericRepository<Proveedores> _proveedoresRepository;
        GenericRepository<TiposClientes> _tiposClienteRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new LABASPRODENTConnection();
        }

        #region Creacion de repositorios


        public GenericRepository<Productos> ProductoRepository
        {
            get
            {
                if (this._productoRepository == null)
                {
                    this._productoRepository = new GenericRepository<Productos>(_context);
                }

                return _productoRepository;
            }
        }

        public GenericRepository<TiposClientes> TipoClienteRepository
        {
            get
            {
                if (this._tiposClienteRepository == null)
                {
                    this._tiposClienteRepository = new GenericRepository<TiposClientes>(_context);
                }

                return _tiposClienteRepository;
            }
        }

        public GenericRepository<Proveedores> ProveedorRepository
        {
            get
            {
                if (this._proveedoresRepository == null)
                {
                    this._proveedoresRepository = new GenericRepository<Proveedores>(_context);
                }

                return _proveedoresRepository;
            }
        }

        public GenericRepository<Empleados> EmpleadosRepository
        {
            get
            {
                if (this._empleadosRepository == null)
                {
                    this._empleadosRepository = new GenericRepository<Empleados>(_context);
                }

                return _empleadosRepository;
            }
        }

        public GenericRepository<Clientes> ClientesRepository
        {
            get
            {
                if (this._clientesRepository == null)
                {
                    this._clientesRepository = new GenericRepository<Clientes>(_context);
                }

                return _clientesRepository;
            }
        }

        #endregion

        #region Miembros Publicos
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\TEMP\errors.txt", outputLines);

                throw e;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

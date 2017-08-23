using BusinessServices.Interface;
using System.Transactions;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices.Services
{
    public class ProductoServices : IProductoServices
    {
        readonly UnitOfWork _unitOfWork;

        public ProductoServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.Productos GetProductById(int productId)
        {
            return _unitOfWork.ProductoRepository.GetById(productId);
        }

        public IEnumerable<BusinessEntities.Productos> GetAllProducts()
        {
            return _unitOfWork.ProductoRepository.GetAll();
        }

        public int CreateProduct(BusinessEntities.Productos productEntity)
        {
            using (var scope = new TransactionScope())
            {
                _unitOfWork.ProductoRepository.Insert(productEntity);
                _unitOfWork.Save();
                scope.Complete();

                return productEntity.IdProducto;
            }
        }

        public bool UpdateProduct(int productId, BusinessEntities.Productos productEntity)
        {
            var success = false;

            if (productEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.ProductoRepository.GetById(productId);
                    if (product != null)
                    {
                        _unitOfWork.ProductoRepository.Update(product);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }

            return success;
        }

        public bool DeleteProduct(int productId)
        {
            var success = false;
            if (productId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.ProductoRepository.GetById(productId);

                    if (product != null)
                    {
                        _unitOfWork.ProductoRepository.Delete(product);
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

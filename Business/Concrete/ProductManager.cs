using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;

using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
            {
                _productDal = productDal;
            }
        [ValidationAspect(typeof(ProductValidater))]
        public IResult Add(Product product)
        {
            //İş kodları yazılır. Örneğin birim fiyat >0
            ValidationTool.Validate(new ProductValidater(), product);
            //bussiness code
             _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            //predict
            return new SuccessDataResult<Product>( _productDal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult <List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails());
        }

       
    }
}

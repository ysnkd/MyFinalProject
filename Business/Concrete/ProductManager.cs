﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            //bussiness codes (web apiye giriş)
            //REQUEST:ISTEK DEMEKTİR.
            //RESPONSE:GERİ YANIT.
            
            if (product.ProductName.Length<2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); //bunu yapabilmenin çözümü resultta constructor yapmaktır.
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==1)
            {
               return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //İş Kodları
            //yetkisi var mı ?
            return new DataResult<List<Product>>(_productDal.GetAll(),true,Messages.ProductsListed);
            //iş sınıfı , bir iş sınfını newleyemez!

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            //Expression kodu : bana lambda ver demektir.
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccesDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Product>>
                (_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccesDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
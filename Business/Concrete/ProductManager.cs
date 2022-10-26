﻿using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        //bir manager başka bir entity dal entegre edemeyiz.SERVİS kullanırız.
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            
            _productDal = productDal;
            _categoryService = categoryService;
        }
        //PRODUCTMANAGER OLARAK BİR DAL VE LOG'A İHTİYACIM VAR.
        [ValidationAspect(typeof(ProductValidator))]
        //[Log] Mettottan önce log çalışacak.
        //loglama: yapılan operasyonların bir yerde kaydını tutmak.
        //Cross Cutting Concerns:Her katmanda dikini kesen yapılardır.
        //Validation,Log,Cache,Transaction,Auth=>CCS.
        //ATRIBUTE'LARA TYPEOF ILE TANIMLARIZ.
        public IResult Add(Product product)
        {
            //DRY, CLEAN CODE PRENSİBİ
            //İŞ KURALLARINI
            var result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                CheckIfProductCountOfCategoryCheck(product.CategoryId),
                CheckIfCategoryLimitExeded()
                );
            if (result!=null)
            {
                return result;
            }
            //eğer çalışmayan metot varsa döndür,
            //result içi doluysa result'ı döndür yoksa 
            //ürün ekleme işlemine devam et.
            _productDal.Add(product);
            return new SuccessResult();
            
            //LOGLARI BURDA
            //Validation kodlarımı aspect yapsın.
            
            //bussiness code: iş kuralı, iş gereksinimlerimize uygunluk.
            //ehliyet alırken 70 üstü almak.
            //bankada kredi notu 70'den üstünlere kredi vs.
            //REQUEST:ISTEK DEMEKTİR.
            //RESPONSE:GERİ YANIT.
            //validation code:
            //kayıt olurken şifre uzunluğu 5 olmalı gibi
            //kuralları belirleyen doğrulamalara validation 
            //code denir
            

            //[Validate] //öyle bir şey olucak ki aşşağıdaki intance'leri vs bile yazmıcaz.
             //bunu yapabilmenin çözümü resultta constructor yapmaktır.
            //Loglama
            //CacheRemove
            //Performance
            //Transaction
            //Yetkilendirme

            //AOP NEDİR: METOTLARI LOGLAMAK İSTERSİNİZ? BAŞINDA VEYA SONUNDA HATA VERDİĞİNDE
            //ÇALIŞMASINI İSTEDİĞİN KODLARN VARSA LOGLAMA YAPABİLİRSİN.
            //INTERCEPTOR: ARAYA GİRMEK DEMEK. HATABAŞI VEYA SONU VS
        }//BURDA LOGLAMA KULLANABİLİRİZ.

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
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfProductCountOfCategoryCheck(int categoryId)
        {
            var result = (_productDal.GetAll(p => p.CategoryId == categoryId).Count);

            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountCategoryError);
            }
            return new SuccessResult();
        }//iş kuralı parçacığı olduğu için private yapıyoruz!!
        private IResult CheckIfProductNameExist(string productName)
        {
            //Any: şuna uyan kayıt var mı demek.
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExeded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();


        }
    }
}

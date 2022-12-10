using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        //iş katmanında kullanacağımız bir servis katmanı.

        IDataResult<List<Product>> GetAll();

        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product); //ekleme operasyonu // void yerine IRESULT servisi eklendi
        IResult Update(Product product);

        IResult AddTransactionalTest(Product product);
        
        //Transaction



        //uygulamalarda tutarlılığı korumaktır.
        //örn hesapta 100 tl para var kerem'e 10 tl aktarıcam,
        //benim hesabımın 10 tl düşülmesi, keremin hesabı 10 tl artması,
        //olayı.
        //gerçekleşmezse işlem geri alması gerekiyor.

    }
}

//RESTFUL --> HTTP --> TCP
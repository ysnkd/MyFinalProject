using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //ENTITY FRAMEWORK'E BAŞLIYORUZ.
    //ORM BİR TABLOYU CLASS GİBİ KULLANMAMIZI SAĞLAR LINQ KODLARI İLE.
    //NUGET
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        //ürün kategorilerine join işlemleri
        public List<ProductDetailDto> GetProductDetails()
        {
            //ürünlerle kategoriyi join et.
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductName=p.ProductName,
                                 ProductId = p.ProductId,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}

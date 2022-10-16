
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess //namespace:isim uzayı
{
    //Generic Constraint (sınırlandırmak)
    //class: referanstip
    //bütün classlar IEntity implementinde olduğu için sınırlandırabiliriz.
    public interface IEntityRepository<T> where T:class,IEntity,new() //IEntity: Entity olabilir veya IEntity implemente eden bir nesne olabilir.
        //new(): new'lenebilir olmalı
    {
        //Generic Reporistory Design Pattern
        //ProductDal CategoryDal diye tek tek interface yazmak yerine generic kullanıp ortak şablon çıkarabiliriz.
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //veride filtreleme yapmak istiyorsak tek tek metotla ugrasmayız Expression
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAllByCategory(int categoryId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //bağımsız bir interface
        T Get<T>(string key); //bu T herşey olabilir.
        object Get(string key);
        void Add(string key, object value,int duration);
        //object:metot,data herşey olur.
        //duration:bu cache kaç dakika olucak?
        bool IsAdd(string key);//cash'da var mı?
        void Remove(string key);//cash'den kaldır.
        void RemoveByPattern(string pattern);
        //Örnek: ProductManager'da get ile başlayan
        //metotları kaldır.

    }
}

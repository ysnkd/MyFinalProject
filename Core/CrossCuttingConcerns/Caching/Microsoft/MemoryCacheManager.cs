using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingConcerns.Cashing.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern: Var olan sistemi kendine göre şekillendirme
        //örnek: IMemoryCache .net'den çağırarak yazdığımız kodlarda
        //kendimize göre şekillendirmek.
        IMemoryCache _memoryCache;

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        //inmemory - interface
        public void Add(string key, object value, int duration)
        {
            //_memmoryCache kullanılacak.
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
            //ne kadar süre verilirse,burası cache'da kalıcak.
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
            //getir
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key,out _);
            //bellekte var mı yok mu?
            //out _ sadece bool'u istediğim için ikinci out parametresi
            //böyle pasif edilir.
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //memoryCache'daki herşeyi EntriesCollection'a atıyor.
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
        //verilen bir pattern'a göre o pattern'a ait data veya metodu silme işlemi.
        //reflection ile çalışma anında oluşturma veya silme yapılır.
        //bellekte cash ile olan yapıyı çekmek istiyorum.
    }
}

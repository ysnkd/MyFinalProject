using System;

namespace Business.CCS
{
    public class DatabaseLogger : ILogger
    {
        //basit bir simulasyon 
        //ccs: cross cutting concern
        //basit bir loglama simulasyonu
        public void Log()
        {
            Console.WriteLine("veritabanına loglandı");
        }
    }
}

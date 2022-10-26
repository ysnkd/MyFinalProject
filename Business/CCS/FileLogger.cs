using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS
{
    public class FileLogger : ILogger
    {
        //basit bir simulasyon 
        //ccs: cross cutting concern
        //basit bir loglama simulasyonu
        public void Log()
        {
            Console.WriteLine("Dosyaya loglandı");
        }
    }
}

using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    //BusinessRules: Business özel operasyonlar için bir array oluşturuyor. Bu operasyonlar eğer ki bir tanesi başarısızsa bildirmesini istiyorum.
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
            //siz params verdiğiniz zaman arrayda IResult metot dizileniyor.
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                    //parametreyle gönderileni
                    //başarısız olanı
                    //döndür ve haber ver.

                }

                
            }
            return null;
        }
    }
}

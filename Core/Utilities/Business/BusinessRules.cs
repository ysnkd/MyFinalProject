using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
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

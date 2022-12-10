using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //test için
        //kullanıcıdan gelecek verileri veritabanında
        //arayacak ve api ile kullanıcıya bir token vericek.
     
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}

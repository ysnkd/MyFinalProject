using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult//generic kullanmızın amacı kategori,product vs datalar istenebilir.
    {
        T Data { get; }
    }
    
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        //mesaj olayına girmek istenilmezse
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message) //data döndürmezsek
        {

        }
        public ErrorDataResult() : base(default, false) //data döndürmeyeceğiz ve mesaj almak istemiyorsak
        {

        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
  
        public Result(bool success, string message):this(success) //this koduyla aşağıdaki constructor da çalışır.BASE CONSTRUCTOR
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        //Aşırı yükleme: overloading

        public bool Success { get; }
        //constructor dışında set edilemez.

        public string Message { get; }
    }
}

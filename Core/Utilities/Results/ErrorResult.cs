using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)//base'da o iki constructordan birini gönderebilirim.
        {

        }
        public ErrorResult() : base(false) //2.const
        {

        }
    }
        

}

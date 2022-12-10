﻿using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
            //Formatı Json'a çevir.
        }

        public class ValidationErrorDetails:ErrorDetails
        {
            public IEnumerable<ValidationFailure> Errors { get; set; }

        }
    }
}

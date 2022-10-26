using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    //bana bir validator ver.(ProductValidator)
    public static class ValidationTool
    {
        //Validationlar genellikle static olur. newlemeye gerek kalmazç
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            //Eğer validation yapılacaksa aşşağıdaki kod bloğu
            //standartttır fakat spagettidir.
            
            var result = validator.Validate(context);
            //Validate metodunu kullan.
            if (!result.IsValid)
            {
                //eğer doğrulama doğruysa uyarı ver.
                throw new ValidationException(result.Errors);
            }
        }
    }
}

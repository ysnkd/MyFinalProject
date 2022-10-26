using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
    
{
    //sen bir methodinterception'sın.
    public class ValidationAspect : MethodInterception//ASPECT
    {
        private Type _validatorType;

        //validator entegre eğer değilse servisi farklıysa hata mesajı ver
        public ValidationAspect(Type validatorType)
        {
            //DEFANSİF KODLAR.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }
            //IsAssignabkeFrom:atanabilir mi
            //validator mu?
            //değilse exception hata

            _validatorType = validatorType;
        }
        //BANA BİR VALIDATORTYPE VER
        protected override void OnBefore(IInvocation invocation)
        {
            //sadece onbefore'u ez.
            //Validation sadece onbefore'da yapılır.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//reflection
            //çalışma anında instance üretmek. Activator. bizim için ProductValidator'u newledi.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//çalışma tipini bul
            //AbstractValidator'un generic yapısı var . O argümanların 0.cısını yakala
            //Product tipi.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //eğer invoke ettiğim entitype ile eşitse onları validate et.

            //metotun argümanlarınlarına(metot( bak parametrelerini bul karşılaştır.
            //tek tek gez, validationtool kullanarak validate et.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}

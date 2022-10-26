using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            //Kurallar buraya yazılıyor.
            RuleFor(p => p.ProductName).MinimumLength(2);
            //ProductName minimum 2 karakter olmalıdır.
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            //NotEmpty : Boş olmamalı
            //GreaterThan(2) 2'den büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("ürünler A harfi ile başlamalı"); //ürün ismi a ile başlamalı

            

        }
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A"); //True döndürür.
        }
    }
}

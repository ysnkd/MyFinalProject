using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //CROSS CUTTING CONCERNS
    //-LOG
    //-CACHE
    //-TRANSACTION
    //-AUTHORIZATION
    //VALIDATION

    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            //iş kodları
            return new SuccesDataResult<List<Category>>(_categoryDal.GetAll());
        }
        //select * from categories where CategoryId=3
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccesDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }
    }
}

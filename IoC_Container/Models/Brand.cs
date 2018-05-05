using IoC_Container.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC_Container
{
    public class Brand : IBrand
    {
        IBrandDataAccess _dataAccess;

        public Brand(IBrandDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public string GetBrandNameById(int id)
        {
            return new List<string>(_dataAccess.GetAllBrands())[id];
        }
    }
}

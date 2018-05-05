using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IoC_Container
{
    class CarBrand : ICarBrand, IBrand
    {
        IList<string> _CarBrands = new Collection<string>() { "Toyota", "Ford", "Fiat" };

        public string GetBrandNameById(int ID)
        {
            return _CarBrands[ID];
        }

        public bool IsCarBrand(string brand)
        {
            return _CarBrands.Contains(brand);
        }
    }
}

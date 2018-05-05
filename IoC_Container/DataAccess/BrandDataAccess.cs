using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IoC_Container.DataAccess
{
    class BrandDataAccess : IBrandDataAccess
    {
        IEnumerable<string> _brandData = new Collection<string> { "Brand: A", "Brand: B", "Brand: C" };

        public IEnumerable<string> GetAllBrands()
        {
            return _brandData;
        }
    }
}

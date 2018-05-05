using System;
using System.Collections.Generic;
using System.Text;

namespace IoC_Container.DataAccess
{
    public interface IBrandDataAccess
    {
        IEnumerable<string> GetAllBrands();
    }
}

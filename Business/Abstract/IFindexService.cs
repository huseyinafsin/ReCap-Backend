using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IFindexService
    {
        IDataResult<int> GetCustomerFindexScore(Guid customerId);
        IDataResult<int> GetCarMinFindexScore(Guid carId);
    }
}

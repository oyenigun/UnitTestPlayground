using UnitTestPlayground.Models;

namespace UnitTestPlayground.Service
{
    public interface ICustomerService
    {
        int RegisterCustomer(CustomerModel customer);
    }
}


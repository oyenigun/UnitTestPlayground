using UnitTestPlayground.Models;
using UnitTestPlayground.Service;

namespace UnitTestPlayground;
public class CustomerUtils
{

    private readonly ICustomerService _customerService;

    public CustomerUtils(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public RegistrationStatus RegisterCustomer(CustomerModel customer)
    {
        if (string.IsNullOrEmpty(customer.IdentityNumber) | string.IsNullOrEmpty(customer.Email))
            return RegistrationStatus.INVALIDDATA;

        if (!Enumerable.Range(8, 100).Contains(customer.Age))
            return RegistrationStatus.INVALIDDATA;

        var response = _customerService.RegisterCustomer(customer);
        if (response <= 0)
            return RegistrationStatus.FAILURE;

        return RegistrationStatus.SUCCESS;
    }
}


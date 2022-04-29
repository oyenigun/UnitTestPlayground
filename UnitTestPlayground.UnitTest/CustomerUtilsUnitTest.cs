using Moq;
using NUnit.Framework;
using UnitTestPlayground.Models;
using UnitTestPlayground.Service;

namespace UnitTestPlayground.UnitTest;

public class CustomerUtilsUnitTest
{

    // Method Name Format: UnitOfWork_Condition_ExpectedResult

    [Test]
    public void Customer_WithInvalidData_InvalidData()
    {
        //Arrange
        var customerMethods = new CustomerUtils(null);
        var customerModel = new CustomerModel();

        //Action
        var response = customerMethods.RegisterCustomer(customerModel);

        //Assertion
        Assert.AreEqual(response, RegistrationStatus.INVALIDDATA);
    }

    [Test]
    public void Customer_WithInvalidAge_InvalidData()
    {
        var customerMethods = new CustomerUtils(null);
        var customerModel = new CustomerModel() { IdentityNumber = "IdentityNumber", Email = "email@outlook.com", Age = 120 };

        RegistrationStatus response = customerMethods.RegisterCustomer(customerModel);

        Assert.AreEqual(response, RegistrationStatus.INVALIDDATA);
    }

    [Test]
    public void Customer_WithValidData_Success()
    {
        var mockValidator = new Mock<ICustomerService>();
        mockValidator.Setup(i => i.RegisterCustomer(It.IsAny<CustomerModel>())).Returns(1);
        var customerMethods = new CustomerUtils(mockValidator.Object);
        var customerModel = new CustomerModel() { IdentityNumber = "IdentityNumber", Email = "email@outlook.com", Age = 28 };

        var response = customerMethods.RegisterCustomer(customerModel);

        Assert.AreEqual(response, RegistrationStatus.SUCCESS);
    }


    [Test]
    public void Customer_WithValidData_Failure()
    {
        var mockValidator = new Mock<ICustomerService>();
        mockValidator.Setup(i => i.RegisterCustomer(It.IsAny<CustomerModel>())).Returns(-1);
        var customerMethods = new CustomerUtils(mockValidator.Object);
        var customerModel = new CustomerModel() { IdentityNumber = "IdentityNumber", Email = "email@outlook.com", Age = 28 };

        var response = customerMethods.RegisterCustomer(customerModel);

        Assert.AreEqual(response, RegistrationStatus.FAILURE);
    }
}

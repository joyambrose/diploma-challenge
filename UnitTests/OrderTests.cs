using Xunit;
using api.models;
using System;

namespace UnitTests;

public class UnitTest1
{
    [Fact]
    public void TotalTest()
    {
        // Arange -- set up what you need
        double expected = 32100;
        Order o = new Order(1, DateTime.Now, 5, DateTime.Now, "CUSTID", "PRODID", "SHIPMODE", new Product());

        //Act -- call the method you want to test
        double result = o.total(100, 321);

        // Assert -- check if actual result is what you ecpcted
        Assert.Equal(result, expected);
    }



    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void GSTtest(double _price)
    {
        double expected = 2;
        Order o = new Order(3, DateTime.Now, 1, DateTime.Now, "CUSTID", "PRODID", "SHIPMODE", new Product());

        double result = (_price * 0.1);

        Assert.Equal(result, expected);
    }
}
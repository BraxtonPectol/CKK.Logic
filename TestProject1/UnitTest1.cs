using CKK.Logic;
using CKK.Logic.Models;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Customer customer = new Customer();
            Product P = new Product();
            ShoppingCart S = new ShoppingCart(customer);
            S.AddProduct(P, 8);
            S.RemoveProduct(P.Id, 10);
           
        }
    }
}
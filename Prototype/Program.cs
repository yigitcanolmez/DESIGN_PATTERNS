using System;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                FirstName = "yiğit",
                LastName = "ölmez",
                City = "newy",
                Id = 1907
            };
            var customer1 = (Customer)customer.Clone();
            customer1.FirstName = "QWERT";

            var customer2 = (Customer)customer1.Clone();
            
            Console.WriteLine(customer.FirstName + " " + customer.LastName);
            Console.WriteLine(customer1.FirstName + " " + customer1.LastName);
            Console.WriteLine(customer2.FirstName + " " + customer2.LastName + " " + customer2.Salary);
            Console.ReadLine();

        }
    }
    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }

    }
    public class Boss : Person
    {
        public string Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }

    }
}

using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Add();
        }
    }
    class CustomerManager
    {
        private static CustomerManager _customer;
        static object _lockObject = new object();
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            lock(_lockObject)
            {
                if (_customer == null)
                    _customer = new CustomerManager();
            }
            return _customer;
        }
        public void Add()
        {
            Console.WriteLine("Ürün eklendi!");
        }
    }
}

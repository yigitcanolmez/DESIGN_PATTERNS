using System;

namespace FactoryMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            Console.ReadLine();
        }
    }
    public class LoggerFactory : ILogger
    {
        public void Logger()
        {

        }
    }
    public interface ILoggerFactory
    {
    } 
    public interface ILogger
    {
        void Logger();
    }
    public class YoLogger : ILogger
    {
        public void Logger()
        {
            Console.Write("Logged with YOLOGGER");
        }
    }
    public class CustomerManager
    {
        private readonly ILogger _logger;
        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Logger();
            Console.WriteLine("SAVED");
            
        }
    }
}

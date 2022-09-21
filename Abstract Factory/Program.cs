using System;

namespace Abstract_Factory
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory());
            productManager.Save();
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);
    }
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net");
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with nlogger");
        }
    }
    public abstract class Caching
    {
        public abstract void Cache(string data);
    }
    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("cached with MemCache");
        }
    }
    public class XCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("cached with XCache");
        }
    }
    public abstract class CCC
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
    public class Factory : CCC
    {
        public override Logging CreateLogger()
        {
            return new NLogger();
        }
        public override Caching CreateCaching()
        {
            return new XCache();
        }
    }
    public class ProductManager
    {
        private readonly CCC _ccc;
        private Logging _logging;
        private Caching _caching;
        public ProductManager(CCC ccc)
        {
            _ccc = ccc;
            _logging = _ccc.CreateLogger();
            _caching = _ccc.CreateCaching();
        }
        
        public void Save()
        {
            _logging.Log("log");
            _caching.Cache("data");
            Console.WriteLine("the content saved");
        }

    }

}

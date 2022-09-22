using System;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCustomerProductBuiler();
            productDirector.GenerateProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.ProductName + " " + model.UnitPrice);
            Console.ReadLine();
            
        }
    }
    class ProductViewModel
    {
        public  int  Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public bool isDiscountApplied { get; set; }
    }
    internal abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();

    }
    class NewCustomerProductBuiler : ProductBuilder
    {
        ProductViewModel productView = new ProductViewModel();
        public override void ApplyDiscount()
        {
            productView.Discount = productView.UnitPrice*(decimal)0.90;
            productView.isDiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return productView;
        }

        public override void GetProductData()
        {
            productView.Id = 1;
            productView.CategoryName = "Beverage";
            productView.CategoryName = "Ice Caramel Chai";
            productView.UnitPrice = 34;
        }
    } 
    class OldCustomerProductBuiler : ProductBuilder
    {
        public override void ApplyDiscount()
        {
            throw new NotImplementedException();
        }

        public override ProductViewModel GetModel()
        {
            throw new NotImplementedException();
        }

        public override void GetProductData()
        {
            throw new NotImplementedException();
        }
    }
    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            //Oracle,Sql Server, Postgres, MongoDb den geliyormuş gibi simülasyon edildi
            _products = new List<Product>
            {
                new Product
                {
                    ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15
                },
                new Product
                {
                    ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3
                },
                new Product
                {
                    ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2
                },
                new Product
                {
                    ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65
                },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1 }
            };

  

        }

       

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
            
        }


        public List<Product> GetAll()
        {
            return _products;

        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.CategoryId=product.CategoryId;
            productToUpdate.UnitPrice=product.UnitPrice;
            productToUpdate.UnitsInStock=product.UnitsInStock;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }























        //Single Line query
        //AnyTest();

        //FindTest();

        //FindAllTest();

        //AscDescTest();

        //ClassicLinqTest();


        //Linqexp();






        //private void Linqexp()
        //{
        //    var result = from p in _products
        //                 join c in categories
        //                 on p.CategoryId equals c.CategoryId
        //                 where p.UnitePrice > 500
        //                 orderby p.UnitePrice descending
        //                 select new ProductDto { ProductId = p.ProductId, CategoryName = c.CategoryName.........};

        //    foreach (var ProductDto in result)
        //    {
        //        Console.WriteLine("{0} --- {1}", ProductDto.ProductName, ProductDto.CategoryName);
        //    }
        //}

        //private void ClassicLinqTest()
        //{
        //    var result = from p in _products
        //                 where p.UnitPrice > 500
        //                 orderby p.UnitPrice descending, p.ProductName ascending
        //                 select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitePrice = p.UnitPrice, };

        //    foreach (var product in result)
        //    {
        //        Console.WriteLine(product.ProductName);
        //    }
        //}

        //private void AscDescTest()
        //{
        //    var result = _products.Where(p => p.ProductName.Contains("a")).OrderBy(p => p.UnitPrice).ThenByDescending(p => p.ProductName);

        //    foreach (var product in result)
        //    {
        //        Console.WriteLine(product.ProductName);
        //    }
        //}

        //private void FindAllTest()
        //{
        //    var result = _products.FindAll(p => p.ProductName.Contains("a"));
        //    Console.WriteLine(result);
        //}

        //private void FindTest()
        //{
        //    var result = _products.Find(p => p.ProductId == 3);
        //    Console.WriteLine(result.ProductName);
        //}

        //private void AnyTest()
        //{
        //    var result = _products.Any(p => p.ProductName == "Bardak");
        //    Console.WriteLine(result);
        //}



    }

    
}
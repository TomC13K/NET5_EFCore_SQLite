using System;

namespace EFCoreWithSQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(">>> Starting the appppp <<<");

            // create new object of type Product
            Product product = new Product()
            {
                Id = 5,
                Name = "Iteeeem 4"
            };

            //add it to the DB
            ProductService.Add(product);

            //get all products from the db
            ProductService.GetAll();

            //get the product from the db
            Console.WriteLine("Original product: \n");
            ProductService.Get(1);

            //edit product
            product.Name = "Newish laptop 3";
            ProductService.Edit(product);

            // get all products from DB
            Console.WriteLine("List of all products: \n");
            ProductService.GetAll();


            //get the edited product from the db
            Console.WriteLine("Edited product: \n");
            ProductService.Get(4);
        }
    }
}

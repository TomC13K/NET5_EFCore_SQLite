using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCoreWithSQLite
{
    public static class ProductService
    {
        public static void Add(Product product)
        {
                using var context = new SampleContext();
                var entity = context.Products.Add(product);
                entity.State = EntityState.Added;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error saving -> {ex.Message}");
                //throw new Exception("Database error while trying to save changes: ", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}");
                //throw new Exception("Database general error while : ", ex);
            }
        }

        public static void Edit(Product product)
        {
            using var context = new SampleContext();
            var entity = context.Products.Update(product);
            entity.State = EntityState.Modified;

            context.SaveChanges();
        }

        public static void Delete(Product product)
        {
            using var context = new SampleContext();
            var entity = context.Products.Remove(product);
            entity.State = EntityState.Deleted;

            context.SaveChanges();
        }

        public static Product Get(int productId)
        {
            using var context = new SampleContext();
            var product = context.Products.Find(productId);
            Console.WriteLine($"Product ID:{product.Id}; Product Name:{product.Name}");

            return product;
        }

        public static void GetAll()
        {
            using var context = new SampleContext();
            if(context.Products.Any())
            {
                var data = context.Products.ToList();
                foreach (var product in data)
                {
                    Console.WriteLine($"Product ID:{product.Id}; Product Name:{product.Name}");
                }
            }
            else
            {
                Console.WriteLine("There are no records in the table");
            }
        }

      
    }
}

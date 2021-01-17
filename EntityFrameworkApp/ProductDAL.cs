using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApp
{
    public class ProductDAL
    {
          //Listing Method
          public List<Product> ProductList()
          {
                using (ETradeContext context = new ETradeContext())
                {
                    return context.Products.ToList();
                }
          }

        // Get a product name using LINQ statements (filter in search textbox)
        public List<Product> GetByProductName(string key)
        {        
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p=>p.Name.Contains(key.ToLower())).ToList();
            }
        }

   
        // Adding Method;
        public void ProductAdd(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        // Update Method;
        public void ProductUpdate(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        //Delete Method;
        public void ProductDelete(Product product)
        {
            using( ETradeContext context=new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        
    }
}

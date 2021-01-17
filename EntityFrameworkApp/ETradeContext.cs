using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApp
{
    public class ETradeContext: DbContext
    {
        /* Here, we have used generic called "Dbset".
        It means that we have built a relationship between Product and Products for data access. */

        public DbSet<Product> Products { get; set; }

    }
}

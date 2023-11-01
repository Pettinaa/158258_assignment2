using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication222222.Data
{
    public class WebApplication222222Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebApplication222222Context() : base("name=WebApplication222222Context")
        {
        }

        public System.Data.Entity.DbSet<WebApplication222222.Models.Character> Characters { get; set; }

        public System.Data.Entity.DbSet<WebApplication222222.Models.Element> Elements { get; set; }
    }
}

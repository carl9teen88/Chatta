using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chatta.Models
{
    public class ChattaDbContext : DbContext
    {
        public DbSet<User> Users { set; get; }
    }
}
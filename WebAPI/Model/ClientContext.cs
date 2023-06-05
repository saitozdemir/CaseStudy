using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebbApi.Controllers
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {

        }
        public DbSet<Clients> Clients { get; set; }
    }
}
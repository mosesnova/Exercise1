using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryWebApp.DataAccess
{
    public class ShipDBContext : DbContext
    {
        public ShipDBContext(DbContextOptions<ShipDBContext> options)
            : base(options)
        {
        }

        public DbSet<EstimatedArrivalDate> EstimatedArrivalDate { get; set; }
    }
}

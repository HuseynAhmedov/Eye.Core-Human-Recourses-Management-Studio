using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eterna.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ClientModel> clients { get; set; }
        public DbSet<FeaturesModel> features { get; set; }
        public DbSet<ServicesModel> services { get; set; }
        public DbSet<SliderModel> sliders { get; set; }
        public DbSet<AppitemModel> appItems { get; set; }
        public DbSet<ListModel> aboutLists { get; set; }
    }
}

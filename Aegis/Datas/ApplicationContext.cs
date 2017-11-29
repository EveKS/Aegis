using Aegis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aegis.Datas
{
  public class ApplicationContext : IdentityDbContext<User>
  {
    public DbSet<ParsingEmailModel> ParsingEmailModels { get; set; }
    public DbSet<ScaningUriModel> ScaningUriModels { get; set; }

    public DbSet<Company> Companys { get; set; }
    public DbSet<Delivery> Deliverys { get; set; }
    public DbSet<DeliveryRegion> DeliveryRegions { get; set; }
    public DbSet<AdditionaServices> AdditionaServices { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
  }
}

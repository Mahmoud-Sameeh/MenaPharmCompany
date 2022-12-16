using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Data
{
    public class MenaPharmCompanyContext : DbContext
    {
        public MenaPharmCompanyContext(DbContextOptions<MenaPharmCompanyContext> options)
            : base(options)
        {
        }

        public DbSet<Asset> Asset { get; set; } = default!;
    }
}
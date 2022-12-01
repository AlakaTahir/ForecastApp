using Forecast.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast.Migrations
{
    public class ForecastInformationDataBaseContext: DbContext
    {
        public ForecastInformationDataBaseContext(DbContextOptions<ForecastInformationDataBaseContext> options) : base(options)
        {
        }

        public DbSet<ForecastInfo> ForecastInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ForecastInfo>().ToTable("ForecastInfos");
        }
    }

}

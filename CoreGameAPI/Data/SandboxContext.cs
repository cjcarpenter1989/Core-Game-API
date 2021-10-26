
using CoreGameAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGameAPI.Data
{
	public class SandboxContext : DbContext
	{
		public SandboxContext(DbContextOptions<SandboxContext> options) : base(options)
		{
			base.ChangeTracker.LazyLoadingEnabled = false;
		}

		public DbSet<SandboxElement> SandboxElements { get; set; }
		public DbSet<SandboxElementStyle> SandboxElementStyles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SandboxElement>().ToTable("SandboxElements");
			modelBuilder.Entity<SandboxElementStyle>().ToTable("SandboxElementStyles");
		}
	}
}

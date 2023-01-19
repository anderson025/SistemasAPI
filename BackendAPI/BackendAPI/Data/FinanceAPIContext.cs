using BackendAPI.Data.Map;
using BackendAPI.Models;	
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data {
	public class FinanceAPIContext : DbContext {

		public FinanceAPIContext(DbContextOptions<FinanceAPIContext> options) : base(options) {

		}
		
		public DbSet<UserModel> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {

			modelBuilder.ApplyConfiguration(new UserMap());
			base.OnModelCreating(modelBuilder);
		}

	}
}

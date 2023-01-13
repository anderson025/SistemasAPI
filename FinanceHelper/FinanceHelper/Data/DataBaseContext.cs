using FinanceHelper.Data.Map;
using FinanceHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceHelper.Data {
	public class DataBaseContext : DbContext {

		public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {

		}

		public DbSet<ContactModel> Contacts { get; set; }
		public DbSet<UserModel> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.ApplyConfiguration(new ContactMap());
			base.OnModelCreating(modelBuilder);
		}
	}
}

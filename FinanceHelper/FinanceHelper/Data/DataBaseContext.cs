using FinanceHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceHelper.Data {
	public class DataBaseContext : DbContext {

		public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {

		}

		public DbSet<ContactModel> Contacts { get; set; }
	}
}

using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendAPI.Data.Map {
	public class UserMap : IEntityTypeConfiguration<UserModel> {
		public void Configure(EntityTypeBuilder<UserModel> builder) {
			builder.HasKey(x => x.Id);
		}
	}
}

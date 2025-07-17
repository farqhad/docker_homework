using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.DataAccess.Entities;

namespace Backend.DataAccess.Entities.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder){
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Nickname).IsUnique(true);
        builder.Property(x => x.Nickname).IsRequired(true);
        builder.Property(x => x.Password).IsRequired(true);
    }
}

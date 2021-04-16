using ProjectServer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProjectServer.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace ProjectServer.Core.Data
{
    public class ProjectServerContext : IdentityDbContext
    {
        public ProjectServerContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<FileUser> FileUser { get; set; }
        public virtual DbSet<SharedFile> Files { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FileUser>(ConfigureFileUser);
            builder.Entity<SharedFile>(ConfigureSharedFile);

            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            
            builder.Ignore<IdentityUser<string>>();
        }

        private void ConfigureSharedFile(EntityTypeBuilder<SharedFile> builder)
        {
            builder.ToTable("SharedFiles")
                .HasKey(ci => ci.Id);

            builder.Property(cb => cb.RecordNo)
                .IsRequired()
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);

            builder.Property(cb => cb.FileName)
                .IsRequired()
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(cb => cb.FilePath)
                .IsRequired()
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(cb => cb.FileExt)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(cb => cb.FileMime)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(cb => cb.Description)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500);

            builder.Property(cb => cb.ShareState)
                .IsRequired();

            builder.Property(cb => cb.SharingDate)
                .IsRequired();
        }

        private void ConfigureFileUser(EntityTypeBuilder<FileUser> builder)
        {
            builder.ToTable("FileUser")
                .HasKey(ci => ci.Id);

            builder.Property(cb => cb.UserId)
                .IsRequired();

            builder.Property(cb => cb.FileId)
                .IsRequired();

            builder.Property(cb => cb.IsOwner);
        }
    }
}

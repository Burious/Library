using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Library.Db
{
    public partial class RemoteBooksDBContext : DbContext
    {
        public RemoteBooksDBContext()
        {
        }

        public RemoteBooksDBContext(DbContextOptions<RemoteBooksDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RemoteBook> RemoteBooks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<RemoteBook>(entity =>
            {
                entity.ToTable("RemoteBook");

                entity.HasIndex(e => e.CustomerInfoId, "IX_RemoteBook_CustomerInfoId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CustomerInfo)
                    .WithMany(p => p.RemoteBooks)
                    .HasForeignKey(d => d.CustomerInfoId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

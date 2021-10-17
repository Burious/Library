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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<RemoteBook>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

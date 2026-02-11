using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_Event.Models;

public partial class EventDBContext : DbContext
{
    public EventDBContext()
    {
    }

    public EventDBContext(DbContextOptions<EventDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, move it out of source code.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EventDB;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookings__3214EC078830FD7A");

            entity.HasOne(d => d.Event)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade) 
                .HasConstraintName("FK_Bookings_Events");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Users");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC0767FE971E");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.OrganizerName).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC071AEC84F2");

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

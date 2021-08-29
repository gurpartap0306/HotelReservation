using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HotelReservation.Models
{
    public partial class hotelContext : DbContext
    {
        public hotelContext()
        {
        }

        public hotelContext(DbContextOptions<hotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvailableHotelRoom1> AvailableHotelRoom1s { get; set; }
        public virtual DbSet<Bookings1> Bookings1s { get; set; }
        public virtual DbSet<Customer1> Customer1s { get; set; }
        public virtual DbSet<Hotel1> Hotel1s { get; set; }
        public virtual DbSet<Room1> Room1s { get; set; }
        public virtual DbSet<Transaction1> Transaction1s { get; set; }
        public virtual DbSet<Users1> Users1s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:a00442518.database.windows.net,1433;Initial Catalog=hotel;Persist Security Info=False;User ID=gurpartap;Password=TEJwant@93;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AvailableHotelRoom1>(entity =>
            {
                entity.HasKey(e => new { e.HotelId, e.Type, e.Date });

                entity.ToTable("AvailableHotelRoom1");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.AvailableHotelRoom1s)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Available__Hotel__151B244E");
            });

            modelBuilder.Entity<Bookings1>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("Bookings1");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Bookings1s)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookings1__Cid__18EBB532");

                entity.HasOne(d => d.HidNavigation)
                    .WithMany(p => p.Bookings1s)
                    .HasForeignKey(d => d.Hid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookings1__Hid__1F98B2C1");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Bookings1s)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookings1__Uid__1EA48E88");
            });

            modelBuilder.Entity<Customer1>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("Customer1");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hotel1>(entity =>
            {
                entity.HasKey(e => e.HotelId);

                entity.ToTable("Hotel1");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Room1>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.ToTable("Room1");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Room1s)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Room1__BookingId__160F4887");
            });

            modelBuilder.Entity<Transaction1>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("Transaction1");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Transaction1s)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Booki__1332DBDC");
            });

            modelBuilder.Entity<Users1>(entity =>
            {
                entity.ToTable("Users1");

                entity.Property(e => e.ConfirmEmail).HasMaxLength(256);

                entity.Property(e => e.Email).HasMaxLength(2560);

                entity.Property(e => e.Password).HasMaxLength(256);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

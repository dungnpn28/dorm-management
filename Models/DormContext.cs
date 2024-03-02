using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DormitoryManagement.Models;

public partial class DormContext : DbContext
{
    public DormContext()
    {
    }

    public DormContext(DbContextOptions<DormContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bed> Beds { get; set; }

    public virtual DbSet<Dormitory> Dormitories { get; set; }

    public virtual DbSet<ElectricityBill> ElectricityBills { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomAllocation> RoomAllocations { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<WaterBill> WaterBills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\NAMDUNG;Initial Catalog=dorm;User ID=sa;Password=123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bed>(entity =>
        {
            entity.HasKey(e => e.BedId).HasName("PK__bed__CFFED75FD47F3F7B");

            entity.ToTable("bed");

            entity.Property(e => e.BedId).HasColumnName("bed_id");
            entity.Property(e => e.BedNumber).HasColumnName("bed_number");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.Room).WithMany(p => p.Beds)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__bed__room_id__31EC6D26");
        });

        modelBuilder.Entity<Dormitory>(entity =>
        {
            entity.HasKey(e => e.DormitoryId).HasName("PK__dormitor__DB201439B861E924");

            entity.ToTable("dormitory");

            entity.Property(e => e.DormitoryId).HasColumnName("dormitory_id");
            entity.Property(e => e.DormitoryName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dormitory_name");
        });

        modelBuilder.Entity<ElectricityBill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__electric__D706DDB31461FA78");

            entity.ToTable("electricity_bill");

            entity.Property(e => e.BillId).HasColumnName("bill_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Room).WithMany(p => p.ElectricityBills)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__electrici__room___398D8EEE");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__room__19675A8A5AE7E556");

            entity.ToTable("room");

            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.AvailabilityStatus).HasColumnName("availability_status");
            entity.Property(e => e.DormitoryId).HasColumnName("dormitory_id");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("room_number");
            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");

            entity.HasOne(d => d.Dormitory).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.DormitoryId)
                .HasConstraintName("FK__room__dormitory___2E1BDC42");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("FK__room__room_type___2F10007B");
        });

        modelBuilder.Entity<RoomAllocation>(entity =>
        {
            entity.HasKey(e => e.AllocationId).HasName("PK__room_all__5DFAFF30AF320FF8");

            entity.ToTable("room_allocation");

            entity.Property(e => e.AllocationId).HasColumnName("allocation_id");
            entity.Property(e => e.BedId).HasColumnName("bed_id");
            entity.Property(e => e.MoveInDate)
                .HasColumnType("date")
                .HasColumnName("move_in_date");
            entity.Property(e => e.MoveOutDate)
                .HasColumnType("date")
                .HasColumnName("move_out_date");
            entity.Property(e => e.ResidentId).HasColumnName("resident_id");

            entity.HasOne(d => d.Bed).WithMany(p => p.RoomAllocations)
                .HasForeignKey(d => d.BedId)
                .HasConstraintName("FK__room_allo__bed_i__36B12243");

            entity.HasOne(d => d.Resident).WithMany(p => p.RoomAllocations)
                .HasForeignKey(d => d.ResidentId)
                .HasConstraintName("FK__room_allo__resid__35BCFE0A");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.RoomTypeId).HasName("PK__room_typ__42395E84EBA22FF4");

            entity.ToTable("room_type");

            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");
            entity.Property(e => e.MaxBeds).HasColumnName("max_beds");
            entity.Property(e => e.PricePerMonth)
                .HasColumnType("money")
                .HasColumnName("price_per_month");
            entity.Property(e => e.TypeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__B9BE370F1E536130");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Mail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user__role_id__267ABA7A");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__user_rol__760965CC5B7B025B");

            entity.ToTable("user_role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<WaterBill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__water_bi__D706DDB3F9EE902E");

            entity.ToTable("water_bill");

            entity.Property(e => e.BillId).HasColumnName("bill_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Room).WithMany(p => p.WaterBills)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__water_bil__room___3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

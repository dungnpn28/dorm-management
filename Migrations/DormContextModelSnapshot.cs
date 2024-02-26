﻿// <auto-generated />
using System;
using DormitoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DormitoryManagement.Migrations
{
    [DbContext(typeof(DormContext))]
    partial class DormContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DormitoryManagement.Models.Bed", b =>
                {
                    b.Property<int>("BedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("bed_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BedId"));

                    b.Property<int>("BedNumber")
                        .HasColumnType("int")
                        .HasColumnName("bed_number");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.HasKey("BedId")
                        .HasName("PK__bed__CFFED75FD47F3F7B");

                    b.HasIndex("RoomId");

                    b.ToTable("bed", (string)null);
                });

            modelBuilder.Entity("DormitoryManagement.Models.Dormitory", b =>
                {
                    b.Property<int>("DormitoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("dormitory_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DormitoryId"));

                    b.Property<string>("DormitoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("dormitory_name");

                    b.HasKey("DormitoryId")
                        .HasName("PK__dormitor__DB201439B861E924");

                    b.ToTable("dormitory", (string)null);
                });

            modelBuilder.Entity("DormitoryManagement.Models.ElectricityBill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("bill_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("amount");

                    b.Property<int>("Month")
                        .HasColumnType("int")
                        .HasColumnName("month");

                    b.Property<int?>("PaymentStatus")
                        .HasColumnType("int")
                        .HasColumnName("payment_status");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("year");

                    b.HasKey("BillId")
                        .HasName("PK__electric__D706DDB31461FA78");

                    b.HasIndex("RoomId");

                    b.ToTable("electricity_bill", (string)null);
                });

            modelBuilder.Entity("DormitoryManagement.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("AvailabilityStatus")
                        .HasColumnType("int")
                        .HasColumnName("availability_status");

                    b.Property<int?>("DormitoryId")
                        .HasColumnType("int")
                        .HasColumnName("dormitory_id");

                    b.Property<int>("Floor")
                        .HasColumnType("int")
                        .HasColumnName("floor");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("room_number");

                    b.Property<int?>("RoomTypeId")
                        .HasColumnType("int")
                        .HasColumnName("room_type_id");

                    b.HasKey("RoomId")
                        .HasName("PK__room__19675A8A5AE7E556");

                    b.HasIndex("DormitoryId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("room", (string)null);
                });

            modelBuilder.Entity("DormitoryManagement.Models.RoomAllocation", b =>
                {
                    b.Property<int>("AllocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("allocation_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllocationId"));

                    b.Property<int?>("BedId")
                        .HasColumnType("int")
                        .HasColumnName("bed_id");

                    b.Property<DateTime>("MoveInDate")
                        .HasColumnType("date")
                        .HasColumnName("move_in_date");

                    b.Property<DateTime?>("MoveOutDate")
                        .HasColumnType("date")
                        .HasColumnName("move_out_date");

                    b.Property<int?>("ResidentId")
                        .HasColumnType("int")
                        .HasColumnName("resident_id");

                    b.HasKey("AllocationId")
                        .HasName("PK__room_all__5DFAFF30AF320FF8");

                    b.HasIndex("BedId");

                    b.HasIndex("ResidentId");

                    b.ToTable("room_allocation", (string)null);
                });

            modelBuilder.Entity("DormitoryManagement.Models.RoomType", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("room_type_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTypeId"));

                    b.Property<int>("MaxBeds")
                        .HasColumnType("int")
                        .HasColumnName("max_beds");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("type_name");

                    b.HasKey("RoomTypeId")
                        .HasName("PK__room_typ__42395E84EBA22FF4");

                    b.ToTable("room_type", (string)null);
                });

            modelBuilder.Entity("DormitoryManagement.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("dob");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("gender");

                    b.Property<string>("Mail")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("mail");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("UserId")
                        .HasName("PK__user__B9BE370F1E536130");

                    b.HasIndex("RoleId");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("DormitoryManagement.Models.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("role_name");

                    b.HasKey("RoleId")
                        .HasName("PK__user_rol__760965CC5B7B025B");

                    b.ToTable("user_role", (string)null);
                });

            modelBuilder.Entity("DormitoryManagement.Models.WaterBill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("bill_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("amount");

                    b.Property<int>("Month")
                        .HasColumnType("int")
                        .HasColumnName("month");

                    b.Property<int?>("PaymentStatus")
                        .HasColumnType("int")
                        .HasColumnName("payment_status");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("year");

                    b.HasKey("BillId")
                        .HasName("PK__water_bi__D706DDB3F9EE902E");

                    b.HasIndex("RoomId");

                    b.ToTable("water_bill", (string)null);
                });

            modelBuilder.Entity("DormitoryManagement.Models.Bed", b =>
                {
                    b.HasOne("DormitoryManagement.Models.Room", "Room")
                        .WithMany("Beds")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK__bed__room_id__31EC6D26");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DormitoryManagement.Models.ElectricityBill", b =>
                {
                    b.HasOne("DormitoryManagement.Models.Room", "Room")
                        .WithMany("ElectricityBills")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK__electrici__room___398D8EEE");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DormitoryManagement.Models.Room", b =>
                {
                    b.HasOne("DormitoryManagement.Models.Dormitory", "Dormitory")
                        .WithMany("Rooms")
                        .HasForeignKey("DormitoryId")
                        .HasConstraintName("FK__room__dormitory___2E1BDC42");

                    b.HasOne("DormitoryManagement.Models.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .HasConstraintName("FK__room__room_type___2F10007B");

                    b.Navigation("Dormitory");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("DormitoryManagement.Models.RoomAllocation", b =>
                {
                    b.HasOne("DormitoryManagement.Models.Bed", "Bed")
                        .WithMany("RoomAllocations")
                        .HasForeignKey("BedId")
                        .HasConstraintName("FK__room_allo__bed_i__36B12243");

                    b.HasOne("DormitoryManagement.Models.User", "Resident")
                        .WithMany("RoomAllocations")
                        .HasForeignKey("ResidentId")
                        .HasConstraintName("FK__room_allo__resid__35BCFE0A");

                    b.Navigation("Bed");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("DormitoryManagement.Models.User", b =>
                {
                    b.HasOne("DormitoryManagement.Models.UserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__user__role_id__267ABA7A");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DormitoryManagement.Models.WaterBill", b =>
                {
                    b.HasOne("DormitoryManagement.Models.Room", "Room")
                        .WithMany("WaterBills")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK__water_bil__room___3C69FB99");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DormitoryManagement.Models.Bed", b =>
                {
                    b.Navigation("RoomAllocations");
                });

            modelBuilder.Entity("DormitoryManagement.Models.Dormitory", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("DormitoryManagement.Models.Room", b =>
                {
                    b.Navigation("Beds");

                    b.Navigation("ElectricityBills");

                    b.Navigation("WaterBills");
                });

            modelBuilder.Entity("DormitoryManagement.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("DormitoryManagement.Models.User", b =>
                {
                    b.Navigation("RoomAllocations");
                });

            modelBuilder.Entity("DormitoryManagement.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
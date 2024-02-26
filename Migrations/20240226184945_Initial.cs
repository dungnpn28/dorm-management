using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormitoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dormitory",
                columns: table => new
                {
                    dormitory_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dormitory_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__dormitor__DB201439B861E924", x => x.dormitory_id);
                });

            migrationBuilder.CreateTable(
                name: "room_type",
                columns: table => new
                {
                    room_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    max_beds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__room_typ__42395E84EBA22FF4", x => x.room_type_id);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_rol__760965CC5B7B025B", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    room_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dormitory_id = table.Column<int>(type: "int", nullable: true),
                    room_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    floor = table.Column<int>(type: "int", nullable: false),
                    room_type_id = table.Column<int>(type: "int", nullable: true),
                    availability_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__room__19675A8A5AE7E556", x => x.room_id);
                    table.ForeignKey(
                        name: "FK__room__dormitory___2E1BDC42",
                        column: x => x.dormitory_id,
                        principalTable: "dormitory",
                        principalColumn: "dormitory_id");
                    table.ForeignKey(
                        name: "FK__room__room_type___2F10007B",
                        column: x => x.room_type_id,
                        principalTable: "room_type",
                        principalColumn: "room_type_id");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    dob = table.Column<DateTime>(type: "date", nullable: true),
                    gender = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    mail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user__B9BE370F1E536130", x => x.user_id);
                    table.ForeignKey(
                        name: "FK__user__role_id__267ABA7A",
                        column: x => x.role_id,
                        principalTable: "user_role",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "bed",
                columns: table => new
                {
                    bed_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_id = table.Column<int>(type: "int", nullable: true),
                    bed_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__bed__CFFED75FD47F3F7B", x => x.bed_id);
                    table.ForeignKey(
                        name: "FK__bed__room_id__31EC6D26",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "room_id");
                });

            migrationBuilder.CreateTable(
                name: "electricity_bill",
                columns: table => new
                {
                    bill_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_id = table.Column<int>(type: "int", nullable: true),
                    month = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    payment_status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__electric__D706DDB31461FA78", x => x.bill_id);
                    table.ForeignKey(
                        name: "FK__electrici__room___398D8EEE",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "room_id");
                });

            migrationBuilder.CreateTable(
                name: "water_bill",
                columns: table => new
                {
                    bill_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_id = table.Column<int>(type: "int", nullable: true),
                    month = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    payment_status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__water_bi__D706DDB3F9EE902E", x => x.bill_id);
                    table.ForeignKey(
                        name: "FK__water_bil__room___3C69FB99",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "room_id");
                });

            migrationBuilder.CreateTable(
                name: "room_allocation",
                columns: table => new
                {
                    allocation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resident_id = table.Column<int>(type: "int", nullable: true),
                    bed_id = table.Column<int>(type: "int", nullable: true),
                    move_in_date = table.Column<DateTime>(type: "date", nullable: false),
                    move_out_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__room_all__5DFAFF30AF320FF8", x => x.allocation_id);
                    table.ForeignKey(
                        name: "FK__room_allo__bed_i__36B12243",
                        column: x => x.bed_id,
                        principalTable: "bed",
                        principalColumn: "bed_id");
                    table.ForeignKey(
                        name: "FK__room_allo__resid__35BCFE0A",
                        column: x => x.resident_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bed_room_id",
                table: "bed",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_electricity_bill_room_id",
                table: "electricity_bill",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_dormitory_id",
                table: "room",
                column: "dormitory_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_room_type_id",
                table: "room",
                column: "room_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_allocation_bed_id",
                table: "room_allocation",
                column: "bed_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_allocation_resident_id",
                table: "room_allocation",
                column: "resident_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                table: "user",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_water_bill_room_id",
                table: "water_bill",
                column: "room_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "electricity_bill");

            migrationBuilder.DropTable(
                name: "room_allocation");

            migrationBuilder.DropTable(
                name: "water_bill");

            migrationBuilder.DropTable(
                name: "bed");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "dormitory");

            migrationBuilder.DropTable(
                name: "room_type");
        }
    }
}

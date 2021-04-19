using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementApplication.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    Schedule = table.Column<int>(type: "int", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreationDate", "RegionName" },
                values: new object[] { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbekistan" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreationDate", "RegionName" },
                values: new object[] { 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreationDate", "DepartmentName", "RegionId" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accounting department", 1 },
                    { 2, new DateTime(1990, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT department", 1 },
                    { 3, new DateTime(1990, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Production department", 1 },
                    { 4, new DateTime(1990, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Research and Development department", 1 },
                    { 5, new DateTime(1995, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Architecture department", 2 },
                    { 6, new DateTime(1995, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Asian Studies department", 2 },
                    { 7, new DateTime(1995, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Middle Eastern Studies department", 2 },
                    { 8, new DateTime(1995, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "French language department", 2 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DateOfBirth", "DepartmentId", "Email", "EmploymentDate", "FirstName", "Gender", "LastName", "PassportNo", "Phone", "Position", "Salary", "Schedule" },
                values: new object[,]
                {
                    { 1, "Little Ring Avn, 13", new DateTime(1960, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john.smith@mail.ru", new DateTime(2020, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 0, "Smith", "AB7564737", "+1-435-545-65-76", "Manager", 12000f, 0 },
                    { 2, "Amir-Temur street, 24", new DateTime(1967, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "phillip.walsh@mail.ru", new DateTime(2007, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phillip", 0, "Walsh", "AB5675434", "+998-93-647-75-63", "Software engineer", 7000f, 1 },
                    { 3, "Alisher Navoiy street, 46", new DateTime(1983, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "dora.williamson@mail.ru", new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dora", 1, "Williamson", "AA7587492", "+998-97-657-47-86", "Product designer", 8000f, 4 },
                    { 4, "Mirabad street, 34", new DateTime(1973, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "nadeem.liu@mail.ru", new DateTime(2012, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nadeem", 1, "Liu", "AA8597573", "+998-90-754-98-12", "Researcher", 7500f, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreationTime", "Deadline", "EmployeeId", "TaskDescription", "TaskName" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 23, 11, 21, 699, DateTimeKind.Local).AddTicks(7529), 1, "John Smith should properly manage employees", "Manage employees" },
                    { 2, new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 23, 11, 21, 701, DateTimeKind.Local).AddTicks(7315), 2, "Phillip Walsh should create software", "Create software" },
                    { 3, new DateTime(2020, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 23, 11, 21, 701, DateTimeKind.Local).AddTicks(7348), 3, "Dora Williamson should create a great product design", "Create a product design" },
                    { 4, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 23, 11, 21, 701, DateTimeKind.Local).AddTicks(7354), 4, "Nadeem Liu should make a research", "Make a research" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_RegionId",
                table: "Departments",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}

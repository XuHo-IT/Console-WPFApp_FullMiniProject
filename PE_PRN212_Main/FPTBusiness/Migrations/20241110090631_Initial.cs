using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FPT.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectDetails",
                columns: table => new
                {
                    ProjectDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    NumberOfHours = table.Column<int>(type: "int", nullable: false),
                    RoleStaff = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDetails", x => x.ProjectDetailID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStaff = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.AccountID);
                });

            migrationBuilder.InsertData(
                table: "ProjectDetails",
                columns: new[] { "ProjectDetailID", "NumberOfHours", "ProjectID", "RoleStaff", "StaffID" },
                values: new object[,]
                {
                    { 1, 120, 1, "Manager", 1 },
                    { 2, 100, 2, "Developer", 7 },
                    { 3, 80, 3, "Design", 8 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "NameProject" },
                values: new object[,]
                {
                    { 1, "Library System" },
                    { 2, "Travel Website" },
                    { 3, "Fashion Website" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffID", "AccountID", "AddressStaff", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, 2, "15 Quang Trung Da Nang", "Nguyen", "Male", "An" },
                    { 2, 3, "25 Hoang Tieu Da Nang", "Le", "FeMale", "Bao" },
                    { 3, 4, "30 Le Duan Da Nang", "Tran", "FeMale", "Cuong" }
                });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "AccountID", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "admin", 1, "admin" },
                    { 2, "user1", 0, "user1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDetails");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}

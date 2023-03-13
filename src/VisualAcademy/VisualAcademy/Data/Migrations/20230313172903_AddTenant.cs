using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisualAcademy.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthenticationHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportWriterURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BadgePhotoType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortalName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}

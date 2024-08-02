using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisplayDiff.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Display",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerticalResolution = table.Column<int>(type: "int", nullable: false),
                    HorizontalResolution = table.Column<int>(type: "int", nullable: false),
                    AdaptiveSync = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PanelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagonalLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RefreshRate = table.Column<int>(type: "int", nullable: false),
                    FullSpecsURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Display", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Display");
        }
    }
}

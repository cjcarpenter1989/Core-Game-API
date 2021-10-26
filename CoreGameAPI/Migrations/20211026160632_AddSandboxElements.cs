using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreGameAPI.Migrations
{
    public partial class AddSandboxElements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SandboxElementStyles",
                columns: table => new
                {
                    SandboxElementStyleKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SandboxElementStyles", x => x.SandboxElementStyleKey);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SandboxElements",
                columns: table => new
                {
                    SandboxElementKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SandboxElementStyleKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SandboxElements", x => x.SandboxElementKey);
                    table.ForeignKey(
                        name: "FK_SandboxElements_SandboxElementStyles_SandboxElementStyleKey",
                        column: x => x.SandboxElementStyleKey,
                        principalTable: "SandboxElementStyles",
                        principalColumn: "SandboxElementStyleKey",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SandboxElements_SandboxElementStyleKey",
                table: "SandboxElements",
                column: "SandboxElementStyleKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SandboxElements");

            migrationBuilder.DropTable(
                name: "SandboxElementStyles");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SchemaAcrossDbViewSamle.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test1",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    QueryTest2Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test1", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Test1",
                columns: new[] { "Id", "Name", "QueryTest2Id" },
                values: new object[] { "test1-1", "test1", "test2-1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test1");
        }
    }
}

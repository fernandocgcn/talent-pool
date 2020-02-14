using Microsoft.EntityFrameworkCore.Migrations;

namespace TPData.Migrations
{
    public partial class DeleteDeveloperKnowledgePk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_developer_knowledge",
                schema: "dbo",
                table: "tb_developer_knowledge");

            migrationBuilder.DropIndex(
                name: "IX_tb_developer_knowledge_dev_id_kno_id",
                schema: "dbo",
                table: "tb_developer_knowledge");

            migrationBuilder.DropColumn(
                name: "dek_id",
                schema: "dbo",
                table: "tb_developer_knowledge");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_developer_knowledge",
                schema: "dbo",
                table: "tb_developer_knowledge",
                columns: new[] { "dev_id", "kno_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_developer_knowledge",
                schema: "dbo",
                table: "tb_developer_knowledge");

            migrationBuilder.AddColumn<int>(
                name: "dek_id",
                schema: "dbo",
                table: "tb_developer_knowledge",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_developer_knowledge",
                schema: "dbo",
                table: "tb_developer_knowledge",
                column: "dek_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_developer_knowledge_dev_id_kno_id",
                schema: "dbo",
                table: "tb_developer_knowledge",
                columns: new[] { "dev_id", "kno_id" },
                unique: true);
        }
    }
}

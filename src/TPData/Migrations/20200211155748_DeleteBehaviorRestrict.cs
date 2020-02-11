using Microsoft.EntityFrameworkCore.Migrations;

namespace TPData.Migrations
{
    public partial class DeleteBehaviorRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_developer_availability_tb_availability_ava_id",
                schema: "dbo",
                table: "tb_developer_availability");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_developer_knowledge_tb_knowledge_kno_id",
                schema: "dbo",
                table: "tb_developer_knowledge");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_developer_working_time_tb_working_time_wot_id",
                schema: "dbo",
                table: "tb_developer_working_time");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_developer_availability_tb_availability_ava_id",
                schema: "dbo",
                table: "tb_developer_availability",
                column: "ava_id",
                principalSchema: "dbo",
                principalTable: "tb_availability",
                principalColumn: "ava_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_developer_knowledge_tb_knowledge_kno_id",
                schema: "dbo",
                table: "tb_developer_knowledge",
                column: "kno_id",
                principalSchema: "dbo",
                principalTable: "tb_knowledge",
                principalColumn: "kno_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_developer_working_time_tb_working_time_wot_id",
                schema: "dbo",
                table: "tb_developer_working_time",
                column: "wot_id",
                principalSchema: "dbo",
                principalTable: "tb_working_time",
                principalColumn: "wot_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_developer_availability_tb_availability_ava_id",
                schema: "dbo",
                table: "tb_developer_availability");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_developer_knowledge_tb_knowledge_kno_id",
                schema: "dbo",
                table: "tb_developer_knowledge");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_developer_working_time_tb_working_time_wot_id",
                schema: "dbo",
                table: "tb_developer_working_time");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_developer_availability_tb_availability_ava_id",
                schema: "dbo",
                table: "tb_developer_availability",
                column: "ava_id",
                principalSchema: "dbo",
                principalTable: "tb_availability",
                principalColumn: "ava_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_developer_knowledge_tb_knowledge_kno_id",
                schema: "dbo",
                table: "tb_developer_knowledge",
                column: "kno_id",
                principalSchema: "dbo",
                principalTable: "tb_knowledge",
                principalColumn: "kno_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_developer_working_time_tb_working_time_wot_id",
                schema: "dbo",
                table: "tb_developer_working_time",
                column: "wot_id",
                principalSchema: "dbo",
                principalTable: "tb_working_time",
                principalColumn: "wot_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

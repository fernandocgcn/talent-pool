using Microsoft.EntityFrameworkCore.Migrations;

namespace TPData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "tb_availability",
                schema: "dbo",
                columns: table => new
                {
                    ava_id = table.Column<int>(nullable: false),
                    ava_description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_availability", x => x.ava_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_developer",
                schema: "dbo",
                columns: table => new
                {
                    dev_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dev_email = table.Column<string>(nullable: false),
                    dev_name = table.Column<string>(nullable: false),
                    dev_city = table.Column<string>(nullable: false),
                    dev_state = table.Column<string>(nullable: false),
                    dev_skype = table.Column<string>(nullable: false),
                    dev_whatsapp = table.Column<string>(nullable: false),
                    dev_salary = table.Column<decimal>(nullable: false),
                    dev_linkedin = table.Column<string>(nullable: true),
                    dev_portfolio = table.Column<string>(nullable: true),
                    dev_extra_knowledge = table.Column<string>(nullable: true),
                    dev_crud_link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_developer", x => x.dev_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_knowledge",
                schema: "dbo",
                columns: table => new
                {
                    kno_id = table.Column<int>(nullable: false),
                    kno_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_knowledge", x => x.kno_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_working_time",
                schema: "dbo",
                columns: table => new
                {
                    wot_id = table.Column<int>(nullable: false),
                    wot_description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_working_time", x => x.wot_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_developer_availability",
                schema: "dbo",
                columns: table => new
                {
                    dev_id = table.Column<int>(nullable: false),
                    ava_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_developer_availability", x => new { x.dev_id, x.ava_id });
                    table.ForeignKey(
                        name: "FK_tb_developer_availability_tb_availability_ava_id",
                        column: x => x.ava_id,
                        principalSchema: "dbo",
                        principalTable: "tb_availability",
                        principalColumn: "ava_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_developer_availability_tb_developer_dev_id",
                        column: x => x.dev_id,
                        principalSchema: "dbo",
                        principalTable: "tb_developer",
                        principalColumn: "dev_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_developer_knowledge",
                schema: "dbo",
                columns: table => new
                {
                    dek_id = table.Column<int>(nullable: false),
                    dek_rate = table.Column<short>(nullable: false),
                    dev_id = table.Column<int>(nullable: false),
                    kno_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_developer_knowledge", x => x.dek_id);
                    table.ForeignKey(
                        name: "FK_tb_developer_knowledge_tb_developer_dev_id",
                        column: x => x.dev_id,
                        principalSchema: "dbo",
                        principalTable: "tb_developer",
                        principalColumn: "dev_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_developer_knowledge_tb_knowledge_kno_id",
                        column: x => x.kno_id,
                        principalSchema: "dbo",
                        principalTable: "tb_knowledge",
                        principalColumn: "kno_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_developer_working_time",
                schema: "dbo",
                columns: table => new
                {
                    dev_id = table.Column<int>(nullable: false),
                    wot_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_developer_working_time", x => new { x.dev_id, x.wot_id });
                    table.ForeignKey(
                        name: "FK_tb_developer_working_time_tb_developer_dev_id",
                        column: x => x.dev_id,
                        principalSchema: "dbo",
                        principalTable: "tb_developer",
                        principalColumn: "dev_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_developer_working_time_tb_working_time_wot_id",
                        column: x => x.wot_id,
                        principalSchema: "dbo",
                        principalTable: "tb_working_time",
                        principalColumn: "wot_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tb_availability",
                columns: new[] { "ava_id", "ava_description" },
                values: new object[,]
                {
                    { 1, "Up to 4 hours per day / Até 4 horas por dia" },
                    { 2, "4 to 6 hours per day / De 4 á 6 horas por dia" },
                    { 3, "6 to 8 hours per day /De 6 á 8 horas por dia" },
                    { 4, "Up to 8 hours a day (are you sure?) / Acima de 8 horas por dia (tem certeza?)" },
                    { 5, "Only weekends / Apenas finais de semana" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tb_knowledge",
                columns: new[] { "kno_id", "kno_name" },
                values: new object[,]
                {
                    { 19, "Django" },
                    { 20, "Majento" },
                    { 21, "PHP" },
                    { 22, "Vue" },
                    { 23, "Wordpress" },
                    { 24, "Phyton" },
                    { 25, "Ruby" },
                    { 27, "My SQL" },
                    { 18, "Cake" },
                    { 28, "Salesforce" },
                    { 29, "Photoshop" },
                    { 30, "Illustrator" },
                    { 31, "SEO" },
                    { 32, "Laravel" },
                    { 26, "My SQL Server" },
                    { 17, "NodeJS" },
                    { 16, "C#" },
                    { 15, "C" },
                    { 1, "Ionic" },
                    { 2, "ReactJS" },
                    { 3, "React Native" },
                    { 4, "Android" },
                    { 5, "IOS" },
                    { 7, "CSS" },
                    { 6, "HTML" },
                    { 9, "Jquery" },
                    { 10, "AngularJs 1.*" },
                    { 11, "Angular" },
                    { 12, "Java" },
                    { 13, "Asp.Net MVC" },
                    { 14, "Asp.Net WebForm" },
                    { 8, "Bootstrap" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tb_working_time",
                columns: new[] { "wot_id", "wot_description" },
                values: new object[,]
                {
                    { 4, "Dawn (from 10 p.m. onwards) / Madrugada (de 22:00 em diante)" },
                    { 1, "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)" },
                    { 2, "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)" },
                    { 3, "Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)" },
                    { 5, "Business (from 08:00 a.m. to 06:00 p.m.) / Comercial (de 08:00 as 18:00)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_developer_dev_email",
                schema: "dbo",
                table: "tb_developer",
                column: "dev_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_developer_availability_ava_id",
                schema: "dbo",
                table: "tb_developer_availability",
                column: "ava_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_developer_knowledge_kno_id",
                schema: "dbo",
                table: "tb_developer_knowledge",
                column: "kno_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_developer_knowledge_dev_id_kno_id",
                schema: "dbo",
                table: "tb_developer_knowledge",
                columns: new[] { "dev_id", "kno_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_developer_working_time_wot_id",
                schema: "dbo",
                table: "tb_developer_working_time",
                column: "wot_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_developer_availability",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_developer_knowledge",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_developer_working_time",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_availability",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_knowledge",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_developer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_working_time",
                schema: "dbo");
        }
    }
}

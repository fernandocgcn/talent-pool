using Microsoft.EntityFrameworkCore.Migrations;

namespace TPData.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_availability",
                keyColumn: "ava_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_availability",
                keyColumn: "ava_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_availability",
                keyColumn: "ava_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_availability",
                keyColumn: "ava_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_availability",
                keyColumn: "ava_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_knowledge",
                keyColumn: "kno_id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_working_time",
                keyColumn: "wot_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_working_time",
                keyColumn: "wot_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_working_time",
                keyColumn: "wot_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_working_time",
                keyColumn: "wot_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_working_time",
                keyColumn: "wot_id",
                keyValue: 5);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizSPA_With_Identity.Data.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HighScores",
                columns: new[] { "Id", "Score", "UserName" },
                values: new object[,]
                {
                    { 1, 1000, "The Literal God of Quiz" },
                    { 2, 0, "50 monkeys on a typewriter" },
                    { 3, 1, "Donald Trump" },
                    { 4, 3, "Cat walked on keyboard" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "What greek god carries a trident, and stirs up hurricanes when he gets grumpy?" },
                    { 2, "What is Hephaestus known for?" },
                    { 3, "Of what is Nemesis the godess of?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, false, 1, "Zeus" },
                    { 2, false, 1, "Hephaestus" },
                    { 3, true, 1, "Poseidon" },
                    { 4, false, 1, "Apollo" },
                    { 5, true, 2, "Making cool stuff in a volcano" },
                    { 6, false, 2, "Flying" },
                    { 7, false, 2, "Slaying mythical creatures" },
                    { 8, false, 2, "Running really fast" },
                    { 9, false, 3, "Mythical creatures" },
                    { 10, false, 3, "Lightning" },
                    { 11, false, 3, "Bad harvests" },
                    { 12, true, 3, "Revenge" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "HighScores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HighScores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HighScores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HighScores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace h23final_serveur.Migrations
{
    public partial class Question4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e8b746a6-e123-45ee-a5e0-90b684a513e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3469821-db4d-4a77-985c-b982a6077a11", "AQAAAAEAACcQAAAAEAL5sN6lwMjom6/jwz49mbHgcGQVsqunEeNzWW6+/iH8mPGHFNZGTUKskRrHffpf9g==", "45f10295-29cf-4b93-a880-eec00611cf0a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78f9608e-1bdb-4b04-b4b3-551e2185b523", "AQAAAAEAACcQAAAAEIJFGMvBKxxvL+EA0zu3+MDosh2uGa/yo3y4YH9mF5phNwe6uTtaC4QXTWhMfzd1sQ==", "7f1c2b21-cbd4-4b2a-b6a7-ee986396cc2a" });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "Id", "ChannelId", "SentAt", "Text", "UserId" },
                values: new object[] { 6, 3, new DateTime(2023, 6, 12, 17, 42, 5, 0, DateTimeKind.Unspecified), "eske qqun peut me donner les réponses de l’examen svp ?", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "Id", "FileName", "MessageId", "MimeType", "Quantity" },
                values: new object[] { 3, "eggplant.png", 6, "image/png", 1 });

            migrationBuilder.InsertData(
                table: "ReactionUser",
                columns: new[] { "ReactionsId", "UsersId" },
                values: new object[] { 3, "11111111-1111-1111-1111-111111111111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReactionUser",
                keyColumns: new[] { "ReactionsId", "UsersId" },
                keyValues: new object[] { 3, "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "dff44e91-a3e2-4040-91fc-0f0434e45e19");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bb9ff4d-bbbe-489e-bc86-9b7272d0ac32", "AQAAAAEAACcQAAAAENTw27ceMxuDsaCfdPLKBsyvGlQTDwOR2dz1ujzn45kxFC2lf1hyTDy1p4RsHNxgRg==", "92e2ca66-6672-430a-8543-1b6282d2fd02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7380fb66-a50c-44a9-88bf-d4381fce3ad9", "AQAAAAEAACcQAAAAEOrt2WKzR1XNP3cjiX/xQTrWe6oi4qSQxzf+cLJnah+zVE00TAn6IuSohiwxGi4m0w==", "52a6a83f-e604-4314-8383-ba9cc175baf5" });
        }
    }
}

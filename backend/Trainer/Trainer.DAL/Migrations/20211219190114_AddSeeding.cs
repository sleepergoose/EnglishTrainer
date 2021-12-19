using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.DAL.Migrations
{
    public partial class AddSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PvExamples_PhrasalVerbs_PhrasalVerbId",
                table: "PvExamples");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Users_AuthorId",
                table: "Track");

            migrationBuilder.DropForeignKey(
                name: "FK_WordExamples_Words_WordId",
                table: "WordExamples");

            migrationBuilder.AlterColumn<int>(
                name: "WordId",
                table: "WordExamples",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhrasalVerbId",
                table: "PvExamples",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "PhrasalVerbs",
                columns: new[] { "Id", "CreatedAt", "Text", "Translation" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 214, DateTimeKind.Unspecified).AddTicks(2199), new TimeSpan(0, 2, 0, 0, 0)), "bring up", "упоминать, заводить разговор об" },
                    { 2, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 214, DateTimeKind.Unspecified).AddTicks(2255), new TimeSpan(0, 2, 0, 0, 0)), "call off", "отменять, отменить" },
                    { 3, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 214, DateTimeKind.Unspecified).AddTicks(2260), new TimeSpan(0, 2, 0, 0, 0)), "work out", "придумать что-нибудь" },
                    { 4, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 214, DateTimeKind.Unspecified).AddTicks(2262), new TimeSpan(0, 2, 0, 0, 0)), "hold up", "задерживать" },
                    { 5, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 214, DateTimeKind.Unspecified).AddTicks(2265), new TimeSpan(0, 2, 0, 0, 0)), "take it out on", "вызвериться на" },
                    { 6, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 214, DateTimeKind.Unspecified).AddTicks(2271), new TimeSpan(0, 2, 0, 0, 0)), "stick up for", "встать на защиту" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirebaseId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 216, DateTimeKind.Unspecified).AddTicks(2572), new TimeSpan(0, 2, 0, 0, 0)), "peter@server.com", null, "Peter" },
                    { 2, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 216, DateTimeKind.Unspecified).AddTicks(2622), new TimeSpan(0, 2, 0, 0, 0)), "nick@server.com", null, "Nick" },
                    { 3, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 216, DateTimeKind.Unspecified).AddTicks(2626), new TimeSpan(0, 2, 0, 0, 0)), "jane@server.com", null, "Jane" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "CreatedAt", "Text", "Transcription", "Translation" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 205, DateTimeKind.Unspecified).AddTicks(6984), new TimeSpan(0, 2, 0, 0, 0)), "name", "naim", "имя" },
                    { 2, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 212, DateTimeKind.Unspecified).AddTicks(1245), new TimeSpan(0, 2, 0, 0, 0)), "old", "old", "имя" },
                    { 3, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 212, DateTimeKind.Unspecified).AddTicks(1298), new TimeSpan(0, 2, 0, 0, 0)), "work", "work", "работать" },
                    { 4, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 212, DateTimeKind.Unspecified).AddTicks(1303), new TimeSpan(0, 2, 0, 0, 0)), "hope", "heup", "надежда" },
                    { 5, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 212, DateTimeKind.Unspecified).AddTicks(1306), new TimeSpan(0, 2, 0, 0, 0)), "convey", "konvei", "передавать" },
                    { 6, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 212, DateTimeKind.Unspecified).AddTicks(1314), new TimeSpan(0, 2, 0, 0, 0)), "gather", "gather", "собирать" }
                });

            migrationBuilder.InsertData(
                table: "PvExamples",
                columns: new[] { "Id", "CreatedAt", "PhrasalVerbId", "Phrase", "Translation" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 215, DateTimeKind.Unspecified).AddTicks(84), new TimeSpan(0, 2, 0, 0, 0)), 1, "Why did you bring it up?", "Почему ты заговорил об этом" },
                    { 2, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 215, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 2, 0, 0, 0)), 1, "Don't even try to bring it up!", "Даже не пытайся сказать это!" },
                    { 3, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 215, DateTimeKind.Unspecified).AddTicks(145), new TimeSpan(0, 2, 0, 0, 0)), 2, "I had to call the meeting off", "Я должен был отменить встречу" },
                    { 4, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 215, DateTimeKind.Unspecified).AddTicks(148), new TimeSpan(0, 2, 0, 0, 0)), 2, "We should to call off the festival", "Нам стоит отменить фестиваль" },
                    { 5, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 215, DateTimeKind.Unspecified).AddTicks(151), new TimeSpan(0, 2, 0, 0, 0)), 4, "We were held up yesterday till five p.m.", "Нас задержали вчера до 5 вечера" },
                    { 6, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 215, DateTimeKind.Unspecified).AddTicks(157), new TimeSpan(0, 2, 0, 0, 0)), 4, "My boss held me up today", "Мой босс задержал меня сегодня" }
                });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Description", "Discriminator", "Level" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 216, DateTimeKind.Unspecified).AddTicks(8278), new TimeSpan(0, 2, 0, 0, 0)), "My first track", "WordTrack", 0 });

            migrationBuilder.InsertData(
                table: "WordExamples",
                columns: new[] { "Id", "CreatedAt", "Phrase", "Translation", "WordId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 215, DateTimeKind.Unspecified).AddTicks(6968), new TimeSpan(0, 2, 0, 0, 0)), "My name is John", "Меня зовут Джон", 1 },
                    { 2, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 215, DateTimeKind.Unspecified).AddTicks(7024), new TimeSpan(0, 2, 0, 0, 0)), "Her name is Jane", "Ее зовут Джейн", 1 },
                    { 3, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 215, DateTimeKind.Unspecified).AddTicks(7028), new TimeSpan(0, 2, 0, 0, 0)), "What's your name?", "Как тебя зовут?", 1 },
                    { 4, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 215, DateTimeKind.Unspecified).AddTicks(7030), new TimeSpan(0, 2, 0, 0, 0)), "He has an old car", "У него есть старая машина", 2 },
                    { 5, new DateTimeOffset(new DateTime(2021, 12, 19, 21, 1, 13, 215, DateTimeKind.Unspecified).AddTicks(7033), new TimeSpan(0, 2, 0, 0, 0)), "She was really old", "Она была очень старая", 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PvExamples_PhrasalVerbs_PhrasalVerbId",
                table: "PvExamples",
                column: "PhrasalVerbId",
                principalTable: "PhrasalVerbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Users_AuthorId",
                table: "Track",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordExamples_Words_WordId",
                table: "WordExamples",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PvExamples_PhrasalVerbs_PhrasalVerbId",
                table: "PvExamples");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Users_AuthorId",
                table: "Track");

            migrationBuilder.DropForeignKey(
                name: "FK_WordExamples_Words_WordId",
                table: "WordExamples");

            migrationBuilder.DeleteData(
                table: "PhrasalVerbs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhrasalVerbs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PhrasalVerbs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PvExamples",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PvExamples",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PvExamples",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PvExamples",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PvExamples",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PvExamples",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WordExamples",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WordExamples",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WordExamples",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WordExamples",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WordExamples",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PhrasalVerbs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhrasalVerbs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhrasalVerbs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "WordId",
                table: "WordExamples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Track",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PhrasalVerbId",
                table: "PvExamples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PvExamples_PhrasalVerbs_PhrasalVerbId",
                table: "PvExamples",
                column: "PhrasalVerbId",
                principalTable: "PhrasalVerbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Users_AuthorId",
                table: "Track",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WordExamples_Words_WordId",
                table: "WordExamples",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

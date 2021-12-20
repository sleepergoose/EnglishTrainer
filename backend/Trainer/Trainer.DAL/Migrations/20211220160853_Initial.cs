using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhrasalVerbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhrasalVerbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FirebaseId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Transcription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Translation = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PvExamples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhrasalVerbId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Phrase = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PvExamples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PvExamples_PhrasalVerbs_PhrasalVerbId",
                        column: x => x.PhrasalVerbId,
                        principalTable: "PhrasalVerbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PvTracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PvTracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PvTracks_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordTracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordTracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordTracks_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordExamples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Phrase = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordExamples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordExamples_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PvToTracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhrasalVerbId = table.Column<int>(type: "int", nullable: false),
                    PvTrackId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PvToTracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PvToTracks_PhrasalVerbs_PhrasalVerbId",
                        column: x => x.PhrasalVerbId,
                        principalTable: "PhrasalVerbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PvToTracks_PvTracks_PvTrackId",
                        column: x => x.PvTrackId,
                        principalTable: "PvTracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordToTracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    WordTrackId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordToTracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordToTracks_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordToTracks_WordTracks_WordTrackId",
                        column: x => x.WordTrackId,
                        principalTable: "WordTracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PhrasalVerbs",
                columns: new[] { "Id", "CreatedAt", "Text", "Translation" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 380, DateTimeKind.Unspecified).AddTicks(2502), new TimeSpan(0, 2, 0, 0, 0)), "bring up", "упоминать, заводить разговор об" },
                    { 2, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 380, DateTimeKind.Unspecified).AddTicks(2558), new TimeSpan(0, 2, 0, 0, 0)), "call off", "отменять, отменить" },
                    { 3, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 380, DateTimeKind.Unspecified).AddTicks(2562), new TimeSpan(0, 2, 0, 0, 0)), "work out", "придумать что-нибудь" },
                    { 4, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 380, DateTimeKind.Unspecified).AddTicks(2565), new TimeSpan(0, 2, 0, 0, 0)), "hold up", "задерживать" },
                    { 5, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 380, DateTimeKind.Unspecified).AddTicks(2568), new TimeSpan(0, 2, 0, 0, 0)), "take it out on", "вызвериться на" },
                    { 6, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 380, DateTimeKind.Unspecified).AddTicks(2574), new TimeSpan(0, 2, 0, 0, 0)), "stick up for", "встать на защиту" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirebaseId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 382, DateTimeKind.Unspecified).AddTicks(1968), new TimeSpan(0, 2, 0, 0, 0)), "peter@server.com", null, "Peter" },
                    { 2, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 382, DateTimeKind.Unspecified).AddTicks(2018), new TimeSpan(0, 2, 0, 0, 0)), "nick@server.com", null, "Nick" },
                    { 3, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 382, DateTimeKind.Unspecified).AddTicks(2021), new TimeSpan(0, 2, 0, 0, 0)), "jane@server.com", null, "Jane" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "CreatedAt", "Text", "Transcription", "Translation" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 374, DateTimeKind.Unspecified).AddTicks(7842), new TimeSpan(0, 2, 0, 0, 0)), "name", "naim", "имя" },
                    { 2, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 378, DateTimeKind.Unspecified).AddTicks(2585), new TimeSpan(0, 2, 0, 0, 0)), "old", "old", "имя" },
                    { 3, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 378, DateTimeKind.Unspecified).AddTicks(2628), new TimeSpan(0, 2, 0, 0, 0)), "work", "work", "работать" },
                    { 4, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 378, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 2, 0, 0, 0)), "hope", "heup", "надежда" },
                    { 5, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 378, DateTimeKind.Unspecified).AddTicks(2635), new TimeSpan(0, 2, 0, 0, 0)), "convey", "konvei", "передавать" },
                    { 6, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 378, DateTimeKind.Unspecified).AddTicks(2643), new TimeSpan(0, 2, 0, 0, 0)), "gather", "gather", "собирать" }
                });

            migrationBuilder.InsertData(
                table: "PvExamples",
                columns: new[] { "Id", "CreatedAt", "PhrasalVerbId", "Phrase", "Translation" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 381, DateTimeKind.Unspecified).AddTicks(290), new TimeSpan(0, 2, 0, 0, 0)), 1, "Why did you bring it up?", "Почему ты заговорил об этом" },
                    { 2, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 381, DateTimeKind.Unspecified).AddTicks(339), new TimeSpan(0, 2, 0, 0, 0)), 1, "Don't even try to bring it up!", "Даже не пытайся сказать это!" },
                    { 3, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 381, DateTimeKind.Unspecified).AddTicks(343), new TimeSpan(0, 2, 0, 0, 0)), 2, "I had to call the meeting off", "Я должен был отменить встречу" },
                    { 4, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 381, DateTimeKind.Unspecified).AddTicks(346), new TimeSpan(0, 2, 0, 0, 0)), 2, "We should to call off the festival", "Нам стоит отменить фестиваль" },
                    { 5, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 381, DateTimeKind.Unspecified).AddTicks(348), new TimeSpan(0, 2, 0, 0, 0)), 4, "We were held up yesterday till five p.m.", "Нас задержали вчера до 5 вечера" },
                    { 6, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 381, DateTimeKind.Unspecified).AddTicks(355), new TimeSpan(0, 2, 0, 0, 0)), 4, "My boss held me up today", "Мой босс задержал меня сегодня" }
                });

            migrationBuilder.InsertData(
                table: "WordExamples",
                columns: new[] { "Id", "CreatedAt", "Phrase", "Translation", "WordId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 381, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 2, 0, 0, 0)), "My name is John", "Меня зовут Джон", 1 },
                    { 2, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 381, DateTimeKind.Unspecified).AddTicks(6086), new TimeSpan(0, 2, 0, 0, 0)), "Her name is Jane", "Ее зовут Джейн", 1 },
                    { 3, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 381, DateTimeKind.Unspecified).AddTicks(6091), new TimeSpan(0, 2, 0, 0, 0)), "What's your name?", "Как тебя зовут?", 1 },
                    { 4, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 381, DateTimeKind.Unspecified).AddTicks(6093), new TimeSpan(0, 2, 0, 0, 0)), "He has an old car", "У него есть старая машина", 2 },
                    { 5, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 381, DateTimeKind.Unspecified).AddTicks(6096), new TimeSpan(0, 2, 0, 0, 0)), "She was really old", "Она была очень старая", 2 }
                });

            migrationBuilder.InsertData(
                table: "WordTracks",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Description", "Level", "Name" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2021, 12, 20, 18, 8, 52, 382, DateTimeKind.Unspecified).AddTicks(7706), new TimeSpan(0, 2, 0, 0, 0)), "My first track", 0, "100 most important words" });

            migrationBuilder.CreateIndex(
                name: "IX_PvExamples_PhrasalVerbId",
                table: "PvExamples",
                column: "PhrasalVerbId");

            migrationBuilder.CreateIndex(
                name: "IX_PvToTracks_PhrasalVerbId",
                table: "PvToTracks",
                column: "PhrasalVerbId");

            migrationBuilder.CreateIndex(
                name: "IX_PvToTracks_PvTrackId",
                table: "PvToTracks",
                column: "PvTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_PvTracks_AuthorId",
                table: "PvTracks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_WordExamples_WordId",
                table: "WordExamples",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordToTracks_WordId",
                table: "WordToTracks",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordToTracks_WordTrackId",
                table: "WordToTracks",
                column: "WordTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_WordTracks_AuthorId",
                table: "WordTracks",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PvExamples");

            migrationBuilder.DropTable(
                name: "PvToTracks");

            migrationBuilder.DropTable(
                name: "WordExamples");

            migrationBuilder.DropTable(
                name: "WordToTracks");

            migrationBuilder.DropTable(
                name: "PhrasalVerbs");

            migrationBuilder.DropTable(
                name: "PvTracks");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "WordTracks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchEngineKeywordTracker.DataAccessLayer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchEngines",
                columns: table => new
                {
                    SearchEngineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchEngineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchEngines", x => x.SearchEngineId);
                });

            migrationBuilder.CreateTable(
                name: "SearchEngineSearches",
                columns: table => new
                {
                    SearchEngineSearchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keyword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SearchEngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchEngineSearches", x => x.SearchEngineSearchId);
                    table.ForeignKey(
                        name: "FK_SearchEngineSearches_SearchEngines_SearchEngineId",
                        column: x => x.SearchEngineId,
                        principalTable: "SearchEngines",
                        principalColumn: "SearchEngineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SearchEngineSearchPositions",
                columns: table => new
                {
                    SearchEngineSearchPositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchEngineSearchId = table.Column<int>(type: "int", nullable: false),
                    PositionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchEngineSearchPositions", x => x.SearchEngineSearchPositionId);
                    table.ForeignKey(
                        name: "FK_SearchEngineSearchPositions_SearchEngineSearches_SearchEngineSearchId",
                        column: x => x.SearchEngineSearchId,
                        principalTable: "SearchEngineSearches",
                        principalColumn: "SearchEngineSearchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchEngineSearches_SearchEngineId",
                table: "SearchEngineSearches",
                column: "SearchEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchEngineSearchPositions_SearchEngineSearchId",
                table: "SearchEngineSearchPositions",
                column: "SearchEngineSearchId");

            migrationBuilder.Sql(@"
                USE [KeywordTrackerDB]
                GO
                SET IDENTITY_INSERT [dbo].[SearchEngines] ON
                GO
		        INSERT [dbo].[SearchEngines] ([SearchEngineId], [SearchEngineName], [SearchUrl]) VALUES (1, N'Google', N'https://www.google.co.uk/search?q=')
                GO
                SET IDENTITY_INSERT [dbo].[SearchEngines] OFF
                GO
                SET IDENTITY_INSERT [dbo].[SearchEngineSearches] ON 
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (10, N'land registry search', N'www.infotrack.co.uk', CAST(N'2022-07-04T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (11, N'land registry search', N'www.infotrack.co.uk', CAST(N'2022-07-03T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (12, N'land registry search', N'www.infotrack.co.uk', CAST(N'2022-07-02T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (13, N'land registry search', N'www.infotrack.co.uk', CAST(N'2022-07-01T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (14, N'land registry search', N'www.infotrack.co.uk', CAST(N'2022-06-30T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (15, N'land registry search', N'www.infotrack.co.uk', CAST(N'2022-06-29T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (16, N'land registry search', N'www.infotrack.co.uk', CAST(N'2022-06-28T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (17, N'land registry search', N'www.infotrack.co.uk', CAST(N'2022-06-27T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (18, N'land registry', N'www.infotrack.co.uk', CAST(N'2022-07-04T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (19, N'land registry', N'www.infotrack.co.uk', CAST(N'2022-07-03T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (20, N'land registry', N'www.infotrack.co.uk', CAST(N'2022-07-02T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (21, N'land registry', N'www.infotrack.co.uk', CAST(N'2022-07-01T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (22, N'land registry', N'www.infotrack.co.uk', CAST(N'2022-06-30T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (23, N'land registry', N'www.infotrack.co.uk', CAST(N'2022-06-29T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (24, N'land registry', N'www.infotrack.co.uk', CAST(N'2022-06-28T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (25, N'land registry', N'www.infotrack.co.uk', CAST(N'2022-06-27T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (26, N'land registry search', N'gov.uk', CAST(N'2022-07-04T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (27, N'land registry search', N'gov.uk', CAST(N'2022-07-03T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (28, N'land registry search', N'gov.uk', CAST(N'2022-07-02T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (29, N'land registry search', N'gov.uk', CAST(N'2022-07-01T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (30, N'land registry search', N'gov.uk', CAST(N'2022-06-30T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (31, N'land registry search', N'gov.uk', CAST(N'2022-06-29T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (32, N'land registry search', N'gov.uk', CAST(N'2022-06-28T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (33, N'land registry search', N'gov.uk', CAST(N'2022-06-27T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (34, N'land registry', N'gov.uk', CAST(N'2022-07-04T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (35, N'land registry', N'gov.uk', CAST(N'2022-07-03T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (36, N'land registry', N'gov.uk', CAST(N'2022-07-02T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (37, N'land registry', N'gov.uk', CAST(N'2022-07-01T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (38, N'land registry', N'gov.uk', CAST(N'2022-06-30T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (39, N'land registry', N'gov.uk', CAST(N'2022-06-29T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (40, N'land registry', N'gov.uk', CAST(N'2022-06-28T00:00:00.000' AS DateTime), 1)
                GO
                INSERT [dbo].[SearchEngineSearches] ([SearchEngineSearchId], [Keyword], [Url], [SearchDateTime], [SearchEngineId]) VALUES (41, N'land registry', N'gov.uk', CAST(N'2022-06-27T00:00:00.000' AS DateTime), 1)
                GO
                SET IDENTITY_INSERT [dbo].[SearchEngineSearches] OFF
                GO
                SET IDENTITY_INSERT [dbo].[SearchEngineSearchPositions] ON 
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (30, 10, 11)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (31, 11, 13)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (32, 12, 16)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (33, 13, 15)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (34, 14, 19)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (35, 15, 28)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (36, 16, 15)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (37, 17, 24)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (38, 18, 28)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (39, 19, 22)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (40, 20, 26)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (41, 21, 27)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (42, 22, 25)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (43, 23, 24)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (44, 24, 27)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (45, 25, 26)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (46, 26, 1)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (47, 27, 2)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (48, 28, 1)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (49, 29, 1)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (50, 30, 1)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (51, 31, 2)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (52, 32, 2)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (53, 33, 1)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (54, 34, 3)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (55, 35, 1)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (56, 36, 1)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (57, 37, 1)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (58, 38, 3)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (59, 39, 1)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (60, 40, 1)
                GO
                INSERT [dbo].[SearchEngineSearchPositions] ([SearchEngineSearchPositionId], [SearchEngineSearchId], [PositionNumber]) VALUES (61, 41, 2)
                GO
                SET IDENTITY_INSERT [dbo].[SearchEngineSearchPositions] OFF
                GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchEngineSearchPositions");

            migrationBuilder.DropTable(
                name: "SearchEngineSearches");

            migrationBuilder.DropTable(
                name: "SearchEngines");
        }
    }
}

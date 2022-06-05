using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datactx.Migrations
{
    public partial class CMSdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charsets",
                columns: table => new
                {
                    charId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    charName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    charValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charsets", x => x.charId);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    giftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    giftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    giftDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    giftCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.giftId);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    posId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    posName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.posId);
                });

            migrationBuilder.CreateTable(
                name: "ProgramSizes",
                columns: table => new
                {
                    psId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    psName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    psDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramSizes", x => x.psId);
                });

            migrationBuilder.CreateTable(
                name: "RepeatSchedules",
                columns: table => new
                {
                    repeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    repeatName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepeatSchedules", x => x.repeatId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userEmail = table.Column<string>(type: "varchar(50)", nullable: false),
                    userPassword = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    camId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    camName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    camAutoUpdate = table.Column<bool>(type: "bit", nullable: false),
                    camJoinOnlyOne = table.Column<bool>(type: "bit", nullable: false),
                    ApplyAllCampaign = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    camCodeUsageLimit = table.Column<int>(type: "int", nullable: false),
                    camUnlimited = table.Column<bool>(type: "bit", nullable: false),
                    camCodeCount = table.Column<int>(type: "int", nullable: false),
                    charId = table.Column<int>(type: "int", nullable: false),
                    camCodeLength = table.Column<int>(type: "int", nullable: false),
                    camPrefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    camPostfix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    camStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    camEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    camStartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    camEndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    psId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.camId);
                    table.ForeignKey(
                        name: "FK_Campaigns_Charsets_charId",
                        column: x => x.charId,
                        principalTable: "Charsets",
                        principalColumn: "charId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaigns_ProgramSizes_psId",
                        column: x => x.psId,
                        principalTable: "ProgramSizes",
                        principalColumn: "psId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    cusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cusPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cusAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cusDoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cusStatus = table.Column<bool>(type: "bit", nullable: false),
                    posId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.cusId);
                    table.ForeignKey(
                        name: "FK_Customers_Positions_posId",
                        column: x => x.posId,
                        principalTable: "Positions",
                        principalColumn: "posId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignCodes",
                columns: table => new
                {
                    ccId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ccCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ccCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    camId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignCodes", x => x.ccId);
                    table.ForeignKey(
                        name: "FK_CampaignCodes_Campaigns_camId",
                        column: x => x.camId,
                        principalTable: "Campaigns",
                        principalColumn: "camId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampGifts",
                columns: table => new
                {
                    cgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cgGiftCodeCount = table.Column<int>(type: "int", nullable: false),
                    camId = table.Column<int>(type: "int", nullable: false),
                    giftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampGifts", x => x.cgId);
                    table.ForeignKey(
                        name: "FK_CampGifts_Campaigns_camId",
                        column: x => x.camId,
                        principalTable: "Campaigns",
                        principalColumn: "camId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampGifts_Gifts_giftId",
                        column: x => x.giftId,
                        principalTable: "Gifts",
                        principalColumn: "giftId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScannedOrSpins",
                columns: table => new
                {
                    sosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scannedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    spinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ccId = table.Column<int>(type: "int", nullable: false),
                    cusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedOrSpins", x => x.sosId);
                    table.ForeignKey(
                        name: "FK_ScannedOrSpins_CampaignCodes_ccId",
                        column: x => x.ccId,
                        principalTable: "CampaignCodes",
                        principalColumn: "ccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScannedOrSpins_Customers_cusId",
                        column: x => x.cusId,
                        principalTable: "Customers",
                        principalColumn: "cusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignCodeGifts",
                columns: table => new
                {
                    cgcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cgcCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cgcCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cgcActive = table.Column<bool>(type: "bit", nullable: false),
                    cgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignCodeGifts", x => x.cgcId);
                    table.ForeignKey(
                        name: "FK_CampaignCodeGifts_CampGifts_cgId",
                        column: x => x.cgId,
                        principalTable: "CampGifts",
                        principalColumn: "cgId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulesforgifts",
                columns: table => new
                {
                    ruleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ruleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ruleGiftCount = table.Column<int>(type: "int", nullable: false),
                    ruleStartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ruleEndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ruleAllDay = table.Column<bool>(type: "bit", nullable: false),
                    ruleProbability = table.Column<int>(type: "int", nullable: false),
                    ruleScheduleValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    repeatId = table.Column<int>(type: "int", nullable: false),
                    cgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulesforgifts", x => x.ruleId);
                    table.ForeignKey(
                        name: "FK_Rulesforgifts_CampGifts_cgId",
                        column: x => x.cgId,
                        principalTable: "CampGifts",
                        principalColumn: "cgId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rulesforgifts_RepeatSchedules_repeatId",
                        column: x => x.repeatId,
                        principalTable: "RepeatSchedules",
                        principalColumn: "repeatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Winners",
                columns: table => new
                {
                    winId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    winSentGift = table.Column<bool>(type: "bit", nullable: false),
                    winAddressReceivedGift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cgcId = table.Column<int>(type: "int", nullable: false),
                    cusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winners", x => x.winId);
                    table.ForeignKey(
                        name: "FK_Winners_CampaignCodeGifts_cgcId",
                        column: x => x.cgcId,
                        principalTable: "CampaignCodeGifts",
                        principalColumn: "cgcId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Winners_Customers_cusId",
                        column: x => x.cusId,
                        principalTable: "Customers",
                        principalColumn: "cusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignCodeGifts_cgId",
                table: "CampaignCodeGifts",
                column: "cgId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignCodes_camId",
                table: "CampaignCodes",
                column: "camId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_charId",
                table: "Campaigns",
                column: "charId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_psId",
                table: "Campaigns",
                column: "psId");

            migrationBuilder.CreateIndex(
                name: "IX_CampGifts_camId",
                table: "CampGifts",
                column: "camId");

            migrationBuilder.CreateIndex(
                name: "IX_CampGifts_giftId",
                table: "CampGifts",
                column: "giftId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_posId",
                table: "Customers",
                column: "posId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_userId",
                table: "Customers",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Rulesforgifts_cgId",
                table: "Rulesforgifts",
                column: "cgId");

            migrationBuilder.CreateIndex(
                name: "IX_Rulesforgifts_repeatId",
                table: "Rulesforgifts",
                column: "repeatId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedOrSpins_ccId",
                table: "ScannedOrSpins",
                column: "ccId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedOrSpins_cusId",
                table: "ScannedOrSpins",
                column: "cusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userEmail",
                table: "Users",
                column: "userEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Winners_cgcId",
                table: "Winners",
                column: "cgcId");

            migrationBuilder.CreateIndex(
                name: "IX_Winners_cusId",
                table: "Winners",
                column: "cusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rulesforgifts");

            migrationBuilder.DropTable(
                name: "ScannedOrSpins");

            migrationBuilder.DropTable(
                name: "Winners");

            migrationBuilder.DropTable(
                name: "RepeatSchedules");

            migrationBuilder.DropTable(
                name: "CampaignCodes");

            migrationBuilder.DropTable(
                name: "CampaignCodeGifts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CampGifts");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Charsets");

            migrationBuilder.DropTable(
                name: "ProgramSizes");
        }
    }
}

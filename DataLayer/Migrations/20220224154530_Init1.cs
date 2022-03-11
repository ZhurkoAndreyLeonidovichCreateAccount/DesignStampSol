using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AvatarImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bushings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PressedDiametr = table.Column<int>(nullable: false),
                    FlangeDiametr = table.Column<int>(nullable: false),
                    ColumnDiametr = table.Column<int>(nullable: false),
                    TotalHeight = table.Column<int>(nullable: false),
                    DepthHeight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bushings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Diametr = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    HeightDepth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TotalHeight = table.Column<int>(nullable: false),
                    PressHeight = table.Column<int>(nullable: false),
                    Diametr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Thickness = table.Column<int>(nullable: false),
                    ShearingStress = table.Column<int>(nullable: false),
                    AmountDiametrHoles = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "EnlargedPunches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DiametrHoleFirst = table.Column<int>(nullable: false),
                    DiametrHoleLast = table.Column<int>(nullable: false),
                    DiametrSeat = table.Column<int>(nullable: false),
                    DiametrFlange = table.Column<int>(nullable: false),
                    HeightTottal = table.Column<int>(nullable: false),
                    HeighSeat = table.Column<int>(nullable: false),
                    HeighFlange = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnlargedPunches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pressess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Ppress = table.Column<int>(nullable: false),
                    PressRamStroke = table.Column<int>(nullable: false),
                    LengthAdapt = table.Column<int>(nullable: false),
                    WidthAdapt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pressess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Punches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DiametrHole = table.Column<int>(nullable: false),
                    DiametrSeat = table.Column<int>(nullable: false),
                    DiametrFlange = table.Column<int>(nullable: false),
                    HeightTottal = table.Column<int>(nullable: false),
                    HeighSeat = table.Column<int>(nullable: false),
                    HeighFlange = table.Column<int>(nullable: false),
                    HeightHole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Springs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Pspring = table.Column<double>(nullable: false),
                    Diametr = table.Column<int>(nullable: false),
                    Tmin = table.Column<int>(nullable: false),
                    Tmax = table.Column<int>(nullable: false),
                    Stroke = table.Column<int>(nullable: false),
                    LengthScrew = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Springs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DifferHoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountHole = table.Column<int>(nullable: false),
                    Diametr = table.Column<int>(nullable: false),
                    detailName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifferHoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DifferHoles_Details_detailName",
                        column: x => x.detailName,
                        principalTable: "Details",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stamps",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    ClosedHeight = table.Column<int>(nullable: false),
                    detailName = table.Column<string>(nullable: true),
                    BushingId = table.Column<int>(nullable: false),
                    ColumnId = table.Column<int>(nullable: false),
                    SpringId = table.Column<int>(nullable: false),
                    CoverId = table.Column<int>(nullable: false),
                    PressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stamps", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Stamps_Bushings_BushingId",
                        column: x => x.BushingId,
                        principalTable: "Bushings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stamps_Columns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Columns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stamps_Covers_CoverId",
                        column: x => x.CoverId,
                        principalTable: "Covers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stamps_Pressess_PressId",
                        column: x => x.PressId,
                        principalTable: "Pressess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stamps_Springs_SpringId",
                        column: x => x.SpringId,
                        principalTable: "Springs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stamps_Details_detailName",
                        column: x => x.detailName,
                        principalTable: "Details",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllForces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pfelling = table.Column<double>(nullable: false),
                    Ppunching = table.Column<double>(nullable: false),
                    StampName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllForces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllForces_Stamps_StampName",
                        column: x => x.StampName,
                        principalTable: "Stamps",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BottomPlates",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    TotalLength = table.Column<double>(nullable: false),
                    СastLength = table.Column<double>(nullable: false),
                    СastWidth = table.Column<double>(nullable: false),
                    СastHeight = table.Column<double>(nullable: false),
                    TotalWidth = table.Column<double>(nullable: false),
                    SfelfWidth = table.Column<double>(nullable: false),
                    SfelfHeight = table.Column<double>(nullable: false),
                    Hieght = table.Column<double>(nullable: false),
                    StampName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BottomPlates", x => x.Name);
                    table.ForeignKey(
                        name: "FK_BottomPlates_Stamps_StampName",
                        column: x => x.StampName,
                        principalTable: "Stamps",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnlargedPunchesID",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StampName = table.Column<string>(nullable: true),
                    EnlargedPunchID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnlargedPunchesID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnlargedPunchesID_EnlargedPunches_EnlargedPunchID",
                        column: x => x.EnlargedPunchID,
                        principalTable: "EnlargedPunches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnlargedPunchesID_Stamps_StampName",
                        column: x => x.StampName,
                        principalTable: "Stamps",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Holders",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    TotalHieght = table.Column<double>(nullable: false),
                    BodyHieght = table.Column<double>(nullable: false),
                    StampName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holders", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Holders_Stamps_StampName",
                        column: x => x.StampName,
                        principalTable: "Stamps",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matrices",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Hieght = table.Column<double>(nullable: false),
                    StampName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matrices", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Matrices_Stamps_StampName",
                        column: x => x.StampName,
                        principalTable: "Stamps",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pullers",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Hieght = table.Column<double>(nullable: false),
                    StampName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pullers", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Pullers_Stamps_StampName",
                        column: x => x.StampName,
                        principalTable: "Stamps",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PunchesID",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StampName = table.Column<string>(nullable: true),
                    PunchID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunchesID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PunchesID_Punches_PunchID",
                        column: x => x.PunchID,
                        principalTable: "Punches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PunchesID_Stamps_StampName",
                        column: x => x.StampName,
                        principalTable: "Stamps",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PunchMatrices",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Hieght = table.Column<int>(nullable: false),
                    FlangeHieght = table.Column<int>(nullable: false),
                    FlangeWidth = table.Column<int>(nullable: false),
                    StampName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunchMatrices", x => x.Name);
                    table.ForeignKey(
                        name: "FK_PunchMatrices_Stamps_StampName",
                        column: x => x.StampName,
                        principalTable: "Stamps",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopPlates",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    TotalLength = table.Column<double>(nullable: false),
                    СastLength = table.Column<double>(nullable: false),
                    СastWidth = table.Column<double>(nullable: false),
                    СastHeight = table.Column<double>(nullable: false),
                    TotalWidth = table.Column<double>(nullable: false),
                    Hieght = table.Column<double>(nullable: false),
                    SfelfWidth = table.Column<double>(nullable: false),
                    SfelfHeight = table.Column<double>(nullable: false),
                    StampName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopPlates", x => x.Name);
                    table.ForeignKey(
                        name: "FK_TopPlates_Stamps_StampName",
                        column: x => x.StampName,
                        principalTable: "Stamps",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllForces_StampName",
                table: "AllForces",
                column: "StampName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BottomPlates_StampName",
                table: "BottomPlates",
                column: "StampName");

            migrationBuilder.CreateIndex(
                name: "IX_DifferHoles_detailName",
                table: "DifferHoles",
                column: "detailName");

            migrationBuilder.CreateIndex(
                name: "IX_EnlargedPunchesID_EnlargedPunchID",
                table: "EnlargedPunchesID",
                column: "EnlargedPunchID");

            migrationBuilder.CreateIndex(
                name: "IX_EnlargedPunchesID_StampName",
                table: "EnlargedPunchesID",
                column: "StampName");

            migrationBuilder.CreateIndex(
                name: "IX_Holders_StampName",
                table: "Holders",
                column: "StampName");

            migrationBuilder.CreateIndex(
                name: "IX_Matrices_StampName",
                table: "Matrices",
                column: "StampName");

            migrationBuilder.CreateIndex(
                name: "IX_Pullers_StampName",
                table: "Pullers",
                column: "StampName");

            migrationBuilder.CreateIndex(
                name: "IX_PunchesID_PunchID",
                table: "PunchesID",
                column: "PunchID");

            migrationBuilder.CreateIndex(
                name: "IX_PunchesID_StampName",
                table: "PunchesID",
                column: "StampName");

            migrationBuilder.CreateIndex(
                name: "IX_PunchMatrices_StampName",
                table: "PunchMatrices",
                column: "StampName");

            migrationBuilder.CreateIndex(
                name: "IX_Stamps_BushingId",
                table: "Stamps",
                column: "BushingId");

            migrationBuilder.CreateIndex(
                name: "IX_Stamps_ColumnId",
                table: "Stamps",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Stamps_CoverId",
                table: "Stamps",
                column: "CoverId");

            migrationBuilder.CreateIndex(
                name: "IX_Stamps_PressId",
                table: "Stamps",
                column: "PressId");

            migrationBuilder.CreateIndex(
                name: "IX_Stamps_SpringId",
                table: "Stamps",
                column: "SpringId");

            migrationBuilder.CreateIndex(
                name: "IX_Stamps_detailName",
                table: "Stamps",
                column: "detailName");

            migrationBuilder.CreateIndex(
                name: "IX_TopPlates_StampName",
                table: "TopPlates",
                column: "StampName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllForces");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BottomPlates");

            migrationBuilder.DropTable(
                name: "DifferHoles");

            migrationBuilder.DropTable(
                name: "EnlargedPunchesID");

            migrationBuilder.DropTable(
                name: "Holders");

            migrationBuilder.DropTable(
                name: "Matrices");

            migrationBuilder.DropTable(
                name: "Pullers");

            migrationBuilder.DropTable(
                name: "PunchesID");

            migrationBuilder.DropTable(
                name: "PunchMatrices");

            migrationBuilder.DropTable(
                name: "TopPlates");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EnlargedPunches");

            migrationBuilder.DropTable(
                name: "Punches");

            migrationBuilder.DropTable(
                name: "Stamps");

            migrationBuilder.DropTable(
                name: "Bushings");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropTable(
                name: "Pressess");

            migrationBuilder.DropTable(
                name: "Springs");

            migrationBuilder.DropTable(
                name: "Details");
        }
    }
}

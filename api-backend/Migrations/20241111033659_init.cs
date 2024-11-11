using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => new { x.AppUserId, x.Id });
                    table.UniqueConstraint("AK_Posts_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Comentarios_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comentarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", null, "Admin", "ADMIN" },
                    { "eccf1bde-a0ff-48f2-96c1-8ec39d921791", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "e7dd45ea-7508-4225-806a-e35af5b2d05f", null, false, false, null, null, "Jhonny Mello", "AQAAAAIAAYagAAAAEPxeeKz8TYlBWRjL/1vXUBprjEL4GpExl6iTN7fuLOiP10eWp2IyU6JQrQ9Vxo7z9g==", null, false, "ca5d9254-37be-4805-aa6f-e16c5c26f149", false, "Jhonny" },
                    { "b79228c5-5fdb-4e2e-9ce6-e23dd29b97cc", 0, "a05d2fda-5fd9-4c5e-ad58-2778812cc296", null, false, false, null, null, "Heloyza Morais", "AQAAAAIAAYagAAAAEJ1/E9bLSksBqW/ImgRP/lTOgtYtixbX/7jGBj2joPgucZBwlX/qIdR9kaLXe21+tg==", null, false, "66b94876-6fda-498d-adf6-8867769eaaff", false, "Heloyza" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "AppUserId", "Id", "CreatedOn", "PostContent", "Tema" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3803), "Esta publicação foi adicionada diretamente pelo migration do entity framework", "Apenas um novo tema inserido diretamente do migration pelo meu usuário ADM" });

            migrationBuilder.InsertData(
                table: "Avaliacoes",
                columns: new[] { "Id", "AppUserId", "CommentId", "CreatedOn", "PostId", "Value" },
                values: new object[,]
                {
                    { new Guid("04865829-bb86-4c30-aadd-26964a6b3149"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3912), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 3 },
                    { new Guid("0d7f5774-0c33-461a-9d02-fbf3f45326b1"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3909), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 3 },
                    { new Guid("2ae36c0f-da48-465b-b0ed-2c3cc7cb9417"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3890), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 3 },
                    { new Guid("363dda5b-2d5e-487f-bb86-a047e6de8a6c"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3888), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 4 },
                    { new Guid("40d776cf-838e-43be-a4a3-f4112c78b54a"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4035), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 1 },
                    { new Guid("41baf53a-3103-4b0b-bfee-75f348503ced"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3915), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 2 },
                    { new Guid("42b20ced-c00c-4b0a-9e8b-efa4865aa322"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4043), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 2 },
                    { new Guid("4391f290-96fb-4cb3-8b79-bf45f3e76dd0"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4039), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 3 },
                    { new Guid("515f4da9-9b41-4924-85d5-5478cda7fcde"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4040), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 4 },
                    { new Guid("552c96aa-3141-4848-b60d-c8e0d470f3c6"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4044), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 3 },
                    { new Guid("5ded3879-fa37-46d4-bc79-4e8638f0c812"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3911), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 4 },
                    { new Guid("69bc7ffe-c6bf-4719-9e10-1b77f48abef8"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4045), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 1 },
                    { new Guid("6ab10d86-0062-4ad4-97cd-1de059428710"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4041), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 2 },
                    { new Guid("6f1d9ab3-1859-4b7d-8f47-4aa5ff709d51"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4034), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 2 },
                    { new Guid("721c8066-86a1-4419-88d4-638aaf67f051"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3913), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 1 },
                    { new Guid("7b8ce489-c244-4886-8889-9a080d52f753"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3902), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 2 },
                    { new Guid("979c229b-1c02-46f2-b9a1-0fc3384c6d80"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4033), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 3 },
                    { new Guid("99b169f5-530f-498b-8cf7-0b89fa7bd270"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3905), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 1 },
                    { new Guid("9d000cf9-69df-4699-8e19-8bea3401d830"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3891), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 2 },
                    { new Guid("a0d11bb0-6028-4ae8-b6cd-c8a29b6ddcf5"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3893), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 4 },
                    { new Guid("a4704e3b-74bb-4630-a01e-beb9e12936f5"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3907), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 2 },
                    { new Guid("a7a9159a-47ce-4fb7-9d15-db48ad14a6a1"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3916), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 2 },
                    { new Guid("aa40cba2-0d2f-4121-9d41-ce978c7961a1"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3910), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 2 },
                    { new Guid("b7694e75-1a56-499f-ac88-b6e5af87a4d9"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4039), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 2 },
                    { new Guid("c67e7756-8d61-4fa2-81a8-d6f204201594"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4036), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 1 },
                    { new Guid("cfd195a6-a89d-46a3-aeec-f4ccbe74f147"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3906), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 4 },
                    { new Guid("da220ade-9bce-4dc4-8dbf-adccbf15a5f2"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3919), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 4 },
                    { new Guid("dced971a-a9be-4652-a4f1-1009e8e4bfd0"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3892), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 1 },
                    { new Guid("ebc63d48-165f-481a-95aa-2d55b82e0ab3"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4042), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 4 },
                    { new Guid("ec2744c4-51cd-4556-99e8-80a7c009b495"), "8e445865-a24d-4543-a6c6-9443d048cdb9", null, new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3917), new Guid("368645db-9552-4d7a-9039-117496cc2ca8"), 4 }
                });

            migrationBuilder.InsertData(
                table: "Comentarios",
                columns: new[] { "Id", "AppUserId", "Content", "CreatedOn", "PostId" },
                values: new object[,]
                {
                    { new Guid("0cfee263-3331-47c4-a593-5efb23054ff3"), "b79228c5-5fdb-4e2e-9ce6-e23dd29b97cc", "Apenas um comentário inserido diramente do migration", new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3846), new Guid("368645db-9552-4d7a-9039-117496cc2ca8") },
                    { new Guid("c0c7bc79-d3df-479e-9d45-a1036d75ebfe"), "b79228c5-5fdb-4e2e-9ce6-e23dd29b97cc", "Apenas outro comentário inserido diramente do migration", new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3850), new Guid("368645db-9552-4d7a-9039-117496cc2ca8") }
                });

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
                name: "IX_Avaliacoes_AppUserId",
                table: "Avaliacoes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_CommentId",
                table: "Avaliacoes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_PostId",
                table: "Avaliacoes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_AppUserId",
                table: "Comentarios",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PostId",
                table: "Comentarios",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

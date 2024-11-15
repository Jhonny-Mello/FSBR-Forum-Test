﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api_backend.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241111033659_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "eccf1bde-a0ff-48f2-96c1-8ec39d921791",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("api.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e7dd45ea-7508-4225-806a-e35af5b2d05f",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "Jhonny Mello",
                            PasswordHash = "AQAAAAIAAYagAAAAEPxeeKz8TYlBWRjL/1vXUBprjEL4GpExl6iTN7fuLOiP10eWp2IyU6JQrQ9Vxo7z9g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ca5d9254-37be-4805-aa6f-e16c5c26f149",
                            TwoFactorEnabled = false,
                            UserName = "Jhonny"
                        },
                        new
                        {
                            Id = "b79228c5-5fdb-4e2e-9ce6-e23dd29b97cc",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a05d2fda-5fd9-4c5e-ad58-2778812cc296",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "Heloyza Morais",
                            PasswordHash = "AQAAAAIAAYagAAAAEJ1/E9bLSksBqW/ImgRP/lTOgtYtixbX/7jGBj2joPgucZBwlX/qIdR9kaLXe21+tg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "66b94876-6fda-498d-adf6-8867769eaaff",
                            TwoFactorEnabled = false,
                            UserName = "Heloyza"
                        });
                });

            modelBuilder.Entity("api.Models.Avaliacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Avaliacoes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("363dda5b-2d5e-487f-bb86-a047e6de8a6c"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3888),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 4
                        },
                        new
                        {
                            Id = new Guid("2ae36c0f-da48-465b-b0ed-2c3cc7cb9417"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3890),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 3
                        },
                        new
                        {
                            Id = new Guid("9d000cf9-69df-4699-8e19-8bea3401d830"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3891),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("dced971a-a9be-4652-a4f1-1009e8e4bfd0"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3892),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 1
                        },
                        new
                        {
                            Id = new Guid("a0d11bb0-6028-4ae8-b6cd-c8a29b6ddcf5"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3893),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 4
                        },
                        new
                        {
                            Id = new Guid("7b8ce489-c244-4886-8889-9a080d52f753"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3902),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("99b169f5-530f-498b-8cf7-0b89fa7bd270"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3905),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 1
                        },
                        new
                        {
                            Id = new Guid("cfd195a6-a89d-46a3-aeec-f4ccbe74f147"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3906),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 4
                        },
                        new
                        {
                            Id = new Guid("a4704e3b-74bb-4630-a01e-beb9e12936f5"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3907),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("0d7f5774-0c33-461a-9d02-fbf3f45326b1"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3909),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 3
                        },
                        new
                        {
                            Id = new Guid("aa40cba2-0d2f-4121-9d41-ce978c7961a1"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3910),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("5ded3879-fa37-46d4-bc79-4e8638f0c812"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3911),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 4
                        },
                        new
                        {
                            Id = new Guid("04865829-bb86-4c30-aadd-26964a6b3149"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3912),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 3
                        },
                        new
                        {
                            Id = new Guid("721c8066-86a1-4419-88d4-638aaf67f051"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3913),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 1
                        },
                        new
                        {
                            Id = new Guid("41baf53a-3103-4b0b-bfee-75f348503ced"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3915),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("a7a9159a-47ce-4fb7-9d15-db48ad14a6a1"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3916),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("ec2744c4-51cd-4556-99e8-80a7c009b495"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3917),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 4
                        },
                        new
                        {
                            Id = new Guid("da220ade-9bce-4dc4-8dbf-adccbf15a5f2"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3919),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 4
                        },
                        new
                        {
                            Id = new Guid("979c229b-1c02-46f2-b9a1-0fc3384c6d80"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4033),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 3
                        },
                        new
                        {
                            Id = new Guid("6f1d9ab3-1859-4b7d-8f47-4aa5ff709d51"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4034),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("40d776cf-838e-43be-a4a3-f4112c78b54a"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4035),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 1
                        },
                        new
                        {
                            Id = new Guid("c67e7756-8d61-4fa2-81a8-d6f204201594"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4036),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 1
                        },
                        new
                        {
                            Id = new Guid("4391f290-96fb-4cb3-8b79-bf45f3e76dd0"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4039),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 3
                        },
                        new
                        {
                            Id = new Guid("b7694e75-1a56-499f-ac88-b6e5af87a4d9"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4039),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("515f4da9-9b41-4924-85d5-5478cda7fcde"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4040),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 4
                        },
                        new
                        {
                            Id = new Guid("6ab10d86-0062-4ad4-97cd-1de059428710"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4041),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("ebc63d48-165f-481a-95aa-2d55b82e0ab3"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4042),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 4
                        },
                        new
                        {
                            Id = new Guid("42b20ced-c00c-4b0a-9e8b-efa4865aa322"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4043),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 2
                        },
                        new
                        {
                            Id = new Guid("552c96aa-3141-4848-b60d-c8e0d470f3c6"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4044),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 3
                        },
                        new
                        {
                            Id = new Guid("69bc7ffe-c6bf-4719-9e10-1b77f48abef8"),
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(4045),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            Value = 1
                        });
                });

            modelBuilder.Entity("api.Models.Comentario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("PostId");

                    b.ToTable("Comentarios");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0cfee263-3331-47c4-a593-5efb23054ff3"),
                            AppUserId = "b79228c5-5fdb-4e2e-9ce6-e23dd29b97cc",
                            Content = "Apenas um comentário inserido diramente do migration",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3846),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8")
                        },
                        new
                        {
                            Id = new Guid("c0c7bc79-d3df-479e-9d45-a1036d75ebfe"),
                            AppUserId = "b79228c5-5fdb-4e2e-9ce6-e23dd29b97cc",
                            Content = "Apenas outro comentário inserido diramente do migration",
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3850),
                            PostId = new Guid("368645db-9552-4d7a-9039-117496cc2ca8")
                        });
                });

            modelBuilder.Entity("api.Models.Post", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppUserId", "Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            AppUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            Id = new Guid("368645db-9552-4d7a-9039-117496cc2ca8"),
                            CreatedOn = new DateTime(2024, 11, 11, 0, 36, 59, 192, DateTimeKind.Local).AddTicks(3803),
                            PostContent = "Esta publicação foi adicionada diretamente pelo migration do entity framework",
                            Tema = "Apenas um novo tema inserido diretamente do migration pelo meu usuário ADM"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("api.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("api.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("api.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.Avaliacao", b =>
                {
                    b.HasOne("api.Models.AppUser", "AppUser")
                        .WithMany("Avaliacao")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("api.Models.Comentario", "Comentario")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("api.Models.Post", "Post")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("PostId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("AppUser");

                    b.Navigation("Comentario");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("api.Models.Comentario", b =>
                {
                    b.HasOne("api.Models.AppUser", "AppUser")
                        .WithMany("Comentarios")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Post", "Post")
                        .WithMany("Comentarios")
                        .HasForeignKey("PostId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("api.Models.Post", b =>
                {
                    b.HasOne("api.Models.AppUser", "AppUser")
                        .WithMany("Posts")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("api.Models.AppUser", b =>
                {
                    b.Navigation("Avaliacao");

                    b.Navigation("Comentarios");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("api.Models.Comentario", b =>
                {
                    b.Navigation("Avaliacoes");
                });

            modelBuilder.Entity("api.Models.Post", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using h23final_serveur.Data;

#nullable disable

namespace h23final_serveur.Migrations
{
    [DbContext(typeof(h23final_serveurContext))]
    partial class h23final_serveurContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("h23final_serveur.Models.Channel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Channel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "général | 📢"
                        },
                        new
                        {
                            Id = 2,
                            Name = "école | 😴"
                        },
                        new
                        {
                            Id = 3,
                            Name = "nsfw | 🍑"
                        });
                });

            modelBuilder.Entity("h23final_serveur.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChannelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("UserId");

                    b.ToTable("Message");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChannelId = 1,
                            SentAt = new DateTime(2023, 5, 10, 20, 15, 27, 0, DateTimeKind.Unspecified),
                            Text = "eske qqun peut me donner les réponses de l'exam svp ?",
                            UserId = "11111111-1111-1111-1111-111111111112"
                        },
                        new
                        {
                            Id = 2,
                            ChannelId = 1,
                            SentAt = new DateTime(2023, 5, 10, 20, 15, 31, 0, DateTimeKind.Unspecified),
                            Text = "Tu n'auras droit qu'à un seul avertissement @sussyfella : tu n'as pas utilisé le bon salon.",
                            UserId = "11111111-1111-1111-1111-111111111111"
                        },
                        new
                        {
                            Id = 3,
                            ChannelId = 2,
                            SentAt = new DateTime(2023, 5, 10, 21, 41, 17, 0, DateTimeKind.Unspecified),
                            Text = "Comment on fait déjà pour juste permettre au proprio d'un objet de le supprimer ? (Dans l'exam)",
                            UserId = "11111111-1111-1111-1111-111111111111"
                        },
                        new
                        {
                            Id = 4,
                            ChannelId = 2,
                            SentAt = new DateTime(2023, 5, 10, 21, 42, 31, 0, DateTimeKind.Unspecified),
                            Text = "g pas été capable de faire ce num la non plu xd pg g eu une bonne note à l'intra",
                            UserId = "11111111-1111-1111-1111-111111111112"
                        },
                        new
                        {
                            Id = 5,
                            ChannelId = 3,
                            SentAt = new DateTime(2023, 5, 11, 18, 51, 2, 0, DateTimeKind.Unspecified),
                            Text = "huh 👉👈",
                            UserId = "11111111-1111-1111-1111-111111111112"
                        },
                        new
                        {
                            Id = 6,
                            ChannelId = 3,
                            SentAt = new DateTime(2023, 6, 12, 17, 42, 5, 0, DateTimeKind.Unspecified),
                            Text = "eske qqun peut me donner les réponses de l’examen svp ?",
                            UserId = "11111111-1111-1111-1111-111111111111"
                        });
                });

            modelBuilder.Entity("h23final_serveur.Models.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Reaction");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FileName = "11111111-1111-1111-1111-111111111111.png",
                            MessageId = 2,
                            MimeType = "image/png",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            FileName = "11111111-1111-1111-1111-111111111112.png",
                            MessageId = 5,
                            MimeType = "image/png",
                            Quantity = 2
                        },
                        new
                        {
                            Id = 3,
                            FileName = "eggplant.png",
                            MessageId = 6,
                            MimeType = "image/png",
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("h23final_serveur.Models.User", b =>
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
                            Id = "11111111-1111-1111-1111-111111111111",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e3469821-db4d-4a77-985c-b982a6077a11",
                            Email = "a@a.a",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "A@A.A",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEAL5sN6lwMjom6/jwz49mbHgcGQVsqunEeNzWW6+/iH8mPGHFNZGTUKskRrHffpf9g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "45f10295-29cf-4b93-a880-eec00611cf0a",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111112",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "78f9608e-1bdb-4b04-b4b3-551e2185b523",
                            Email = "s@s.s",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "S@S.S",
                            NormalizedUserName = "SUSSYFELLA",
                            PasswordHash = "AQAAAAEAACcQAAAAEIJFGMvBKxxvL+EA0zu3+MDosh2uGa/yo3y4YH9mF5phNwe6uTtaC4QXTWhMfzd1sQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f1c2b21-cbd4-4b2a-b6a7-ee986396cc2a",
                            TwoFactorEnabled = false,
                            UserName = "sussyfella"
                        });
                });

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
                            Id = "1",
                            ConcurrencyStamp = "e8b746a6-e123-45ee-a5e0-90b684a513e4",
                            Name = "moderator",
                            NormalizedName = "MODERATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                            UserId = "11111111-1111-1111-1111-111111111111",
                            RoleId = "1"
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

            modelBuilder.Entity("ReactionUser", b =>
                {
                    b.Property<int>("ReactionsId")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReactionsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ReactionUser");

                    b.HasData(
                        new
                        {
                            ReactionsId = 1,
                            UsersId = "11111111-1111-1111-1111-111111111112"
                        },
                        new
                        {
                            ReactionsId = 2,
                            UsersId = "11111111-1111-1111-1111-111111111111"
                        },
                        new
                        {
                            ReactionsId = 2,
                            UsersId = "11111111-1111-1111-1111-111111111112"
                        },
                        new
                        {
                            ReactionsId = 3,
                            UsersId = "11111111-1111-1111-1111-111111111111"
                        });
                });

            modelBuilder.Entity("h23final_serveur.Models.Message", b =>
                {
                    b.HasOne("h23final_serveur.Models.Channel", "Channel")
                        .WithMany("Messages")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("h23final_serveur.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId");

                    b.Navigation("Channel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("h23final_serveur.Models.Reaction", b =>
                {
                    b.HasOne("h23final_serveur.Models.Message", "Message")
                        .WithMany("Reactions")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
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
                    b.HasOne("h23final_serveur.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("h23final_serveur.Models.User", null)
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

                    b.HasOne("h23final_serveur.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("h23final_serveur.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReactionUser", b =>
                {
                    b.HasOne("h23final_serveur.Models.Reaction", null)
                        .WithMany()
                        .HasForeignKey("ReactionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("h23final_serveur.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("h23final_serveur.Models.Channel", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("h23final_serveur.Models.Message", b =>
                {
                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("h23final_serveur.Models.User", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}

//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace OpenBook.Adapter.Migrations
//{
//    /// <inheritdoc />
//    public partial class InitialCreate : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "EmailVerifs",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    Email = table.Column<string>(type: "TEXT", nullable: false),
//                    Code = table.Column<string>(type: "TEXT", nullable: false),
//                    IsAcivate = table.Column<bool>(type: "INTEGER", nullable: false),
//                    CreatAt = table.Column<DateTime>(type: "TEXT", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_EmailVerifs", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "Genres",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    Name = table.Column<string>(type: "TEXT", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Genres", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "Roles",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    Name = table.Column<string>(type: "TEXT", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Roles", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "Users",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    Email = table.Column<string>(type: "TEXT", nullable: false),
//                    Password = table.Column<string>(type: "TEXT", nullable: false),
//                    Name = table.Column<string>(type: "TEXT", nullable: false),
//                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
//                    RoleId = table.Column<int>(type: "INTEGER", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Users", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Users_Roles_RoleId",
//                        column: x => x.RoleId,
//                        principalTable: "Roles",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Baskets",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Baskets", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Baskets_Users_UserId",
//                        column: x => x.UserId,
//                        principalTable: "Users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Cycles",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    Name = table.Column<string>(type: "TEXT", nullable: false),
//                    Cover = table.Column<byte[]>(type: "BLOB", nullable: true),
//                    Description = table.Column<string>(type: "TEXT", nullable: true),
//                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Cycles", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Cycles_Users_UserId",
//                        column: x => x.UserId,
//                        principalTable: "Users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Posts",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    Content = table.Column<string>(type: "TEXT", nullable: false),
//                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
//                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Posts", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Posts_Users_UserId",
//                        column: x => x.UserId,
//                        principalTable: "Users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Subscribes",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    AuthId = table.Column<int>(type: "INTEGER", nullable: true),
//                    AuthorId = table.Column<int>(type: "INTEGER", nullable: true),
//                    SubId = table.Column<int>(type: "INTEGER", nullable: true),
//                    SubscriberId = table.Column<int>(type: "INTEGER", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Subscribes", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Subscribes_Users_AuthId",
//                        column: x => x.AuthId,
//                        principalTable: "Users",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK_Subscribes_Users_SubId",
//                        column: x => x.SubId,
//                        principalTable: "Users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Books",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    Cover = table.Column<byte[]>(type: "BLOB", nullable: true),
//                    Name = table.Column<string>(type: "TEXT", nullable: false),
//                    Description = table.Column<string>(type: "TEXT", nullable: false),
//                    Author = table.Column<string>(type: "TEXT", nullable: false),
//                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false),
//                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
//                    CycleId = table.Column<int>(type: "INTEGER", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Books", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Books_Cycles_CycleId",
//                        column: x => x.CycleId,
//                        principalTable: "Cycles",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK_Books_Users_UserId",
//                        column: x => x.UserId,
//                        principalTable: "Users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "BookBaskets",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    BookId = table.Column<int>(type: "INTEGER", nullable: true),
//                    BasketId = table.Column<int>(type: "INTEGER", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_BookBaskets", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_BookBaskets_Baskets_BasketId",
//                        column: x => x.BasketId,
//                        principalTable: "Baskets",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK_BookBaskets_Books_BookId",
//                        column: x => x.BookId,
//                        principalTable: "Books",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "BookGenres",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    BookId = table.Column<int>(type: "INTEGER", nullable: true),
//                    GenreId = table.Column<int>(type: "INTEGER", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_BookGenres", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_BookGenres_Books_BookId",
//                        column: x => x.BookId,
//                        principalTable: "Books",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK_BookGenres_Genres_GenreId",
//                        column: x => x.GenreId,
//                        principalTable: "Genres",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Chapters",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    Name = table.Column<string>(type: "TEXT", nullable: false),
//                    Content = table.Column<string>(type: "TEXT", nullable: false),
//                    Number = table.Column<int>(type: "INTEGER", nullable: true),
//                    IsPublic = table.Column<bool>(type: "INTEGER", nullable: false),
//                    BookId = table.Column<int>(type: "INTEGER", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Chapters", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Chapters_Books_BookId",
//                        column: x => x.BookId,
//                        principalTable: "Books",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Likes",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
//                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
//                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Likes", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Likes_Books_BookId",
//                        column: x => x.BookId,
//                        principalTable: "Books",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_Likes_Users_UserId",
//                        column: x => x.UserId,
//                        principalTable: "Users",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "Reviews",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "INTEGER", nullable: false)
//                        .Annotation("Sqlite:Autoincrement", true),
//                    Text = table.Column<string>(type: "TEXT", nullable: false),
//                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
//                    IsEdited = table.Column<bool>(type: "INTEGER", nullable: false),
//                    BookId = table.Column<int>(type: "INTEGER", nullable: true),
//                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Reviews", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Reviews_Books_BookId",
//                        column: x => x.BookId,
//                        principalTable: "Books",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK_Reviews_Users_UserId",
//                        column: x => x.UserId,
//                        principalTable: "Users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_Baskets_UserId",
//                table: "Baskets",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_BookBaskets_BasketId",
//                table: "BookBaskets",
//                column: "BasketId");

//            migrationBuilder.CreateIndex(
//                name: "IX_BookBaskets_BookId",
//                table: "BookBaskets",
//                column: "BookId");

//            migrationBuilder.CreateIndex(
//                name: "IX_BookGenres_BookId",
//                table: "BookGenres",
//                column: "BookId");

//            migrationBuilder.CreateIndex(
//                name: "IX_BookGenres_GenreId",
//                table: "BookGenres",
//                column: "GenreId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Books_CycleId",
//                table: "Books",
//                column: "CycleId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Books_UserId",
//                table: "Books",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Chapters_BookId",
//                table: "Chapters",
//                column: "BookId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Cycles_UserId",
//                table: "Cycles",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Likes_BookId",
//                table: "Likes",
//                column: "BookId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Likes_UserId",
//                table: "Likes",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Posts_UserId",
//                table: "Posts",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Reviews_BookId",
//                table: "Reviews",
//                column: "BookId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Reviews_UserId",
//                table: "Reviews",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Subscribes_AuthId",
//                table: "Subscribes",
//                column: "AuthId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Subscribes_SubId",
//                table: "Subscribes",
//                column: "SubId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Users_RoleId",
//                table: "Users",
//                column: "RoleId");
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "BookBaskets");

//            migrationBuilder.DropTable(
//                name: "BookGenres");

//            migrationBuilder.DropTable(
//                name: "Chapters");

//            migrationBuilder.DropTable(
//                name: "EmailVerifs");

//            migrationBuilder.DropTable(
//                name: "Likes");

//            migrationBuilder.DropTable(
//                name: "Posts");

//            migrationBuilder.DropTable(
//                name: "Reviews");

//            migrationBuilder.DropTable(
//                name: "Subscribes");

//            migrationBuilder.DropTable(
//                name: "Baskets");

//            migrationBuilder.DropTable(
//                name: "Genres");

//            migrationBuilder.DropTable(
//                name: "Books");

//            migrationBuilder.DropTable(
//                name: "Cycles");

//            migrationBuilder.DropTable(
//                name: "Users");

//            migrationBuilder.DropTable(
//                name: "Roles");
//        }
//    }
//}

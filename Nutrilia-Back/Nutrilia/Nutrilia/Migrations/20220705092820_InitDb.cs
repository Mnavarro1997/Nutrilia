using Microsoft.EntityFrameworkCore.Migrations;

namespace Nutrilia.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Plan = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_User = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id_Plan = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    ImageURl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id_Plan);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id_Recipe = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id_Recipe);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Bank_Account = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "CartPlans",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlansId_Plan = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartPlans", x => new { x.CartId, x.PlansId_Plan });
                    table.ForeignKey(
                        name: "FK_CartPlans_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartPlans_Plans_PlansId_Plan",
                        column: x => x.PlansId_Plan,
                        principalTable: "Plans",
                        principalColumn: "Id_Plan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartUsers",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId_User = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartUsers", x => new { x.CartId, x.UsersId_User });
                    table.ForeignKey(
                        name: "FK_CartUsers_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartUsers_Users_UsersId_User",
                        column: x => x.UsersId_User,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlansUsers",
                columns: table => new
                {
                    PlansId_Plan = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId_User = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlansUsers", x => new { x.PlansId_Plan, x.UsersId_User });
                    table.ForeignKey(
                        name: "FK_PlansUsers_Plans_PlansId_Plan",
                        column: x => x.PlansId_Plan,
                        principalTable: "Plans",
                        principalColumn: "Id_Plan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlansUsers_Users_UsersId_User",
                        column: x => x.UsersId_User,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartPlans_PlansId_Plan",
                table: "CartPlans",
                column: "PlansId_Plan");

            migrationBuilder.CreateIndex(
                name: "IX_CartUsers_UsersId_User",
                table: "CartUsers",
                column: "UsersId_User");

            migrationBuilder.CreateIndex(
                name: "IX_PlansUsers_UsersId_User",
                table: "PlansUsers",
                column: "UsersId_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartPlans");

            migrationBuilder.DropTable(
                name: "CartUsers");

            migrationBuilder.DropTable(
                name: "PlansUsers");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

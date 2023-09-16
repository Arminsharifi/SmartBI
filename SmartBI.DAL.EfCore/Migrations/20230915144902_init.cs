using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBI.DAL.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_business",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_business", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_food",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_food", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_transaction",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    business_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_transaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_transaction_tbl_business_business_id",
                        column: x => x.business_id,
                        principalTable: "tbl_business",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_transaction_tbl_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "tbl_customer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_transaction_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    count = table.Column<int>(type: "int", nullable: false),
                    food_id = table.Column<int>(type: "int", nullable: false),
                    transaction_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_transaction_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_transaction_detail_tbl_food_food_id",
                        column: x => x.food_id,
                        principalTable: "tbl_food",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_transaction_detail_tbl_transaction_transaction_id",
                        column: x => x.transaction_id,
                        principalTable: "tbl_transaction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customer_phone_number",
                table: "tbl_customer",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_transaction_business_id",
                table: "tbl_transaction",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_transaction_customer_id",
                table: "tbl_transaction",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_transaction_detail_food_id",
                table: "tbl_transaction_detail",
                column: "food_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_transaction_detail_transaction_id",
                table: "tbl_transaction_detail",
                column: "transaction_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_transaction_detail");

            migrationBuilder.DropTable(
                name: "tbl_food");

            migrationBuilder.DropTable(
                name: "tbl_transaction");

            migrationBuilder.DropTable(
                name: "tbl_business");

            migrationBuilder.DropTable(
                name: "tbl_customer");
        }
    }
}

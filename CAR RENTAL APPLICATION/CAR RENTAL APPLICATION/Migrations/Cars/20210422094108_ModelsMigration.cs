using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CAR_RENTAL_APPLICATION.Migrations.Cars
{
    public partial class ModelsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Capacity = table.Column<string>(nullable: true),
                    NumberOfDoors = table.Column<string>(nullable: true),
                    FabricationYear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarRecords",
                columns: table => new
                {
                    CarRecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRecords", x => x.CarRecordId);
                    table.ForeignKey(
                        name: "FK_CarRecords_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRecords_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    PaymentId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "newsletterlogs",
                columns: table => new
                {
                    newsletterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    contactId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsletterlogs", x => x.newsletterId);
                });

            migrationBuilder.CreateTable(
                name: "mailingListlogs",
                columns: table => new
                {
                    mailingListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip = table.Column<int>(nullable: false),
                    policy = table.Column<bool>(nullable: false),
                    newsletterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mailingListlogs", x => x.mailingListId);
                    table.ForeignKey(
                        name: "FK_mailingListlogs_newsletterlogs_newsletterId",
                        column: x => x.newsletterId,
                        principalTable: "newsletterlogs",
                        principalColumn: "newsletterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contactlogs",
                columns: table => new
                {
                    contactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true),
                    mailingListId = table.Column<int>(nullable: false),
                    newsletterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactlogs", x => x.contactId);
                    table.ForeignKey(
                        name: "FK_contactlogs_mailingListlogs_mailingListId",
                        column: x => x.mailingListId,
                        principalTable: "mailingListlogs",
                        principalColumn: "mailingListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contactlogs_newsletterlogs_newsletterId",
                        column: x => x.newsletterId,
                        principalTable: "newsletterlogs",
                        principalColumn: "newsletterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRecords_CarId",
                table: "CarRecords",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRecords_UserId",
                table: "CarRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_contactlogs_mailingListId",
                table: "contactlogs",
                column: "mailingListId");

            migrationBuilder.CreateIndex(
                name: "IX_contactlogs_newsletterId",
                table: "contactlogs",
                column: "newsletterId");

            migrationBuilder.CreateIndex(
                name: "IX_mailingListlogs_newsletterId",
                table: "mailingListlogs",
                column: "newsletterId");

            migrationBuilder.CreateIndex(
                name: "IX_newsletterlogs_contactId",
                table: "newsletterlogs",
                column: "contactId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CarId",
                table: "Transactions",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PaymentId",
                table: "Transactions",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_newsletterlogs_contactlogs_contactId",
                table: "newsletterlogs",
                column: "contactId",
                principalTable: "contactlogs",
                principalColumn: "contactId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contactlogs_mailingListlogs_mailingListId",
                table: "contactlogs");

            migrationBuilder.DropForeignKey(
                name: "FK_contactlogs_newsletterlogs_newsletterId",
                table: "contactlogs");

            migrationBuilder.DropTable(
                name: "CarRecords");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "mailingListlogs");

            migrationBuilder.DropTable(
                name: "newsletterlogs");

            migrationBuilder.DropTable(
                name: "contactlogs");
        }
    }
}

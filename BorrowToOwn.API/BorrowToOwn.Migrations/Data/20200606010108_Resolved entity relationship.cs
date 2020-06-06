using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BorrowToOwn.API.BorrowToOwn.Migrations.Data
{
    public partial class Resolvedentityrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ImageExtension",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "AmortizationRate",
                table: "PaymentPlans");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "FinanceRate",
                table: "Products",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "OneOffRate",
                table: "Products",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<long>(
                name: "ProductDetailId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductImages",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MonthlyAmortizationValue",
                table: "PaymentPlans",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryPrice",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOneOffPurchase",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderState",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PenaltyFeeInduced",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsOrderLevelReady",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserProfilePicUrl",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HomeAddressId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OfficeAddressId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetNumber = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserBankStatement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(nullable: true),
                    DocumentUrl = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserBankStatement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserBankStatement_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovalComment = table.Column<string>(nullable: true),
                    OrderId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityDocument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(nullable: true),
                    IdentityName = table.Column<string>(nullable: true),
                    IdentityType = table.Column<int>(nullable: false),
                    DocumentUrl = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityDocument_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProductState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPaymentPlan",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false),
                    PaymentPlanId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    PaymentPlanName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPaymentPlan", x => new { x.ProductId, x.PaymentPlanId });
                    table.ForeignKey(
                        name: "FK_ProductPaymentPlan_PaymentPlans_PaymentPlanId",
                        column: x => x.PaymentPlanId,
                        principalTable: "PaymentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPaymentPlan_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SurrogateIdentifier",
                table: "AspNetUsers",
                column: "SurrogateIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FirstName_LastName_Email_UserName",
                table: "AspNetUsers",
                columns: new[] { "FirstName", "LastName", "Email", "UserName" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_HomeAddressId",
                table: "Addresses",
                column: "HomeAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_OfficeAddressId",
                table: "Addresses",
                column: "OfficeAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserBankStatement_AppUserId",
                table: "AppUserBankStatement",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_OrderId",
                table: "Comment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocument_AppUserId",
                table: "IdentityDocument",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPaymentPlan_PaymentPlanId",
                table: "ProductPaymentPlan",
                column: "PaymentPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressDetails_HomeAddressId",
                table: "Addresses",
                column: "HomeAddressId",
                principalTable: "AddressDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressDetails_OfficeAddressId",
                table: "Addresses",
                column: "OfficeAddressId",
                principalTable: "AddressDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDetail_ProductDetailId",
                table: "Products",
                column: "ProductDetailId",
                principalTable: "ProductDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressDetails_HomeAddressId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressDetails_OfficeAddressId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDetail_ProductDetailId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "AddressDetails");

            migrationBuilder.DropTable(
                name: "AppUserBankStatement");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "IdentityDocument");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "ProductPaymentPlan");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SurrogateIdentifier",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FirstName_LastName_Email_UserName",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_HomeAddressId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_OfficeAddressId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "FinanceRate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OneOffRate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "MonthlyAmortizationValue",
                table: "PaymentPlans");

            migrationBuilder.DropColumn(
                name: "DeliveryPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsOneOffPurchase",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderState",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PenaltyFeeInduced",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsOrderLevelReady",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserProfilePicUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HomeAddressId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "OfficeAddressId",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SellingPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "ProductImages",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageExtension",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "AmortizationRate",
                table: "PaymentPlans",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StreetNumber",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

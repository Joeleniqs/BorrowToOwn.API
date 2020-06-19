using Microsoft.EntityFrameworkCore.Migrations;

namespace BorrowToOwn.API.BorrowToOwn.Migrations.Data
{
    public partial class modifiedpaymentPlanandorderentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyAmortizationValue",
                table: "PaymentPlans");

            migrationBuilder.DropColumn(
                name: "IsOneOffPurchase",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PaymentPlans",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PlanType",
                table: "PaymentPlans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyAmortizationValue",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UpFrontAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PaymentPlans");

            migrationBuilder.DropColumn(
                name: "PlanType",
                table: "PaymentPlans");

            migrationBuilder.DropColumn(
                name: "MonthlyAmortizationValue",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpFrontAmount",
                table: "Orders");

            migrationBuilder.AddColumn<float>(
                name: "MonthlyAmortizationValue",
                table: "PaymentPlans",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "IsOneOffPurchase",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}

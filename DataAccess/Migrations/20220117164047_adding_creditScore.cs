using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class adding_creditScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinCreditScore",
                table: "Cars",
                nullable: true
            );
            
            migrationBuilder.AddColumn<int>(
                name: "CreditScore",
                table: "Customers",
                nullable: true
            );

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}

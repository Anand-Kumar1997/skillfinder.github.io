using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skill4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminlogs",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminlogs", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Citiess",
                columns: table => new
                {
                    CityCode = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    Activated = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citiess", x => x.CityCode);
                });

            migrationBuilder.CreateTable(
                name: "RequestForProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    ServiceName = table.Column<string>(nullable: true),
                    RequestedOn = table.Column<DateTime>(nullable: false),
                    Activated = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestForProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderMapss",
                columns: table => new
                {
                    ServiceSysId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceProviderSysId = table.Column<long>(nullable: false),
                    Verified = table.Column<bool>(nullable: false),
                    CityCode = table.Column<string>(nullable: true),
                    AvgCharge = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderMapss", x => x.ServiceSysId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderss",
                columns: table => new
                {
                    ServiceProviderSysId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    Activated = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    ContNo = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    AltContNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderss", x => x.ServiceProviderSysId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequestss",
                columns: table => new
                {
                    RequestSysId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserSysId = table.Column<long>(nullable: false),
                    ServiceSysId = table.Column<long>(nullable: false),
                    CityCode = table.Column<string>(nullable: true),
                    ServiceProviderSysId = table.Column<long>(nullable: false),
                    RequestOn = table.Column<DateTime>(nullable: false),
                    RequestStatus = table.Column<byte>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequestss", x => x.RequestSysId);
                });

            migrationBuilder.CreateTable(
                name: "Servicess",
                columns: table => new
                {
                    ServiceSysId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceTitle = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    Activated = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicess", x => x.ServiceSysId);
                });

            migrationBuilder.CreateTable(
                name: "Userss",
                columns: table => new
                {
                    UserSysId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RegOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userss", x => x.UserSysId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminlogs");

            migrationBuilder.DropTable(
                name: "Citiess");

            migrationBuilder.DropTable(
                name: "RequestForProviders");

            migrationBuilder.DropTable(
                name: "ServiceProviderMapss");

            migrationBuilder.DropTable(
                name: "ServiceProviderss");

            migrationBuilder.DropTable(
                name: "ServiceRequestss");

            migrationBuilder.DropTable(
                name: "Servicess");

            migrationBuilder.DropTable(
                name: "Userss");
        }
    }
}

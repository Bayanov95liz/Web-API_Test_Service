using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_Test_Service.Migrations
{
    public partial class InitialParcel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Адрес",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Город = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Улица = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Номердома = table.Column<string>(name: "Номер дома", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Адрес", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Посылка",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Улица = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Посылка", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Посылка_Адрес_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Адрес",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Посылка_AddressID",
                table: "Посылка",
                column: "AddressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Посылка");

            migrationBuilder.DropTable(
                name: "Адрес");
        }
    }
}

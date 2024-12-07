using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiap.Migrations
{
    /// <inheritdoc />
    public partial class AddColeta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_coleta",
                columns: table => new
                {
                    ColetaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    rota = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    dataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_coleta", x => x.ColetaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_coleta");
        }
    }
}

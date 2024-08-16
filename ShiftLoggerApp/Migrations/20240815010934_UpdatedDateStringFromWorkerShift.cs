using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftLoggerApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDateStringFromWorkerShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkerShiftDate",
                table: "WorkerShifts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "WorkerShiftDate",
                table: "WorkerShifts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MailSender.Data.Migrations
{
    public partial class NameRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_ShedulerTasks_ShedulerTaskId",
                table: "Recipients");

            migrationBuilder.DropTable(
                name: "ShedulerTasks");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_ShedulerTaskId",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "ShedulerTaskId",
                table: "Recipients");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Senders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchedulerTaskId",
                table: "Recipients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SchedulerTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(nullable: false),
                    ServerId = table.Column<int>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    MessageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulerTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchedulerTasks_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchedulerTasks_Senders_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Senders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchedulerTasks_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_SchedulerTaskId",
                table: "Recipients",
                column: "SchedulerTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerTasks_MessageId",
                table: "SchedulerTasks",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerTasks_SenderId",
                table: "SchedulerTasks",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerTasks_ServerId",
                table: "SchedulerTasks",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_SchedulerTasks_SchedulerTaskId",
                table: "Recipients",
                column: "SchedulerTaskId",
                principalTable: "SchedulerTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_SchedulerTasks_SchedulerTaskId",
                table: "Recipients");

            migrationBuilder.DropTable(
                name: "SchedulerTasks");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_SchedulerTaskId",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "SchedulerTaskId",
                table: "Recipients");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Senders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ShedulerTaskId",
                table: "Recipients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShedulerTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: true),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    ServerId = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShedulerTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShedulerTasks_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShedulerTasks_Senders_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Senders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShedulerTasks_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_ShedulerTaskId",
                table: "Recipients",
                column: "ShedulerTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ShedulerTasks_MessageId",
                table: "ShedulerTasks",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ShedulerTasks_SenderId",
                table: "ShedulerTasks",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShedulerTasks_ServerId",
                table: "ShedulerTasks",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_ShedulerTasks_ShedulerTaskId",
                table: "Recipients",
                column: "ShedulerTaskId",
                principalTable: "ShedulerTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

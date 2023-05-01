using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeHero.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Requests_RequestID",
                table: "Complaints");

            migrationBuilder.DropTable(
                name: "ComplaintUser");

            migrationBuilder.RenameColumn(
                name: "RequestID",
                table: "Complaints",
                newName: "UnsatisfiedUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Complaints_RequestID",
                table: "Complaints",
                newName: "IX_Complaints_UnsatisfiedUserID");

            migrationBuilder.AddColumn<int>(
                name: "AttenderUserID",
                table: "Complaints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Complaints",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId2",
                table: "Complaints",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId3",
                table: "Complaints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_AttenderUserID",
                table: "Complaints",
                column: "AttenderUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ComplaintedUserID",
                table: "Complaints",
                column: "ComplaintedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_RequestComplaintID",
                table: "Complaints",
                column: "RequestComplaintID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_UserId1",
                table: "Complaints",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_UserId2",
                table: "Complaints",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_UserId3",
                table: "Complaints",
                column: "UserId3");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Requests_RequestComplaintID",
                table: "Complaints",
                column: "RequestComplaintID",
                principalTable: "Requests",
                principalColumn: "RequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Users_AttenderUserID",
                table: "Complaints",
                column: "AttenderUserID",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Users_ComplaintedUserID",
                table: "Complaints",
                column: "ComplaintedUserID",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Users_UnsatisfiedUserID",
                table: "Complaints",
                column: "UnsatisfiedUserID",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Users_UserId1",
                table: "Complaints",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Users_UserId2",
                table: "Complaints",
                column: "UserId2",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Users_UserId3",
                table: "Complaints",
                column: "UserId3",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Requests_RequestComplaintID",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Users_AttenderUserID",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Users_ComplaintedUserID",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Users_UnsatisfiedUserID",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Users_UserId1",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Users_UserId2",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Users_UserId3",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_AttenderUserID",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ComplaintedUserID",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_RequestComplaintID",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_UserId1",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_UserId2",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_UserId3",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "AttenderUserID",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "UserId2",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "UserId3",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "UnsatisfiedUserID",
                table: "Complaints",
                newName: "RequestID");

            migrationBuilder.RenameIndex(
                name: "IX_Complaints_UnsatisfiedUserID",
                table: "Complaints",
                newName: "IX_Complaints_RequestID");

            migrationBuilder.CreateTable(
                name: "ComplaintUser",
                columns: table => new
                {
                    ComplaintUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttenderComplaintID = table.Column<int>(type: "int", nullable: false),
                    AttenderUserID = table.Column<int>(type: "int", nullable: false),
                    UnsatisfiedComplaintID = table.Column<int>(type: "int", nullable: false),
                    UnsatisfiedUserID = table.Column<int>(type: "int", nullable: false),
                    ComplaintID = table.Column<int>(type: "int", nullable: true),
                    ComplaintID1 = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintUser", x => x.ComplaintUserID);
                    table.ForeignKey(
                        name: "FK_ComplaintUser_Complaints_AttenderComplaintID",
                        column: x => x.AttenderComplaintID,
                        principalTable: "Complaints",
                        principalColumn: "ComplaintID");
                    table.ForeignKey(
                        name: "FK_ComplaintUser_Complaints_ComplaintID",
                        column: x => x.ComplaintID,
                        principalTable: "Complaints",
                        principalColumn: "ComplaintID");
                    table.ForeignKey(
                        name: "FK_ComplaintUser_Complaints_ComplaintID1",
                        column: x => x.ComplaintID1,
                        principalTable: "Complaints",
                        principalColumn: "ComplaintID");
                    table.ForeignKey(
                        name: "FK_ComplaintUser_Complaints_UnsatisfiedComplaintID",
                        column: x => x.UnsatisfiedComplaintID,
                        principalTable: "Complaints",
                        principalColumn: "ComplaintID");
                    table.ForeignKey(
                        name: "FK_ComplaintUser_Users_AttenderUserID",
                        column: x => x.AttenderUserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplaintUser_Users_UnsatisfiedUserID",
                        column: x => x.UnsatisfiedUserID,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_ComplaintUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintUser_AttenderComplaintID",
                table: "ComplaintUser",
                column: "AttenderComplaintID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintUser_AttenderUserID",
                table: "ComplaintUser",
                column: "AttenderUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintUser_ComplaintID",
                table: "ComplaintUser",
                column: "ComplaintID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintUser_ComplaintID1",
                table: "ComplaintUser",
                column: "ComplaintID1");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintUser_UnsatisfiedComplaintID",
                table: "ComplaintUser",
                column: "UnsatisfiedComplaintID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintUser_UnsatisfiedUserID",
                table: "ComplaintUser",
                column: "UnsatisfiedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintUser_UserId",
                table: "ComplaintUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Requests_RequestID",
                table: "Complaints",
                column: "RequestID",
                principalTable: "Requests",
                principalColumn: "RequestID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

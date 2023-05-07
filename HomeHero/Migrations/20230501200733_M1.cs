using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeHero.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aptitudes",
                columns: table => new
                {
                    AptitudeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AptitudeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AptitudeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aptitudes", x => x.AptitudeID);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "PayMethods",
                columns: table => new
                {
                    PMethodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMethods", x => x.PMethodID);
                });

            migrationBuilder.CreateTable(
                name: "RequestStates",
                columns: table => new
                {
                    ReqStateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStates", x => x.ReqStateID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRecords",
                columns: table => new
                {
                    PRecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PMethodID = table.Column<int>(type: "int", nullable: false),
                    PaymentReceipt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRecords", x => x.PRecordID);
                    table.ForeignKey(
                        name: "FK_PaymentRecords_PayMethods_PMethodID",
                        column: x => x.PMethodID,
                        principalTable: "PayMethods",
                        principalColumn: "PMethodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    RealUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamesUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurnamesUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QualificationUser = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationResidenceID = table.Column<int>(type: "int", nullable: false),
                    SexUser = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Curriculum = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VolunteerPermises = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Locations_LocationResidenceID",
                        column: x => x.LocationResidenceID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aptitude_Users",
                columns: table => new
                {
                    UserApID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AptitudeID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aptitude_Users", x => x.UserApID);
                    table.ForeignKey(
                        name: "FK_Aptitude_Users_Aptitudes_AptitudeID",
                        column: x => x.AptitudeID,
                        principalTable: "Aptitudes",
                        principalColumn: "AptitudeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aptitude_Users_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    NumPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doubts",
                columns: table => new
                {
                    DoubtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionerID = table.Column<int>(type: "int", nullable: false),
                    ResponderID = table.Column<int>(type: "int", nullable: false),
                    QuestionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnswerDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doubts", x => x.DoubtID);
                    table.ForeignKey(
                        name: "FK_Doubts_Users_QuestionerID",
                        column: x => x.QuestionerID,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Doubts_Users_ResponderID",
                        column: x => x.ResponderID,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Tutorials",
                columns: table => new
                {
                    TutorialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TutorialLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TutorialIPDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutorials", x => x.TutorialID);
                    table.ForeignKey(
                        name: "FK_Tutorials_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RequestID = table.Column<int>(type: "int", nullable: false),
                    RequestedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequestID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicantID);
                    table.ForeignKey(
                        name: "FK_Applications_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttentionRequests",
                columns: table => new
                {
                    AttentionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<int>(type: "int", nullable: false),
                    HelperUserID = table.Column<int>(type: "int", nullable: false),
                    AttentionReqValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AttentionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentRecordID = table.Column<int>(type: "int", nullable: false),
                    Qualification = table.Column<int>(type: "int", nullable: false),
                    RequestID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttentionRequests", x => x.AttentionID);
                    table.ForeignKey(
                        name: "FK_AttentionRequests_PaymentRecords_PaymentRecordID",
                        column: x => x.PaymentRecordID,
                        principalTable: "PaymentRecords",
                        principalColumn: "PRecordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttentionRequests_Users_HelperUserID",
                        column: x => x.HelperUserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<int>(type: "int", nullable: false),
                    ChatCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MesaggeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatID = table.Column<int>(type: "int", nullable: false),
                    UserChatID = table.Column<int>(type: "int", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateMessage = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MesaggeID);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatID",
                        column: x => x.ChatID,
                        principalTable: "Chats",
                        principalColumn: "ChatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserChatID",
                        column: x => x.UserChatID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationServiceID = table.Column<int>(type: "int", nullable: false),
                    ApplicantUserID = table.Column<int>(type: "int", nullable: false),
                    RequestContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationReqDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChatID = table.Column<int>(type: "int", nullable: false),
                    ReqStateID = table.Column<int>(type: "int", nullable: false),
                    MembersNeeded = table.Column<int>(type: "int", nullable: false),
                    RequestPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RequestTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_Requests_Chats_ChatID",
                        column: x => x.ChatID,
                        principalTable: "Chats",
                        principalColumn: "ChatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Locations_LocationServiceID",
                        column: x => x.LocationServiceID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_RequestStates_ReqStateID",
                        column: x => x.ReqStateID,
                        principalTable: "RequestStates",
                        principalColumn: "ReqStateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Users_ApplicantUserID",
                        column: x => x.ApplicantUserID,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Requests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    ComplaintID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnsatisfiedUserID = table.Column<int>(type: "int", nullable: false),
                    AttenderUserID = table.Column<int>(type: "int", nullable: false),
                    ComplaintedUserID = table.Column<int>(type: "int", nullable: false),
                    RequestComplaintID = table.Column<int>(type: "int", nullable: false),
                    ComplaintMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaimentState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true),
                    UserId2 = table.Column<int>(type: "int", nullable: true),
                    UserId3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.ComplaintID);
                    table.ForeignKey(
                        name: "FK_Complaints_Requests_RequestComplaintID",
                        column: x => x.RequestComplaintID,
                        principalTable: "Requests",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Complaints_Users_AttenderUserID",
                        column: x => x.AttenderUserID,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Complaints_Users_ComplaintedUserID",
                        column: x => x.ComplaintedUserID,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Complaints_Users_UnsatisfiedUserID",
                        column: x => x.UnsatisfiedUserID,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Complaints_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Complaints_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Complaints_Users_UserId2",
                        column: x => x.UserId2,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Complaints_Users_UserId3",
                        column: x => x.UserId3,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    QualificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HelperUserID = table.Column<int>(type: "int", nullable: false),
                    ApplicantUserID = table.Column<int>(type: "int", nullable: false),
                    RequestID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.QualificationID);
                    table.ForeignKey(
                        name: "FK_Qualifications_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Qualifications_Users_ApplicantUserID",
                        column: x => x.ApplicantUserID,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Qualifications_Users_HelperUserID",
                        column: x => x.HelperUserID,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Qualifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Request_Areas",
                columns: table => new
                {
                    RequestAreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<int>(type: "int", nullable: false),
                    AreaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_Areas", x => x.RequestAreaID);
                    table.ForeignKey(
                        name: "FK_Request_Areas_Areas_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Areas",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Areas_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_RequestID",
                table: "Applications",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_RequestID1",
                table: "Applications",
                column: "RequestID1");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserID",
                table: "Applications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Aptitude_Users_AptitudeID",
                table: "Aptitude_Users",
                column: "AptitudeID");

            migrationBuilder.CreateIndex(
                name: "IX_Aptitude_Users_UserID",
                table: "Aptitude_Users",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionRequests_HelperUserID",
                table: "AttentionRequests",
                column: "HelperUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionRequests_PaymentRecordID",
                table: "AttentionRequests",
                column: "PaymentRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionRequests_RequestID",
                table: "AttentionRequests",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionRequests_RequestID1",
                table: "AttentionRequests",
                column: "RequestID1");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_RequestID",
                table: "Chats",
                column: "RequestID");

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
                name: "IX_Complaints_UnsatisfiedUserID",
                table: "Complaints",
                column: "UnsatisfiedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_UserId",
                table: "Complaints",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserID",
                table: "Contacts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Doubts_QuestionerID",
                table: "Doubts",
                column: "QuestionerID");

            migrationBuilder.CreateIndex(
                name: "IX_Doubts_ResponderID",
                table: "Doubts",
                column: "ResponderID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatID",
                table: "Messages",
                column: "ChatID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserChatID",
                table: "Messages",
                column: "UserChatID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecords_PMethodID",
                table: "PaymentRecords",
                column: "PMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_ApplicantUserID",
                table: "Qualifications",
                column: "ApplicantUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_HelperUserID",
                table: "Qualifications",
                column: "HelperUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_RequestID",
                table: "Qualifications",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_UserId",
                table: "Qualifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Areas_AreaID",
                table: "Request_Areas",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Areas_RequestID",
                table: "Request_Areas",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ApplicantUserID",
                table: "Requests",
                column: "ApplicantUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ChatID",
                table: "Requests",
                column: "ChatID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_LocationServiceID",
                table: "Requests",
                column: "LocationServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ReqStateID",
                table: "Requests",
                column: "ReqStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_CreatorID",
                table: "Tutorials",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationResidenceID",
                table: "Users",
                column: "LocationResidenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Requests_RequestID",
                table: "Applications",
                column: "RequestID",
                principalTable: "Requests",
                principalColumn: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Requests_RequestID1",
                table: "Applications",
                column: "RequestID1",
                principalTable: "Requests",
                principalColumn: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_AttentionRequests_Requests_RequestID",
                table: "AttentionRequests",
                column: "RequestID",
                principalTable: "Requests",
                principalColumn: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_AttentionRequests_Requests_RequestID1",
                table: "AttentionRequests",
                column: "RequestID1",
                principalTable: "Requests",
                principalColumn: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Requests_RequestID",
                table: "Chats",
                column: "RequestID",
                principalTable: "Requests",
                principalColumn: "RequestID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Requests_RequestID",
                table: "Chats");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Aptitude_Users");

            migrationBuilder.DropTable(
                name: "AttentionRequests");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Doubts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "Request_Areas");

            migrationBuilder.DropTable(
                name: "Tutorials");

            migrationBuilder.DropTable(
                name: "Aptitudes");

            migrationBuilder.DropTable(
                name: "PaymentRecords");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "PayMethods");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "RequestStates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

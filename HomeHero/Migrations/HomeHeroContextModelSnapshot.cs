﻿// <auto-generated />
using System;
using HomeHero.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeHero.Migrations
{
    [DbContext(typeof(HomeHeroContext))]
    partial class HomeHeroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HomeHero.Models.Application", b =>
                {
                    b.Property<int>("ApplicantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicantID"));

                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.Property<int?>("RequestID1")
                        .HasColumnType("int");

                    b.Property<decimal>("RequestedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ApplicantID");

                    b.HasIndex("RequestID");

                    b.HasIndex("RequestID1");

                    b.HasIndex("UserID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("HomeHero.Models.Aptitude", b =>
                {
                    b.Property<int>("AptitudeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AptitudeID"));

                    b.Property<string>("AptitudeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AptitudeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AptitudeID");

                    b.ToTable("Aptitudes");
                });

            modelBuilder.Entity("HomeHero.Models.Aptitude_User", b =>
                {
                    b.Property<int>("UserApID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserApID"));

                    b.Property<int>("AptitudeID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UserApID");

                    b.HasIndex("AptitudeID");

                    b.HasIndex("UserID");

                    b.ToTable("Aptitude_Users");
                });

            modelBuilder.Entity("HomeHero.Models.Area", b =>
                {
                    b.Property<int>("AreaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaID"));

                    b.Property<int>("NameArea")
                        .HasColumnType("int");

                    b.HasKey("AreaID");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("HomeHero.Models.AttentionRequest", b =>
                {
                    b.Property<int>("AttentionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttentionID"));

                    b.Property<DateTime>("AttentionDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("AttentionReqValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HelperUserID")
                        .HasColumnType("int");

                    b.Property<int>("PaymentRecordID")
                        .HasColumnType("int");

                    b.Property<int>("Qualification")
                        .HasColumnType("int");

                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.Property<int?>("RequestID1")
                        .HasColumnType("int");

                    b.HasKey("AttentionID");

                    b.HasIndex("HelperUserID");

                    b.HasIndex("PaymentRecordID");

                    b.HasIndex("RequestID");

                    b.HasIndex("RequestID1");

                    b.ToTable("AttentionRequests");
                });

            modelBuilder.Entity("HomeHero.Models.Chat", b =>
                {
                    b.Property<int>("ChatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatID"));

                    b.Property<DateTime>("ChatCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.HasKey("ChatID");

                    b.HasIndex("RequestID");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("HomeHero.Models.Complaint", b =>
                {
                    b.Property<int>("ComplaintID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplaintID"));

                    b.Property<int>("AttenderUserID")
                        .HasColumnType("int");

                    b.Property<string>("ComplaimentState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComplaintMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ComplaintedUserID")
                        .HasColumnType("int");

                    b.Property<int>("RequestComplaintID")
                        .HasColumnType("int");

                    b.Property<int>("UnsatisfiedUserID")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.Property<int?>("UserId2")
                        .HasColumnType("int");

                    b.Property<int?>("UserId3")
                        .HasColumnType("int");

                    b.HasKey("ComplaintID");

                    b.HasIndex("AttenderUserID");

                    b.HasIndex("ComplaintedUserID");

                    b.HasIndex("RequestComplaintID");

                    b.HasIndex("UnsatisfiedUserID");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.HasIndex("UserId2");

                    b.HasIndex("UserId3");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("HomeHero.Models.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"));

                    b.Property<string>("EmailUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ContactID");

                    b.HasIndex("UserID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("HomeHero.Models.Doubt", b =>
                {
                    b.Property<int>("DoubtID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoubtID"));

                    b.Property<string>("AnswerContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AnswerDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("QuestionContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("QuestionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuestionerID")
                        .HasColumnType("int");

                    b.Property<int>("ResponderID")
                        .HasColumnType("int");

                    b.HasKey("DoubtID");

                    b.HasIndex("QuestionerID");

                    b.HasIndex("ResponderID");

                    b.ToTable("Doubts");
                });

            modelBuilder.Entity("HomeHero.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("HomeHero.Models.Message", b =>
                {
                    b.Property<int>("MesaggeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MesaggeID"));

                    b.Property<int>("ChatID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateMessage")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserChatID")
                        .HasColumnType("int");

                    b.HasKey("MesaggeID");

                    b.HasIndex("ChatID");

                    b.HasIndex("UserChatID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("HomeHero.Models.PayMethod", b =>
                {
                    b.Property<int>("PMethodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PMethodID"));

                    b.Property<string>("NamePMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PMethodID");

                    b.ToTable("PayMethods");
                });

            modelBuilder.Entity("HomeHero.Models.PaymentRecord", b =>
                {
                    b.Property<int>("PRecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PRecordID"));

                    b.Property<int>("PMethodID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PaymentReceipt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PRecordID");

                    b.HasIndex("PMethodID");

                    b.ToTable("PaymentRecords");
                });

            modelBuilder.Entity("HomeHero.Models.Qualification", b =>
                {
                    b.Property<int>("QualificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QualificationID"));

                    b.Property<int>("ApplicantUserID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HelperUserID")
                        .HasColumnType("int");

                    b.Property<decimal>("QualificationNumber")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("QualificationID");

                    b.HasIndex("ApplicantUserID");

                    b.HasIndex("HelperUserID");

                    b.HasIndex("RequestID");

                    b.HasIndex("UserId");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("HomeHero.Models.Request", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestID"));

                    b.Property<int>("ApplicantUserID")
                        .HasColumnType("int");

                    b.Property<int>("ChatID")
                        .HasColumnType("int");

                    b.Property<int>("LocationServiceID")
                        .HasColumnType("int");

                    b.Property<int>("MembersNeeded")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationReqDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReqStateID")
                        .HasColumnType("int");

                    b.Property<string>("RequestContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RequestPicture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RequestTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RequestID");

                    b.HasIndex("ApplicantUserID");

                    b.HasIndex("ChatID");

                    b.HasIndex("LocationServiceID");

                    b.HasIndex("ReqStateID");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("HomeHero.Models.RequestState", b =>
                {
                    b.Property<int>("ReqStateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReqStateID"));

                    b.Property<int>("NameState")
                        .HasColumnType("int");

                    b.HasKey("ReqStateID");

                    b.ToTable("RequestStates");
                });

            modelBuilder.Entity("HomeHero.Models.Request_Area", b =>
                {
                    b.Property<int>("RequestAreaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestAreaID"));

                    b.Property<int>("AreaID")
                        .HasColumnType("int");

                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.HasKey("RequestAreaID");

                    b.HasIndex("AreaID");

                    b.HasIndex("RequestID");

                    b.ToTable("Request_Areas");
                });

            modelBuilder.Entity("HomeHero.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("NameRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HomeHero.Models.Tutorial", b =>
                {
                    b.Property<int>("TutorialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorialID"));

                    b.Property<int>("CreatorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TutorialIPDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TutorialLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TutorialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TutorialID");

                    b.HasIndex("CreatorID");

                    b.ToTable("Tutorials");
                });

            modelBuilder.Entity("HomeHero.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<byte[]>("Curriculum")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationResidenceID")
                        .HasColumnType("int");

                    b.Property<string>("NamesUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QualificationUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("RealUserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<string>("SexUser")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("SurnamesUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("VolunteerPermises")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("UserId");

                    b.HasIndex("LocationResidenceID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HomeHero.Models.Application", b =>
                {
                    b.HasOne("HomeHero.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.Request", null)
                        .WithMany("Applications")
                        .HasForeignKey("RequestID1");

                    b.HasOne("HomeHero.Models.User", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeHero.Models.Aptitude_User", b =>
                {
                    b.HasOne("HomeHero.Models.Aptitude", "Aptitude")
                        .WithMany("Aptitude_Users")
                        .HasForeignKey("AptitudeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.User", "User")
                        .WithMany("Aptitude_Users")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aptitude");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeHero.Models.AttentionRequest", b =>
                {
                    b.HasOne("HomeHero.Models.User", "User")
                        .WithMany("AttentionRequests")
                        .HasForeignKey("HelperUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.PaymentRecord", "PaymentRecord")
                        .WithMany()
                        .HasForeignKey("PaymentRecordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.Request", null)
                        .WithMany("AttentionRequests")
                        .HasForeignKey("RequestID1");

                    b.Navigation("PaymentRecord");

                    b.Navigation("Request");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeHero.Models.Chat", b =>
                {
                    b.HasOne("HomeHero.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("HomeHero.Models.Complaint", b =>
                {
                    b.HasOne("HomeHero.Models.User", "AttenderUser")
                        .WithMany()
                        .HasForeignKey("AttenderUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.User", "ComplaintedUser")
                        .WithMany()
                        .HasForeignKey("ComplaintedUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.Request", "Request")
                        .WithMany("Complaints")
                        .HasForeignKey("RequestComplaintID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.User", "UnsatisfiedUser")
                        .WithMany()
                        .HasForeignKey("UnsatisfiedUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.User", null)
                        .WithMany("AttenderUsers")
                        .HasForeignKey("UserId");

                    b.HasOne("HomeHero.Models.User", null)
                        .WithMany("ComplaintedUsers")
                        .HasForeignKey("UserId1");

                    b.HasOne("HomeHero.Models.User", null)
                        .WithMany("Complaints")
                        .HasForeignKey("UserId2");

                    b.HasOne("HomeHero.Models.User", null)
                        .WithMany("UnsatisfiedUsers")
                        .HasForeignKey("UserId3");

                    b.Navigation("AttenderUser");

                    b.Navigation("ComplaintedUser");

                    b.Navigation("Request");

                    b.Navigation("UnsatisfiedUser");
                });

            modelBuilder.Entity("HomeHero.Models.Contact", b =>
                {
                    b.HasOne("HomeHero.Models.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeHero.Models.Doubt", b =>
                {
                    b.HasOne("HomeHero.Models.User", "Questioner")
                        .WithMany("Doubts")
                        .HasForeignKey("QuestionerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.User", "Responder")
                        .WithMany()
                        .HasForeignKey("ResponderID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Questioner");

                    b.Navigation("Responder");
                });

            modelBuilder.Entity("HomeHero.Models.Message", b =>
                {
                    b.HasOne("HomeHero.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserChatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeHero.Models.PaymentRecord", b =>
                {
                    b.HasOne("HomeHero.Models.PayMethod", "PayMethod")
                        .WithMany("PaymentRecords")
                        .HasForeignKey("PMethodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PayMethod");
                });

            modelBuilder.Entity("HomeHero.Models.Qualification", b =>
                {
                    b.HasOne("HomeHero.Models.User", "ApplicantUser")
                        .WithMany()
                        .HasForeignKey("ApplicantUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.User", "HelperUser")
                        .WithMany()
                        .HasForeignKey("HelperUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.Request", "Request")
                        .WithMany("Qualifications")
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.User", null)
                        .WithMany("Qualifications")
                        .HasForeignKey("UserId");

                    b.Navigation("ApplicantUser");

                    b.Navigation("HelperUser");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("HomeHero.Models.Request", b =>
                {
                    b.HasOne("HomeHero.Models.User", "ApplicantUser")
                        .WithMany()
                        .HasForeignKey("ApplicantUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.Location", "Location")
                        .WithMany("Requests")
                        .HasForeignKey("LocationServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.RequestState", "RequestState")
                        .WithMany("Requests")
                        .HasForeignKey("ReqStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.User", null)
                        .WithMany("Requests")
                        .HasForeignKey("UserId");

                    b.Navigation("ApplicantUser");

                    b.Navigation("Chat");

                    b.Navigation("Location");

                    b.Navigation("RequestState");
                });

            modelBuilder.Entity("HomeHero.Models.Request_Area", b =>
                {
                    b.HasOne("HomeHero.Models.Area", "Area")
                        .WithMany("Request_Areas")
                        .HasForeignKey("AreaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.Request", "Request")
                        .WithMany("Request_Areas")
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("HomeHero.Models.Tutorial", b =>
                {
                    b.HasOne("HomeHero.Models.User", "User")
                        .WithMany("Tutorials")
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeHero.Models.User", b =>
                {
                    b.HasOne("HomeHero.Models.Location", "Location")
                        .WithMany("Users")
                        .HasForeignKey("LocationResidenceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HomeHero.Models.Aptitude", b =>
                {
                    b.Navigation("Aptitude_Users");
                });

            modelBuilder.Entity("HomeHero.Models.Area", b =>
                {
                    b.Navigation("Request_Areas");
                });

            modelBuilder.Entity("HomeHero.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("HomeHero.Models.Location", b =>
                {
                    b.Navigation("Requests");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HomeHero.Models.PayMethod", b =>
                {
                    b.Navigation("PaymentRecords");
                });

            modelBuilder.Entity("HomeHero.Models.Request", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("AttentionRequests");

                    b.Navigation("Complaints");

                    b.Navigation("Qualifications");

                    b.Navigation("Request_Areas");
                });

            modelBuilder.Entity("HomeHero.Models.RequestState", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("HomeHero.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("HomeHero.Models.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Aptitude_Users");

                    b.Navigation("AttenderUsers");

                    b.Navigation("AttentionRequests");

                    b.Navigation("ComplaintedUsers");

                    b.Navigation("Complaints");

                    b.Navigation("Contacts");

                    b.Navigation("Doubts");

                    b.Navigation("Messages");

                    b.Navigation("Qualifications");

                    b.Navigation("Requests");

                    b.Navigation("Tutorials");

                    b.Navigation("UnsatisfiedUsers");
                });
#pragma warning restore 612, 618
        }
    }
}

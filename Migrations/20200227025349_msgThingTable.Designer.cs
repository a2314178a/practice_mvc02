﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using practice_mvc02.Repositories;

namespace practice_mvc02.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20200227025349_msgThingTable")]
    partial class msgThingTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("practice_mvc02.Models.dataTable.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accLV")
                        .HasColumnType("int");

                    b.Property<string>("account")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("departmentID")
                        .HasColumnType("int");

                    b.Property<int>("groupID")
                        .HasColumnType("int");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<string>("loginTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("timeRuleID")
                        .HasColumnType("int");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("userName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("account")
                        .IsUnique();

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("department")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<string>("position")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("principalID")
                        .HasColumnType("int");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("department", "position", "principalID")
                        .IsUnique();

                    b.ToTable("departments");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.EmployeeDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("humanID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<DateTime>("startWorkDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("accountID")
                        .IsUnique();

                    b.ToTable("employeedetails");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.GroupRule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("groupName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<int>("ruleParameter")
                        .HasColumnType("int");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("grouprules");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.LeaveOfficeApply", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<int>("applyStatus")
                        .HasColumnType("int");

                    b.Property<int>("applyType")
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<string>("note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("optionType")
                        .HasColumnType("int");

                    b.Property<int>("principalID")
                        .HasColumnType("int");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("leaveofficeapplys");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("message");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.MsgSendReceive", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<int>("messageID")
                        .HasColumnType("int");

                    b.Property<bool>("rDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("read")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("receiveID")
                        .HasColumnType("int");

                    b.Property<bool>("sDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("sendID")
                        .HasColumnType("int");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("msgsendreceive");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.PunchCardLog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("departmentID")
                        .HasColumnType("int");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<DateTime>("logDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("offlineTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("onlineTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("punchStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("accountID", "logDate")
                        .IsUnique();

                    b.ToTable("punchcardlogs");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.PunchLogWarn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("principalID")
                        .HasColumnType("int");

                    b.Property<int>("punchLogID")
                        .HasColumnType("int");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("warnStatus")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("punchLogID")
                        .IsUnique();

                    b.ToTable("punchlogwarns");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.SpecialDate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<string>("note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("specialdate");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.WorkTimeRule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("endTime")
                        .HasColumnType("time");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("lateTime")
                        .HasColumnType("time");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<TimeSpan>("startTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("startTime", "endTime")
                        .IsUnique();

                    b.ToTable("worktimerules");
                });
#pragma warning restore 612, 618
        }
    }
}
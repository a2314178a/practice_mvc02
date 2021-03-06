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
    [Migration("20200604053353_createOperateLogTB")]
    partial class createOperateLogTB
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
                        .HasColumnType("int")
                        .HasComment("1職員2單位主管3部門主管4處長廠長5協理6總經理7董事");

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

            modelBuilder.Entity("practice_mvc02.Models.dataTable.AnnualDaysOffset", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("emAnnualID")
                        .HasColumnType("int");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<string>("reason")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("value")
                        .HasColumnType("int")
                        .HasComment("unit:hour");

                    b.HasKey("ID");

                    b.ToTable("annualdaysoffset");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.AnnualLeaveRule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("buffDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<float>("seniority")
                        .HasColumnType("float")
                        .HasComment("unit:year");

                    b.Property<int>("specialDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("seniority")
                        .IsUnique();

                    b.ToTable("annualleaverule");
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

            modelBuilder.Entity("practice_mvc02.Models.dataTable.EmployeeAnnualLeave", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("deadLine")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("employeeID")
                        .HasColumnType("int");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<float>("remainHours")
                        .HasColumnType("float");

                    b.Property<int>("ruleID")
                        .HasColumnType("int");

                    b.Property<int>("specialDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("employeeannualleaves");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.EmployeeDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<bool>("agentEnable")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("humanID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<int>("myAgentID")
                        .HasColumnType("int");

                    b.Property<int>("sex")
                        .HasColumnType("int(1)");

                    b.Property<DateTime>("startWorkDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("accountID")
                        .IsUnique();

                    b.ToTable("employeedetails");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.EmployeePrincipal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("employeeID")
                        .HasColumnType("int")
                        .HasComment("員工ID");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<int>("principalAgentID")
                        .HasColumnType("int")
                        .HasComment("主管代理人ID");

                    b.Property<int>("principalID")
                        .HasColumnType("int")
                        .HasComment("主管ID");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("employeeprincipals");
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

            modelBuilder.Entity("practice_mvc02.Models.dataTable.LeaveName", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<string>("leaveName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("timeUnit")
                        .HasColumnType("int")
                        .HasComment("1:全天 2:半天 3:小時");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("leavenames");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.LeaveOfficeApply", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<int>("applyStatus")
                        .HasColumnType("int")
                        .HasComment("0:申請中 1:通過 2:沒通過");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<int>("leaveID")
                        .HasColumnType("int");

                    b.Property<string>("note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("optionType")
                        .HasColumnType("int");

                    b.Property<int>("principalID")
                        .HasColumnType("int");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime(6)");

                    b.Property<byte>("unit")
                        .HasColumnType("tinyint unsigned")
                        .HasComment("1:全天 2:半天 3:小時");

                    b.Property<float>("unitVal")
                        .HasColumnType("float");

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

                    b.Property<int>("read")
                        .HasColumnType("int(1)")
                        .HasComment("0:未讀 1:已讀");

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

            modelBuilder.Entity("practice_mvc02.Models.dataTable.OperateLog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("active")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("category")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("employeeID")
                        .HasColumnType("int");

                    b.Property<int>("operateID")
                        .HasColumnType("int");

                    b.Property<string>("remark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("operateLogs");
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
                        .HasColumnType("int")
                        .HasComment("0x01:正常 0x02:遲到 0x04:早退 0x08:加班 0x10:缺卡 0x20:曠職 0x40:請假");

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
                        .HasColumnType("int")
                        .HasComment("0:未處理 1:已處理 2:忽略");

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

                    b.Property<string>("departClass")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<string>("note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("status")
                        .HasColumnType("int")
                        .HasComment("1:休假 2:上班");

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

                    b.Property<TimeSpan>("eRestTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("endTime")
                        .HasColumnType("time");

                    b.Property<int>("lastOperaAccID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("lateTime")
                        .HasColumnType("time");

                    b.Property<string>("name")
                        .HasColumnType("varchar(255)");

                    b.Property<TimeSpan>("sRestTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("startTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("startTime", "endTime")
                        .IsUnique();

                    b.ToTable("worktimerules");
                });

            modelBuilder.Entity("practice_mvc02.Models.dataTable.workTimeTotal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dateMonth")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("totalTime")
                        .HasColumnType("double")
                        .HasComment("unit : minute");

                    b.Property<DateTime>("updateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("accountID", "dateMonth")
                        .IsUnique();

                    b.ToTable("worktimetotals");
                });
#pragma warning restore 612, 618
        }
    }
}

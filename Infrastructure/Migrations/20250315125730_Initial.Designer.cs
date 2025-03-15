﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SportNest.Infrastructure;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250315125730_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Attendance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsAttending")
                        .HasColumnType("boolean")
                        .HasColumnName("is_attending");

                    b.Property<long>("TrainingSessionId")
                        .HasColumnType("bigint")
                        .HasColumnName("training_session_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_attendance");

                    b.HasIndex("TrainingSessionId")
                        .HasDatabaseName("ix_attendance_training_session_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_attendance_user_id");

                    b.ToTable("attendance", (string)null);
                });

            modelBuilder.Entity("Domain.Club", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now() AT TIME ZONE 'UTC'");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_club");

                    b.ToTable("club", (string)null);
                });

            modelBuilder.Entity("Domain.ClubRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ClubId")
                        .HasColumnType("bigint")
                        .HasColumnName("club_id");

                    b.Property<string>("PermissionsJson")
                        .HasColumnType("text")
                        .HasColumnName("permissions_json");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_name");

                    b.HasKey("Id")
                        .HasName("pk_club_role");

                    b.HasIndex("ClubId")
                        .HasDatabaseName("ix_club_role_club_id");

                    b.ToTable("club_role", (string)null);
                });

            modelBuilder.Entity("Domain.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ClubId")
                        .HasColumnType("bigint")
                        .HasColumnName("club_id");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("department_name");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_department");

                    b.HasIndex("ClubId")
                        .HasDatabaseName("ix_department_club_id");

                    b.ToTable("department", (string)null);
                });

            modelBuilder.Entity("Domain.DepartmentKPI", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint")
                        .HasColumnName("department_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_department_kpi");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_department_kpi_department_id");

                    b.ToTable("department_kpi", (string)null);
                });

            modelBuilder.Entity("Domain.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint")
                        .HasColumnName("department_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("group_name");

                    b.HasKey("Id")
                        .HasName("pk_group");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_group_department_id");

                    b.ToTable("group", (string)null);
                });

            modelBuilder.Entity("Domain.GroupKPI", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("DepartmentKPIId")
                        .HasColumnType("bigint")
                        .HasColumnName("department_kpi_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint")
                        .HasColumnName("group_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_group_kpi");

                    b.HasIndex("DepartmentKPIId")
                        .HasDatabaseName("ix_group_kpi_department_kpi_id");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_group_kpi_group_id");

                    b.ToTable("group_kpi", (string)null);
                });

            modelBuilder.Entity("Domain.MembershipRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ClubRoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("club_role_id");

                    b.Property<long>("UserClubMembershipId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_club_membership_id");

                    b.HasKey("Id")
                        .HasName("pk_membership_role");

                    b.HasIndex("ClubRoleId")
                        .HasDatabaseName("ix_membership_role_club_role_id");

                    b.HasIndex("UserClubMembershipId")
                        .HasDatabaseName("ix_membership_role_user_club_membership_id");

                    b.ToTable("membership_role", (string)null);
                });

            modelBuilder.Entity("Domain.Option", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ClubId")
                        .HasColumnType("bigint")
                        .HasColumnName("club_id");

                    b.Property<long?>("DepartmentId")
                        .HasColumnType("bigint")
                        .HasColumnName("department_id");

                    b.Property<long?>("GroupId")
                        .HasColumnType("bigint")
                        .HasColumnName("group_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_option");

                    b.HasIndex("ClubId")
                        .HasDatabaseName("ix_option_club_id");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_option_department_id");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_option_group_id");

                    b.ToTable("option", (string)null);
                });

            modelBuilder.Entity("Domain.TrainingSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint")
                        .HasColumnName("group_id");

                    b.Property<string>("Location")
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<DateTime>("SessionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("session_date")
                        .HasDefaultValueSql("now() AT TIME ZONE 'UTC'");

                    b.HasKey("Id")
                        .HasName("pk_training_session");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_training_session_group_id");

                    b.ToTable("training_session", (string)null);
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("display_name");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_user_email");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasDatabaseName("ix_user_phone_number");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Domain.UserClubMembership", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ClubId")
                        .HasColumnType("bigint")
                        .HasColumnName("club_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_club_membership");

                    b.HasIndex("ClubId")
                        .HasDatabaseName("ix_user_club_membership_club_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_club_membership_user_id");

                    b.ToTable("user_club_membership", (string)null);
                });

            modelBuilder.Entity("Domain.UserGroupKPIValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("GroupKPIId")
                        .HasColumnType("bigint")
                        .HasColumnName("group_kpi_id");

                    b.Property<int>("IntValue")
                        .HasColumnType("integer")
                        .HasColumnName("int_value");

                    b.Property<string>("TextValue")
                        .HasColumnType("text")
                        .HasColumnName("text_value");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_group_kpi_value");

                    b.HasIndex("GroupKPIId")
                        .HasDatabaseName("ix_user_group_kpi_value_group_kpi_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_group_kpi_value_user_id");

                    b.ToTable("user_group_kpi_value", (string)null);
                });

            modelBuilder.Entity("Domain.Attendance", b =>
                {
                    b.HasOne("Domain.TrainingSession", "TrainingSession")
                        .WithMany("Attendances")
                        .HasForeignKey("TrainingSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_attendance_training_session_training_session_id");

                    b.HasOne("Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_attendance_user_user_id");

                    b.Navigation("TrainingSession");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.ClubRole", b =>
                {
                    b.HasOne("Domain.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_club_role_club_club_id");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("Domain.Department", b =>
                {
                    b.HasOne("Domain.Club", "Club")
                        .WithMany("Departments")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_department_club_club_id");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("Domain.DepartmentKPI", b =>
                {
                    b.HasOne("Domain.Department", "Department")
                        .WithMany("DepartmentKPIs")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_department_kpi_department_department_id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Domain.Group", b =>
                {
                    b.HasOne("Domain.Department", "Department")
                        .WithMany("Groups")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_group_department_department_id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Domain.GroupKPI", b =>
                {
                    b.HasOne("Domain.DepartmentKPI", "DepartmentKPI")
                        .WithMany("GroupKPIs")
                        .HasForeignKey("DepartmentKPIId")
                        .HasConstraintName("fk_group_kpi_department_kpi_department_kpi_id");

                    b.HasOne("Domain.Group", "Group")
                        .WithMany("GroupKPIs")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_group_kpi_group_group_id");

                    b.Navigation("DepartmentKPI");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Domain.MembershipRole", b =>
                {
                    b.HasOne("Domain.ClubRole", "ClubRole")
                        .WithMany("MembershipRoles")
                        .HasForeignKey("ClubRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_membership_role_club_role_club_role_id");

                    b.HasOne("Domain.UserClubMembership", "UserClubMembership")
                        .WithMany("MembershipRoles")
                        .HasForeignKey("UserClubMembershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_membership_role_user_club_membership_user_club_membership_id");

                    b.Navigation("ClubRole");

                    b.Navigation("UserClubMembership");
                });

            modelBuilder.Entity("Domain.Option", b =>
                {
                    b.HasOne("Domain.Club", "Club")
                        .WithMany("Options")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_option_club_club_id");

                    b.HasOne("Domain.Department", "Department")
                        .WithMany("Options")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_option_department_department_id");

                    b.HasOne("Domain.Group", "Group")
                        .WithMany("Options")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_option_group_group_id");

                    b.Navigation("Club");

                    b.Navigation("Department");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Domain.TrainingSession", b =>
                {
                    b.HasOne("Domain.Group", "Group")
                        .WithMany("TrainingSessions")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_training_session_group_group_id");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Domain.UserClubMembership", b =>
                {
                    b.HasOne("Domain.Club", "Club")
                        .WithMany("Memberships")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_club_membership_club_club_id");

                    b.HasOne("Domain.User", "User")
                        .WithMany("UserClubMemberships")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_club_membership_user_user_id");

                    b.Navigation("Club");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.UserGroupKPIValue", b =>
                {
                    b.HasOne("Domain.GroupKPI", "GroupKPI")
                        .WithMany("UserGroupKPIValues")
                        .HasForeignKey("GroupKPIId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_group_kpi_value_group_kpi_group_kpi_id");

                    b.HasOne("Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_group_kpi_value_user_user_id");

                    b.Navigation("GroupKPI");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Club", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Memberships");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("Domain.ClubRole", b =>
                {
                    b.Navigation("MembershipRoles");
                });

            modelBuilder.Entity("Domain.Department", b =>
                {
                    b.Navigation("DepartmentKPIs");

                    b.Navigation("Groups");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("Domain.DepartmentKPI", b =>
                {
                    b.Navigation("GroupKPIs");
                });

            modelBuilder.Entity("Domain.Group", b =>
                {
                    b.Navigation("GroupKPIs");

                    b.Navigation("Options");

                    b.Navigation("TrainingSessions");
                });

            modelBuilder.Entity("Domain.GroupKPI", b =>
                {
                    b.Navigation("UserGroupKPIValues");
                });

            modelBuilder.Entity("Domain.TrainingSession", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("UserClubMemberships");
                });

            modelBuilder.Entity("Domain.UserClubMembership", b =>
                {
                    b.Navigation("MembershipRoles");
                });
#pragma warning restore 612, 618
        }
    }
}

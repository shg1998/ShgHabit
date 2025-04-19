﻿// <auto-generated />
using System;
using DevHabbit.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DevHabbit.Api.Migrations.Application
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250419110318_Add_Habbits")]
    partial class Add_Habbits
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dev-habbit")
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DevHabbit.Api.Entities.Habbit", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CREATED_AT_UTC");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("END_DATE");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean")
                        .HasColumnName("IS_ARCHIVED");

                    b.Property<DateTime?>("LastCompletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LAST_COMPLETED_AT_UTC");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("NAME");

                    b.Property<int>("Statue")
                        .HasColumnType("integer")
                        .HasColumnName("STATUE");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("TYPE");

                    b.Property<DateTime?>("UpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UPDATED_AT_UTC");

                    b.HasKey("Id")
                        .HasName("PK_HABBITS");

                    b.ToTable("HABBITS", "dev-habbit");
                });

            modelBuilder.Entity("DevHabbit.Api.Entities.Habbit", b =>
                {
                    b.OwnsOne("DevHabbit.Api.Entities.Frequency", "Frequency", b1 =>
                        {
                            b1.Property<string>("HabbitId")
                                .HasColumnType("character varying(500)")
                                .HasColumnName("ID");

                            b1.Property<int>("TimesPerPeriod")
                                .HasColumnType("integer")
                                .HasColumnName("FREQUENCY_TIMES_PER_PERIOD");

                            b1.Property<int>("Type")
                                .HasColumnType("integer")
                                .HasColumnName("FREQUENCY_TYPE");

                            b1.HasKey("HabbitId");

                            b1.ToTable("HABBITS", "dev-habbit");

                            b1.WithOwner()
                                .HasForeignKey("HabbitId")
                                .HasConstraintName("FK_HABBITS_HABBITS_ID");
                        });

                    b.OwnsOne("DevHabbit.Api.Entities.Milestone", "Milestone", b1 =>
                        {
                            b1.Property<string>("HabbitId")
                                .HasColumnType("character varying(500)")
                                .HasColumnName("ID");

                            b1.Property<int>("Current")
                                .HasColumnType("integer")
                                .HasColumnName("MILESTONE_CURRENT");

                            b1.Property<int>("Target")
                                .HasColumnType("integer")
                                .HasColumnName("MILESTONE_TARGET");

                            b1.HasKey("HabbitId");

                            b1.ToTable("HABBITS", "dev-habbit");

                            b1.WithOwner()
                                .HasForeignKey("HabbitId")
                                .HasConstraintName("FK_HABBITS_HABBITS_ID");
                        });

                    b.OwnsOne("DevHabbit.Api.Entities.Target", "Target", b1 =>
                        {
                            b1.Property<string>("HabbitId")
                                .HasColumnType("character varying(500)")
                                .HasColumnName("ID");

                            b1.Property<string>("Unit")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("TARGET_UNIT");

                            b1.Property<int>("Value")
                                .HasColumnType("integer")
                                .HasColumnName("TARGET_VALUE");

                            b1.HasKey("HabbitId");

                            b1.ToTable("HABBITS", "dev-habbit");

                            b1.WithOwner()
                                .HasForeignKey("HabbitId")
                                .HasConstraintName("FK_HABBITS_HABBITS_ID");
                        });

                    b.Navigation("Frequency")
                        .IsRequired();

                    b.Navigation("Milestone");

                    b.Navigation("Target")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

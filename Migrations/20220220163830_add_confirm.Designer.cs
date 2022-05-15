﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuiQue;

namespace QuiQue.Migrations
{
    [DbContext(typeof(QuickQueueContext))]
    [Migration("20220220163830_add_confirm")]
    partial class add_confirm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("QuiQue.Models.Event", b =>
                {
                    b.Property<long>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("event_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsSuspended")
                        .HasColumnType("boolean")
                        .HasColumnName("is_suspended");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint")
                        .HasColumnName("owner_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("WaitingTimer")
                        .HasColumnType("text")
                        .HasColumnName("waiting_timer");

                    b.Property<bool>("isFastQueue")
                        .HasColumnType("boolean")
                        .HasColumnName("is_fast_queue");

                    b.HasKey("EventId")
                        .HasName("pk_events");

                    b.HasIndex("OwnerId")
                        .HasDatabaseName("ix_events_owner_id");

                    b.ToTable("events");
                });

            modelBuilder.Entity("QuiQue.Models.Queue", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("EventId")
                        .HasColumnType("bigint")
                        .HasColumnName("event_id");

                    b.Property<long>("Number")
                        .HasColumnType("bigint")
                        .HasColumnName("number");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<DateTime>("Time_queue")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("time_queue");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.Property<long>("idUser")
                        .HasColumnType("bigint")
                        .HasColumnName("id_user");

                    b.HasKey("ID")
                        .HasName("pk_queues");

                    b.HasIndex("EventId")
                        .HasDatabaseName("ix_queues_event_id");

                    b.HasIndex("idUser")
                        .HasDatabaseName("ix_queues_id_user");

                    b.ToTable("queues");
                });

            modelBuilder.Entity("QuiQue.Models.User", b =>
                {
                    b.Property<long>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_user")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("idUser")
                        .HasName("pk_users");

                    b.ToTable("users");
                });

            modelBuilder.Entity("QuiQue.Models.Event", b =>
                {
                    b.HasOne("QuiQue.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("fk_events_users_owner_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("QuiQue.Models.Queue", b =>
                {
                    b.HasOne("QuiQue.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .HasConstraintName("fk_queues_events_event_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuiQue.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .HasConstraintName("fk_queues_users_id_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

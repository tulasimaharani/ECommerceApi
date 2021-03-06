﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PaymentApi.Data;

namespace PaymentApi.Migrations
{
    [DbContext(typeof(PaymentContext))]
    [Migration("20201227142940_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("PaymentApi.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Bandeira")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Cvv")
                        .HasColumnType("integer");

                    b.Property<string>("DataExpiracao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titular")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PaymentApi.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("CartaoId")
                        .HasColumnType("integer");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CartaoId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PaymentApi.Models.Payment", b =>
                {
                    b.HasOne("PaymentApi.Models.Card", "Cartao")
                        .WithMany()
                        .HasForeignKey("CartaoId");

                    b.Navigation("Cartao");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using back_end_mega_hack_5;

namespace back_end_mega_hack_5.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201114203321_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("back_end_mega_hack_5.Entidades.Boleto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataVencimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<int>("TipoBoletoId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("TipoBoletoId");

                    b.ToTable("Boleto");
                });

            modelBuilder.Entity("back_end_mega_hack_5.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("back_end_mega_hack_5.Entidades.ContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("ContaCorrente");
                });

            modelBuilder.Entity("back_end_mega_hack_5.Entidades.Lembrete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DataAviso")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataDoPagamento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<decimal>("ValorBoleto")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Lembrete");
                });

            modelBuilder.Entity("back_end_mega_hack_5.Entidades.TipoBoleto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TipoBoleto");
                });

            modelBuilder.Entity("back_end_mega_hack_5.Entidades.Boleto", b =>
                {
                    b.HasOne("back_end_mega_hack_5.Entidades.TipoBoleto", "TipoBoleto")
                        .WithMany("Boletos")
                        .HasForeignKey("TipoBoletoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("back_end_mega_hack_5.Entidades.ContaCorrente", b =>
                {
                    b.HasOne("back_end_mega_hack_5.Entidades.Cliente", "Cliente")
                        .WithOne("ContaCorrente")
                        .HasForeignKey("back_end_mega_hack_5.Entidades.ContaCorrente", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

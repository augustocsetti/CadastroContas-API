﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using API.Data;

#nullable disable

namespace Exercicio.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240304030216_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Exercicio.API.Models.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DataPagamento")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DataVencimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("DiasEmAtraso")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("ValorCorrigido")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorInicial")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Contas");
                });
#pragma warning restore 612, 618
        }
    }
}

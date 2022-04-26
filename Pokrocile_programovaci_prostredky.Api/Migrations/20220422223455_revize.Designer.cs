﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokrocile_programovaci_prostredky.Api.Data;

#nullable disable

namespace Pokrocile_programovaci_prostredky.Api.Migrations
{
    [DbContext(typeof(NemocniceDbContext))]
    [Migration("20220422223455_revize")]
    partial class revize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("Pokrocile_programovaci_prostredky.Api.Data.RevizeData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Revizes");
                });

            modelBuilder.Entity("Pokrocile_programovaci_prostredky.Api.Data.VybaveniData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BoughtDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastRevision")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("PriceCzk")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Vybavenis");
                });
#pragma warning restore 612, 618
        }
    }
}
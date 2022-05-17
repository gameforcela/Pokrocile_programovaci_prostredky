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
    [Migration("20220517134838_pracovnici")]
    partial class pracovnici
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("Pokrocile_programovaci_prostredky.Api.Data.PracovniciData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pracovnicis");
                });

            modelBuilder.Entity("Pokrocile_programovaci_prostredky.Api.Data.RevizeData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("VybaveniId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VybaveniId");

                    b.ToTable("Revizes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b21ec945-0b43-42b7-b900-900a95b1556b"),
                            DateTime = new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "fffff",
                            VybaveniId = new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a")
                        },
                        new
                        {
                            Id = new Guid("1754100a-54e7-4f14-a6aa-e23e09629ec1"),
                            DateTime = new DateTime(2019, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "dsdfegfg",
                            VybaveniId = new Guid("bc541f54-965f-45b2-a18b-aacf68e81c37")
                        },
                        new
                        {
                            Id = new Guid("c1287015-5d0c-4d87-bc3c-2170d64f1538"),
                            DateTime = new DateTime(2017, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "defdgdvdce",
                            VybaveniId = new Guid("555242cb-c93a-4f71-9350-eeb58c681e13")
                        },
                        new
                        {
                            Id = new Guid("9161e045-df3b-4e7e-a067-ddfc2c6dd083"),
                            DateTime = new DateTime(2018, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "ahojjjjdvdce",
                            VybaveniId = new Guid("555242cb-c93a-4f71-9350-eeb58c681e13")
                        },
                        new
                        {
                            Id = new Guid("23457a2a-2570-41e6-85cb-41a2dff0ea74"),
                            DateTime = new DateTime(2018, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "dvojice",
                            VybaveniId = new Guid("555242cb-c93a-4f71-9350-eeb58c681e13")
                        });
                });

            modelBuilder.Entity("Pokrocile_programovaci_prostredky.Api.Data.UkonData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("OutPutGood")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("PracovniciId")
                        .HasColumnType("TEXT");

                    b.Property<double>("PriceCzk")
                        .HasColumnType("REAL");

                    b.Property<Guid>("VybaveniId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PracovniciId");

                    b.HasIndex("VybaveniId");

                    b.ToTable("Ukonis");

                    b.HasData(
                        new
                        {
                            Id = new Guid("01e35d41-f75a-49b6-974b-1f1c85117ecf"),
                            DateTime = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "EEG",
                            OutPutGood = true,
                            PriceCzk = 22222.0,
                            VybaveniId = new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a")
                        },
                        new
                        {
                            Id = new Guid("b5f9d6be-6fec-4286-a66f-60aefbb92ee6"),
                            DateTime = new DateTime(2019, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Centerifuga",
                            OutPutGood = true,
                            PriceCzk = 10000000.0,
                            VybaveniId = new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a")
                        },
                        new
                        {
                            Id = new Guid("37306475-6e31-41d4-96e7-88810012bfd8"),
                            DateTime = new DateTime(2022, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ozáření",
                            OutPutGood = false,
                            PriceCzk = 555555555555.0,
                            VybaveniId = new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a")
                        },
                        new
                        {
                            Id = new Guid("6bd0a8a9-4e86-4db1-b22c-fcaa746fc6b7"),
                            DateTime = new DateTime(2018, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Depilace",
                            OutPutGood = true,
                            PriceCzk = 124577.0,
                            VybaveniId = new Guid("442a4ca6-e703-427e-a07b-a70619d5d3bd")
                        },
                        new
                        {
                            Id = new Guid("46ea0db9-bfaf-4bda-b9fc-d8f11359730c"),
                            DateTime = new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Opalování",
                            OutPutGood = false,
                            PriceCzk = 100.0,
                            VybaveniId = new Guid("7ec0f0ce-45ee-43a9-87c2-0e234c874f06")
                        });
                });

            modelBuilder.Entity("Pokrocile_programovaci_prostredky.Api.Data.VybaveniData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BoughtDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("PriceCzk")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Vybavenis");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a"),
                            BoughtDateTime = new DateTime(2020, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "XXX",
                            PriceCzk = 500.0
                        },
                        new
                        {
                            Id = new Guid("bc541f54-965f-45b2-a18b-aacf68e81c37"),
                            BoughtDateTime = new DateTime(2018, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "ZZZZ",
                            PriceCzk = 100.0
                        },
                        new
                        {
                            Id = new Guid("555242cb-c93a-4f71-9350-eeb58c681e13"),
                            BoughtDateTime = new DateTime(2017, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "yyyyy",
                            PriceCzk = 20.0
                        },
                        new
                        {
                            Id = new Guid("442a4ca6-e703-427e-a07b-a70619d5d3bd"),
                            BoughtDateTime = new DateTime(2016, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "yyfddgdsgdsfdsyy",
                            PriceCzk = 222220.0
                        },
                        new
                        {
                            Id = new Guid("7ec0f0ce-45ee-43a9-87c2-0e234c874f06"),
                            BoughtDateTime = new DateTime(2015, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "yyyyfdfdsfdfdsfy",
                            PriceCzk = 66666.0
                        });
                });

            modelBuilder.Entity("Pokrocile_programovaci_prostredky.Api.Data.RevizeData", b =>
                {
                    b.HasOne("Pokrocile_programovaci_prostredky.Api.Data.VybaveniData", "Vybaveni")
                        .WithMany("Revizions")
                        .HasForeignKey("VybaveniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vybaveni");
                });

            modelBuilder.Entity("Pokrocile_programovaci_prostredky.Api.Data.UkonData", b =>
                {
                    b.HasOne("Pokrocile_programovaci_prostredky.Api.Data.PracovniciData", "Pracovnici")
                        .WithMany()
                        .HasForeignKey("PracovniciId");

                    b.HasOne("Pokrocile_programovaci_prostredky.Api.Data.VybaveniData", "Vybaveni")
                        .WithMany("Ukonis")
                        .HasForeignKey("VybaveniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pracovnici");

                    b.Navigation("Vybaveni");
                });

            modelBuilder.Entity("Pokrocile_programovaci_prostredky.Api.Data.VybaveniData", b =>
                {
                    b.Navigation("Revizions");

                    b.Navigation("Ukonis");
                });
#pragma warning restore 612, 618
        }
    }
}

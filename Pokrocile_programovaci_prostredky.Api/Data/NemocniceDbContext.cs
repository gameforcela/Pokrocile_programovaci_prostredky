using Microsoft.EntityFrameworkCore;

namespace Pokrocile_programovaci_prostredky.Api.Data;
public class NemocniceDbContext : DbContext
{
    public NemocniceDbContext(DbContextOptions<NemocniceDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        Guid Id1 = new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a");
        Guid Id2 = new Guid("bc541f54-965f-45b2-a18b-aacf68e81c37");
        Guid Id3 = new Guid("555242cb-c93a-4f71-9350-eeb58c681e13");
        Guid Id4 = new Guid("442a4ca6-e703-427e-a07b-a70619d5d3bd");
        Guid Id5 = new Guid("7ec0f0ce-45ee-43a9-87c2-0e234c874f06");

        builder.Entity<VybaveniData>().HasData(
            new VybaveniData() { Id = Id1, Name = "XXX", BoughtDateTime = new DateTime(2020,6,9), PriceCzk=500},
            new VybaveniData() { Id = Id2, Name = "ZZZZ", BoughtDateTime = new DateTime(2018, 6, 9), PriceCzk = 100 },
            new VybaveniData() { Id = Id3, Name = "yyyyy", BoughtDateTime = new DateTime(2017, 6, 9), PriceCzk = 20 },
            new VybaveniData() { Id = Id4, Name = "yyfddgdsgdsfdsyy", BoughtDateTime = new DateTime(2016, 6, 9), PriceCzk = 222220 },
            new VybaveniData() { Id = Id5, Name = "yyyyfdfdsfdfdsfy", BoughtDateTime = new DateTime(2015, 6, 9), PriceCzk = 66666 });
        builder.Entity<RevizeData>().HasData(
            new RevizeData() { Id = new Guid("b21ec945-0b43-42b7-b900-900a95b1556b"), VybaveniId = Id1, DateTime = new DateTime(2021, 6, 9), Name="fffff" },
            new RevizeData() { Id = new Guid("1754100a-54e7-4f14-a6aa-e23e09629ec1"), VybaveniId = Id2, DateTime = new DateTime(2019, 6, 9), Name="dsdfegfg" },
            new RevizeData() { Id = new Guid("c1287015-5d0c-4d87-bc3c-2170d64f1538"), VybaveniId = Id3, DateTime = new DateTime(2017, 6, 9), Name="defdgdvdce" },
            new RevizeData() { Id = new Guid("9161e045-df3b-4e7e-a067-ddfc2c6dd083"), VybaveniId = Id3, DateTime = new DateTime(2018, 6, 9), Name = "ahojjjjdvdce" },
            new RevizeData() { Id = new Guid("23457a2a-2570-41e6-85cb-41a2dff0ea74"), VybaveniId = Id3, DateTime = new DateTime(2018, 6, 9), Name = "dvojice" }
            );
        builder.Entity<UkonData>().HasData(
           new UkonData() { Id = new Guid("01e35d41-f75a-49b6-974b-1f1c85117ecf"), VybaveniId = Id1, DateTime = new DateTime(2020, 6, 1), Name = "EEG", PriceCzk=22222, OutPutGood=true },
           new UkonData() { Id = new Guid("b5f9d6be-6fec-4286-a66f-60aefbb92ee6"), VybaveniId = Id1, DateTime = new DateTime(2019, 5, 9), Name = "Centerifuga", PriceCzk=10000000, OutPutGood=true },
           new UkonData() { Id = new Guid("37306475-6e31-41d4-96e7-88810012bfd8"), VybaveniId = Id1, DateTime = new DateTime(2022, 5, 12), Name = "Ozáření", PriceCzk=555555555555, OutPutGood =false },
           new UkonData() { Id = new Guid("6bd0a8a9-4e86-4db1-b22c-fcaa746fc6b7"), VybaveniId = Id4, DateTime = new DateTime(2018, 8, 8), Name = "Depilace", PriceCzk=124577, OutPutGood=true },
           new UkonData() { Id = new Guid("46ea0db9-bfaf-4bda-b9fc-d8f11359730c"), VybaveniId = Id5, DateTime = new DateTime(2019, 7, 1), Name = "Opalování", PriceCzk=100, OutPutGood=false }
           );
    }

    public DbSet<VybaveniData> Vybavenis => Set<VybaveniData>();
    public DbSet<RevizeData> Revizes => Set<RevizeData>();
    public DbSet<UkonData> Ukonis => Set<UkonData>();
    public DbSet<PracovniciData> Pracovnicis => Set<PracovniciData>();
}


using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pokrocile_programovaci_prostredky.Api.Data;
using PptNemocnice.Shared;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NemocniceDbContext>(
    opt => opt.UseSqlite("FileName=Nemocnice.db")
    );

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());    

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(corsOptions => corsOptions.AddDefaultPolicy(policy =>
    policy.WithOrigins(builder.Configuration["AllowedOrigins"])
    .WithMethods("GET", "POST", "PUT", "DELETE")
    .AllowAnyHeader()
));

builder.Services.AddControllers();

var app = builder.Build();  

app.UseCors();

app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<VybaveniModel> seznam = VybaveniModel.GetTestList();
List<RevizeModel> seznamRevize = RevizeModel.GetTestList();

app.MapGet("/", () => "Hello");

app.MapGet("/revize/{vyhledavanyRetezec}", (NemocniceDbContext db, string vyhledavanyRetezec) =>
{
    if (string.IsNullOrWhiteSpace(vyhledavanyRetezec)) return Results.Problem("Parametr musi byt neprazdny");
    var kdeJeRetezec = db.Revizes.Where(x => x.Name.Contains(vyhledavanyRetezec));
    return Results.Json(kdeJeRetezec);
});

app.MapPost("/revize", (RevizeModel prichoziModel,
    NemocniceDbContext db, IMapper mapper) =>
{
    prichoziModel.Id = Guid.Empty;//vynuluju id, db si idèka ošéfuje sama
    RevizeData ent = mapper.Map<RevizeData>(prichoziModel);//mapovaná na "databázový" typ
    db.Revizes.Add(ent);//pøidání do db
    db.SaveChanges();//uložení db (v tuto chvíli se vytvoøí id) 

    return Results.Created("/revize", ent.Id);

});

app.MapPost("/NewUkon", (UkonModel prichoziModel,
    NemocniceDbContext db, IMapper mapper) =>
{
    prichoziModel.Id = Guid.Empty;//vynuluju id, db si idèka ošéfuje sama
    UkonData ent = mapper.Map<UkonData>(prichoziModel);//mapovaná na "databázový" typ
    db.Ukonis.Add(ent);//pøidání do db
    db.SaveChanges();//uložení db (v tuto chvíli se vytvoøí id)

    return Results.Created("/NewUkon", ent.Id);
});

app.MapPost("/seed/{tajnyKod}", (string tajnyKod, IConfiguration config, NemocniceDbContext db) =>
{
    if (tajnyKod != config["seedSecrete"])
        return Results.NotFound();

    Random rnd = new();
    List<PracovniciData> pracanti = new();
    int pocetPracantu = 10;
    for (int i = 0; i < pocetPracantu; i++)
        pracanti.Add(new() { Name = RandomString(12) });

    db.AddRange(pracanti); db.SaveChanges();

    foreach (var vyb in db.Vybavenis)//pro každé vybavení
    {
        int pocetUkonu = rnd.Next(13, 25);
        for (int i = 0; i < pocetUkonu; i++)//se vytvoøí nìkolik úkonù
        {
            UkonData uk = new()
            {
                DateTime = DateTime.UtcNow.AddDays(rnd.Next(-100, -1)),
                Name = RandomString(56).Replace("x", " "),
                PriceCzk = rnd.Next(10, 1000000),
                VybaveniId = vyb.Id,//daného vybavení
                PracovniciId = pracanti[rnd.Next(pocetPracantu - 1)].Id
            };
            db.Ukonis.Add(uk);
        }
    }
    db.SaveChanges();

    return Results.Ok();

    string RandomString(int length) =>//lokální funkce
        new(Enumerable.Range(0, length).Select(_ => (char)rnd.Next('a', 'z')).ToArray());
});


app.Run();


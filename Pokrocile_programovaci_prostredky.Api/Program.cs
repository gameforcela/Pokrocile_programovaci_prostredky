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
    policy.WithOrigins("https://localhost:7124")
    .WithMethods("GET", "POST", "PUT", "DELETE")
    .AllowAnyHeader()
));

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<VybaveniModel> seznam = VybaveniModel.GetTestList();
List<RevizeModel> seznamRevize = RevizeModel.GetTestList();

app.MapGet("/vybaveni", (NemocniceDbContext db) =>
{
    return db.Vybavenis;
});

app.MapGet("/vybaveni/{Id}", (Guid Id, NemocniceDbContext db) =>
{
    var item = db.Find<VybaveniData>(Id);
    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!!");
    return Results.Ok(item);
});


app.MapPost("/vybaveni", (VybaveniModel prichoziModel,
    NemocniceDbContext db, IMapper mapper) =>
{
    prichoziModel.Id = Guid.Empty;//vynuluju id, db si idèka ošéfuje sama
    VybaveniData ent = mapper.Map<VybaveniData>(prichoziModel);//mapovaná na "databázový" typ
    db.Vybavenis.Add(ent);//pøidání do db
    db.SaveChanges();//uložení db (v tuto chvíli se vytvoøí id)

    return Results.Created("/vybaveni", ent.Id);
});

app.MapDelete("/vybaveni/{Id}", (Guid Id, NemocniceDbContext db, IMapper mapper) =>
{  
    var item = db.Find<VybaveniData>(Id);
    if (item == null) return Results.NotFound("Tato položka nebyla nalezena!!!");
    VybaveniData ent = mapper.Map<VybaveniData>(item);
    db.Vybavenis.Remove(ent);
    db.SaveChanges();
    return Results.Ok();
});


app.MapPut("/vybaveni", (VybaveniModel prichoziModel, NemocniceDbContext db, IMapper mapper) =>
{

    var staryZaznam = db.Vybavenis.SingleOrDefault(x => x.Id == prichoziModel.Id);
    if (staryZaznam == null) return Results.NotFound("Tento záznam není v seznamu");
    mapper.Map(prichoziModel, staryZaznam);
    db.SaveChanges();
    return Results.Ok();
});

app.MapGet("/revize/{vyhledavanyRetezec}", (NemocniceDbContext db, string vyhledavanyRetezec) =>
{
    if (string.IsNullOrWhiteSpace(vyhledavanyRetezec)) return Results.Problem("Parametr musi byt neprazdny");
    var kdeJeRetezec = db.Revizes.Where(x => x.Name.Contains(vyhledavanyRetezec));
    return Results.Json(kdeJeRetezec);
});

app.Run();

//record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
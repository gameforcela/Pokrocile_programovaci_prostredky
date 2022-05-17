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
    prichoziModel.Id = Guid.Empty;//vynuluju id, db si id�ka o��fuje sama
    RevizeData ent = mapper.Map<RevizeData>(prichoziModel);//mapovan� na "datab�zov�" typ
    db.Revizes.Add(ent);//p�id�n� do db
    db.SaveChanges();//ulo�en� db (v tuto chv�li se vytvo�� id) 

    return Results.Created("/revize", ent.Id);

});

app.MapPost("/NewUkon", (UkonModel prichoziModel,
    NemocniceDbContext db, IMapper mapper) =>
{
    prichoziModel.Id = Guid.Empty;//vynuluju id, db si id�ka o��fuje sama
    UkonData ent = mapper.Map<UkonData>(prichoziModel);//mapovan� na "datab�zov�" typ
    db.Ukonis.Add(ent);//p�id�n� do db
    db.SaveChanges();//ulo�en� db (v tuto chv�li se vytvo�� id)

    return Results.Created("/NewUkon", ent.Id);
});


app.Run();


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
    db.SaveChanges();//uložení db (v tuto chvíli se vytvoøí id) NEFUNGUJE!!!!!!!!!!!!!!!

    return Results.Created("/revize", ent.Id);


    //List<VybaveniData> models = new();
    //var ents = db.Vybavenis.Include(x => x.Revizions);
    //foreach (var ent in ents)
    //{
    //    VybaveniData vybaveni = mapper.Map<VybaveniData>(ent);
    //    models.Add(vybaveni);
    //}
    ////return Results.Json(models);
    //var zaznam = models.SingleOrDefault(x => x.Id == prichoziModel.Id);        

    //RevizeData newRevize = new RevizeData();
    //newRevize.Name = "sfasfdgdg";
    //newRevize.VybaveniDataID = prichoziModel.Id;
    //newRevize.DateTime = prichoziModel.LastRevision;
    //newRevize.Vybaveni = zaznam;
    //db.Revizes.Add(newRevize);//pøidání do db
    //db.SaveChanges();//uložení db (v tuto chvíli se vytvoøí id)

    //return Results.Created("/revize", newRevize.Id);
});

app.Run();


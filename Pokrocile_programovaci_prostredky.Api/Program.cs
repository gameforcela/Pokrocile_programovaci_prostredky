using PptNemocnice.Shared;
var builder = WebApplication.CreateBuilder(args);

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

app.MapGet("/vybaveni", () =>
{
    return seznam;
});

app.MapGet("/vybaveni/{Id}", (Guid Id) =>
{
    var item = seznam.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound("Tato polo�ka nebyla nalezena!!!");
    return Results.Ok(item);
});



app.MapPost("/vybaveni", (VybaveniModel prichoziModel) =>
{
    Guid ID = Guid.NewGuid();
    prichoziModel.Id = ID;
    seznam.Insert(0, prichoziModel);
    return Results.Created("/vybaveni", prichoziModel);
});

app.MapDelete("/vybaveni/{Id}", (Guid Id) =>
{
    var item = seznam.SingleOrDefault(x=> x.Id == Id);
    if (item == null)
        return Results.NotFound("Tato polo�ka nebyla nalezena!!!");
    seznam.Remove(item);
    return Results.Ok();
});


app.MapPut("/vybaveni", (VybaveniModel prichoziModel) =>
{
    var staryZaznam = seznam.SingleOrDefault(x => x.Id == prichoziModel.Id);
    if (staryZaznam == null) return Results.NotFound("Tento z�znam nen� v seznamu");
    int ind = seznam.IndexOf(staryZaznam);
    seznam.Insert(ind, prichoziModel);
    seznam.Remove(staryZaznam);
    return Results.Ok();
});

app.MapGet("/revize/{vyhledavanyRetezec}", (string vyhledavanyRetezec) =>
{
    if (string.IsNullOrWhiteSpace(vyhledavanyRetezec)) return Results.Problem("Parametr musi byt neprazdny");
    var kdeJeRetezec = seznamRevize.Where(x => x.Name.Contains(vyhledavanyRetezec));
    return Results.Json(kdeJeRetezec);
});

app.Run();

//record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
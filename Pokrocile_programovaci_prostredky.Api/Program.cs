using PptNemocnice.Shared;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<VybaveniModel> seznam = VybaveniModel.GetTestList();

app.MapGet("/vybaveni", () =>
{
    return seznam;
});

app.MapGet("/vybaveni/{Id}", (Guid Id) =>
{
    var item = seznam.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!!");
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
        return Results.NotFound("Tato položka nebyla nalezena!!!");
    seznam.Remove(item);
    return Results.Ok();
});


app.MapPut("/vybaveni/{Id}",(Guid Id, string jmeno, int prize) =>
{
    var item = seznam.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!!");
    var newItem = new VybaveniModel
    {
        Id = item.Id,
        Name = jmeno,
        BoughtDateTime = item.BoughtDateTime,
        LastRevision = item.LastRevision,
        IsInEditMode = item.IsInEditMode,
        PriceCzk = prize
    };
    seznam.Add(newItem);
    seznam.Remove(item);


    return Results.Ok();
});

app.Run();

//record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
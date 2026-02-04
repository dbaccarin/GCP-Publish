using Api.Models;
using Api.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMongoClient>(new MongoClient(builder.Configuration["ConnectionStrings:MongoConnection"]));

builder.Services.AddScoped<IMovieRepository>(provider => {
    var client = provider.GetRequiredService<IMongoClient>();
    return new MovieRepository(client);
});

BsonSerializer.RegisterSerializer(typeof(DateTime), new DateTimeSerializer(BsonType.DateTime));

BsonClassMap.RegisterClassMap<Movie>(b =>
    {
        b.AutoMap();
        b.MapMember(m => m.Title).SetElementName("title");
        b.MapMember(m => m.Runtime).SetElementName("runtime");
        b.MapMember(m => m.Released).SetElementName("released");       
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

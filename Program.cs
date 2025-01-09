using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using pokedex.Middlewares;
using pokedex.Models;
using pokedex.Options;
using pokedex.Services;
using pokedex.Services.MongoDB;

var builder = WebApplication.CreateBuilder(args);


{
    BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

    // Load mongo options from appsettings.json
    // We'll use options pattern to configure the MongoDB Context inside the service
    builder.Services.Configure<MongoDbOptions>(
        builder.Configuration.GetSection(MongoDbOptions.SectionName)
    );

    // Register MongoService for the Pokemon collection
    builder.Services.AddSingleton<IPokemonContext, PokemonContext>();

    builder.Services.AddScoped<IPokemonService, PokemonService>();

    // Add services to the container.
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();


{
    // register middlewares
    app.UseMiddleware<ErrorHandlingMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

using Api.Endpoints;
using Api.Extensions;
using Api.Mapsters;
using Api.Validations;

var builder = WebApplication.CreateBuilder(args); {
    builder
        .ConfigureCors()
        .ConfigureServices()
        .ConfigureSwaggerOpenApi()
        .ConfigureMapster()
        .ConfigureFluentValidation();
}

var app = builder.Build(); {
    app.SetupRequestPipeLine();
    app.UseDataSeeder();
    app.MapCollectionEndpoints();
    app.MapProductEndpoints();

    app.Run();
}


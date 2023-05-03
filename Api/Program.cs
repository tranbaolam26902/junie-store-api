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
    app.SetupContext();
    app.SetupRequestPipeLine();
    app.UseDataSeeder();
    app.MapCollectionEndpoints();
    app.MapProductEndpoints();
    app.MapOrderEndpoints();

    app.Run();
}


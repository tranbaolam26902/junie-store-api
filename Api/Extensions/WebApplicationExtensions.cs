using Data.Contexts;
using Data.Seeders;
using Microsoft.EntityFrameworkCore;
using Services.Media;
using Services.Store;

namespace Api.Extensions {
    public static class WebApplicationExtensions {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder) {
            builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IDataSeeder, DataSeeder>();
            builder.Services.AddScoped<IMediaManager, LocalFileSystemMediaManager>();
            builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            return builder;
        }

        public static IApplicationBuilder UseDataSeeder(this IApplicationBuilder app) {
            using var scope = app.ApplicationServices.CreateScope();

            try {
                scope.ServiceProvider.GetRequiredService<IDataSeeder>().Initialize();
            }
            catch (Exception e) {
                scope.ServiceProvider.GetRequiredService<ILogger<Program>>()
                    .LogError(e, "Count not insert data into database");
            }

            return app;
        }

        public static WebApplicationBuilder ConfigureCors(this WebApplicationBuilder builder) {
            builder.Services.AddCors(options => {
                options.AddPolicy("JunieStoreApp", policyBuilder => policyBuilder.AllowAnyOrigin()
                                                                                   .AllowAnyHeader()
                                                                                   .AllowAnyMethod());
            });

            return builder;
        }

        public static WebApplicationBuilder ConfigureSwaggerOpenApi(this WebApplicationBuilder builder) {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplication SetupRequestPipeLine(this WebApplication app) {
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseCors("JunieStoreApp");

            return app;
        }

        public static WebApplication SetupContext(this WebApplication app) {
            app.Use(async (context, next) => {
                context.Request.EnableBuffering(); // Enable buffering to allow reading the body multiple times

                var length = context.Request.ContentLength;
                if (length != null && length > 0 && length > 33554432) // Check if the length of the request body exceeds the limit
                {
                    context.Response.StatusCode = StatusCodes.Status413RequestEntityTooLarge;
                    await context.Response.WriteAsync("Request body too large");
                    return;
                }

                await next();
            });

            return app;
        }
    }
}

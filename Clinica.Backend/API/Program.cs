using API.Options.Database;
using Microsoft.Extensions.Options;
using Persistence.Database.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


#region Add Database context
// First, get database options
builder.Services.ConfigureOptions<DatabaseOptionsSetup>();

builder.Services.AddDbContext<ClinicaDbContext>(
    (serviceProvider, dbContectOptionsBuilder) =>
    {
        // Now, get options just like any other service
        var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

        dbContectOptionsBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServerAction =>
        {
            sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);

            sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);
        });

        // Be careful with this option, true only in development process!

        dbContectOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
    });
#endregion


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();

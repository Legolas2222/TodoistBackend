using Microsoft.Extensions.DependencyInjection;
using TodoistClone.Application;
using TodoistClone.Infrastructure;
using TodoistClone.Infrastructure.Persistence.config;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddControllers(/*options => options.Filters.Add<ErrorHandlingFilterAttribute>()*/);
//  Add custom Config for MongoDB
builder.Services.Configure<MongoDbConfiguration>(builder.Configuration.GetSection("MongoDBConfiguration"));

builder.Services.AddSingleton<ITodosContext, TodosContext>();
//builder.Services.Configure<MongoDBConfiguration>(builder.Configuration.GetSection("MongoDBConfiguration"));

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

Console.WriteLine("Starting App...");
{
    app.UseHttpsRedirection();
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    // app.UseExceptionHandler("/error");
    app.UseAuthorization();


    app.MapControllers();

    app.Run();

}

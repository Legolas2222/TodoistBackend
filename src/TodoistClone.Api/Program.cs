using TodoistClone.Api.Filters;
using TodoistClone.Api.Middleware;
using TodoistClone.Application;
using TodoistClone.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddControllers(/*options => options.Filters.Add<ErrorHandlingFilterAttribute>()*/);

/*
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/
var app = builder.Build();
{
    //app.UseHttpsRedirection();
    //app.UseMiddleware<ErrorHandlingMiddlware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    //app.UseAuthorization();

    app.MapControllers();

    app.Run();

}

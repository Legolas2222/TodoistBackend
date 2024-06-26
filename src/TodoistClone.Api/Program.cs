using TodoistClone.Application;
using TodoistClone.Infrastructure;
using TodoistClone.Infrastructure.Persistence.config;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddControllers(/*options => options.Filters.Add<ErrorHandlingFilterAttribute>()*/);
builder.Services.AddScoped<ITodosContext>(sp => new TodosContext("mongodb://localhost:27017", "TodoistClone", "TodoItems"));


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


{
    app.UseHttpsRedirection();
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    // app.UseExceptionHandler("/error");
    app.UseAuthorization();
    

    app.MapControllers();

    app.Run();

}

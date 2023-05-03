var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// default to the swagger docs
app.MapGet("/", context => 
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

// Update the following line to bind the application to all available IP addresses inside the container
app.Run("http://+:80");

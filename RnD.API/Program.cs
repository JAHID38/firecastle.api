using RnD.API.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region AppSettings:
builder.Services.Configure<LoggerOption>(builder.Configuration.GetSection(LoggerOption.LoggerSettings));
#endregion

builder.Services.AddControllers();

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

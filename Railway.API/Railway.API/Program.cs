using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Railway.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureEnvironment(builder.Configuration);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

builder.Services.AddCors(options => options.AddPolicy(name: builder.Configuration["UI:Name"],
        policy =>
        {
            policy
            .WithOrigins(builder.Configuration["UI:Link"])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder.Configuration["UI:Name"]);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

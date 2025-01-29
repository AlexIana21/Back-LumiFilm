using Models;
using Reto_Back.Controllers;
using Reto_Back.Repositories;
using Reto_Back.Service;
using Reto_Back.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString(""); //Poner la nuestra que sea necesaria.


builder.Services.AddScoped<IMovieRepository, MovieRepository>(provider =>
new MovieRepository(connectionString));

builder.Services.AddScoped<IReviewRepository, ReviewRepository>(provider =>
new ReviewRepository(connectionString));

builder.Services.AddScoped<ISeatRepository, SeatRepository>(provider =>
new SeatRepository(connectionString));

builder.Services.AddScoped<IScreenRepository, ScreenRepository>(provider =>
new ScreenRepository(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>(provider =>
new UserRepository(connectionString));

builder.Services.AddScoped<IOrderRepository, OrderRepository>(provider =>
new OrderRepository(connectionString));

builder.Services.AddScoped<ISessionRepository, SessionRepository>(provider =>
new SessionRepository(connectionString));


// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services 
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IScreenService, ScreenService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ISeatService, SeatService>();

var app = builder.Build();

app.UseCors(configurePolicy: policy =>
{
    // policy.WithOrigins("*","https://localhost","http://localhost");
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});


// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

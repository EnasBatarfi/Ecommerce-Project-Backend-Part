using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;
using Backend;
using Backend.Data;
using Backend.EmailSetup;
using Backend.Middleware;
using Backend.Models;
using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Load env var from from .env file 
DotNetEnv.Env.Load();

// Get JWT settings from environment variables
var jwtIssuer = Environment.GetEnvironmentVariable("Jwt__Issuer") ?? throw new InvalidOperationException("JWT Issuer is missing in environment variables.");
var jwtAudience = Environment.GetEnvironmentVariable("Jwt__Audience") ?? throw new InvalidOperationException("JWT Audience is missing in environment variables.");
var jwtKey = Environment.GetEnvironmentVariable("Jwt__Key") ?? throw new InvalidOperationException("JWT Key is missing in environment variables.");

// Get the database connection string from environment variables
var legendsConnection = Environment.GetEnvironmentVariable("LegendsConnection") ?? throw new InvalidOperationException("Legends Connection is missing in environment variables.");

// Add email sender
builder.Services.AddTransient<IEmailSender, EmailSender>();

// Add DbContext with PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(legendsConnection)
           .EnableSensitiveDataLogging());

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:3000", "https://main--beautyblisswebsite.netlify.app")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

// Add authentication
var configuration = builder.Configuration;
var key = Encoding.ASCII.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Set to true in production
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

// Add scoped services
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderProductService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IPasswordHasher<Admin>, PasswordHasher<Admin>>();
builder.Services.AddScoped<IPasswordHasher<Customer>, PasswordHasher<Customer>>();
builder.Services.AddScoped<DbInitializer>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

var app = builder.Build();

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        var initializer = services.GetRequiredService<DbInitializer>();
        await initializer.InitializeAsync(context, services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () =>
{
    return "Welcome to E-commerce Api";
}).WithOpenApi();
app.UseCors("AllowOrigin");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().WithParameterValidation();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenBook.Adapter;
using OpenBook.Adapter.Repository;
using OpenBook.Adapter.Transaction;
using OpenBook.App.Data.Transaction;
using OpenBook.App.Interactors;
using OpenBook.App.Storage;
using OpenBook.Server;

var builder = WebApplication.CreateBuilder(args);

//Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
   options.RequireHttpsMetadata = false;
   options.TokenValidationParameters = new TokenValidationParameters
   {
       ValidateIssuer = true,
       ValidIssuer = AuthOptions.ISSUER,

       ValidateAudience = true,
       ValidAudience = AuthOptions.AUDIENCE,
       ValidateLifetime = true,

       IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
       ValidateIssuerSigningKey = true,
   };
});

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var connectDBStringSQLite = builder.Configuration.GetConnectionString("SQLiteDbConnection")
    ?? throw new InvalidOperationException("Connection string 'SQLiteDbConnection' not found."); ;
var connectDBStringPostgre = builder.Configuration.GetConnectionString("PostgreDbConnection")
    ?? throw new InvalidOperationException("Connection string 'PostgreDbConnection' not found.");

//	временно SQLite DB для Swaggera
builder.Services.AddDbContext<OpenBookContext>(options => options.UseSqlite(connectDBStringSQLite));

builder.Services.AddTransient<IUnitWork, UnitWork>();

builder.Services.AddScoped<BasketInteractor>();
builder.Services.AddScoped<BookInteractor>();
builder.Services.AddScoped<ChapterInteractor>();
builder.Services.AddScoped<CycleInteractor>();
builder.Services.AddScoped<EmailVerifInteractor>();
builder.Services.AddScoped<GenrreInteractor>();
builder.Services.AddScoped<PostInteractor>();
builder.Services.AddScoped<ReviewInteractor>();
builder.Services.AddScoped<RoleInteractor>();
builder.Services.AddScoped<SubscribeInteractor>();
builder.Services.AddScoped<UserInteractor>();
builder.Services.AddScoped<LikeInteractor>();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
builder.Services.AddScoped<ICycleRepository, CycleRepository>();
builder.Services.AddScoped<IEmailVerifRepository, EmailVerifRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ISubscribeRepository, SubsriberRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();

//	Add Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "OpenBook_Service", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenBook Blazor API v1.0");
    });
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

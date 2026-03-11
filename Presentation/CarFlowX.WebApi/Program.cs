using CarFlowX.Application.Features.CQRS.Handlers.AboutHandlers;
using CarFlowX.Application.Features.CQRS.Handlers.BannerHandlers;
using CarFlowX.Application.Features.CQRS.Handlers.BrandHandlers;
using CarFlowX.Application.Features.CQRS.Handlers.CarHandlers;
using CarFlowX.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarFlowX.Application.Features.CQRS.Handlers.ContactHandlers;
using CarFlowX.Application.Features.Mediator.Handlers.TestimonialHandlers;
using CarFlowX.Application.Features.RepositoryPattern;
using CarFlowX.Application.Interfaces;
using CarFlowX.Application.Interfaces.BlogInterfaces;
using CarFlowX.Application.Interfaces.CarDescriptionInterfaces;
using CarFlowX.Application.Interfaces.CarFeatureInterfaces;
using CarFlowX.Application.Interfaces.CarInterfaces;
using CarFlowX.Application.Interfaces.CarPricingInterfaces;
using CarFlowX.Application.Interfaces.RentACarInterfaces;
using CarFlowX.Application.Interfaces.ReviewInterfaces;
using CarFlowX.Application.Interfaces.StatisticsInterfaces;
using CarFlowX.Application.Interfaces.TagCloudInterfaces;
using CarFlowX.Application.Services;
using CarFlowX.Application.Tools;
using CarFlowX.Persistence.Context;
using CarFlowX.Persistence.Repositories;
using CarFlowX.Persistence.Repositories.BlogRepositories;
using CarFlowX.Persistence.Repositories.CarDescriptionRepositories;
using CarFlowX.Persistence.Repositories.CarFeatureRepositories;
using CarFlowX.Persistence.Repositories.CarPricingRepositories;
using CarFlowX.Persistence.Repositories.CarRepositories;
using CarFlowX.Persistence.Repositories.CommentRepositories;
using CarFlowX.Persistence.Repositories.RentACarRepositories;
using CarFlowX.Persistence.Repositories.ReviewRepositories;
using CarFlowX.Persistence.Repositories.StatisticsRepositories;
using CarFlowX.Persistence.Repositories.TagCloudRepositories;
using CarFlowX.WebApi.Hubs;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});
builder.Services.AddSignalR();

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddScoped<CarFlowXContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));

builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();


builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddScoped<GetTestimonialQueryHandler>();
builder.Services.AddScoped<GetTestimonialByIdQueryHandler>();
builder.Services.AddScoped<CreateTestimonialCommandHandler>();
builder.Services.AddScoped<UpdateTestimonialCommandHandler>();
builder.Services.AddScoped<RemoveTestimonialCommandHandler>();


builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddApplicationService(builder.Configuration);

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<CarHub>("/carhub");

app.Run();

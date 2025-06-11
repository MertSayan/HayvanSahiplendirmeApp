using Application.Behaviors;
using Application.Common;
using Application.Factories;
using Application.Features.MediatR.Users.Handlers.Write;
using Application.Interfaces;
using Application.Interfaces.AdoptionRequestInterface;
using Application.Interfaces.AdoptionTrackingInterface;
using Application.Interfaces.MessageInterface;
using Application.Interfaces.PetCommentInterface;
using Application.Interfaces.PetFavoritesInterface;
using Application.Interfaces.PetImageInterface;
using Application.Interfaces.PetInterface;
using Application.Interfaces.PetLikeInterface;
using Application.Interfaces.PetTypeInterface;
using Application.Interfaces.TokenInterface;
using Application.Interfaces.UserInterface;
using Application.Observers;
using Application.Validations.Pets;
using AutoMapper;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using Persistence.Factories;
using Persistence.Repositories;
using Persistence.Repositories.AdoptionRequestRepository;
using Persistence.Repositories.AdoptionTrackingRepository;
using Persistence.Repositories.MessageRepository;
using Persistence.Repositories.PetCommentRepository;
using Persistence.Repositories.PetFavoriteRepository;
using Persistence.Repositories.PetImageRepository;
using Persistence.Repositories.PetLikeRepository;
using Persistence.Repositories.PetRepository;
using Persistence.Repositories.PetTypeRepository;
using Persistence.Repositories.TokenRepository;
using Persistence.Repositories.UserRepository;
using System.Text;
using WebApi.Consumer;
using WebApi.SignalR.Hubs; // Hub class'ý burada

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<HayvanContext>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")
               ));

            builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(LoginCommandHandler).Assembly);
            });

            builder.Services.AddValidatorsFromAssembly(typeof(CreatePetCommandValidator).Assembly);
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Add services to the container.
            builder.Services.AddScoped<HayvanContext>();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<ITokenRepository, TokenRepository>();
            builder.Services.AddScoped<IPetRepository, PetRepository>();
            builder.Services.AddScoped<IPetCommentRepository, PetCommentRepository>();
            builder.Services.AddScoped<IPetLikeRepository, PetLikeRepository>();
            builder.Services.AddScoped<IAdoptionRequestRepository, AdoptionRequestRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAdoptionTrackingRepository, AdoptionTrackingRepository>();
            builder.Services.AddScoped<IPetFavoritesRepository, PetFavoriteRepository>();
            builder.Services.AddScoped<IPetImageRepository, PetImageRepository>();
            builder.Services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            builder.Services.AddScoped<IPetCreatedObserver, EmailPetCreatedObserver>();


            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

            builder.Services.AddScoped<IUserFactory, UserFactory>();
            builder.Services.AddScoped<IPetFactory, PetFactory>();
            builder.Services.AddScoped<IPetLikesFactory, PetLikeFactory>();
            builder.Services.AddScoped<IPetImageFactory, PetImageFactory>();
            builder.Services.AddScoped<IAdoptionRequestFactory, AdoptionRequestFactory>();

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));



            // ? Message repository DI
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();

            // ? SignalR servisini ekle
            builder.Services.AddSignalR();

            builder.Services.AddControllers();
            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowMvcApp",
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:7052") // ?? MVC portu burada
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials(); // ?? SignalR için þart
                    });
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Application.MapperProfiles.MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<PetCreatedEventConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("pet-created-event-queue", e =>
                    {
                        e.ConfigureConsumer<PetCreatedEventConsumer>(context);
                    });
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowMvcApp");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            // ? SignalR endpoint
            app.MapHub<MessageHub>("/hubs/message");

            app.Run();
        }
    }
}

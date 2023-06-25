using Instagram.Data;
using Instagram.Interfaces;
using Instagram.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("localhost");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy
                                        .AllowAnyHeader()
                                        .AllowAnyOrigin()
                                        .AllowAnyMethod());
});

builder.Services.AddDbContext<InstagramContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IReactionService, ReactionService>();
builder.Services.AddScoped<IPopulateDbService, PopulateDbService>();

builder.Services.AddAutoMapper(typeof(MapperInitializer));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("swagger/v1/swagger.json", "WebAPI v1"));
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();

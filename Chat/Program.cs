using Chat.Database;
using Chat.Mapper;
using Chat.Repositories;
using Chat.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ChatContext>(x => x.UseSqlite("Data Source=app-data.db"));

builder.Services.AddMvc();
builder.Services.AddAutoMapper(typeof(ChatroomMapper), typeof(ChatMessageMapper), typeof(UserMapper));

builder.Services.AddMediatR(mediatr =>
{
    mediatr.RegisterServicesFromAssemblyContaining<Program>();
});

builder.Services.AddScoped(typeof(ChatroomService));
builder.Services.AddScoped(typeof(ChatroomRepository));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
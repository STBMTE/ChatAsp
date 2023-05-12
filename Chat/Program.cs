using AutoMapper;
using Chat.Database;
using Chat.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlite("Data Source=app-data.db"));

//TODO: changed mapper!
// "Оно так не делается, но если хочется, то вот так"
var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new AllMappersProfile()); });
IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddScoped<IMapper>((_) => mapperConfig.CreateMapper());
builder.Services.AddMvc();


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
using spayserver.Data.Contexts;
using spayserver.Data.Repositories.GroupRepo;
using spayserver.Data.Repositories.UserRepo;
using spayserver.Services.GroupService;
using spayserver.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SpaydbContext>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGroupServices, GroupServices>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();

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
